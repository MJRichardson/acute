Framework "4.0"

properties {
	$outDir = "$(Resolve-Path "".."")\src\bin"
	$configuration = "Release"
}

Task default -Depends Build

Task Clean {
	if (Test-Path $outDir) {
		rm -Recurse -Force "$outDir" >$null
	}
	md "$outDir" >$null
}
