/**************** InstallationFunctions ********************
*                                                          *
*          General Functions used by the Installer         *
*                                                          *
*                                                          *
***********************************************************/

!ifndef _InstallationFunctions_NSH_
!define __InstallationFunctions_NSH_

!include "WordFunc.nsh"
!insertmacro WordFind
!insertmacro StrFilter

; *******************************************
; Function to check if a directory is empty
; *******************************************
Function un.isEmptyDir
	# Stack ->                    # Stack: <directory>
	Exch $0                       # Stack: $0
	Push $1                       # Stack: $1, $0
	FindFirst $0 $1 "$0\*.*"
	strcmp $1 "." 0 _notempty
	FindNext $0 $1
	strcmp $1 ".." 0 _notempty
	ClearErrors
	FindNext $0 $1

	IfErrors 0 _notempty
	FindClose $0
	Pop $1                  # Stack: $0
	StrCpy $0 1
	Exch $0                 # Stack: 1 (true)
	goto _end
_notempty:
	FindClose $0
	ClearErrors
	Pop $1                   # Stack: $0
	StrCpy $0 0
	Exch $0                  # Stack: 0 (false)
_end:
FunctionEnd

!endif