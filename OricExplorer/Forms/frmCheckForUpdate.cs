namespace OricExplorer.Forms
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Net;
    using System.Reflection;
    using System.Threading;
    using System.Windows.Forms;
    using System.Xml;

    public partial class frmCheckForUpdate : Form
    {
        private string mstrBinaryUpdateURL = "";
        private Version mNewVersion = null;
        private bool mboolCloseOnShown = false;

        public frmCheckForUpdate(bool autoCheck = false)
        {
            InitializeComponent();
            
            Version curVersion = Assembly.GetExecutingAssembly().GetName().Version;
            ibxCurrentVersion.Text = string.Format("{0}.{1}.{2}.{3}", curVersion.Major, curVersion.Minor, curVersion.Build, curVersion.Revision);

            bool boolUpdateAvailable = false;

            if (getVersionFromWebsite())
            {
                if (compareVersions())
                {
                    ibxDetails.Text = "An update for Oric Explorer is available.\n\nWould you like to update the binary?";

                    btnUpdate.Visible = true;
                    boolUpdateAvailable = true;
                }
                else
                {
                    ibxDetails.Text = "No updates available.\n\nCurrent version is up to date.";
                }
            }

            if (autoCheck && !boolUpdateAvailable)
            {
                mboolCloseOnShown = true;
            }
        }

        private void frmCheckForUpdate_Shown(object sender, EventArgs e)
        {
            if (mboolCloseOnShown)
            {
                this.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;
            btnClose.Enabled = false;

            if (updateFromWebsite())
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                btnUpdate.Visible = false;
                btnClose.Enabled = true;
            }
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
                                        mNewVersion = new Version(reader.Value);
                                        break;

                                    case "url":
                                        mstrBinaryUpdateURL = $"{reader.Value}/{Path.GetFileName(Assembly.GetExecutingAssembly().Location)}";
                                        break;

                                    case "details":
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

            ibxAvailableVersion.Text = string.Format("{0}.{1}.{2}.{3}", mNewVersion.Major, mNewVersion.Minor, mNewVersion.Build, mNewVersion.Revision);

            return (curVersion.CompareTo(mNewVersion) < 0);
        }

        private bool updateFromWebsite()
        {
            string strBinary = Assembly.GetExecutingAssembly().Location;
            string strOldBinary = strBinary + ".old";
            string strNewBinary = strBinary + ".new";

            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                                                     | SecurityProtocolType.Tls11
                                                     | SecurityProtocolType.Tls12
                                                     | SecurityProtocolType.Ssl3;

                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(mstrBinaryUpdateURL);
                req.Proxy = null;
                req.Timeout = 10000;

<<<<<<< HEAD
                // connection to url
                HttpWebResponse rep = (HttpWebResponse)req.GetResponse();

                // status OK?
                if (rep.StatusCode == HttpStatusCode.OK)
=======
                // tentative de connexion à l'url spécifiée
                HttpWebResponse rep = (HttpWebResponse)req.GetResponse();

                // le statut est-il OK ?
                if (rep.StatusCode == HttpStatusCode.OK) // peut être égal à -1 (contenu dynamique)
>>>>>>> 663b4fb90f05a13fabe3953696dd508c064da146
                {
                    if (File.Exists(strNewBinary))
                    {
                        File.Delete(strNewBinary);
                    }
                    
                    long lngTotal = rep.ContentLength;
<<<<<<< HEAD
                    long lngDownloaded = 0;
                    int intBufferSize = 2048;
                    byte[] bytBuffer = new byte[intBufferSize];
                    int intSize;
=======
                    long lngTéléchargé = 0;
                    int intTailleBuffer = 2048;// 4096;
                    byte[] bytBuffer = new byte[intTailleBuffer];
                    int intRécup;
>>>>>>> 663b4fb90f05a13fabe3953696dd508c064da146

                    Stream sr = rep.GetResponseStream();
                    Stream stm = new FileStream(strNewBinary, FileMode.Create, FileAccess.Write, FileShare.None);

                    Stopwatch sw = new Stopwatch();
                    sw.Start();

<<<<<<< HEAD
                    while ((intSize = sr.Read(bytBuffer, 0, bytBuffer.Length)) > 0)
                    {
                        stm.Write(bytBuffer, 0, intSize);

                        lngDownloaded += intSize;

                        double dblDownloaded = (double)lngDownloaded;
                        double dblTotal = (double)lngTotal;
                        double dblPercentage = (dblDownloaded / dblTotal);
                        int intPercentage = (int)(dblPercentage * 100);

                        double dblTemps = sw.ElapsedMilliseconds;
                        double dblReste = Math.Round(dblTemps / dblDownloaded * (dblTotal - dblDownloaded) / 1000, 1);

                        ibxDetails.Text = $"Downloaded: {intPercentage}%, ETA: {dblReste}s";
=======
                    while ((intRécup = sr.Read(bytBuffer, 0, bytBuffer.Length)) > 0)
                    {
                        stm.Write(bytBuffer, 0, intRécup);

                        lngTéléchargé += intRécup;

                        double dblTéléchargé = (double)lngTéléchargé;
                        double dblTotal = (double)lngTotal;
                        double dblPourcentage = (dblTéléchargé / dblTotal);
                        int intPourcentage = (int)(dblPourcentage * 100);

                        double dblTemps = sw.ElapsedMilliseconds;
                        double dblReste = Math.Round(dblTemps / dblTéléchargé * (dblTotal - dblTéléchargé) / 1000, 1);

                        ibxDetails.Text = $"Downloaded: {intPourcentage}%, ETA: {dblReste}s";
>>>>>>> 663b4fb90f05a13fabe3953696dd508c064da146
                        ibxDetails.Refresh();

                        Application.DoEvents();
                    }

                    sw.Stop();
                    stm.Close();
                    sr.Close();

                    ibxDetails.Text = "Download finished.";
                    ibxDetails.Refresh();
                    Application.DoEvents();
                    Thread.Sleep(1000);

                    if (File.Exists(strOldBinary))
                    {
                        File.Delete(strOldBinary);
                    }
                    File.Move(strBinary, strOldBinary);
                    File.Move(strNewBinary, strBinary);

                    ibxDetails.Text += "\n\nBinary updated.";
                    ibxDetails.Refresh();
                    Application.DoEvents();
                    Thread.Sleep(1000);

                    ibxDetails.Text += "\n\nRestarting application.";
                    ibxDetails.Refresh();
                    Application.DoEvents();
                    Thread.Sleep(1000);

                    return true;
                }
            }
            catch (Exception ex)
            {
                ibxDetails.Text = $"Update has failed: {ex.Message}";
            }

            return false;
        }
    }
}