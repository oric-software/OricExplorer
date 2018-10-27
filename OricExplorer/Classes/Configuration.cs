using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Xml;
using System.IO;
using FastColoredTextBoxNS;
using System.Drawing;
using System.Collections.Specialized;

namespace OricExplorer
{
    public class Configuration
    {
        public enum SyntaxHighlightingItems { String, Comment, Keyword, Loops, Branches, DataKeyword, LineNumber, Number, HexNumber };

        Dictionary<SyntaxHighlightingItems, TextStyle> colours;

        Color pageBackground;

        StringCollection tapeFolders;
        StringCollection diskFolders;
        StringCollection romFolders;
		
        String emulatorExecutable;
        String dirListingsFolder;

        Boolean checkForUpdatesOnStartup;

        public Configuration()
        {
            colours = new Dictionary<SyntaxHighlightingItems, TextStyle>();

            pageBackground = Color.Black;

            tapeFolders = new StringCollection();
            diskFolders = new StringCollection();
            romFolders = new StringCollection();

            emulatorExecutable = "";
            dirListingsFolder = "";

            checkForUpdatesOnStartup = false;

            LoadUserSettings();
            LoadSyntaxHighlightingSettings();
        }

        public void ReloadSettings()
        {
            LoadUserSettings();
            LoadSyntaxHighlightingSettings();
        }

        public void SaveSettings()
        {
            Properties.Settings.Default.EmulatorExecutable = emulatorExecutable;
            Properties.Settings.Default.DirectoryListingsFolder = dirListingsFolder;

            Properties.Settings.Default.CheckForUpdatesOnStartup = checkForUpdatesOnStartup;

            Properties.Settings.Default.TapeFolders = tapeFolders;
            Properties.Settings.Default.DiskFolders = diskFolders;
            Properties.Settings.Default.RomFolders = romFolders;

            Properties.Settings.Default.PageBackground = pageBackground;

            foreach (SyntaxHighlightingItems item in Enum.GetValues(typeof(SyntaxHighlightingItems)))
            {
                TextStyle textStyle = colours[item];
                SolidBrush tmp = (SolidBrush)textStyle.ForeBrush;
                String fontStyle = textStyle.FontStyle.ToString();

                try
                {
                    Properties.Settings.Default["Basic" + item.ToString() + "Color"] = tmp.Color;
                    Properties.Settings.Default["Basic" + item.ToString() + "Style"] = textStyle.FontStyle.ToString();
                }
                catch(System.Configuration.SettingsPropertyNotFoundException)
                {
                    System.Configuration.SettingsProperty property = new System.Configuration.SettingsProperty("Basic" + item.ToString() + "Color");
                    property.PropertyType = typeof(string);
                    property.DefaultValue = "TEST";

                    Properties.Settings.Default.Properties.Add(property);
                }
            }

            Properties.Settings.Default.Save();
        }

        private void LoadUserSettings()
        {
            emulatorExecutable = Properties.Settings.Default.EmulatorExecutable;
            dirListingsFolder = Properties.Settings.Default.DirectoryListingsFolder;

            checkForUpdatesOnStartup = Properties.Settings.Default.CheckForUpdatesOnStartup;

            tapeFolders = Properties.Settings.Default.TapeFolders;
            diskFolders = Properties.Settings.Default.DiskFolders;
            romFolders = Properties.Settings.Default.RomFolders;
        }

        private void LoadSyntaxHighlightingSettings()
        {
            pageBackground = Properties.Settings.Default.PageBackground;

            colours.Clear();

            foreach (SyntaxHighlightingItems item in Enum.GetValues(typeof(SyntaxHighlightingItems)))
            {
                try
                {
                    Color foreColor = (Color)Properties.Settings.Default["Basic" + item.ToString() + "Color"];
                    String[] style = Properties.Settings.Default["Basic" + item.ToString() + "Style"].ToString().Split('|');

                    FontStyle fontStyle = new FontStyle();

                    foreach (String s in style)
                    {
                        switch (s)
                        {
                            case "Regular":
                                fontStyle |= FontStyle.Regular;
                                break;

                            case "Bold":
                                fontStyle |= FontStyle.Bold;
                                break;

                            case "Italic":
                                fontStyle |= FontStyle.Italic;
                                break;

                            case "Underline":
                                fontStyle |= FontStyle.Underline;
                                break;

                            default:
                                break;
                        }
                    }

                    TextStyle textStyle = new TextStyle(new SolidBrush(foreColor), null, fontStyle);

                    colours.Add(item, textStyle);
                }
                catch(Exception ex)
                {
                    String message = ex.Message;
                }
            }
        }

        #region Functions to return settings
        public StringCollection TapeFolders
        {
            set { tapeFolders = value; }
            get { return tapeFolders; }
        }

        public StringCollection DiskFolders
        {
            set { diskFolders = value; }
            get { return diskFolders; }
        }

        public StringCollection ROMFolders
        {
            set { romFolders = value; }
            get { return romFolders; }
        }

        public String EmulatorExecutable
        {
            set { emulatorExecutable = value; }
            get { return emulatorExecutable; }
        }

        public String DirListingsFolder
        {
            set { dirListingsFolder = value; }
            get { return dirListingsFolder; }
        }

        public Boolean CheckForUpdatesOnStartup
        {
            set { checkForUpdatesOnStartup = value; }
            get { return checkForUpdatesOnStartup; }
        }

        public Color PageBackground
        {
            set { pageBackground = value; }
            get { return pageBackground; }
        }

        public Dictionary<SyntaxHighlightingItems, TextStyle> SyntaxHighlightingSettings
        {
            set { colours = value; }
            get { return colours; }
        }
        #endregion
    }
}
