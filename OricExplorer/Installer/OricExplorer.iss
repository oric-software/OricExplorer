
#define myAppName               "OricExplorer"
#define myAppShortVersion GetVersionNumbersString("..\bin\Release\OricExplorer.exe")
#define myAppPublisher          "Scott Davies feat. damien"

[Setup]
WizardStyle=modern
DisableWelcomePage=no
AppName="{#MyAppName}"
AppVerName="{#myAppName} v{#myAppShortVersion}"
AppPublisher="{#myAppPublisher}"
AppVersion="{#myAppShortVersion}"
VersionInfoVersion="{#myAppShortVersion}"
AllowNoIcons=no
DefaultGroupName="{#myAppName}"
DefaultDirName="{autopf}\{#myAppName}"
AppCopyright="{#myAppPublisher}"
PrivilegesRequired=Lowest
MinVersion=6.0
OutputBaseFilename="{#myAppName}_v{#myAppShortVersion}"
OutputDir="..\..\dist\"
Compression=lzma2
SolidCompression=yes
AppMutex="{#MyAppName}"

[Languages]
Name: "en"; MessagesFile: "compiler:Default.isl"
Name: "fr"; MessagesFile: "compiler:languages/French.isl"
Name: "de"; MessagesFile: "compiler:languages/German.isl"
Name: "es"; MessagesFile: "compiler:languages/Spanish.isl"
Name: "it"; MessagesFile: "compiler:languages/Italian.isl"
Name: "pt"; MessagesFile: "compiler:languages/Portuguese.isl"
Name: "ru"; MessagesFile: "compiler:languages/Russian.isl"

[CustomMessages]
en.CreateIconOnDesktop=Create a desktop icon
en.RemoveConfigFile=Delete the configuration file?

fr.CreateIconOnDesktop=Créer un icône sur le bureau
fr.RemoveConfigFile=Supprimer le fichier de configuration ?

de.CreateIconOnDesktop=Symbol auf dem Desktop anlegen
de.RemoveConfigFile=Konfigurationsdatei löschen?

es.CreateIconOnDesktop=Crea un icono en el escritorio
es.RemoveConfigFile=¿Eliminar el archivo de configuración?

it.CreateIconOnDesktop=Crea un'icona sul desktop
it.RemoveConfigFile=Eliminare il file di configurazione?

pt.CreateIconOnDesktop=Criar ícone no ambiente de trabalho
pt.RemoveConfigFile=Suprimir o ficheiro de configuração ?

ru.CreateIconOnDesktop=Создайте иконку на рабочем столе
ru.RemoveConfigFile=Удалить файл конфигурации?

[Tasks]
Name: "desktopicon";      Description: "{cm:CreateIconOnDesktop}"

[Files]
Source: "..\bin\Release\OricExplorer.exe";                  DestDir: "{app}"; Flags: ignoreversion
Source: "..\bin\Release\WeifenLuo.WinFormsUI.Docking.dll";  DestDir: "{app}"; Flags: ignoreversion
Source: "..\bin\Release\FastColoredTextBox.dll";            DestDir: "{app}"; Flags: ignoreversion
Source: "..\bin\Release\FormsControlLibrary.dll";           DestDir: "{app}"; Flags: ignoreversion
Source: "..\bin\Release\TabStrip.dll";                      DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{group}\{#MyAppName}";                         		   Filename: "{app}\{#MyAppName}.exe"; WorkingDir: "{app}"
Name: "{autodesktop}\{#MyAppName}";                      		 Filename: "{app}\{#MyAppName}.exe"; WorkingDir: "{app}"; Tasks: "desktopicon"

[Run]
Filename: "{app}\{#MyAppName}.exe"; Description: "{cm:LaunchProgram,{#MyAppName}}"; Flags: nowait postinstall skipifsilent; WorkingDir: "{app}"

[InstallDelete]
Type: files; Name: "{group}\{#MyAppName}.lnk"

[Code]
procedure CurUninstallStepChanged(CurUninstallStep: TUninstallStep);
var
  ConfFile: String;
begin
  case CurUninstallStep of
  usPostUninstall:
    begin
      ConfFile := ExpandConstant('{app}\{#MyAppName}.json');
      
      if FileExists(ConfFile) then
        if MsgBox(ExpandConstant('{cm:RemoveConfigFile}'), mbConfirmation, MB_YESNO) = idYes then
          try
            DeleteFile(ConfFile);
          except
          end;
    end;

  usDone:
    begin
      try
        RemoveDir(ExpandConstant('{app}'));
      except
      end;
    end;
  end;
end;
