Here is a history of OricExplorer evolutions, presenting the non-exhaustive list of corrections/additions of each recent version:

# Oric Explorer 2.4.0.1
* fixed a bug in the construction of the list of media (disks / tapes / roms / other files) when the path is expressed in a relative rather than absolute way.


# Oric Explorer 2.4
* fixed a bug in the tape edit form: app crash on validation when the start address has been changed
* added possibility to represent disks as in the initial tree structure instead of the organization by disk format
* added possibility to represent tapes, roms and other files as in the initial tree structure instead of the flat view
* added control of duplicate folders in the list of folders (in settings form)


# Oric Explorer 2.3.5
* consolidation of the analysis of .tap and .dsk files performed during the scan.
* added post-build processing to automatically create the archive when the release is successfully generated (via a powershell script which extracts the version number of the app_version.xml file and integrates it into the name of the .zip file)


# Oric Explorer 2.3.4
* fixed a bug in the update module: the binary fetch link was wrong


# Oric Explorer 2.3.3
* check for update on startup: the update search window is only displayed if an update is available
* update module: instead of just opening the repo page in the browser, the application can now update its main binary


# Oric Explorer 2.3.2
* updating repo url (for update search)
* in "About" window: replacing contact link (which allowed to send an email to Scott) with repo link


# Oric Explorer 2.3.1
* adding filter feature (CTRL-F) on main list
* updating original/official website (http://oric.mrandmrsdavies.com/) with the archived version of waybackmachine (http://web.archive.org/web/201906091208 ... avies.com/)
and some other minor changes


# Oric Explorer 2.3
* added the possibility to display the source of Hyperbasic files (thanks to Assinie for his help)
* added support for a new "other files" section (under the Disks, Tapes and ROM's items), whose path or paths are to be configured in the configuration window. This new section can be used to make non-executable files appear in the emulator (orix binaries or others) in order to be able to display the content (request formulated by Jede).
* the "media type" items (Disks, Tapes, ROM's and Other Files) and those of sub-categories (FT-Dos, Sedoric, Stratsed, etc ... as well as the entries in the tapes index) are not now displayed only if they contain items


# Oric Explorer 2.2.1
* in the absence of the configuration file, the app crashed at startup
* when closing the configuration window, the paths of the tapes/disks/roms folders were systematically memorized even when closing the window with the "Cancel" button
* change of the initial folder of the folder selection windows
* change of the selected item when opening the syntax colorization setting window


# Oric Explorer 2.2
* search for updates: correction of problem in the path of the repository file
* configuration window: reactivation of the "directory listings" tab
* tape edit window: implementation of moving and deleting blocks
* main window: hiding the empty "Edit" menu and several unused context menu options (not coded)
* floppy context menu: implementation of copy/delete/rename and directory output options
* tape context menu: correction of the "rename" option which did not rename the file on the disk but only in the file list
* disk data viewer window: correction to avoid crashes in the event of a damaged floppy disk (there are certainly cases that are not supported)
* list of files: correction of drag&drop blocking after hovering over an item not eligible for drop
* list of files: correction of drag&drop from one block of a tape to another
* display of the content of a tape: bug correction making it impossible to view a block if another with the same name is already displayed
* extraction of blocks from a tape: correction of the bug resulting in systematic crashes
* improved recognition of certain types of files previously categorized as "BASIC program". This concerns Hyperbasic and Teleass sources and many binaries
* instead of the representation of the tapes in the alphabetical index, it is now possible to display them "flat" (addition of an option in the last tab of the configuration window)
* reorganization of context menus: display functions first, launch emulator and finally content modification functions. The option which appears in bold identifies the one which is executed via a double-click.
* modification of the ergonomics of the tree structure:
  * select a program/file or the block of a tape no longer displays its content automatically (you must now double-click it or go through the "view file" option in the context menu)
  * an option has been added in the tape context menu to display the content of all its blocks in a single operation
  * a double-click on a floppy disk or a tape now launches the emulator (for tapes, the machine type pravetz/oric-1/atmos is defined in the configuration window). For floppy disks it is the Atmos which is systematically launched, except for Stratsed floppy disks obviously
  * a double-click on an unknown format floppy disk now displays its content in the "Raw Data Viewer" window
  * double-clicking on a rom displays its content
* modification of the representation of the floppy disks: instead of using different icons for the floppy disks (ft-dos/oric-dos/sedoric/stratsed), it is now the type (master/slave/game) which is differentiated
* modification of the operation of the drag&drop: currently only tapes and blocks of tapes can be copied via drag&drop and they can only be "deposited" on tapes (apart from that of the original drag&drop). Treatments have been added to avoid unsupported operations which, until then, could cause crashes. The nodes "eligible" to be the destination of a drop are marked in green when they are overflown.
* when renaming a file (.dsk or .tap), the extension is added automatically if missing
* change the name of the "Import Text File" window (and the corresponding entry in the "Tools" menu) to "Import Atmos BASIC File" to correspond to its real function.
* "Import Atmos BASIC File" window: the "Import" button can now be clicked if the source/target files have been entered.
* "Import Atmos BASIC File" window always: implementation of the option "Existing tape" which was not and which allows to add a block to an existing tape. The "New disk" and "Existing disk" options not being implemented, they have been deactivated.
* added display of sources generated under Teleass
* tape context menu: addition of an option to launch the emulator with the Pravetz machine
* contextual menu for unknown disks: addition of an option to launch the emulator with sub-options corresponding to each type of machine (Pravetz, Oric-1, Atmos and Telestrat)
* big refacto again, in particular:
  * renaming of forms, prefixed with "frm"
  * renaming of user controls, prefixed with "ctl"
  * renaming of controls (and related events), prefixed with an abbreviation of their type (btn for buttons, lbl for labels, etc.) in order to recognize them more easily in the code and especially to shorten them because certain names were very long
  * delete unused image resources
* adjustment of the tab order of the controls of all windows


# Oric Explorer 2.1
* use of aliases of variable types (bool instead of Boolean, string instead of String, short instead of Int16, etc.)
* unassignment of unnecessarily assigned variables
* deactivation of variables and unused code
* redesign of the configuration persistence: previously saved in separate files (%userprofile%\AppData\Local\Scott_Davies\OricExplorer.exe_Url _........\ 2.0.0.0\user.config for the list of folders and syntax highlighting ; .\layout.xml for the type/location/size of the panels ; registry for the location/size of the main window), the configuration is now centralized in a single .json file located in the folder of the executable, to facilitate portable use
* completion of the syntax colorization configuration: only the colorization for BASIC was configurable via the application, addition of the configuration for the assembler and the hexadecimal dump
* fixed some problems in the configuration of disks/tapes/roms folders and the location of the emulator
* correction of the update search, change of the url which now points to the laurentd75 repo (which is not yet up to date)
* deactivation of the context menu for ROM type items
* update of dependencies
* and quite a few other little things of which I have not drawn up an exhaustive list


# Oric Explorer 2.0 new features
Here is a quick list of the welcome changes/additions I noted so far in Oric Explorer (compared to the interim 2.0 version released circa 2014/2015):

- new dark theme

- it is now possible to tell Oric Explorer to search tapes/disks in subfolders of the chosen directory (we were really missing this!)

  - *Note this area still needs some work as the process of adding and updating directories is not all together user friendly.*

- new information pane at the right (quite nice since we all have 16:9 screens these days so it makes sense to divide panes horizontally rather than vertically). What's more, in the previous version the information that was displayed in the top pane was often cropped, so this won't happen anymore.

  It should also be noted that the panes can now be dragged to different areas of the GUI with the mouse, i.e. the Information Pane can be dragged across so that it appears below the file list on the left-hand side.

- new preview option in the Data Viewer tab for displaying data as "CHAR" (for fonts) - this is really cool especially since Scott added the grid for individual chars and the ability to add an offset in case there is a header to the font data

- the "Open with emulator" menu now allows you to select to launch the emulator in either Oric-1 or Atmos modes. Although not yet implemented, it should be quite easy to also add Telestrat or Pravetz modes, with the appropriate command-line options.

- in the Data Viewer modes, for HIRES pictures the zoom window has disappeared, now you can select different zoom levels for the entire picture (nice, but I noticed that the zoom appears blurry, I suppose it must be because of the use of some OpenGL library or similar that applies a 3D/textured transformation to the image, hence the blurry "videocard processing" effect?). According to Scott Davies, getting rid of the blurry effect probably just requires some of the graphics settings such as anti-aliasing being setup correctly.

- Redesigned Screen viewer dialogue (previously called Image viewer) now showing thumbnails

  In this dialog, you can use the left and right cursor keys to move to the next and previous images. Also, you should be able to use Ctrl + Left and Ctrl + Right arrow keys to move to the first / last images in the list.

- new "Raw Data Viewer" dialogue

- redesigned "Disk information" tab that is now a pop-up dialogue. I noticed the pie chart for "Disk usage" disappeared (I quite liked it but well, the info is still available as text, which is OK although it needs changing colors as black text on red is not much legible... As this is using a custom control in the "FormsControlLibrary.dll" library, this will involve modifying code in this library. The source code for this library will be published as soon as possible. 
  It must also be noted that the Print option for the Directory Listing is (unfortunately) still grayed out as it most likely is not yet implemented.

- For individual files on tape or disk, new "Extract to" menu with more options (as tape, as text file, as raw data) replaces "Save as TAP file" option.


In addition to these features, there is one I didn't test (it existed in the "v2.0" release before but I never tested it then):
The "Tools > Convert Text File" option (maybe someone knows what it's supposed to do and can comment on this ?)

Also, I noticed a couple of enticing options that look unfortunately unimplemented at present:
* For disks:
  * Create New disk...
  * Format disk...
  * Convert to tape...

* For tapes:
  * Convert to disk...



