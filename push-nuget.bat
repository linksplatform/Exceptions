dotnet pack -c Release --include-symbols
cd bin\Release
dotnet nuget push -s https://api.nuget.org/v3/index.json *.symbols.nupkg -k oy2jadomp2dedanxgvgafhmeykopm3rebdcvnec3ykedm4
del *.symbols.nupkg
dotnet nuget push -s https://api.nuget.org/v3/index.json *.nupkg -k oy2jadomp2dedanxgvgafhmeykopm3rebdcvnec3ykedm4
del *.nupkg
cd ..
cd ..