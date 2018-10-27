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



