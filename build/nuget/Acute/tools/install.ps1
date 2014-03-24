Param($installPath, $toolsPath, $package, $project)

Function MakeRelativePath($Origin, $Target) {
    $originUri = New-Object Uri('file://' + $Origin)
    $targetUri = New-Object Uri('file://' + $Target)
    $originUri.MakeRelativeUri($targetUri).ToString().Replace('/', [System.IO.Path]::DirectorySeparatorChar)
}

Add-Type -AssemblyName 'Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
$msbuild = [Microsoft.Build.Evaluation.ProjectCollection]::GlobalProjectCollection.GetLoadedProjects($project.FullName) | Select-Object -First 1

#Set the target framework to v2.0. This was how I got around the 'Indirectly referenced assembly X must be referenced.' problem  
$msbuild.SetProperty("TargetFrameworkVersion", "v2.0")

# Set the NoStdLib property. Not that we need it, but other tools (eg. ReSharper) will have use for it.
$msbuild.SetProperty("NoStdLib", "True")

# Remove default assemblies System, System.*, Microsoft.*
$project.Object.References | ? { $_.Name.StartsWith("System.") } | % { try { $_.Remove() } catch {} }
$project.Object.References | ? { $_.Name -eq "System" } | % { $_.Remove() }
$project.Object.References | ? { $_.Name.StartsWith("Microsoft.") } | % { $_.Remove() }

# Swap the import for Microsoft.CSharp.targets for Acute.Compile.targets. Also remove any existing reference to Acute.Compiler.targets since we might be upgrading.
# Ensure that the new import appears in the same place in the project file as the old one.
$toRemove = $msbuild.Xml.Imports | ? { $_.Project.EndsWith("Acute.Compile.targets") -or $_.Project.EndsWith("Microsoft.CSharp.targets") }
$newLocation = $toRemove | Select-Object -First 1
if (-not $newLocation) {
	$newLocation = $msbuild.Xml.Imports | Select-Object -First 1
	if (-not $newLocation) {
		$newLocation = $msbuild.Xml.Children | Select-Object -Last 1
	}
}
$newImportPath = "`$(SolutionDir)$(MakeRelativePath -Origin $project.DTE.Solution.FullName -Target ([System.IO.Path]::Combine($toolsPath, ""Acute.Compile.targets"")))"
$newImport = $msbuild.Xml.CreateImportElement($newImportPath)
$newImport.Condition = "Exists('$newImportPath')"
$newImportCSharp = $msbuild.Xml.CreateImportElement("`$(MSBuildToolsPath)\Microsoft.CSharp.targets")
$newImportCSharp.Condition = "!Exists('$newImportPath')"

$msbuild.Xml.InsertAfterChild($newImport, $newLocation)
$msbuild.Xml.InsertAfterChild($newImportCSharp, $newLocation)

if ($toRemove) {
	$toRemove | % { $msbuild.Xml.RemoveChild($_) }
}

# Add a reference to our custom mscorlib.dll (adding this reference by putting the file in the lib/ folder does not work).
$old = @($msbuild.GetItems("Reference") | ? { $_.UnevaluatedInclude -eq "mscorlib" })
$old | % { $msbuild.RemoveItem($_) }

$mscorlib = $msbuild.AddItem("Reference", "mscorlib") | Select-Object -First 1
$mscorlib.SetMetadataValue("HintPath", "`$(SolutionDir)$(MakeRelativePath -Origin $project.DTE.Solution.FullName -Target ([System.IO.Path]::Combine($toolsPath, ""mscorlib.dll"")))")

$project.Save()

# comment ComVisible and Guid attributes from AssemblyInfo.cs
$assemblyInfoPath = Join-Path -Path ([System.IO.FileInfo]$project.FullName).DirectoryName -ChildPath "Properties\AssemblyInfo.cs"
(Get-Content $assemblyInfoPath) `
	-replace '\[assembly: ComVisible', '//[assembly: ComVisible' `
	-replace '\[assembly: Guid', '//[assembly: Guid' `
	| Out-File $assemblyInfoPath 
