namespace OricExplorer.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.IO.Compression;
    using System.Net;
    using System.Reflection;
    using System.Text;
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
                                        //mstrBinaryUpdateURL = $"{reader.Value.Replace("/blob/", "/raw/")}/{Assembly.GetExecutingAssembly().GetName().Name}.bin";
                                        mstrBinaryUpdateURL = reader.Value;
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

            Version curVersion = Assembly.GetExecutingAssembly().GetName().Version;

            ibxAvailableVersion.Text = string.Format("{0}.{1}.{2}.{3}", mNewVersion.Major, mNewVersion.Minor, mNewVersion.Build, mNewVersion.Revision);

            return (curVersion.CompareTo(mNewVersion) < 0);
        }

        private bool updateFromWebsite()
        {
            string strSourceURL = $"{mstrBinaryUpdateURL.Replace("/blob/", "/raw/")}/{Assembly.GetExecutingAssembly().GetName().Name}_v{mNewVersion}.zip";
            string strBinary = Assembly.GetExecutingAssembly().Location;
            string strOldBinary = $"{Path.GetFileNameWithoutExtension(strBinary)}.old";
            string strDownloadedZIP = $"{Path.GetFileNameWithoutExtension(strBinary)}_v{mNewVersion}.zip";

            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                                                     | SecurityProtocolType.Tls11
                                                     | SecurityProtocolType.Tls12
                                                     | SecurityProtocolType.Ssl3;

                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(strSourceURL);
                req.Proxy = null;
                req.Timeout = 10000;

                // connection to url
                HttpWebResponse rep = (HttpWebResponse)req.GetResponse();

                // status OK?
                if (rep.StatusCode == HttpStatusCode.OK)
                {
                    if (File.Exists(strDownloadedZIP))
                    {
                        File.Delete(strDownloadedZIP);
                    }
                    
                    long lngTotal = rep.ContentLength;
                    long lngDownloaded = 0;
                    int intBufferSize = 2048;
                    byte[] bytBuffer = new byte[intBufferSize];
                    int intSize;

                    Stream sr = rep.GetResponseStream();
                    Stream stm = new FileStream(strDownloadedZIP, FileMode.Create, FileAccess.Write, FileShare.None);

                    Stopwatch sw = new Stopwatch();
                    sw.Start();

                    while ((intSize = sr.Read(bytBuffer, 0, bytBuffer.Length)) > 0)
                    {
                        stm.Write(bytBuffer, 0, intSize);

                        lngDownloaded += intSize;

                        double dblDownloaded = (double)lngDownloaded;
                        double dblTotal = (double)lngTotal;
                        double dblPercentage = (dblDownloaded / dblTotal);
                        int intPercentage = (int)(dblPercentage * 100);

                        double dblElapsed = sw.ElapsedMilliseconds;
                        double dblRemaining = Math.Round(dblElapsed / dblDownloaded * (dblTotal - dblDownloaded) / 1000, 1);

                        ibxDetails.Text = $"Downloaded: {intPercentage}%, ETA: {dblRemaining}s";
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


                    bool boolExtractionError = false;
                    ibxDetails.Text += "\n\nUpdate in progress.";
                    Application.DoEvents();
                    
                    // if .old main executable exists, delete it
                    if (File.Exists(strOldBinary))
                    {
                        File.Delete(strOldBinary);
                    }
                    // rename main executable (.exe to .old)
                    File.Move(strBinary, strOldBinary);

                    // unzip each file of the downloaded archive
                    using (ZipStorer zip = ZipStorer.Open(strDownloadedZIP, FileAccess.Read))
                    {
                        List<ZipStorer.ZipFileEntry> lstFiles = zip.ReadCentralDir();
                        foreach (ZipStorer.ZipFileEntry zfe in lstFiles)
                        {
                            string strSource = zfe.FilenameInZip;
                            string strTarget = Path.Combine(Application.StartupPath, strSource);

                            // is it a file?
                            if (!strSource.EndsWith("/"))
                            {
                                // yes...

                                string strLockedTarget = null;

                                // does a file already exist with this name and in this location?
                                if (File.Exists(strTarget))
                                {
                                    // yes...

                                    try
                                    {
                                        // we try to delete it
                                        File.Delete(strTarget);
                                    }
                                    catch (UnauthorizedAccessException) // the file appears to be locked
                                    {
                                        // modification of the name under which the file will be extracted. The file will then be renamed
                                        // the next time the application is started (before the file is locked)
                                        strLockedTarget = strTarget;
                                        strTarget += ConstantsAndEnums.UPDATE_EXTENSION;
                                    }
                                }

                                // attempting to extract the file
                                if (!zip.ExtractFile(zfe, strTarget))
                                {
                                    // extraction failed
                                    boolExtractionError = true;
                                }
                                // extraction performed successfully but not under the original file name (indicating that the target file is locked)
                                else if (!string.IsNullOrEmpty(strLockedTarget))
                                {
                                    // we need to compare the two files
                                    FileVersionInfo fiOld = FileVersionInfo.GetVersionInfo(strLockedTarget);
                                    FileVersionInfo fiNew = FileVersionInfo.GetVersionInfo(strTarget);

                                    // if the file which has just been extracted is identical to the one which was already present, delete it
                                    if (fiNew.FileVersion == fiOld.FileVersion)
                                    {
                                        try
                                        {
                                            File.Delete(strTarget);
                                        } catch { }
                                    }
                                }
                            }
                        }

                        zip.Close();
                    }

                    // successful decompression?
                    if (boolExtractionError)
                    {
                        MessageBox.Show($"One or more files could not be decompressed. The downloaded archive may be corrupted or the application directory may be read-only.\r\n\r\nClose the application and try to update manually by unzipping the archive left for this purpose in the application folder.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
                        // attempt to delete the archive which has become useless
                        try
                        {
                            File.Delete(strDownloadedZIP);
                        } catch { }
                    }


                    ibxDetails.Text += "\n\nUpdate done.";
                    ibxDetails.Refresh();
                    Application.DoEvents();
                    Thread.Sleep(3000);

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