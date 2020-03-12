namespace OricExplorer.Forms
{
    using System;
    using System.Collections;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    public partial class frmScreenViewer : Form
    {
        private enum ImageFormatsToDisplay { HIRES_ONLY, TEXT_ONLY, BOTH};
        private enum SlideshowStatus {RUNNING, PAUSED, STOPPED};

        public OricDiskInfo diskInfo;
        public string diskPathname;

        public OricProgram oricProgram;
        public OricFileInfo oricFileInfo;

        ScreenImage.ScreenImageFormat screenImageFormat;

        private ScreenImage oricScreenImage;

        private System.Windows.Forms.Timer IntervalTimer;

        bool slideshowPaused = false;
        bool slideshowLoop = false;
        bool slideshowRunning = false;

        private System.Windows.Forms.Timer FlashTimer;

        int imageIndex = 0;
        int imageInterval = 500;

        int hiresCount = 0;
        int textCount = 0;

        Image screenImage;

        OricFileInfo[] imageList;

        private ImageFormatsToDisplay imageFormatsToShow = ImageFormatsToDisplay.BOTH;

        public frmScreenViewer()
        {
            InitializeComponent();

            oricScreenImage = new ScreenImage();

            oricFileInfo = new OricFileInfo();
            oricProgram = new OricProgram();
        }

        private void Initialise()
        {
            // Build a list containing all the image files
            imageIndex = 0;
            imageList = buildImageList();

            if (hiresCount > 0 || textCount > 0)
            {
                // Display number of images found
                displayImageCount();

                // Display first image
                displayImage(0);
            }
            else
            {
                ibxImageCount.Text = "No screens found on disk";
                NoPreview();
            }

            // Set state of slideshow controls
            enableDisableControls();

            displaySlideShowStatus(SlideshowStatus.STOPPED);

            lblSpeed.Text = string.Format("Interval\n{0:N1} seconds", (float)(imageInterval) / 1000);

            if (hiresCount > 0 || textCount > 0)
            {
                generateThumbnails();

                if (FlashTimer == null)
                {
                    FlashTimer = new System.Windows.Forms.Timer();
                    FlashTimer.Interval = 700;
                    FlashTimer.Start();
                    FlashTimer.Tick += new EventHandler(FlashTimer_Tick);
                }
                else
                {
                    FlashTimer.Stop();
                    FlashTimer = null;
                }
            }

            if (hiresCount == 0 || textCount == 0)
            {
                optShowHiresOnly.Enabled = false;
                optShowTextOnly.Enabled = false;
                optShowBoth.Enabled = false;
                optShowBoth.Checked = true;
            }
            else
            {
                optShowHiresOnly.Enabled = true;
                optShowTextOnly.Enabled = true;
                optShowBoth.Enabled = true;
            }
        }

        private void generateThumbnails()
        {
            // Remove any images
            flpThumbnails.Controls.Clear();

            for (int imageIndex = 0; imageIndex < imageList.Count(); imageIndex++)
            {
                Panel imagePanel = new Panel();
                imagePanel.Name = string.Format("panel_{0}", imageIndex);
                imagePanel.Size = new Size(170, 175);
                imagePanel.BorderStyle = BorderStyle.FixedSingle;
                imagePanel.BackColor = Color.FromArgb(200, 200, 200);

                Label imageLabel = new Label();
                imageLabel.Name = string.Format("label_{0}", imageIndex);
                imageLabel.Size = new Size(160, 18);
                imageLabel.Font = new Font("Segoe UI", 8);
                imageLabel.TextAlign = ContentAlignment.MiddleCenter;
                imageLabel.Text = imageList[imageIndex].ProgramName;
                imageLabel.Left = 5;
                imageLabel.Top = 154;

                PictureBox screenImage = new PictureBox();

                screenImage.Name = string.Format("{0}", imageIndex);
                screenImage.Size = new Size(160, 150);
                screenImage.BackColor = Color.White;
                screenImage.BorderStyle = BorderStyle.None;
                screenImage.SizeMode = PictureBoxSizeMode.Zoom;
                screenImage.Cursor = System.Windows.Forms.Cursors.Hand;
                screenImage.Top = 5;
                screenImage.Left = 5;

                tlpToolTip = new ToolTip();
                tlpToolTip.ToolTipTitle = "Image Information";
                tlpToolTip.SetToolTip(screenImage, string.Format("Name : {0}\nFormat : {1}", imageList[imageIndex].ProgramName, imageList[imageIndex].FormatToString()));
                tlpToolTip.Popup += tlpToolTip_Popup;

                screenImage.Click += new System.EventHandler(screenImage_Click);

                OricProgram oricProgram = imageList[imageIndex].LoadFile();

                ScreenImage thumbnailImage = new ScreenImage();
                thumbnailImage.m_ui16StartAddress = oricProgram.StartAddress;
                thumbnailImage.m_ui16DataLength = oricProgram.ProgramLength;
                thumbnailImage.bScrnData = oricProgram.m_programData;

                if (oricProgram.Format == OricProgram.ProgramFormat.HiresScreen)
                {
                    screenImageFormat = ScreenImage.ScreenImageFormat.IMAGE_FORMAT_HIRES;
                }
                else
                {
                    screenImageFormat = ScreenImage.ScreenImageFormat.IMAGE_FORMAT_TEXT;
                }

                thumbnailImage.DrawScreenImage(ScreenImage.ScreenImageSize.IMAGE_SIZE_NORMAL, screenImageFormat);

                screenImage.Image = thumbnailImage.screenImageData;

                imagePanel.Controls.Add(screenImage);
                imagePanel.Controls.Add(imageLabel);

                flpThumbnails.Controls.Add(imagePanel);
            }
        }

        private void screenImage_Click(object sender, EventArgs e)
        {
            PictureBox thumbnail = (PictureBox)sender;

            imageIndex = Convert.ToInt16(thumbnail.Name);
            displayImage(imageIndex);
        }

        private void frmScreenViewer_Load(object sender, EventArgs e)
        {
            Text = string.Format("Screen Viewer - {0}", diskInfo.FullName);

            // Set initial slideshow speed
            tkbSpeed.Value = 1;

            Initialise();
        }

        private void frmScreenViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IntervalTimer != null)
            {
                IntervalTimer.Stop();
            }
        }

        #region Slideshow Controls
        private void btnFirstImage_Click(object sender, EventArgs e)
        {
            imageIndex = 0;
            displayImage(imageIndex);
        }

        private void btnPrevImage_Click(object sender, EventArgs e)
        {
            if (imageIndex > 0)
            {
                imageIndex--;
                displayImage(imageIndex);
            }
        }

        private void btnNextImage_Click(object sender, EventArgs e)
        {
            if (imageIndex < imageList.Count())
            {
                imageIndex++;
                displayImage(imageIndex);
            }
        }

        private void btnLastImage_Click(object sender, EventArgs e)
        {
            imageIndex = imageList.Count()-1;
            displayImage(imageIndex);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            displaySlideShowStatus(SlideshowStatus.RUNNING);

            slideshowRunning = true;
            slideshowPaused = false;

            imageIndex = 0;
            enableDisableControls();
            createTimer();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (slideshowPaused)
            {
                slideshowPaused = false;

                displaySlideShowStatus(SlideshowStatus.RUNNING);

                createTimer();
            }
            else
            {
                slideshowPaused = true;

                displaySlideShowStatus(SlideshowStatus.PAUSED);

                if (IntervalTimer != null)
                {
                    IntervalTimer.Stop();
                    IntervalTimer = null;
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            displaySlideShowStatus(SlideshowStatus.STOPPED);

            slideshowRunning = false;
            slideshowPaused = false;

            if (IntervalTimer != null)
            {
                IntervalTimer.Stop();
                IntervalTimer = null;
            }

            enableDisableControls();
        }

        private void buttonLoop_Click(object sender, EventArgs e)
        {

        }

        private void tkbSpeed_ValueChanged(object sender, EventArgs e)
        {
            setInterval();
        }

        private void chkLoop_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLoop.Checked)
            {
                slideshowLoop = true;
            }
            else
            {
                slideshowLoop = false;
            }
        }
        #endregion

        private OricFileInfo[] buildImageList()
        {
            hiresCount = 0;
            textCount = 0;

            ArrayList listOfImages = new ArrayList();

            // Get list of files on disk
            OricFileInfo[] fileList = diskInfo.GetFiles();

            foreach (OricFileInfo fileInfo in fileList)
            {
                switch(fileInfo.Format)
                {
                    case OricProgram.ProgramFormat.HiresScreen:
                        hiresCount++;

                        if(imageFormatsToShow == ImageFormatsToDisplay.BOTH || imageFormatsToShow == ImageFormatsToDisplay.HIRES_ONLY)
                        {
                            listOfImages.Add(fileInfo);
                        }
                        break;

                    case OricProgram.ProgramFormat.TextScreen:
                    case OricProgram.ProgramFormat.HelpFile:
                    case OricProgram.ProgramFormat.WindowFile:
                        textCount++;

                        if (imageFormatsToShow == ImageFormatsToDisplay.BOTH || imageFormatsToShow == ImageFormatsToDisplay.TEXT_ONLY)
                        {
                            listOfImages.Add(fileInfo);
                        }
                        break;

                    default:
                        break;
                }
            }

            imageList = new OricFileInfo[listOfImages.Count];
            listOfImages.CopyTo(imageList);

            return imageList;
        }

        private void createTimer()
        {
            if (IntervalTimer != null)
            {
                IntervalTimer.Stop();
                IntervalTimer.Interval = imageInterval;
                IntervalTimer.Start();
            }
            else
            {
                IntervalTimer = new System.Windows.Forms.Timer();
                IntervalTimer.Interval = imageInterval;
                IntervalTimer.Start();

                IntervalTimer.Tick += new EventHandler(SlideshowTimer_Tick);
            }
        }

        private void SlideshowTimer_Tick(object sender, System.EventArgs e)
        {
            if (imageIndex < imageList.Count())
            {
                displayImage(imageIndex);
                imageIndex++;
            }
            else
            {
                // End of slideshow
                if (slideshowLoop)
                {
                    imageIndex = 0;
                    displayImage(imageIndex);
                }
                else
                {
                    slideshowRunning = false;
                    slideshowPaused = false;

                    displaySlideShowStatus(SlideshowStatus.STOPPED);
                    enableDisableControls();

                    IntervalTimer.Stop();
                }
            }
        }

        private void FlashTimer_Tick(object sender, System.EventArgs e)
        {
            if (imageIndex < imageList.Count())
            {
                displayImage(imageIndex);
            }
        }

        private void setInterval()
        {
            float interval = (float)(tkbSpeed.Value) / 2;
            imageInterval = (int)(interval * 1000);

            if (slideshowRunning)
            {
                createTimer();
            }

            lblSpeed.Text = string.Format("Interval\n{0:N1} seconds", (float)(imageInterval) / 1000);
        }

        private void displayImage(int imageIndex)
        {
            OricFileInfo fileInfo = (OricFileInfo)imageList[imageIndex];
            OricProgram oricProgram = fileInfo.LoadFile();

            oricScreenImage.m_ui16StartAddress = oricProgram.StartAddress;
            oricScreenImage.m_ui16DataLength = oricProgram.ProgramLength;
            oricScreenImage.bScrnData = oricProgram.m_programData;
            oricScreenImage.m_bFlash = !oricScreenImage.m_bFlash;

            if (oricProgram.Format == OricProgram.ProgramFormat.HiresScreen)
            {
                screenImageFormat = ScreenImage.ScreenImageFormat.IMAGE_FORMAT_HIRES;
            }
            else
            {
                screenImageFormat = ScreenImage.ScreenImageFormat.IMAGE_FORMAT_TEXT;
            }

            oricScreenImage.DrawScreenImage(ScreenImage.ScreenImageSize.IMAGE_SIZE_ENLARGED, screenImageFormat);
            picScreenImage.Image = oricScreenImage.screenImageData;

            displayImageInfo(fileInfo);

            if (!slideshowRunning)
            {
                // Display thumbnail of current image
                foreach(Control control in flpThumbnails.Controls)
                {
                    if(control is Panel)
                    {
                        Panel panel = (Panel)control;
                        panel.BackColor = Color.FromArgb(200, 200, 200);
                    }
                }

                Control[] imagePanel = flpThumbnails.Controls.Find(string.Format("panel_{0}", imageIndex), true);

                if(imagePanel.Count() == 1)
                {
                    Panel panel = (Panel)imagePanel[0];
                    panel.BackColor = Color.FromArgb(150, 150, 150);
                    panel.Focus();
                }
            }

            enableDisableControls();
        }

        private void enableDisableControls()
        {
            if (slideshowRunning)
            {
                btnFirstImage.Enabled = false;
                btnLastImage.Enabled = false;
                btnPrevImage.Enabled = false;
                btnNextImage.Enabled = false;
            }
            else
            {
                if (imageIndex > 0)
                {
                    btnFirstImage.Enabled = true;
                    btnPrevImage.Enabled = true;
                }
                else
                {
                    btnFirstImage.Enabled = false;
                    btnPrevImage.Enabled = false;
                }

                if (imageIndex < imageList.Count()-1)
                {
                    btnLastImage.Enabled = true;
                    btnNextImage.Enabled = true;
                }
                else
                {
                    btnLastImage.Enabled = false;
                    btnNextImage.Enabled = false;
                }
            }

            if (slideshowRunning)
            {
                btnPlay.Enabled = false;
                btnPause.Enabled = true;
                btnStop.Enabled = true;
                chkLoop.Enabled = true;
            }
            else
            {
                btnPlay.Enabled = true;
                btnPause.Enabled = false;
                btnStop.Enabled = false;
                chkLoop.Enabled = true;
            }
        }

        private void NoPreview()
        {
            screenImage = new Bitmap(picScreenImage.Width, picScreenImage.Height);

            // Create graphics object for alteration.
            Graphics newGraphics = Graphics.FromImage(screenImage);
            newGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

            // Fill entire image with black background.
            newGraphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, 240, 224);

            string strMessage = "No Screens on Disk";

            // Create font and brush.
            Font drawFont = new Font("Segoe UI", 16);
            SolidBrush drawBrush = new SolidBrush(Color.FromArgb(0, 255, 0));

            SizeF stringSize = new SizeF();
            stringSize = newGraphics.MeasureString(strMessage, drawFont);

            // Calc position of text so that it is centred
            float x = (screenImage.Width / 2) - (stringSize.Width / 2);
            float y = (screenImage.Height / 2) - (stringSize.Height / 2);

            // Draw string to screen.
            newGraphics.DrawString(strMessage, drawFont, drawBrush, x, y);

            // Dispose of graphics object.
            newGraphics.Dispose();

            picScreenImage.Image = screenImage;
        }

        #region Info Display Functions
        private void displayImageCount()
        {
            string hiresCountInfo = "";
            string textCountInfo = "";

            if (hiresCount == 1)
            {
                hiresCountInfo = "1 HIRES";
            }
            else
            {
                hiresCountInfo = string.Format("{0} HIRES", hiresCount);
            }

            if (textCount == 1)
            {
                textCountInfo = "1 TEXT";
            }
            else
            {
                textCountInfo = string.Format("{0} TEXT", textCount);
            }

            if (hiresCount == 0 && textCount == 0)
            {
                ibxImageCount.Text = "No Screens found";
            }
            else if (hiresCount == 0)
            {
                ibxImageCount.Text = string.Format("Found {0} Screens", textCountInfo);
            }
            else if (textCount == 0)
            {
                ibxImageCount.Text = string.Format("Found {0} Screens", hiresCountInfo);
            }
            else
            {
                ibxImageCount.Text = string.Format("Found {0} and {1} Screens", hiresCountInfo, textCountInfo);
            }
        }

        private void displayImageInfo(OricFileInfo fileinfo)
        {
            switch(imageFormatsToShow)
            {
                case ImageFormatsToDisplay.HIRES_ONLY:
                    ibxImageFormat.Text = "HIRES Screens only";
                    break;

                case ImageFormatsToDisplay.TEXT_ONLY:
                    ibxImageFormat.Text = "TEXT Screens only";
                    break;

                case ImageFormatsToDisplay.BOTH:
                    ibxImageFormat.Text = "All Screens";
                    break;
            }

            ibxImageCounter.Text = string.Format("{0} of {1}", imageIndex+1, imageList.Count());

            ibxFilename.Text = fileinfo.ProgramName;

            if (fileinfo.Format == OricProgram.ProgramFormat.HiresScreen)
            {
                ibxFormat.Text = "HIRES Screen";
            }
            else if (fileinfo.Format == OricProgram.ProgramFormat.TextScreen)
            {
                ibxFormat.Text = "TEXT Screen";
            }
            else if (fileinfo.Format == OricProgram.ProgramFormat.HelpFile)
            {
                ibxFormat.Text = "Help Screen";
            }
            else if(fileinfo.Format == OricProgram.ProgramFormat.WindowFile)
            {
                ibxFormat.Text = "Window Screen";
            }
            else
            {
                ibxFormat.Text = "Unknown";
            }

            ibxStartAddress.Text = string.Format("{0} (${0:X4})", fileinfo.StartAddress, fileinfo.StartAddress);
            ibxEndAddress.Text = string.Format("{0} (${0:X4})", fileinfo.EndAddress, fileinfo.EndAddress);

            ibxLength.Text = string.Format("{0:N0} bytes ({1:N1} KB)", fileinfo.LengthBytes, (float)fileinfo.LengthBytes / 1024);

            if (fileinfo.Format == OricProgram.ProgramFormat.HiresScreen)
            {
               ibxDimensions.Text = string.Format("240 x {0:N0}", (float)(fileinfo.LengthBytes / 40));
            }
            else
            {
                ibxDimensions.Text = string.Format("40 x {0:N0}", (float)(fileinfo.LengthBytes / 40));
            }
        }

        private void displaySlideShowStatus(SlideshowStatus slideShowStatus)
        {
            switch (slideShowStatus)
            {
                case SlideshowStatus.STOPPED:
                    ibxSlideshowStatus.Text = "Stopped";
                    ibxSlideshowStatus.ForeColor = Color.Red;
                    break;

                case SlideshowStatus.PAUSED:
                    ibxSlideshowStatus.Text = "Paused...";
                    ibxSlideshowStatus.ForeColor = Color.Blue;
                    break;

                case SlideshowStatus.RUNNING:
                    ibxSlideshowStatus.Text = "Running";

                    if (slideshowLoop)
                    {
                        ibxSlideshowStatus.Text += " (Loop)";
                    }

                    ibxSlideshowStatus.ForeColor = Color.Green;
                    break;

                default:
                    break;
            }
        }
        #endregion

        private void optShowHiresOnly_CheckedChanged(object sender, EventArgs e)
        {
            imageFormatsToShow = ImageFormatsToDisplay.HIRES_ONLY;
            Initialise();
        }

        private void optShowTextOnly_CheckedChanged(object sender, EventArgs e)
        {
            imageFormatsToShow = ImageFormatsToDisplay.TEXT_ONLY;
            Initialise();
        }

        private void optShowBoth_CheckedChanged(object sender, EventArgs e)
        {
            imageFormatsToShow = ImageFormatsToDisplay.BOTH;
            Initialise();
        }

        private void tlpToolTip_Popup(object sender, PopupEventArgs e)
        {
            Control selectedControl = e.AssociatedControl;
        }

        private void btnSaveScreen_Click(object sender, EventArgs e)
        {
            oricScreenImage.SaveScreen();
        }

        private void btnPrintScreen_Click(object sender, EventArgs e)
        {
            prtDocument.OriginAtMargins = true;
            prtDocument.DocumentName = imageList[imageIndex].ProgramName;

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = prtDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                prtDocument.Print();
            }
        }

        private void prtDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int xPos = (e.MarginBounds.Width - picScreenImage.Width) / 2;
            int yPos = (e.MarginBounds.Height - picScreenImage.Height) / 2;

            e.Graphics.DrawImage(picScreenImage.Image, xPos, yPos);
        }

        private void frmScreenViewer_KeyUp(object sender, KeyEventArgs e)
        {
            switch (Keys.KeyCode & e.KeyCode)
            {
                case Keys.Left:
                    if (imageIndex > 0)
                    {
                        imageIndex--;
                        displayImage(imageIndex);
                    }
                    break;

                case Keys.Right:
                    if (imageIndex < imageList.Count()-1)
                    {
                        imageIndex++;
                        displayImage(imageIndex);
                    }
                    break;

                case Keys.Home:
                    if (imageIndex != 0)
                    {
                        imageIndex = 0;
                        displayImage(imageIndex);
                    }
                    break;

                case Keys.End:
                    if(imageIndex != imageList.Count()-1)
                    {
                        imageIndex = imageList.Count() - 1;
                        displayImage(imageIndex);
                    }
                    break;
            }
        }
    }
}
