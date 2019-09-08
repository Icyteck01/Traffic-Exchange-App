; -- Example1.iss --
; Demonstrates copying 3 files and creating an icon.

; SEE THE DOCUMENTATION FOR DETAILS ON CREATING .ISS SCRIPT FILES!
[Setup]
AppName=Surfing Shark
AppVersion=1
DefaultDirName={pf}\Surfing Shark
DefaultGroupName=Surfing Shark
UninstallDisplayIcon={app}\uninstall.exe
Compression=lzma2
SolidCompression=yes
OutputDir=C:\Users\IcyTeck\Documents\Visual Studio 2015\Projects\SurfShark\setup
OutputBaseFilename=Install_Surfing_Shark
DiskSpanning=false
DiskSliceSize=2000000000

[Files]
Source: "C:\Users\IcyTeck\Documents\Visual Studio 2015\Projects\SurfShark\SurfShark\bin\Release\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs; Permissions: everyone-modify

[Icons]
Name: {group}\Surfing Shark; Filename: {app}\Surfing Shark.exe; WorkingDir: {app}; IconFilename: {app}\GrooveShark.ico; Comment: "Surfing Shark";
Name: {commondesktop}\Surfing Shark; Filename: {app}\Surfing Shark.exe; WorkingDir: {app}; IconFilename: {app}\GrooveShark.ico; Comment: "Surfing Shark";
[Tasks]


[Run]Filename: "{app}\Surfing Shark.exe"; Flags: nowait postinstall

[CustomMessages]
dotnetmissing=This application needs Microsoft .Net 3.5 SP 1 which is not yet installed. Do you like to download it now?
  
[Code]
function InitializeSetup(): Boolean;
var
  ErrorCode: Integer;
  netFrameWorkInstalled : Boolean;
  isInstalled: Cardinal;
begin
  result := true;
   
  // Check for the .Net 3.5 framework
  isInstalled := 0;
  netFrameworkInstalled := RegQueryDWordValue(HKLM, 'SOFTWARE\Microsoft\NET Framework Setup\NDP\v3.5', 'Install', isInstalled);
  if ((netFrameworkInstalled)  and (isInstalled <> 1)) then netFrameworkInstalled := false;
   
  if netFrameworkInstalled = false then
  begin
    if (MsgBox(ExpandConstant('{cm:dotnetmissing}'), mbConfirmation, MB_YESNO) = idYes) then
    begin
      ShellExec('open',
      'https://www.microsoft.com/en-us/download/details.aspx?id=25150',
      '','',SW_SHOWNORMAL,ewNoWait,ErrorCode);
    end;
    result := false;
  end;
   
end;
