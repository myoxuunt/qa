  ; �ű��� Inno Setup �ű��� ���ɣ�
; �йش��� Inno Setup �ű��ļ�����ϸ��������İ����ĵ���

#define MyAppName               "�������ݲ�ѯ"
#define MyAppVersion            "1.0.0.0"
#define MyAppPublisher          "LY-TECH"
#define MyAppURL                ""
#define MyAppExeName            "QA.exe"
#define MyAppDir                "LxDataQuery"
#define CompanyName             "LY-TECH"

#define QADir                   "..\..\QA\bin\Debug\"
#define OutputBaseName          "qa_lx"

#define GateContentSourceDir    "..\VGateQuery\bin\Debug\"
#define GateContentDestDir	    "C\VGate"

#define PumpContentSourceDir    "..\VPumpQuery\bin\Debug\"
#define PumpContentDestDir	    "C\VPump"

#define SetupBin				"bin"

// 
// 2.0 3.5 4.0
//
#define DotNetFx20              "2.0"
#define DotNetFx35              "3.5"
#define DotNetFx40              "4.0"

#define DotNetFxNeed            "2.0"

#define MsgNeedDotNetFx20       "�˰�װ������Ҫ .NET Framework �汾 2.0, �밲װ .NET Framework �汾, Ȼ���������д˰�װ����."
#define MsgNeedDotNetFx35       "�˰�װ������Ҫ .NET Framework �汾 3.5, �밲װ .NET Framework �汾, Ȼ���������д˰�װ����."
#define MsgNeedDotNetFx40       "�˰�װ������Ҫ .NET Framework �汾 4.0, �밲װ .NET Framework �汾, Ȼ���������д˰�װ����."

[Setup]
; ע: AppId��ֵΪ������ʶ��Ӧ�ó���
; ��ҪΪ������װ����ʹ����ͬ��AppIdֵ��
; (�����µ�GUID����� ����|��IDE������GUID��)
AppId               ={{34AA0E27-D84B-4BAB-B5E9-F01A2C3F2E90}
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
Source: "{#QADir}\DbNetLink.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#QADir}\QRes.dll"; DestDir: "{app}"; Flags: ignoreversion

Source: "{#QADir}\Config\for_lx\*.xml"; DestDir: "{app}\Config"; Flags: ignoreversion

Source: "{#GateContentSourceDir}\VGateQuery.dll"; DestDir: "{app}\{#GateContentDestDir}"; Flags: ignoreversion
Source: "{#GateContentSourceDir}\Config\*.xml"; DestDir: "{app}\{#GateContentDestDir}\Config"; Flags: ignoreversion

Source: "{#PumpContentSourceDir}\VPumpQuery.dll"; DestDir: "{app}\{#PumpContentDestDir}"; Flags: ignoreversion
Source: "{#PumpContentSourceDir}\Config\*.xml"; DestDir: "{app}\{#PumpContentDestDir}\Config"; Flags: ignoreversion

; ע��: ��Ҫ���κι���ϵͳ�ļ���ʹ�á�Flags: ignoreversion��

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent unchecked


[code]
//
//
function IsDotNET20Detected(): boolean;
var
    success: boolean;
    install: cardinal;
begin
    success := RegQueryDWordValue(HKLM, 'SOFTWARE\Microsoft\NET Framework Setup\NDP\v2.0.50727', 'Install', install);
    Result := success and (install = 1);
end;


//
//
function IsDotNET35Detected(): boolean;
var
    success: boolean;
    install: cardinal;
begin
    success := RegQueryDWordValue(HKLM, 'SOFTWARE\Microsoft\NET Framework Setup\NDP\v3.5', 'Install', install);
    Result := success and (install = 1);
end;


//
//
function IsDotNET40Detected(): boolean;
var
    success: boolean;
    install: cardinal;
begin
    success := RegQueryDWordValue(HKLM, 'SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full', 'Install', install);
    Result := success and (install = 1);
end;

//
//
//
function CheckDotNetFx(): boolean;
var 
    success: boolean;
    message: string;
begin
    case {#DotNetFxNeed} of
        {#DotNetFx20}: begin success := IsDotNET20Detected(); message := '{#MsgNeedDotNetFx20}'; end;
        {#DotNetFx35}: begin success := IsDotNET35Detected(); message := '{#MsgNeedDotNetFx35}'; end;
        {#DotNetFx40}: begin success := IsDotNET40Detected(); message := '{#MsgNeedDotNetFx40}'; end;
    else
         MsgBox('.Net Framework version error: {#DotNetFxNeed}', mbCriticalError, MB_OK);
    end;
    
    if not success then 
    begin
        MsgBox( message, mbInformation, MB_OK);
    end;

    Result := success;
end;


//
//
//
function InitializeSetup(): Boolean;
begin
    Result := CheckDotNetFx();
end;
