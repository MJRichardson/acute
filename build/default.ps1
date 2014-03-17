Framework "4.0"

properties {
	$baseDir = Resolve-Path ".."
	$outDir = "$(Resolve-Path "".."")\src\bin"
	$configuration = "Release"
}

Task default -Depends Build-Compiler

Task Clean {
	if (Test-Path $outDir) {
		rm -Recurse -Force "$outDir" >$null
	}
	md "$outDir" >$null
}

Task Build-Library -Depends Clean {
	Exec { msbuild "$baseDir\src\library.sln" /verbosity:minimal /p:"Configuration=$configuration" }
	copy "$baseDir\src\Acute\bin\$configuration\Acute.dll" "$outDir"  
	copy "$baseDir\src\Acute\bin\$configuration\Acute.js" "$outDir"  
}

Task Build-Compiler -Depends Clean {
	$msBuildProjectTargetDir = "$baseDir\src\Acute.Build\bin\$configuration\"
	$msBuildProjectTargetFileName = "Acute.Build.dll"
	Exec { msbuild "$baseDir\src\compiler.sln" /verbosity:minimal /p:"Configuration=$configuration" }
	copy $msBuildProjectTargetDir*.* "$outDir"  
	Exec { & "$baseDir\submodules\saltarelle.compiler\build\EmbedAssemblies.exe" /o "$outDir\$msBuildProjectTargetFileName" /a "$msBuildProjectTargetDir*.dll" /a "$msBuildProjectTargetDir*.exe"  $msBuildProjectTargetDir$msBuildProjectTargetFileName}
}
