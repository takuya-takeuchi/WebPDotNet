set APPDIR=netcoreapp3.1
set DLL=WebPDotNetNative.dll
set PDB=WebPDotNetNative.pdb
set NATIVEROOT="D:\Works\OpenSource\WebPDotNet\src\WebPDotNet.Native\build_win_desktop_cpu_x64"

mkdir bin\Debug\%APPDIR%
del bin\Debug\%APPDIR%\%DLL%
del bin\Debug\%APPDIR%\%PDB%
mklink bin\Debug\%APPDIR%\%DLL% %NATIVEROOT%\Debug\%DLL%
mklink bin\Debug\%APPDIR%\%PDB% %NATIVEROOT%\Debug\%PDB%
mkdir bin\Release\%APPDIR%
del bin\Release\%APPDIR%\%DLL%
mklink bin\Release\%APPDIR%\%DLL% %NATIVEROOT%\Release\%DLL%

mkdir bin\x64\Debug\%APPDIR%
del bin\x64\Debug\%APPDIR%\%DLL%
del bin\x64\Debug\%APPDIR%\%PDB%
mklink bin\x64\Debug\%APPDIR%\%DLL% %NATIVEROOT%\Debug\%DLL%
mklink bin\x64\Debug\%APPDIR%\%PDB% %NATIVEROOT%\Debug\%PDB%
mkdir bin\x64\Release\%APPDIR%
del bin\x64\Release\%APPDIR%\%DLL%
mklink bin\x64\Release\%APPDIR%\%DLL% %NATIVEROOT%\Release\%DLL%