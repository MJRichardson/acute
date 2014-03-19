Framework "4.0"

properties {
	$baseDir = Resolve-Path ".."
	$outDir = "$(Resolve-Path "".."")\src\bin"
	$configuration = "Release"
}

Task default -Depends Build-Compiler, Build-Library

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

Task Nuget-Pack -Depends Nuget-Pack-Library, Nuget-Pack-Project {
} 

Task Nuget-Pack-Library -Depend Build-Library {
	copy "$outDir\Acute.dll" "$baseDir\build\nuget\Acute.Library\lib" 
	copy "$outDir\Acute.js" "$baseDir\build\nuget\Acute.Library\content" 
	Exec{ & "$baseDir\build\nuget\nuget.exe" pack "$baseDir\build\nuget\Acute.Library\Acute.Library.nuspec"  }
}

Task Nuget-Pack-Project -Depend Build-Compiler {
	copy "$outDir\Acute.Build.dll" "$baseDir\build\nuget\Acute\tools" 
	copy "$outDir\Acute.Compile.targets" "$baseDir\build\nuget\Acute\tools" 
	copy "$outDir\Acute.Compiler.exe" "$baseDir\build\nuget\Acute\tools" 
	copy "$outDir\Antlr3.Runtime.dll" "$baseDir\build\nuget\Acute\tools" 
	copy "$outDir\Castle.Core.dll" "$baseDir\build\nuget\Acute\tools" 
	copy "$outDir\Castle.Windsor.dll" "$baseDir\build\nuget\Acute\tools" 
	copy "$outDir\ICSharpCode.NRefactory.CSharp.dll" "$baseDir\build\nuget\Acute\tools" 
	copy "$outDir\ICSharpCode.NRefactory.dll" "$baseDir\build\nuget\Acute\tools" 
	copy "$outDir\ICSharpCode.NRefactory.IKVM.dll" "$baseDir\build\nuget\Acute\tools" 
	copy "$outDir\IKVM.Reflection.dll" "$baseDir\build\nuget\Acute\tools" 
	copy "$outDir\JavaScriptParser.dll" "$baseDir\build\nuget\Acute\tools" 
	copy "$outDir\JavaScriptParser.dll" "$baseDir\build\nuget\Acute\tools" 
	copy "$outDir\Saltarelle.Compiler.dll" "$baseDir\build\nuget\Acute\tools" 
	copy "$outDir\Saltarelle.Compiler.JSModel.dll" "$baseDir\build\nuget\Acute\tools" 
	Exec{ & "$baseDir\build\nuget\nuget.exe" pack "$baseDir\build\nuget\Acute\Acute.nuspec" -NoPackageAnalysis}
}
