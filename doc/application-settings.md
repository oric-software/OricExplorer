# Oric Explorer Application Settings



There are two levels of application settings in Oric Explorer:

## Default application settings

Default application settings are loaded on startup from the **OricExplorer.cfg** file in the application's directory. This file contains default values for some settings, e.g. for default folder locations.

The **OricExplorer.cfg** file is actually generated from the contents of the **OricExplorer.Properties.Settings** class, that is itself automatically generated when editing the project's properties (see documentation on the Settings page of the Project Designer in Visual Studio: https://docs.microsoft.com/en-us/visualstudio/ide/reference/settings-page-project-designer)



## User-modified settings

In previous versions of Oric Explorer, some settings got stored in the Windows registry (see Appendix).

With recent versions of Oric Explorer, User-modified settings are stored in the Windows registry.

- For version 2.0 of Oric Explorer, it is not clear at the moment where the user settings are actually stored and whether the registry is used.





## Appendix - information about settings in old version of Oric Explorer

In version 0.70 of Oric Explorer, user settings can be found at the following location:

**HKEY_CURRENT_USER\Software\OricExplorer**

Within this registry key there is a Folders key that stores the different locations defined for folders used by the application: 

- DirectoryListing (REG_SZ)	- default: C:\OricFiles.txt)
- Disks (REG_SZ)
- Emulator (REG_SZ)
- ROMs (REG_SZ)
- Tapes (REG_SZ)