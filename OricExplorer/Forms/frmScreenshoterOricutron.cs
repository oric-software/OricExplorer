namespace OricExplorer.Forms
{
    using OricExplorer.Class;
    using OricExplorer.User_Controls;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using System.Media;
    using System.Reflection;
    using System.Threading;
    using System.Windows.Forms;
    using static OricExplorer.ConstantsAndEnums;

    public partial class frmScreenshoterOricutron : Form
    {
        private Process mprocOricutron = null;

        public frmScreenshoterOricutron(frmMainForm mainForm)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(mainForm.Left + (mainForm.Width - this.Width) / 2, mainForm.Top + (mainForm.Height - this.Height) / 2);

            foreach(var v in Enum.GetValues(typeof(ConstantsAndEnums.CaptureFormat)))
            {
                cboFormat.Items.Add(v);
            }

            nudCaptureInterval.Value = Configuration.Persistent.ScreenshoterForOricutron.CaptureInterval;
            chkIgnoreIfSameAsPrevious.Checked = Configuration.Persistent.ScreenshoterForOricutron.IgnoreIfSameAsPrevious;
            if (Configuration.Persistent.ScreenshoterForOricutron.Format.ToString().In(Enum.GetNames(typeof(CaptureFormat))))
            {
                cboFormat.SelectedItem = Configuration.Persistent.ScreenshoterForOricutron.Format;
            }
            else
            {
                cboFormat.SelectedItem = CaptureFormat.Png;
            }
            txtNamePrefix.Text = Configuration.Persistent.ScreenshoterForOricutron.NamePrefix;
            nudFrameDelay.Value = Configuration.Persistent.ScreenshoterForOricutron.AnimatedGifFrameDelay;
            if (Configuration.Persistent.ScreenshoterForOricutron.AnimatedGifRepeat < 1)
            {
                cboRepeat.SelectedIndex = Configuration.Persistent.ScreenshoterForOricutron.AnimatedGifRepeat + 1;
            }
            else
            {
                cboRepeat.Text = Configuration.Persistent.ScreenshoterForOricutron.AnimatedGifRepeat.ToString();
            }

            UpdateButtonsState();

            bwOricutronMonitoring.RunWorkerAsync();
        }

        private void frmScreenshoterOricutron_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmrAutomaticCapture.Stop();

            Configuration.Persistent.ScreenshoterForOricutron.CaptureInterval = (int)nudCaptureInterval.Value;
            Configuration.Persistent.ScreenshoterForOricutron.IgnoreIfSameAsPrevious = chkIgnoreIfSameAsPrevious.Checked;
            Configuration.Persistent.ScreenshoterForOricutron.Format = (CaptureFormat)cboFormat.SelectedItem;
            Configuration.Persistent.ScreenshoterForOricutron.NamePrefix = txtNamePrefix.Text;
            Configuration.Persistent.ScreenshoterForOricutron.AnimatedGifFrameDelay = (int)nudFrameDelay.Value;
            Configuration.Persistent.ScreenshoterForOricutron.AnimatedGifRepeat = (cboRepeat.SelectedIndex == -1 ? int.Parse(cboRepeat.Text) : cboRepeat.SelectedIndex - 1);
            Configuration.Persistent.Save();

            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Hide();
                e.Cancel = true;
            }
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            IntPtr iptrHandle = mprocOricutron.MainWindowHandle;

            if (iptrHandle != IntPtr.Zero)
            {
                try
                {
                    NativeMethods.Rect rect = new NativeMethods.Rect();
                    var r = NativeMethods.GetWindowRect(iptrHandle, ref rect);

                    Rectangle rec = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);

                    if (rec.Height < 50)
                    {
                        tmrAutomaticCapture.Stop();

                        MessageBox.Show("The Oricutron window seems reduced, capturing its content is impossible.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }

                    using (Bitmap bmp = new Bitmap(rec.Width, rec.Height))
                    {
                        using (Graphics gra = Graphics.FromImage(bmp))
                        {
                            IntPtr iptrHdc = gra.GetHdc();
                            bool boolOK = NativeMethods.PrintWindow(iptrHandle, iptrHdc, 0);
                            gra.ReleaseHdc(iptrHdc);

                            if (!boolOK)
                            {
                                gra.FillRectangle(new SolidBrush(Color.Gray), new Rectangle(Point.Empty, bmp.Size));
                            }

                            IntPtr iptrRegion = NativeMethods.CreateRectRgn(0, 0, 0, 0);
                            NativeMethods.GetWindowRgn(iptrHandle, iptrRegion);
                            Region region = Region.FromHrgn(iptrRegion);

                            if (!region.IsEmpty(gra))
                            {
                                gra.ExcludeClip(region);
                                gra.Clear(Color.Transparent);
                            }
                        }
                        

                        Rectangle recOffset = new Rectangle(80 + 3, SystemInformation.CaptionHeight + 3 + 14, 480, 448);
                        Image img;
                        using (Bitmap bmpRetaillé = bmp.Clone(recOffset, PixelFormat.DontCare))
                        {
                            img = new Bitmap(bmpRetaillé, new Size(bmpRetaillé.Width / 2, bmpRetaillé.Height / 2));

                            if (sender == null && chkIgnoreIfSameAsPrevious.Checked && flpCaptures.Controls.Count > 0)
                            {
                                Image imgPrécédente = flpCaptures.Controls.OfType<ctlCaptureViewer>().Last().Image;

                                if (img.Same(imgPrécédente))
                                {
                                    return;
                                }
                            }
                        }


                        DateTime dtNow = DateTime.Now;
                        string strNom = dtNow.ToString(@"yyyy-MM-dd-HHmmssff");
                        img.Tag = strNom;

                        ctlCaptureViewer cap = new ctlCaptureViewer(img, strNom);
                        cap.CheckChanged += (object s, EventArgs e2) => { UpdateButtonsState(); };

                        flpCaptures.Controls.Add(cap);
                        flpCaptures.ScrollControlIntoView(cap);


                        UpdateButtonsState();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    SystemSounds.Exclamation.Play();
                } catch { }
            }
        }
        
        private void btnStartStopAutomaticCapture_Click(object sender, EventArgs e)
        {
            if (!tmrAutomaticCapture.Enabled)
            {
                tmrAutomaticCapture.Interval = (int)nudCaptureInterval.Value;
                tmrAutomaticCapture.Start();
                tmrAutomaticCapture_Tick(null, null);
            }
            else
            {
                tmrAutomaticCapture.Stop();
            }

            UpdateCaptureButtonsState();
        }
        private void tmrAutomaticCapture_Tick(object sender, EventArgs e)
        {
            btnCapture_Click(null, null);
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            flpCaptures.Controls.OfType<ctlCaptureViewer>().ToList().ForEach(x => x.Checked = true);

            UpdateButtonsState();
        }
        private void btnUnselectAll_Click(object sender, EventArgs e)
        {
            flpCaptures.Controls.OfType<ctlCaptureViewer>().ToList().ForEach(x => x.Checked = false);

            UpdateButtonsState();
        }

        private void btnRemoveSelection_Click(object sender, EventArgs e)
        {
            flpCaptures.SuspendLayout();

            var lstCapturesToRemove = flpCaptures.Controls.OfType<ctlCaptureViewer>().Where(w => w.Checked).ToList();

            for (int i = lstCapturesToRemove.Count - 1; i > -1; i--)
            {
                flpCaptures.Controls.Remove(lstCapturesToRemove[i]);
            }

            flpCaptures.ResumeLayout();

            UpdateButtonsState();
        }

        private void cboCaptureFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblFrameDelay.Enabled = nudFrameDelay.Enabled = lblFrameDelayMs.Enabled = lblRepeat.Enabled = cboRepeat.Enabled = ((CaptureFormat)cboFormat.SelectedItem == CaptureFormat.AnimatedGif);
        }
        private void txtNamePrefix_Validating(object sender, CancelEventArgs e)
        {
            if (txtNamePrefix.Text.ToCharArray().Any(w => w.In(Path.GetInvalidFileNameChars())))
            {
                MessageBox.Show($"These characters are not allowed: {string.Join(", ", Path.GetInvalidFileNameChars().Where(w => !Char.IsControl(w)))}", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
        }
        private void cboRepeat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRepeat.SelectedIndex == 2)
            {
                this.BeginInvoke(new Action(() => { cboRepeat.ResetText(); }));
            }
        }
        private void cboRepeat_Validating(object sender, CancelEventArgs e)
        {
            if (cboRepeat.Text.Length == 0)
            {
                cboRepeat.SelectedIndex = 0;
            }

            if (!(cboRepeat.Text.In(cboRepeat.Items[0], cboRepeat.Items[1]) || (int.TryParse(cboRepeat.Text, out int intRepeat) && intRepeat > 0)))
            {
                e.Cancel = true;
                MessageBox.Show("Incorrect value.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnSaveSelection_Click(object sender, EventArgs e)
        {
            if (!CheckFolder()) return;

            CaptureFormat captureFormat = (CaptureFormat)cboFormat.SelectedItem;
            int intNbSavedCaptures = 0;

            if (captureFormat == CaptureFormat.AnimatedGif)
            {
                try
                { 
                    string strFilename = $@"{Configuration.Persistent.ScreenshoterForOricutron.Folder}\{txtNamePrefix.Text}{flpCaptures.Controls.OfType<ctlCaptureViewer>().First(w => w.Checked).Image.Tag}.gif";

                    using (var outputStream = File.OpenWrite(strFilename))
                    {
                        int intRepeat = (cboRepeat.SelectedIndex == -1 ? int.Parse(cboRepeat.Text) : cboRepeat.SelectedIndex - 1);

                        using (var encoder = new GifWriter(outputStream, (int)nudFrameDelay.Value, intRepeat))
                        {
                            foreach (Image img in flpCaptures.Controls.OfType<ctlCaptureViewer>().Where(w => w.Checked).Select(s => s.Image).ToList())
                            {
                                encoder.WriteFrame(img);
                                intNbSavedCaptures++;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // ImageFormat not being an Enum, we have to do a little hack to determine it according to CaptureFormat without having to go through a switch
                ImageFormat imageFormat = (ImageFormat)typeof(ImageFormat).GetProperty(captureFormat.ToString(), BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase).GetValue(null);

                foreach (Image img in flpCaptures.Controls.OfType<ctlCaptureViewer>().Where(w => w.Checked).Select(s => s.Image).ToList())
                {
                    try
                    {
                        img.Save($@"{Configuration.Persistent.ScreenshoterForOricutron.Folder}\{txtNamePrefix.Text}{img.Tag}.{imageFormat.ToString().ToLower()}", imageFormat);
                        intNbSavedCaptures++;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (intNbSavedCaptures > 0)
            {
                MessageBox.Show($"Saved captures: {intNbSavedCaptures}", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void tsslScreenshotsFolder_Click(object sender, EventArgs e)
        {
            if (CheckFolder())
            {
                Process.Start(Configuration.Persistent.ScreenshoterForOricutron.Folder);
            }
        }

        private void bwSurveillanceFenêtre_DoWork(object sender, DoWorkEventArgs e)
        {
            while (bwOricutronMonitoring.IsBusy)
            {
                Process p = Process.GetProcesses().Where(w => w.ProcessName.ToLower().Equals("oricutron")).FirstOrDefault();

                bwOricutronMonitoring.ReportProgress(0, p);

                Thread.Sleep(300);
            }
        }
        private void bwSurveillanceFenêtre_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            mprocOricutron = e.UserState as Process;

            UpdateCaptureButtonsState();
        }

        private void UpdateButtonsState()
        {
            int intCaptures = flpCaptures.Controls.Count;
            int intSelection = flpCaptures.Controls.OfType<ctlCaptureViewer>().ToList().Count(x => x.Checked);

            tsslNumberOfCapturesNb.Text = intCaptures.ToString();
            tsslSelectionNb.Text = intSelection.ToString();

            btnSelectAll.Enabled = intSelection < intCaptures;
            btnUnselectAll.Enabled = btnRemoveSelection.Enabled = btnSaveSelection.Enabled = intSelection > 0;
        }
        private void UpdateCaptureButtonsState()
        {
            if (mprocOricutron == null && tmrAutomaticCapture.Enabled)
            {
                tmrAutomaticCapture.Stop();
            }

            btnCapture.Enabled = btnStartStopAutomaticCapture.Enabled = mprocOricutron != null;
            
            btnStartStopAutomaticCapture.Text = tmrAutomaticCapture.Enabled ? "Stop" : "Start";
        }
        private bool CheckFolder()
        {
            if (!Directory.Exists(Configuration.Persistent.ScreenshoterForOricutron.Folder))
            {
                try
                {
                    Directory.CreateDirectory(Configuration.Persistent.ScreenshoterForOricutron.Folder);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }
    }

    /// <summary>
    /// Creates a GIF using .Net GIF encoding and additional animation headers.
    /// </summary>
    public class GifWriter : IDisposable
    {
        #region Fields
        const long SourceGlobalColorInfoPosition = 10,
            SourceImageBlockPosition = 789;

        readonly BinaryWriter _writer;
        bool _firstFrame = true;
        readonly object _syncLock = new object();
        #endregion

        /// <summary>
        /// Creates a new instance of GifWriter.
        /// </summary>
        /// <param name="OutStream">The <see cref="Stream"/> to output the Gif to.</param>
        /// <param name="DefaultFrameDelay">Default Delay between consecutive frames... FrameRate = 1000 / DefaultFrameDelay.</param>
        /// <param name="Repeat">No of times the Gif should repeat... -1 not to repeat, 0 to repeat indefinitely.</param>
        public GifWriter(Stream OutStream, int DefaultFrameDelay = 500, int Repeat = -1)
        {
            if (OutStream == null)
                throw new ArgumentNullException(nameof(OutStream));

            if (DefaultFrameDelay <= 0)
                throw new ArgumentOutOfRangeException(nameof(DefaultFrameDelay));

            if (Repeat < -1)
                throw new ArgumentOutOfRangeException(nameof(Repeat));

            _writer = new BinaryWriter(OutStream);
            this.DefaultFrameDelay = DefaultFrameDelay;
            this.Repeat = Repeat;
        }

        /// <summary>
        /// Creates a new instance of GifWriter.
        /// </summary>
        /// <param name="FileName">The path to the file to output the Gif to.</param>
        /// <param name="DefaultFrameDelay">Default Delay between consecutive frames... FrameRate = 1000 / DefaultFrameDelay.</param>
        /// <param name="Repeat">No of times the Gif should repeat... -1 not to repeat, 0 to repeat indefinitely.</param>
        public GifWriter(string FileName, int DefaultFrameDelay = 500, int Repeat = -1)
            : this(new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read), DefaultFrameDelay, Repeat) { }

        #region Properties
        /// <summary>
        /// Gets or Sets the Default Width of a Frame. Used when unspecified.
        /// </summary>
        public int DefaultWidth { get; set; }

        /// <summary>
        /// Gets or Sets the Default Height of a Frame. Used when unspecified.
        /// </summary>
        public int DefaultHeight { get; set; }

        /// <summary>
        /// Gets or Sets the Default Delay in Milliseconds.
        /// </summary>
        public int DefaultFrameDelay { get; set; }

        /// <summary>
        /// The Number of Times the Animation must repeat.
        /// -1 indicates no repeat. 0 indicates repeat indefinitely
        /// </summary>
        public int Repeat { get; }
        #endregion

        /// <summary>
        /// Adds a frame to this animation.
        /// </summary>
        /// <param name="Image">The image to add</param>
        /// <param name="Delay">Delay in Milliseconds between this and last frame... 0 = <see cref="DefaultFrameDelay"/></param>
        public void WriteFrame(Image Image, int Delay = 0)
        {
            lock (_syncLock)
                using (var gifStream = new MemoryStream())
                {
                    Image.Save(gifStream, ImageFormat.Gif);

                    // Steal the global color table info
                    if (_firstFrame)
                        InitHeader(gifStream, _writer, Image.Width, Image.Height);

                    WriteGraphicControlBlock(gifStream, _writer, Delay == 0 ? DefaultFrameDelay : Delay);
                    WriteImageBlock(gifStream, _writer, !_firstFrame, 0, 0, Image.Width, Image.Height);
                }

            if (_firstFrame)
                _firstFrame = false;
        }

        #region Write
        void InitHeader(Stream SourceGif, BinaryWriter Writer, int Width, int Height)
        {
            // File Header
            Writer.Write("GIF".ToCharArray()); // File type
            Writer.Write("89a".ToCharArray()); // File Version

            Writer.Write((short)(DefaultWidth == 0 ? Width : DefaultWidth)); // Initial Logical Width
            Writer.Write((short)(DefaultHeight == 0 ? Height : DefaultHeight)); // Initial Logical Height

            SourceGif.Position = SourceGlobalColorInfoPosition;
            Writer.Write((byte)SourceGif.ReadByte()); // Global Color Table Info
            Writer.Write((byte)0); // Background Color Index
            Writer.Write((byte)0); // Pixel aspect ratio
            WriteColorTable(SourceGif, Writer);

            // App Extension Header for Repeating
            if (Repeat == -1)
                return;

            Writer.Write(unchecked((short)0xff21)); // Application Extension Block Identifier
            Writer.Write((byte)0x0b); // Application Block Size
            Writer.Write("NETSCAPE2.0".ToCharArray()); // Application Identifier
            Writer.Write((byte)3); // Application block length
            Writer.Write((byte)1);
            Writer.Write((short)Repeat); // Repeat count for images.
            Writer.Write((byte)0); // terminator
        }

        static void WriteColorTable(Stream SourceGif, BinaryWriter Writer)
        {
            SourceGif.Position = 13; // Locating the image color table
            var colorTable = new byte[768];
            SourceGif.Read(colorTable, 0, colorTable.Length);
            Writer.Write(colorTable, 0, colorTable.Length);
        }

        static void WriteGraphicControlBlock(Stream SourceGif, BinaryWriter Writer, int FrameDelay)
        {
            SourceGif.Position = 781; // Locating the source GCE
            var blockhead = new byte[8];
            SourceGif.Read(blockhead, 0, blockhead.Length); // Reading source GCE

            Writer.Write(unchecked((short)0xf921)); // Identifier
            Writer.Write((byte)0x04); // Block Size
            Writer.Write((byte)(blockhead[3] & 0xf7 | 0x08)); // Setting disposal flag
            Writer.Write((short)(FrameDelay / 10)); // Setting frame delay
            Writer.Write(blockhead[6]); // Transparent color index
            Writer.Write((byte)0); // Terminator
        }

        static void WriteImageBlock(Stream SourceGif, BinaryWriter Writer, bool IncludeColorTable, int X, int Y, int Width, int Height)
        {
            SourceGif.Position = SourceImageBlockPosition; // Locating the image block
            var header = new byte[11];
            SourceGif.Read(header, 0, header.Length);
            Writer.Write(header[0]); // Separator
            Writer.Write((short)X); // Position X
            Writer.Write((short)Y); // Position Y
            Writer.Write((short)Width); // Width
            Writer.Write((short)Height); // Height

            if (IncludeColorTable) // If first frame, use global color table - else use local
            {
                SourceGif.Position = SourceGlobalColorInfoPosition;
                Writer.Write((byte)(SourceGif.ReadByte() & 0x3f | 0x80)); // Enabling local color table
                WriteColorTable(SourceGif, Writer);
            }
            else Writer.Write((byte)(header[9] & 0x07 | 0x07)); // Disabling local color table

            Writer.Write(header[10]); // LZW Min Code Size

            // Read/Write image data
            SourceGif.Position = SourceImageBlockPosition + header.Length;

            var dataLength = SourceGif.ReadByte();
            while (dataLength > 0)
            {
                var imgData = new byte[dataLength];
                SourceGif.Read(imgData, 0, dataLength);

                Writer.Write((byte)dataLength);
                Writer.Write(imgData, 0, dataLength);
                dataLength = SourceGif.ReadByte();
            }

            Writer.Write((byte)0); // Terminator
        }
        #endregion

        /// <summary>
        /// Frees all resources used by this object.
        /// </summary>
        public void Dispose()
        {
            // Complete File
            _writer.Write((byte)0x3b); // File Trailer

            _writer.BaseStream.Dispose();
            _writer.Dispose();
        }
    }
}
