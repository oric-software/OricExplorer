# Oric Explorer

This is the new official *Oric Explorer* GitHub repository at https://github.com/oric-software/OricExplorer, imported from the original version that was initially published and maintained at https://github.com/laurentd75/OricExplorer.

This software was originally written by **Scott Davies** (http://oric.mrandmrsdavies.com/ -- archived in the Wayback Machine Internet Archive at https://web.archive.org/web/20190609120811/http://oric.mrandmrsdavies.com/).

*First documented and published to GitHub by **Laurent D.** (https://github.com/laurentd75) in September 2018 at https://github.com/laurentd75/OricExplorer.*

*Moved to the **oric-software** GitHub organization (https://github.com/oric-software/) by __retroric__ (https://github.com/retroric) on 25 September 2020.*

*Primarily maintained by **Damien P.** aka __dipisoft__ (https://github.com/dipisoft).*


## Presentation and History

Oric Explorer is a .Net GUI  application (running primarily on Windows but also compatible with macOS & Linux) for exploring collections of Oric media, primarily tape and floppy disk images of various formats. Features include viewing text and binary data, pictures, and code with syntax highlighting pertaining to software designed for the different models of Oric 8-bit computers: Oric 1, Oric Atmos, and Oric Telestrat.

This application was originally created and developed by Scott Davies and published on his web site at http://oric.mrandmrsdavies.com/ (now archived at https://web.archive.org/web/20190609120811/http://oric.mrandmrsdavies.com/).

The first version of Oric Explorer (referred to as "v0.70" in the application and on the author's website, although the executable file bore the "0.69.0" internal version number)  was released circa November 2008.

A tentative "2.0" version (more like a "1.5" version in the words of the author himself) was released and temporarily made available for download circa 2015 and actually bore the "1.0.0" internal version.

This 2.0 version was also distributed with [issue 317 of the French CEO Magazine in September 2016 ](https://www.oric.org/magazine/ceomag-384.html) (in the 317_options.zip file coming with the mag).

A 2-part detailed review of this version was published in issues [317 (September 2016)](https://www.oric.org/magazine/ceomag-384.html) and [318 (October 2016)](https://www.oric.org/magazine/ceomag-383.html) of the French CEO magazine.

The current "Work in Progress" version 2.0 of this application stands as of 24 March 2018, and is significantly different from the previous "v2.0" that was previously released.

The original description for this application is reproduced below:

*Oric Explorer is a Windows application with a similar look and feel to Windows Explorer. It has been designed to help you manage your collection of virtual Oric tapes (.tap) and disks (.dsk).*

*With Oric Explorer, you are able to view the files and programs stored in the disk and tapes, displaying their contents in various formats such as a BASIC listing, 6502 disassembly or a hex dump. It can also display TEXT and HIRES screens along with Character sets.*

*A handy feature of Oric Explorer is the ability to display data embedded within a program using the Data Viewer, this can be Text, HIRES data or character sets.*



## Development status

Oric Explorer is currently maintained by **Damien P. (dipisoft on GitHub)**. If you are interested in further developing and maintaining this software, you are encouraged to participate by getting in touch with the **oric-software** GitHub organization members (https://github.com/oric-software) or using the CEO forums (http://forums.oric.org/) or the Defence Force forum (http://forum.defence-force.org/).

See the thread that was initially started on the Defence Force forum when this softare was first published on GitHub:
http://forum.defence-force.org/viewtopic.php?t=1829

Please also read ***AuthorsNotes.md*** which is a copy of an email sent to Laurent D. by Scott on 23 April 2018 that explains in detail the  status of the software when it was first open-sourced and the reasons why Scott had to stop development.

Please acknowledge the original author's name and wishes in all further development and abide by the [CC BY-NC-SA 4.0](https://creativecommons.org/licenses/by-nc-sa/4.0/) licence this project was placed under (see **OricExplorer-LICENCE-CC-BY-NC-SA-4.0**.md or .txt file).



## Development Environment Prerequisites 

Oric Explorer is a graphical Microsoft .Net application written in the C# language. The current version targets v4.5.2 of the Microsoft .Net framework, and version 6.0 of the C# language.

As such, it requires version 2015 of Microsoft Visual Studio as a minimum (although Visual Studio 2013 can be used, it requires adding support for C# v6.0 through a specific add-on package).

The recommended development environment is Microsoft Visual Studio 2017. Any edition of Visual Studio can be used, including the free "Community" edition, since Oric Explorer is a free, non-commercial application.

The recommended steps for setting up your development environment are as follows:

- Download and install **.NET Framework 4.5.2** : 

  The runtime can be downloaded from https://www.microsoft.com/net/download/visual-studio-sdks

- Download  and install the latest version of **Visual Studio Community Edition**:

  Go to https://www.visualstudio.com/fr/downloads/



## Building

Building the application is currently a manual task that must be carried out from within the Visual Studio IDE.

The steps involved are as follows :

* open the **OricExplorer.sln** file in Visual Studio
* Select "**Build solution**" from the "**Build**" menu. This will build both "Debug" and "Release" versions of the application in corresponding subdirectories of the **OricExplorer\bin** subtree.

For additional information on *Building and Cleaning Projects and Solutions in Visual Studio*, please refer to 
https://msdn.microsoft.com/en-US/library/5tdasz7h.aspx.



## Packaging

The "Installer" subdirectory of the Oric Explorer source contains installation scripts meant to be used with NSIS (The Nullsoft Scriptable Install System, an open-source system to create Windows installation programs available from http://nsis.sourceforge.net).

However, these scripts are currently unfinished and will NOT work as expected. Specifically, in the main installation script (OricExplorerInstaller.nsi):

* the main installation function for the programme (CopyOricExplorerExecutable) is currently not implemented (OricExplorerInstaller.nsi lines 154-158)

* there are disabled (commented) lines with hard-coded paths (see lines 24, 121, 124, 138, 142,157, 200) 


Therefore, until the installation scripts are fully tested and ironed out, the recommended packaging method so far is to build the project under Visual Studio and then ZIP the full contents of the **OricExplorer\bin\Release** directory. The resulting ZIP should be copied to the "**dist**" directory and its name should include details about the version and build date.

The generated ZIP file can then be used as a distributable file: for installing Oric Explorer, users will simply need to extract the contents of the ZIP to a suitable location.

Side notes: 

* my personal opinion is that while being free, the NSIS installer is not a very good option as it is quite cumbersome to use. There may be other installers better suited to the task.

* In any case, I do not think it is worth wasting any time working on an installer for this programme, especially since a fully-fledged installer would require to package the .Net framework redistributable files and installer, which would take up a huge amount of space. As it stands, the current manual means of installation is not overly complicated and is probably suitable for most users.



## Installing and Running

* **Prerequisites:**

  The **Microsoft .NET Framework version 4.5.2** : must be installed on the target machine prior to installing and running Oric Explorer. The required installer package can be downloaded from https://www.microsoft.com/net/download/visual-studio-sdks

* **Installing:**

  Installing Oric Explorer currently consists in extracting the contents of the ZIP file in the **dist/** subdirectory at the location of your choice. It is advisable NOT to extract it to "Program Files", as this location should be reserved for programs with proper installers (this is only a piece of advice, you may have a different opinion on this!).

  The program can thus be run from any directory on any drive (including thumb drives), *as long as* the prerequisite .Net 4.5.2 SDK library is installed on the host machine.

* **Running:** 

  To run the application, you only have to launch the OricExplorer.exe file form within the installation directory (you may wish to create a shortcut to the application and add it to the Windows Start Menu for convenience).



## Cross-platform compatibility

Although this application was primarily and solely targeted at the Microsoft Windows platform, it should normally be compatible with Linux and macOS platforms, thanks to the Mono project (https://www.mono-project.com/) that brings Microsoft .Net compatibility to Linux and macOS environments.

Likewise, the MonoDevelop IDE (https://www.monodevelop.com/) can normally be used in lieu of the Visual Studio IDE to edit, build and run the project on either the Windows, macOS or Linux platforms.



## Copyright and Licensing

Oric Explorer is (c) Scott Davies, original creator and author of this application. 

Scott agreed to distribute the source of his work in April 2018, on condition that he will be given due credit as the original author.

Since this application was always meant to be free for the Oric community, the following license model was chosen:

This software is ruled by the **Creative Commons License CC BY-NC-SA, version 4.0**.

See https://creativecommons.org/licenses/by-nc-sa/4.0/ for a description of the licensing terms.

See also https://en.wikipedia.org/wiki/Creative_Commons_license for a more general presentation and discussion of the Creative Commons licensing model and variants.

By downloading and using this software, you hereby declare that you agree to be bound by the terms of this licence. If you do not agree to these terms, do not download, install or use the software.



## Features Overview

The following are some of the features currently available in Oric Explorer.

* Display the contents of Oric Tape files including multipart tapes.
* Display the contents of ORICDOS, SEDORIC, STRATSED and FTDOS disks.

- Display Character Sets and HIRES/TEXT screens.
- Show a file as a Hexdump.
- Show the source of BASIC programs with syntax highlighting.
- Show the source of HYPERBASIC programs with syntax highlighting. ***==> IMPLEMENTED AS OF v2.3.0***
- Show the source of TELEASS programs with syntax highlighting. ***==> IMPLEMENTED AS OF v2.3.0***
- Show Machine code programs in 6502 assembly source form.
- View embedded data in TEXT or HIRES format or as a Character set (by means of a built-in Data viewer that currently supports the viewing of these 3 kinds of data)
- Save HIRES or TEXT screens as an image file (formats currently supported include .bmp, .gif, .jpg, .png and .tif)
- Print HIRES or TEXT screens to an attached printer.
- View Disk contents using a graphical representation of the sectors.
- View TEXT or HIRES images stored on a floppy disk image through a built-in specific Image Viewer
- Launch .dsk and .tap medias in Oricutron emulator
- Take screenshots (manually or automatically) and save them in several formats (animated gif, bmp, gif, jpeg, png and tiff) ***==> IMPLEMENTED AS OF v2.5.0***


## Author's Notes and Caveats

- The code has been developed in C# using Visual Studio 2015/2017.
- It requires the .Net V4.5.2 framework to be installed.
- The code is not the best code in the world so may be difficult to follow in some areas.
- Likewise some areas are not extensively commented and other areas are not commented at all.
- The project includes an installation script that uses the NullSoft installation application (not fully tested).
- The code is far from complete and therefore will certainly contain bugs as well as incomplete features.
- The main thing that is missing is code to write to .dsk files.
- The 'FormsControlLibrary.dll' is one that I have written (*source code available on request*), all the other dll's are third-party ones.
- There is currently no readme file or help text but installation can be done simply by copying the bin/Release directory to wherever you want it.



## Known Bugs

* DSK create/write feature: the DSK creation feature is currently broken and needs to be fixed

~~* Oric Explorer Settings Dialogue: in the "Tape and DIsk Folders" tab, clicking on the "Update" button raises an untrapped exception if there is no active selection in the listbox below (Media type/Folder listbox).~~  ***==> CORRECTED AS OF v2.1.0***

  ~~Note: this feature provides an easy means to update the selected location in the listbox with the contents of the text entered in the text field in the "Folder details" section to the left of the "Update" button.~~



## Suggestions for improvement

### Usability

* Selection of Tapes/Disks/ROMs directories

  The File selection dialogue chosen is currently quite cumbersome to use as it employs the "new style" Windows "Search Folder" folder selection dialogue instead of the "old style" "Open" file/folder selector that allows you to type the name of directories or create new directories.

  If possible this should be changed, or, at the very least, there should be a text field to input the desired location instead of having to browse all the way from the desktop root to the desired location.

  ~~Note: there actually is a means of entering a path in a text field and use it, via the Update button (see "bugs" section above...). But it actually is quite tedious, as you first have to add an entry using the "Search Folder" Windows dialogue, then change the added entry using the update button.~~  ***==> CORRECTED AS OF v2.1.0***



## Missing/Wanted Features

* Search:  ***NOW IMPLEMENTED AS OF v2.3.1 AS A "FILTER" TEXT FIELD***

  It would be nice to add a "search" feature to search for a particular software by name in the tapes and/or disks library.

  It would also be nice to be able to search for a particular file on a disk, in the entire disk library.



* Test Suite:

  There are currently no unit or integration tests for this application.

  Unit tests would be particularly appropriate for testing the tape/disk format functions (such as read/write tape, read/write sector, etc.) and ensuring there is no regression.

  Integration tests would be useful to test the UI and ensure there are no bugs such as the one mentioned for the "Settings dialogue" in the "Tape and Disk Folders" tab, when clicking on the "Update" button if there is no selected line in the listbox below.

* Help > Check for Updates: should now check for newer versions on the Github repo (by checking version number on dist/ on master, and/or by checking git version number tags that should need to be standardized, i.e. to use [SemVer](https://semver.org/) versioning rules).
***==> NOW IMPLEMENTED AS OF v2.3.0***



