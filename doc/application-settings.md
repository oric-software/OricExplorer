# Oric Explorer Application Settings



Since v2.1 there is only one configuration file. It is called **OricExplorer.json** and is located in the application folder. This folder must therefore be *writable*, which is why it is preferable to *avoid* placing it in the "Program Files" or "Program Files (x86)" tree.


## Appendix - information about settings in old version of Oric Explorer

In OricExplorer v2.0, there were several configuration files:
- **OricExplorer.cfg** (in the application folder) contained the default settings, used when the application was launched for the first time
- **Layout.xml** (in the application folder) contained the interface settings (location and sizes of the different frames)
- **user.config** (in "%appdata%\Scott_davies\OricExplorer.exe_Url_AAAAAA\v2.0.0.0" folder, where AAAAA is an encrypted string representing the path to the executable) contained the user-defined parameters

In version 0.70 of Oric Explorer, user settings can be found at the following location:

**HKEY_CURRENT_USER\Software\OricExplorer**

Within this registry key there is a Folders key that stores the different locations defined for folders used by the application: 

- DirectoryListing (REG_SZ)	- default: C:\OricFiles.txt)
- Disks (REG_SZ)
- Emulator (REG_SZ)
- ROMs (REG_SZ)
- Tapes (REG_SZ)
