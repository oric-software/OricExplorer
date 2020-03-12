namespace OricExplorer.Forms
{
    using System;
    using System.IO;
    using System.Net;
    using System.Windows.Forms;
    using System.Xml;

    public partial class frmCheckForUpdate : Form
    {
        private string websiteURL = "";
        //private string updateDetails = "";
        private Version newVersion = null;

        public frmCheckForUpdate()
        {
            InitializeComponent();
        }

        private void frmCheckForUpdate_Shown(object sender, EventArgs e)
        {
            Version curVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            ibxCurrentVersion.Text = string.Format("{0}.{1}.{2}.{3}", curVersion.Major, curVersion.Minor, curVersion.Build, curVersion.Revision);

            btnYes.Enabled = false;
            btnYes.Hide();

            Application.DoEvents();

            if (getVersionFromWebsite())
            {
                if (compareVersions())
                {
                    btnClose.Text = "No";
                }
            }
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(websiteURL);

            btnYes.Hide();
            btnClose.Text = "Close";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool getVersionFromWebsite()
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                                                     | SecurityProtocolType.Tls11
                                                     | SecurityProtocolType.Tls12
                                                     | SecurityProtocolType.Ssl3;

                // Provide the XmlTextReader with the URL of our xml document
                XmlTextReader reader = new XmlTextReader(ConstantsAndEnums.APP_VERSION_URL);

                // Simply (and easily) skip the junk at the beginning
                reader.MoveToContent();

                // internal - as the XmlTextReader moves only forward, we save current xml element name
                // in elementName variable. When we parse a text node, we refer to elementName to check
                // what was the node name
                string elementName = "";

                // We check if the xml starts with a proper "ourfancyapp" element node
                if ((reader.NodeType == XmlNodeType.Element))
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
                                        //updateDetails = reader.Value;
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
                string message = ex.Message;

                ibxDetails.Text = "Version check has failed.\n\nUpdate file was not found on server.";
                return false;
            }
            catch (Exception ex)
            {
                ibxDetails.Text = string.Format("Version check has failed.\n\n{0}.", ex.Message);
                return false;
            }

            return true;
        }

        private bool compareVersions()
        {
            // Example : 2.1.3.4567
            // Major.Minor.Build.Revision

            Version curVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            ibxAvailableVersion.Text = string.Format("{0}.{1}.{2}.{3}", newVersion.Major, newVersion.Minor, newVersion.Build, newVersion.Revision);

            if (curVersion.CompareTo(newVersion) < 0)
            {
                btnYes.Enabled = true;
                btnYes.Show();

                ibxDetails.Text = "An update for Oric Explorer is available.\n\nCheck the update web page for more details and to download the update.\n\nWould you like to go to the update web page?";
                return true;
            }
            else
            {
                ibxDetails.Text = "No updates available.\n\nCurrent version is up to date.";
                return false;
            }
        }
    }
}