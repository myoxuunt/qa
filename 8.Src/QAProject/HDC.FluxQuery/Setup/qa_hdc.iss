; �ű��� Inno Setup �ű��� ���ɣ�
; �йش��� Inno Setup �ű��ļ�����ϸ��������İ����ĵ���

#define MyAppName               "���ݲ�ѯ"
#define MyAppVersion            "1.0.0.0"
#define MyAppPublisher          "LY-TECH"
#define MyAppURL                ""
#define MyAppExeName            "QA.exe"
#define MyAppDir                "DataQuery"
#define CompanyName             "LY-TECH"

#define QADir                   "..\..\QA\bin\Debug\"
#define OutputBaseName          "qa_hdc"
#define ContentSourceDir        "..\bin\Debug\"
#define ContentDestDir			"C"
#define SetupBin				"bin"


[Setup]
; ע: AppId��ֵΪ������ʶ��Ӧ�ó���
; ��ҪΪ������װ����ʹ����ͬ��AppIdֵ��
; (�����µ�GUID����� ����|��IDE������GUID��)
AppId               ={{0FF109B7-12DE-44C5-9ECE-46BF4932CFB5}
AppName             ={#MyAppName}
AppVersion          ={#MyAppVersion}
;AppVerName         ={#MyAppName} {#MyAppVersion}
AppPublisher        ={#MyAppPublisher}
AppPublisherURL     ={#MyAppURL}
AppSupportURL       ={#MyAppURL}
AppUpdatesURL       ={#MyAppURL}
DefaultDirName      ={pf}\{#CompanyName}\{#MyAppDir}
DefaultGroupName    ={#MyAppName}
OutputDir           =.         
OutputBaseFilename  ={#SetupBin}\{#OutputBaseName}_{#MyAppVersion}
Compression         =lzma
SolidCompression    =yes

[Languages]
Name: "chinesesimp"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: checkablealone; OnlyBelowVersion: 0,6.1

[Files]
Source: "{#QADir}\QA.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#QADir}\QA.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#QADir}\QA.Interface.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#QADir}\Xdgk.Common.dll"; DestDir: "{app}"; Flags: ignoreversion

Source: "{#QADir}\Config\ContentInfo_for_hdc.xml"; DestDir: "{app}\Config\"; DestName: "ContentInfo.xml"; Flags: ignoreversion

Source: "{#ContentSourceDir}\HDC.FluxQuery.dll"; DestDir: "{app}\{#ContentDestDir}"; Flags: ignoreversion
Source: "{#ContentSourceDir}\Config\FluxColumnConfig.xml"; DestDir: "{app}\{#ContentDestDir}\Config"; Flags: ignoreversion

; ע��: ��Ҫ���κι���ϵͳ�ļ���ʹ�á�Flags: ignoreversion��

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent unchecked

