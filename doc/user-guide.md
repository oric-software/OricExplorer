# Oric Explorer User guide



## Presentation

Oric Explorer is a Windows utility aimed at facilitating management of Oric software on tape and disk file images (.TAP and .DSK files). 

It provides facilities to view the files contained in tape and disk images, and to view the contents of individual files. It has specialised data viewers for BASIC code, HIRES images, and more:

1. BASIC source code with syntax highlighting
2. Assembly source code viewer
3. Data dump in hexadecimal format
4. Display TEXT screen data (screens in TEXT, LORES 0 and LORES 1 modes) with a built-in zoom feature.
5. Display screen masks (with built-in zoom feature)
6. Display high-resolution screen data (HIRES), with built-in zoom feature
7. Display random access file data (listing each individual records and individual record details)
8. Display sequential access file data
9. Display character font data (graphical representation, byte data and addresses)



## Initial configuration

After first launching the programme, you will need to edit the settings to configure locations of your tape and disk image collections.

New in Oric Explorer 2.0, you can define as many folder locations as you want for tape and disk collections (note however there is currently no "remove folder" option).

You can also define the location of the Oric emulator you want to use (Euphoric or Oricutron).

After modifying folder locations and validating changes, you will need to refresh data by hitting the Refresh button so the new folders are scanned and their contents get displayed in the treeview.



***Note**: the **OricExplorer.cfg**  file in the application's directory only contains default configuration options that are used on first launch of Oric Explorer. Any modified settings will be saved in files located in the user's profile settings directory (known as **%APPDATA%** in Windows Explorer). See the application-application-settings.md file for more information.*


