using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace OricExplorer.Forms
{
    public partial class CheckForUpdateForm : Form
    {
        private String websiteURL = "";
        private String updateDetails = "";
        private Version newVersion = null;

        public CheckForUpdateForm()
        {
            InitializeComponent();
        }

        private void CheckForUpdateForm_Shown(object sender, EventArgs e)
        {
            buttonWebsite.Enabled = false;
            buttonWebsite.Hide();

            Application.DoEvents();

            if (getVersionFromWebsite())
            {
                compareVersions();
            }
        }

        private void buttonWebsite_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(websiteURL);

            buttonWebsite.Hide();
            buttonClose.Text = "Close";
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private Boolean getVersionFromWebsite()
        {
            try
            {
                // Provide the XmlTextReader with the URL of our xml document
                String xmlURL = "http://oric.mrandmrsdavies.com/app_version.xml";

                XmlTextReader reader = new XmlTextReader(xmlURL);

                // Simply (and easily) skip the junk at the beginning
                reader.MoveToContent();

                // internal - as the XmlTextReader moves only forward, we save current xml element name
                // in elementName variable. When we parse a text node, we refer to elementName to check
                // what was the node name
                string elementName = "";

                // We check if the xml starts with a proper "ourfancyapp" element node
                if ((reader.NodeType == XmlNodeType.Element)) // && (reader.Name == "oricexplorer"))
                {
                    while (reader.Read())
                    {
                        // When we find an element node, we remember its name
                        if (reader.NodeType == XmlNodeType.Element)
                            elementName = reader.Name;
                        else
                        {
                            // for text nodes...
                            if ((reader.NodeType == XmlNodeType.Text) && (reader.HasValue))
                            {
                                // We check what the name of the node was
                                switch (elementName)
                                {
                                    case "version":
                                        // Thats why we keep the version info in xxx.xxx.xxx.xxx format
                                        // the Version class does the parsing for us
                                        newVersion = new Version(reader.Value);
                                        break;

                                    case "url":
                                        websiteURL = reader.Value;
                                        break;

                                    case "details":
                                        updateDetails = reader.Value;
                                        break;
                                }
                            }
                        }
                    }
                }

                reader.Close();
            }
            catch (FileNotFoundException ex)
            {
                String message = ex.Message;

                infoBoxDetails.Text = "Version check has failed.\n\nUpdate file was not found on server.";
                return false;
            }
            catch (Exception ex)
            {
                infoBoxDetails.Text = String.Format("Version check has failed.\n\n{0}.", ex.Message);
                return false;
            }

            return true;
        }

        private void compareVersions()
        {
            // Example : 2.1.3.4567
            // Major.Minor.Build.Revision

            Version curVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            infoBoxCurrentVersion.Text = String.Format("{0}.{1}.{2}.{3}", curVersion.Major, curVersion.Minor, curVersion.Build, curVersion.Revision);
            infoBoxAvailableVersion.Text = String.Format("{0}.{1}.{2}.{3}", newVersion.Major, newVersion.Minor, newVersion.Build, newVersion.Revision);

            int result = curVersion.CompareTo(newVersion);

            if (curVersion.CompareTo(newVersion) < 0)
            {
                buttonWebsite.Enabled = true;
                buttonWebsite.Show();

                infoBoxDetails.Text = "An update for Oric Explorer is available.\n\nCheck the update web page for more details and to download the update.\n\nWould you like to go to the update web page ? ";
            }
            else
            {
                infoBoxDetails.Text = "No updates available.\n\nCurrent version is upto date.";
                buttonClose.Text = "Close";
            }
        }
    }
}