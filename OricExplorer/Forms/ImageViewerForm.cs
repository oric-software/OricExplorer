using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace OricExplorer.Forms
{
    public partial class ImageViewerForm : Form
    {
        private enum SlideshowStatus {RUNNING, PAUSED, STOPPED};

        public OricDiskInfo diskInfo;
        public String diskPathname;

        public OricProgram oricProgram;
        public OricFileInfo oricFileInfo;

        ScreenImage.ScreenImageFormat screenImageFormat;

        private ScreenImage oricScreenImage;

        private System.Windows.Forms.Timer IntervalTimer;

        Boolean slideshowPaused = false;
        Boolean slideshowLoop = false;
        Boolean slideshowRunning = false;

        int imageIndex = 0;
        int imageInterval = 500;

        OricFileInfo[] imageList;

        public ImageViewerForm()
        {
            InitializeComponent();

            oricScreenImage = new ScreenImage();

            oricFileInfo = new OricFileInfo();
            oricProgram = new OricProgram();
        }

        private void SlideshowViewerForm_Load(object sender, EventArgs e)
        {
            // Build a list containing all the image files
            imageList = buildImageList();

            // Display number of images found
            displayImageCount();

            // Display first image
            displayImage(0);

            // Set state of slideshow controls
            enableDisableControls();

            // Set initial slideshow speed
            trackBarSpeed.Value = 1;

            displaySlideShowStatus(SlideshowStatus.STOPPED);

            labelSpeed.Text = String.Format("{0:N1} seconds", (float)(imageInterval) / 1000);
        }

        private void SlideshowViewerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IntervalTimer != null)
            {
                IntervalTimer.Stop();
            }
        }

        #region Slideshow Controls
        private void buttonFirstImage_Click(object sender, EventArgs e)
        {
            imageIndex = 0;
            displayImage(imageIndex);
        }

        private void buttonPrevImage_Click(object sender, EventArgs e)
        {
            if (imageIndex > 0)
            {
                imageIndex--;
                displayImage(imageIndex);
            }
        }

        private void buttonNextImage_Click(object sender, EventArgs e)
        {
            if (imageIndex < imageList.Count())
            {
                imageIndex++;
                displayImage(imageIndex);
            }
        }

        private void buttonLastImage_Click(object sender, EventArgs e)
        {
            imageIndex = imageList.Count()-1;
            displayImage(imageIndex);
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            displaySlideShowStatus(SlideshowStatus.RUNNING);

            slideshowRunning = true;
            slideshowPaused = false;

            imageIndex = 0;
            enableDisableControls();
            createTimer();
        }

        private void buttonPause_Click(object sender, EventArgs e)
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

        private void buttonStop_Click(object sender, EventArgs e)
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

        private void trackBarSpeed_ValueChanged(object sender, EventArgs e)
        {
            setInterval();
        }

        private void checkBoxLoop_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLoop.Checked)
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
            ArrayList listOfImages = new ArrayList();

            // Get list of files on disk
            OricFileInfo[] fileList = diskInfo.GetFiles();

            foreach (OricFileInfo fileInfo in fileList)
            {
                if (fileInfo.Format == OricProgram.ProgramFormat.HiresScreen ||
                    fileInfo.Format == OricProgram.ProgramFormat.TextScreen ||
                    fileInfo.Format == OricProgram.ProgramFormat.HelpFile)
                {
                    listOfImages.Add(fileInfo);
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

                IntervalTimer.Tick += new EventHandler(Timer_Tick);
            }
        }

        private void Timer_Tick(object sender, System.EventArgs e)
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

        private void setInterval()
        {
            float interval = (float)(trackBarSpeed.Value) / 2;
            imageInterval = (int)(interval * 1000);

            if (slideshowRunning)
            {
                createTimer();
            }

            labelSpeed.Text = String.Format("{0:N1} seconds", (float)(imageInterval) / 1000);
        }

        private void displayImage(int imageIndex)
        {
            OricProgram oricProgram = imageList[imageIndex].LoadFile();

            oricScreenImage.m_ui16StartAddress = oricProgram.StartAddress;
            oricScreenImage.m_ui16DataLength = oricProgram.ProgramLength;
            oricScreenImage.bScrnData = oricProgram.m_programData;

            if (oricProgram.Format == OricProgram.ProgramFormat.HiresScreen)
            {
                screenImageFormat = ScreenImage.ScreenImageFormat.IMAGE_FORMAT_HIRES;
            }
            else if (oricProgram.Format == OricProgram.ProgramFormat.TextScreen || oricProgram.Format == OricProgram.ProgramFormat.HelpFile)
            {
                screenImageFormat = ScreenImage.ScreenImageFormat.IMAGE_FORMAT_TEXT;
            }

            oricScreenImage.DrawScreenImage(ScreenImage.ScreenImageSize.IMAGE_SIZE_ENLARGED, screenImageFormat);
            pictureBoxScreenImage.Image = oricScreenImage.screenImageData;

            displayImageInfo(oricProgram);

            enableDisableControls();
        }

        private void enableDisableControls()
        {
            if (slideshowRunning)
            {
                buttonFirstImage.Enabled = false;
                buttonLastImage.Enabled = false;
                buttonPrevImage.Enabled = false;
                buttonNextImage.Enabled = false;
            }
            else
            {
                if (imageIndex > 0)
                {
                    buttonFirstImage.Enabled = true;
                    buttonPrevImage.Enabled = true;
                }
                else
                {
                    buttonFirstImage.Enabled = false;
                    buttonPrevImage.Enabled = false;
                }

                if (imageIndex < imageList.Count()-1)
                {
                    buttonLastImage.Enabled = true;
                    buttonNextImage.Enabled = true;
                }
                else
                {
                    buttonLastImage.Enabled = false;
                    buttonNextImage.Enabled = false;
                }
            }

            if (slideshowRunning)
            {
                buttonPlay.Enabled = false;
                buttonPause.Enabled = true;
                buttonStop.Enabled = true;
                checkBoxLoop.Enabled = true;
            }
            else
            {
                buttonPlay.Enabled = true;
                buttonPause.Enabled = false;
                buttonStop.Enabled = false;
                checkBoxLoop.Enabled = true;
            }
        }

        #region Info Display Functions
        private void displayImageCount()
        {
            int hiresCount = 0;
            int textCount = 0;

            foreach (OricFileInfo fileInfo in imageList)
            {
                if (fileInfo.Format == OricProgram.ProgramFormat.HiresScreen)
                {
                    hiresCount++;
                }
                else if (fileInfo.Format == OricProgram.ProgramFormat.TextScreen)
                {
                    textCount++;
                }
                else if (fileInfo.Format == OricProgram.ProgramFormat.HelpFile)
                {
                    textCount++;
                }
            }

            if (hiresCount == 1)
            {
                labelHiresCount.Text = "1 HIRES Image";
            }
            else
            {
                labelHiresCount.Text = String.Format("{0} HIRES Images", hiresCount);
            }

            if (textCount == 1)
            {
                labelTextCount.Text = "1 TEXT Image";
            }
            else
            {
                labelTextCount.Text = String.Format("{0} TEXT Images", textCount);
            }
        }

        private void displayImageInfo(OricProgram oricProgram)
        {
            labelImageCount.Text = String.Format("{0} of {1}", imageIndex+1, imageList.Count());

            Text = String.Format("Image Viewer - {0}", oricProgram.ProgramName);

            labelFilename.Text = oricProgram.ProgramName;

            if (oricProgram.Format == OricProgram.ProgramFormat.HiresScreen)
            {
                labelFormat.Text = "HIRES Screen";
            }
            else if (oricProgram.Format == OricProgram.ProgramFormat.TextScreen)
            {
                labelFormat.Text = "TEXT Screen";
            }
            else if (oricProgram.Format == OricProgram.ProgramFormat.HelpFile)
            {
                labelFormat.Text = "TEXT Screen";
            }
            else
            {
                labelFormat.Text = "Unknown";
            }

            labelStartAddress.Text = String.Format("{0}", oricProgram.StartAddress);
            labelEndAddress.Text = String.Format("{0}", oricProgram.EndAddress);

            labelStartAddressHex.Text = String.Format("${0:X4}", oricProgram.StartAddress);
            labelEndAddressHex.Text = String.Format("${0:X4}", oricProgram.EndAddress);

            labelLength.Text = String.Format("{0:N0} bytes ({1:N1} KB)", oricProgram.ProgramLength, (float)oricProgram.ProgramLength/1024);

            labelRowCount.Text = String.Format("{0:N0} Rows", (float)(oricProgram.ProgramLength / 40));
        }

        private void displaySlideShowStatus(SlideshowStatus slideShowStatus)
        {
            switch (slideShowStatus)
            {
                case SlideshowStatus.STOPPED:
                    labelSlideshowStatus.Text = "Stopped";
                    labelSlideshowStatus.ForeColor = Color.Red;
                    break;

                case SlideshowStatus.PAUSED:
                    labelSlideshowStatus.Text = "Paused...";
                    labelSlideshowStatus.ForeColor = Color.Blue;
                    break;

                case SlideshowStatus.RUNNING:
                    labelSlideshowStatus.Text = "Running";

                    if (slideshowLoop)
                    {
                        labelSlideshowStatus.Text += " (Loop)";
                    }

                    labelSlideshowStatus.ForeColor = Color.Green;
                    break;

                default:
                    break;
            }
        }
        #endregion
    }
}
