; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{AFEE1270-61EB-40E9-B89E-919260FC8E2F}
AppName=SystemInfo
AppVersion=0.4
;AppVerName=SystemInfo 0.4
AppPublisher=MITTORY
DefaultDirName={autopf}\SystemInfo
ChangesAssociations=yes
DisableProgramGroupPage=yes
; Uncomment the following line to run in non administrative install mode (install for current user only.)
;PrivilegesRequired=lowest
OutputDir=C:\Users\Aydar\Desktop
OutputBaseFilename=mysetup
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "D:\Program Files (x86)\���������� ������\c++\DeleteTemp\DeleteTemp\bin\Release\DeleteTemp.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Program Files (x86)\���������� ������\c++\DeleteTemp\DeleteTemp\bin\Release\DeleteTemp.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Program Files (x86)\���������� ������\c++\DeleteTemp\DeleteTemp\bin\Release\DeleteTemp.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Program Files (x86)\���������� ������\c++\DeleteTemp\DeleteTemp\12.iss"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Program Files (x86)\���������� ������\c++\DeleteTemp\DeleteTemp\App.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Program Files (x86)\���������� ������\c++\DeleteTemp\DeleteTemp\Computer_icon-icons.com_55237.ico"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Program Files (x86)\���������� ������\c++\DeleteTemp\DeleteTemp\DeleteTemp.csproj"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Program Files (x86)\���������� ������\c++\DeleteTemp\DeleteTemp\Form1.cs"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Program Files (x86)\���������� ������\c++\DeleteTemp\DeleteTemp\Form1.Designer.cs"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Program Files (x86)\���������� ������\c++\DeleteTemp\DeleteTemp\Form1.resx"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Program Files (x86)\���������� ������\c++\DeleteTemp\DeleteTemp\Program.cs"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Registry]
Root: HKA; Subkey: "Software\Classes\.myp\OpenWithProgids"; ValueType: string; ValueName: "SystemInfoFile.myp"; ValueData: ""; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemInfoFile.myp"; ValueType: string; ValueName: ""; ValueData: "SystemInfo File"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\SystemInfoFile.myp\DefaultIcon"; ValueType: string; ValueName: ""; ValueData: "{app}\DeleteTemp.exe,0"
Root: HKA; Subkey: "Software\Classes\SystemInfoFile.myp\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\DeleteTemp.exe"" ""%1"""
Root: HKA; Subkey: "Software\Classes\Applications\DeleteTemp.exe\SupportedTypes"; ValueType: string; ValueName: ".myp"; ValueData: ""

[Icons]
Name: "{autoprograms}\SystemInfo"; Filename: "{app}\DeleteTemp.exe"
Name: "{autodesktop}\SystemInfo"; Filename: "{app}\DeleteTemp.exe"; Tasks: desktopicon

[Run]
Filename: "{app}\DeleteTemp.exe"; Description: "{cm:LaunchProgram,SystemInfo}"; Flags: nowait postinstall skipifsilent

