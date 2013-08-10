  ; 脚本由 Inno Setup 脚本向导 生成！
; 有关创建 Inno Setup 脚本文件的详细资料请查阅帮助文档！

#define MyAppName               "滦下"

#define QAAppName               "滦下数据查询"
#define MyAppVersion            "1.1.0.0"
#define MyAppPublisher          "LY-TECH"
#define MyAppURL                ""
#define QAExeName               "QA.exe"
#define MyAppDir                "LX"
#define CompanyName             "LY-TECH"

#define QADir                   "..\..\QA\bin\Debug\"
#define QADestDir               "QA"
#define OutputBaseName          "lx"

#define GateContentSourceDir    "..\VGateQuery\bin\Debug\"
#define GateContentDestDir      "C\VGate"

#define PumpContentSourceDir    "..\VPumpQuery\bin\Debug\"
#define PumpContentDestDir      "C\VPump"

; c
;
#define C3AppName               "滦下数据采集"
#define C3ExeName               "C3.exe"
#define C3SrcDir                "f:\C3\8.Src\"
#define C3Dir                   "f:\C3\8.Src\C3\bin\Debug\"
#define BCDir                   "f:\C3\8.Src\C3\bin\Debug\bc\"
#define CRCDir                  "f:\C3\8.Src\C3\bin\Debug\crc\"
#define ConfigDir               "f:\C3\8.Src\C3\bin\Debug\Config\for_lx\"

#define SpuDir                  "f:\C3\8.Src\DBSPU\bin\Debug\"
#define C3DestDir               "C3"

#define VGate100SourceDir       "f:\C3\8.Src\VGate100DPU\bin\Debug\"
#define VPump100SourceDir       "f:\C3\8.Src\VPump100DPU\bin\Debug\"

#define SetupBin                "bin"

// 
// 2.0 3.5 4.0
//
#define DotNetFx20              "2.0"
#define DotNetFx35              "3.5"
#define DotNetFx40              "4.0"

#define DotNetFxNeed            "2.0"

#define MsgNeedDotNetFx20       "此安装程序需要 .NET Framework 版本 2.0, 请安装 .NET Framework 版本, 然后重新运行此安装程序."
#define MsgNeedDotNetFx35       "此安装程序需要 .NET Framework 版本 3.5, 请安装 .NET Framework 版本, 然后重新运行此安装程序."
#define MsgNeedDotNetFx40       "此安装程序需要 .NET Framework 版本 4.0, 请安装 .NET Framework 版本, 然后重新运行此安装程序."

[Setup]
; 注: AppId的值为单独标识该应用程序。
; 不要为其他安装程序使用相同的AppId值。
; (生成新的GUID，点击 工具|在IDE中生成GUID。)
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

Source: "..\DB\lx.mdb"; DestDir: "{app}\DB"; Flags: ignoreversion


Source: "{#QADir}\QA.exe"; DestDir: "{app}\{#QADestDir}"; Flags: ignoreversion
Source: "{#QADir}\QA.exe.config"; DestDir: "{app}\{#QADestDir}"; Flags: ignoreversion
Source: "{#QADir}\QA.Interface.dll"; DestDir: "{app}\{#QADestDir}"; Flags: ignoreversion
Source: "{#QADir}\Xdgk.Common.dll"; DestDir: "{app}\{#QADestDir}"; Flags: ignoreversion
Source: "{#QADir}\DbNetLink.dll"; DestDir: "{app}\{#QADestDir}"; Flags: ignoreversion
Source: "{#QADir}\QRes.dll"; DestDir: "{app}\{#QADestDir}"; Flags: ignoreversion
Source: "{#QADir}\Config\for_lx\*.xml"; DestDir: "{app}\{#QADestDir}\Config"; Flags: ignoreversion
Source: "{#C3SrcDir}\VPump100Common\bin\Debug\VPump100Common.dll "; DestDir: "{app}\{#QADestDir}"; Flags: ignoreversion


Source: "{#GateContentSourceDir}\VGateQuery.dll"; DestDir: "{app}\{#QADestDir}\{#GateContentDestDir}"; Flags: ignoreversion
Source: "{#GateContentSourceDir}\Config\*.xml"; DestDir: "{app}\{#QADestDir}\{#GateContentDestDir}\Config"; Flags: ignoreversion

Source: "{#PumpContentSourceDir}\VPumpQuery.dll"; DestDir: "{app}\{#QADestDir}\{#PumpContentDestDir}"; Flags: ignoreversion
Source: "{#PumpContentSourceDir}\Config\*.xml"; DestDir: "{app}\{#QADestDir}\{#PumpContentDestDir}\Config"; Flags: ignoreversion

; c
;

Source: "{#C3Dir}\C3.exe"; DestDir: "{app}\{#C3DestDir}"; Flags: ignoreversion
Source: "{#C3Dir}\C3.exe.config"; DestDir: "{app}\{#C3DestDir}"; Flags: ignoreversion
Source: "{#C3Dir}\C3.Communi.dll"; DestDir: "{app}\{#C3DestDir}"; Flags: ignoreversion
Source: "{#C3Dir}\DbNetLink.dll"; DestDir: "{app}\{#C3DestDir}"; Flags: ignoreversion
Source: "{#C3Dir}\Xdgk.Common.dll"; DestDir: "{app}\{#C3DestDir}"; Flags: ignoreversion
Source: "{#C3Dir}\Nlog.dll"; DestDir: "{app}\{#C3DestDir}"; Flags: ignoreversion
Source: "{#C3Dir}\Nlog.Config"; DestDir: "{app}\{#C3DestDir}"; Flags: ignoreversion

; config
;
Source: "{#ConfigDir}\*.xml"; DestDir: "{app}\{#C3DestDir}\Config"; Flags: ignoreversion

; bc
;
Source: "{#C3Dir}\bc\*.dll"; DestDir: "{app}\{#C3DestDir}\bc"; Flags: ignoreversion

; crc
;
Source: "{#C3Dir}\crc\*.dll"; DestDir: "{app}\{#C3DestDir}\crc"; Flags: ignoreversion


; spu
;
Source: "{#SpuDir}\DBSpu.dll"; DestDir: "{app}\{#C3DestDir}\s"; Flags: ignoreversion

; VGate100
;
Source: "{#VGate100SourceDir}\VGate100DPU.dll"; DestDir: "{app}\{#C3DestDir}\d\VGate100"; Flags: ignoreversion
Source: "{#VGate100SourceDir}\VGate100Common.dll"; DestDir: "{app}\{#C3DestDir}\d\VGate100"; Flags: ignoreversion
Source: "{#VGate100SourceDir}\DeviceDefine\*.xml"; DestDir: "{app}\{#C3DestDir}\d\VGate100\DeviceDefine"; Flags: ignoreversion
Source: "{#VGate100SourceDir}\Task\*.xml"; DestDir: "{app}\{#C3DestDir}\d\VGate100\Task"; Flags: ignoreversion

; VPump100
;
Source: "{#VPump100SourceDir}\VPump100DPU.dll"; DestDir: "{app}\{#C3DestDir}\d\VPump100"; Flags: ignoreversion
Source: "{#VPump100SourceDir}\VPump100Common.dll"; DestDir: "{app}\{#C3DestDir}\d\VPump100"; Flags: ignoreversion
Source: "{#VPump100SourceDir}\DeviceDefine\*.xml"; DestDir: "{app}\{#C3DestDir}\d\VPump100\DeviceDefine"; Flags: ignoreversion
Source: "{#VPump100SourceDir}\Task\*.xml"; DestDir: "{app}\{#C3DestDir}\d\VPump100\Task"; Flags: ignoreversion

; 注意: 不要在任何共享系统文件上使用“Flags: ignoreversion”

[Icons]
Name: "{group}\{#C3AppName}"; Filename: "{app}\{#C3DestDir}\{#C3ExeName}"
Name: "{group}\{#QAAppName}"; Filename: "{app}\{#QADestDir}\{#QAExeName}"
Name: "{group}\{cm:UninstallProgram,{#QAAppName}}"; Filename: "{uninstallexe}"

Name: "{commondesktop}\{#QAAppName}"; Filename: "{app}\{#QADestDir}\{#QAExeName}"; Tasks: desktopicon
Name: "{commondesktop}\{#C3AppName}"; Filename: "{app}\{#C3DestDir}\{#C3ExeName}"; Tasks: desktopicon

[Run]
;Filename: "{app}\{#QAExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent unchecked


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
