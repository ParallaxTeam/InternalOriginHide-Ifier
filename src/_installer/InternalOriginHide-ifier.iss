#define MyAppName "Freebies - Internal Origin Hide-ifier"
#define MyAppVersion "1.0.0"
#define MyAppPublisher "ParallaxTeam"
#define MyAppURL "https://github.com/johnpierson/InternalOriginHideifier"

#define RevitAppName  "HideInternalOriginEverywhere"
#define RevitAddinFolder "{userappdata}\Autodesk\REVIT\Addins"

#define RevitAddin20  RevitAddinFolder+"\2020\"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{AD22A4E5-166E-469C-95B1-3601EF0FCA0E}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppName}
DisableDirPage=yes
DefaultGroupName=Parallax Team, Inc\{#MyAppName}
DisableProgramGroupPage=yes
LicenseFile=.\LICENSEFREE
OutputDir=.
OutputBaseFilename=InternalOriginHide-ifier.v{#MyAppVersion}
Compression=lzma
SolidCompression=yes
;info: http://revolution.screenstepslive.com/s/revolution/m/10695/l/95041-signing-installers-you-create-with-inno-setup
;comment/edit the line below if you are not signing the exe with the CASE pfx
;SignTool=signtoolcase

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Components]
Name: revit20; Description: Internal Origin Hide-ifier for Autodesk Revit 2020;  Types: full

[Files]

;REVIT 2020 ~~~~~~~~~~~~~~~~~~~
Source: "deploy\2020\*"; DestDir: "{#RevitAddin20}"; Excludes: "*.pdb,*.xml,*.config,*.addin,*.tmp"; Flags: ignoreversion recursesubdirs createallsubdirs; Components: revit20
Source: "deploy\{#RevitAppName}.addin"; DestDir: "{#RevitAddin20}"; Flags: ignoreversion; Components: revit20

; NOTE: Don't use "Flags: ignoreversion" on any shared system files
