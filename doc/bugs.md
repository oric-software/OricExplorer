## Known Bugs

- Bugs in code handling DSK format 

  - DSK create / write feature: the DSK creation feature is currently broken and needs to be fixed.
  - The code that reads .dsk files does have problems with some disks: it either doesn't recognize them or isn't able to determine all the values correctly such as space used or free space in some cases. However for the most part it does handle correctly most disks it was tested with.



## Unqualified Bugs

Here is a quick list of unqualified/unverified bugs in the current version of Oric Explorer (feel free to add to the list):

- I was unable to have the programme show me the BASIC source for the disk version of the *"Detective Story*" game. Mind you, this disk seems slightly bugged anyway so maybe this explains why (looks like the DSK version was created from a faulty TAP file, as there are graphics bugs and also bogus characters in the Basic code that cause runtime errors and are symptomatic of a faulty transfer). Nevertheless, it seems that the BASIC code viewer may have some bugs/difficulties displaying some programs.

