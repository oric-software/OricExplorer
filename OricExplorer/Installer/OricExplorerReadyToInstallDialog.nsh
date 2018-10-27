; *******************************************
; Variables for our custom dialog
; *******************************************
Var hCtl_OricExplorerReadyToInstallDialog
Var hCtl_OricExplorerReadyToInstallDialog_Label1
 
; *******************************************
; Dialog create function
; *******************************************
Function fnc_OricExplorerReadyToInstallDialog_Create
	nsDialogs::Create 1018
	Pop $hCtl_OricExplorerReadyToInstallDialog

	${If} $hCtl_OricExplorerReadyToInstallDialog == error
		Abort
	${EndIf}

	!insertmacro MUI_HEADER_TEXT "Ready to Install" "You are now ready to install Oric Explorer."

	${NSD_CreateLabel} 0 3u 100% 36u "Press the Next button to begin the installation or the Back button to re-enter the installation information."
	Pop $hCtl_OricExplorerReadyToInstallDialog_Label1
FunctionEnd

; *******************************************
; Dialog show function
; *******************************************
Function fnc_OricExplorerReadyToInstallDialog_Show
	Call fnc_OricExplorerReadyToInstallDialog_Create
	nsDialogs::Show
FunctionEnd
