# Oric Explorer packaging information

Generating the project in "release" mode automatically triggers several post-compile actions:
* the deletion of the * .zip and * .exe files located in the "\dist" folder
* the copy of the new executable in the "\dist" folder, renamed to .bin (used for the automatic update)
* the execution of the script "OricExplorer\Packager\update_app_version.ps1" which updates the file "dist\app_version.xml" (used for the automatic update)   according to the version number extracted from the generated executable
* the execution of the script "OricExplorer\Packager\create_archive.ps1" which creates the archive by placing the binaries in it.

However, the generation of the installer package *is not automatic*. It must be done manually by opening the "OricExplorer\Installer\OricExplorer.iss" file in the *InnoSetup* software which should have been installed beforehand. The generation of the installer will then be done automatically in the "\dist" folder.