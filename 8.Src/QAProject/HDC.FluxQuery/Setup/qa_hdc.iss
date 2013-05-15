; 脚本由 Inno Setup 脚本向导 生成！
; 有关创建 Inno Setup 脚本文件的详细资料请查阅帮助文档！

#define MyAppName               "数据查询"
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

; 注意: 不要在任何共享系统文件上使用“Flags: ignoreversion”

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
