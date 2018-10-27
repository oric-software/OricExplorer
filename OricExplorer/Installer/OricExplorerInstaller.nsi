!include Sections.nsh
!include MUI2.nsh
!include nsDialogs.nsh
!include LogicLib.nsh
!include Library.nsh
!include WordFunc.nsh
!include StrFunc.nsh
!include WinVer.nsh

!include "InstallationFunctions.nsh"
!include "OricExplorerReadyToInstallDialog.nsh"

!define APPNAME "Oric Explorer"
!define VERSION "2.0.0.0"
!define APPVERSION "V2.0"

; Title displayed in the dialogs titlebar
Name "${APPNAME} ${APPVERSION}"

; Name of the actual installation file
Outfile "OricExplorer.exe"

; Make sure the final executable is digitally signed
;!finalize 'F:\MasterbuildRoot\CodeSigning\CodeSign.bat "%1"'

; Displays Company name at the bottom of the Installation dialogs
BrandingText "© 2018 Scott Davies"

; Set details for the Installer file
VIProductVersion ${VERSION}
VIAddVersionKey "FileDescription" "Oric Disk and Tape Management"
VIAddVersionKey "ProductName" "Oric Explorer"
VIAddVersionKey "ProductVersion" "V2.0"
VIAddVersionKey "FileVersion" ${VERSION}
VIAddVersionKey "LegalCopyright" "© 2018 Scott Davies"

; Make sure the installation details are shown during the install
ShowInstDetails show
ShowUninstDetails hide

; Installer must have admin level privileges
RequestExecutionLevel admin

XPStyle on

; Global variables
Var vInstalledVersion
Var vComputerName
Var SMDir

; Sets the font of the installer
SetFont "Segoe UI" 8

!define MUI_ICON "${NSISDIR}\Contrib\Graphics\Icons\orange-install.ico"
!define MUI_UNICON "${NSISDIR}\Contrib\Graphics\Icons\orange-uninstall.ico"

!define MUI_HEADERIMAGE
!define MUI_HEADERIMAGE_BITMAP "${NSISDIR}\Contrib\Graphics\Header\orange.bmp"
!define MUI_WELCOMEFINISHPAGE_BITMAP "${NSISDIR}\Contrib\Graphics\Wizard\orange.bmp"
!define MUI_ABORTWARNING

!define MUI_WELCOMEPAGE_TITLE "Welcome to the Oric Explorer Installation Wizard"
!define MUI_WELCOMEPAGE_TEXT "The Installation Wizard will install the Oric Explorer application on your computer.$\r$\n$\r$\n$_CLICK"

!define MUI_FINISHPAGE_RUN "$INSTDIR\OricExplorer.exe"
!define MUI_FINISHPAGE_RUN_NOTCHECKED

!define MUI_FINISHPAGE_NOAUTOCLOSE

!insertmacro WordFind
!insertmacro StrFilter

; Defines the actual dialogs shown during installation
!insertmacro MUI_PAGE_WELCOME
!insertmacro MUI_PAGE_DIRECTORY
!insertmacro MUI_PAGE_STARTMENU 0 $SMDir

; Our own custom dialogs
Page custom fnc_OricExplorerReadyToInstallDialog_Show

!insertmacro MUI_PAGE_INSTFILES
!insertmacro MUI_PAGE_FINISH

;Uninstall properties
!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_UNPAGE_INSTFILES

; N.b. This needs to be after all other insertmacro calls
!insertmacro MUI_LANGUAGE "English"

; *******************************************
; Function to perform initialisation tasks
; *******************************************
Function .onInit
	; Determines which section of the Registry is used
	SetRegView 32
		
	; Set the installation folder
	StrCpy $INSTDIR "$PROGRAMFILES32\OricExplorer"
	
	ReadEnvStr $vComputerName COMPUTERNAME
	
	; Check for previous installation
	ReadRegStr $vInstalledVersion HKLM "Software\Oric Explorer" "Version"
	
	${If} $vInstalledVersion == ${APPVERSION}
		MessageBox MB_YESNO|MB_ICONQUESTION "Version ${APPVERSION} of Oric Explorer is already installed.$\n$\nDo you wish to overwrite this version?" IDYES ContinueInstallation
		Abort
	${EndIf}

	ContinueInstallation:
FunctionEnd

; *******************************************
; Install required library (DLL) files
; *******************************************
Function InstallLibraryFiles
	DetailPrint "Installing library files..."

	${If} ${AtLeastWinVista}
		;!insertmacro InstallLib DLL SHARED NOREBOOT_PROTECTED F:\MasterBuildRoot\SystemComponents\V6\Comctl32.dll $SYSDIR\Comctl32.dll $SYSDIR
	${EndIf}

	;!insertmacro InstallLib DLL SHARED NOREBOOT_PROTECTED F:\MasterBuildRoot\SystemComponents\V6\Msrdc20.ocx $INSTDIR\Msrdc20.dll $INSTDIR
FunctionEnd	

; *******************************************
; Copy ini files
; *******************************************
Function CopyIniFiles
	DetailPrint "Copy ini files..."

    ; Don't overwrite inifiles if they already exist
	SetOverwrite off
	
	${IfNot} ${AtLeastWinVista}
		; Put inifiles into the Install directory
		;File F:\MasterBuildRoot\Reflex\${APPVERSION}\Distributables\ReflexDistributables\Dash.ini
	${Else}
		SetOutPath $APPDATA\OricExplorer\
		
		;File F:\MasterBuildRoot\Reflex\${APPVERSION}\Distributables\ReflexDistributables\Dash.ini

		SetOutPath $INSTDIR
	${EndIf}

	; Reset the overwrite flag
	SetOverwrite on
FunctionEnd

; *******************************************
; Copy the main Oric Explorer exe
; *******************************************
Function CopyOricExplorerExecutable
    DetailPrint "Copying Oric Explorer executable..."

	;File F:\MasterBuildRoot\Reflex\${APPVERSION}\Release\Reflex.exe
FunctionEnd

; *******************************************
; Add links to the Start menu
; *******************************************
Function SetupStartMenu
	DetailPrint "Creating program shortcuts..."

	!insertmacro MUI_STARTMENU_WRITE_BEGIN 0

	CreateDirectory "$SMPROGRAMS\$SMDir"

	CreateShortCut "$SMPROGRAMS\$SMDir\Oric Explorer.lnk" "$INSTDIR\OricExplorer.exe" ""
	CreateShortCut "$SMPROGRAMS\$SMDir\Uninstall.lnk" "$INSTDIR\Uninstall.exe" ""

    ; Create shortcut to Oric Explorer on the desktop
	CreateShortCut "$DESKTOP\OricExplorer.lnk" "$INSTDIR\OricExplorer.exe" ""

	!insertmacro MUI_STARTMENU_WRITE_END
FunctionEnd

; *******************************************
; Main body of installation script
; *******************************************
Section Install
	DetailPrint "Installing Oric Explorer ${APPVERSION}..."

	SetOutPath $INSTDIR
	
	; Create the directories
	CreateDirectory $INSTDIR

	${If} ${Errors}
		DetailPrint "Failed to create directory"
		MessageBox MB_OK|MB_ICONEXCLAMATION "Failed to create directory $INSTDIR"
		Abort
	${EndIf}
	
	; Uninstaller
	WriteUninstaller "$INSTDIR\Uninstall.exe"
	
	; Copy and Install files needed by Reflex
	Call InstallLibraryFiles
	Call CopyIniFiles

	; Copy the Oric Explorer executable
	Call CopyOricExplorerExecutable
	
	; Set Version in the Registry
	WriteRegStr HKLM "Software\Oric Explorer" "Version" ${APPVERSION}

	SetOutPath $INSTDIR

	; Add links to the Start menu
	Call SetupStartMenu

	; Write uninstall information to registry
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}" "DisplayName" "${APPNAME}"
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}" "Publisher" "Scott Davies"
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}" "DisplayVersion" "${APPVERSION}"
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}" "UninstallString" '"$INSTDIR\Uninstall.exe"'

	;WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}" "DisplayIcon" "F:\MasterBuildRoot\Reflex\${APPVERSION}\Reflex\res\REFLEX.ico"

	WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}" "NoModify" 1
	WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}" "NoRepair" 1
SectionEnd

Section "Uninstall"
	; Delete all the files in the Oric Explorer folder

	; Delete start menu entries
	RMDir /r "$SMPROGRAMS\$SMDir"
	
	; Delete desktop shortcut
	Delete "$DESKTOP\OricExplorer.lnk"

	; Delete registry keys
	DeleteRegKey HKLM "Software\Oric Explorer"
	DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}"
	
	; Delete executables
	Delete "$INSTDIR\*.exe"

	; Delete DLL files
	Delete "$INSTDIR\*.dll"

	; Remove the Oric Explorer folder if it is empty
	Push "$PROGRAMFILES32\OricExplorer"
	Call un.isEmptyDir
	Pop $0

	${If} $0 == 1
		RMDir /r "$PROGRAMFILES32\OricExplorer"
	${EndIf}
SectionEnd
