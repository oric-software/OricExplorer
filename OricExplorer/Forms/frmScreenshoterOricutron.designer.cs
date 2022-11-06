namespace OricExplorer.Forms
{
    partial class frmScreenshoterOricutron
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tlp = new System.Windows.Forms.TableLayoutPanel();
            this.flpCaptures = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRemoveSelection = new System.Windows.Forms.Button();
            this.btnUnselectAll = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.grpAutomaticCapture = new System.Windows.Forms.GroupBox();
            this.tlpAutomaticCapture = new System.Windows.Forms.TableLayoutPanel();
            this.lblInterval = new System.Windows.Forms.Label();
            this.nudCaptureInterval = new System.Windows.Forms.NumericUpDown();
            this.chkIgnoreIfSameAsPrevious = new System.Windows.Forms.CheckBox();
            this.btnStartStopAutomaticCapture = new System.Windows.Forms.Button();
            this.lblIntervalMs = new System.Windows.Forms.Label();
            this.btnCapture = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpOutput = new System.Windows.Forms.GroupBox();
            this.tlpOutput = new System.Windows.Forms.TableLayoutPanel();
            this.lblFormat = new System.Windows.Forms.Label();
            this.nudFrameDelay = new System.Windows.Forms.NumericUpDown();
            this.btnSaveSelection = new System.Windows.Forms.Button();
            this.cboFormat = new System.Windows.Forms.ComboBox();
            this.lblPrefix = new System.Windows.Forms.Label();
            this.txtNamePrefix = new System.Windows.Forms.TextBox();
            this.lblFrameDelay = new System.Windows.Forms.Label();
            this.lblRepeat = new System.Windows.Forms.Label();
            this.lblFrameDelayMs = new System.Windows.Forms.Label();
            this.cboRepeat = new System.Windows.Forms.ComboBox();
            this.bwOricutronMonitoring = new System.ComponentModel.BackgroundWorker();
            this.tmrAutomaticCapture = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslScreenshotsFolder = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslNumberOfCaptures = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslNumberOfCapturesNb = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslSelection = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslSelectionNb = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlp.SuspendLayout();
            this.grpAutomaticCapture.SuspendLayout();
            this.tlpAutomaticCapture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaptureInterval)).BeginInit();
            this.grpOutput.SuspendLayout();
            this.tlpOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFrameDelay)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp
            // 
            this.tlp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlp.ColumnCount = 2;
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp.Controls.Add(this.flpCaptures, 0, 0);
            this.tlp.Controls.Add(this.btnRemoveSelection, 1, 8);
            this.tlp.Controls.Add(this.btnUnselectAll, 1, 6);
            this.tlp.Controls.Add(this.btnSelectAll, 1, 5);
            this.tlp.Controls.Add(this.grpAutomaticCapture, 1, 3);
            this.tlp.Controls.Add(this.btnCapture, 1, 1);
            this.tlp.Controls.Add(this.btnClose, 1, 13);
            this.tlp.Controls.Add(this.grpOutput, 1, 11);
            this.tlp.Location = new System.Drawing.Point(12, 12);
            this.tlp.Name = "tlp";
            this.tlp.RowCount = 14;
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp.Size = new System.Drawing.Size(960, 441);
            this.tlp.TabIndex = 0;
            // 
            // flpCaptures
            // 
            this.flpCaptures.AutoScroll = true;
            this.flpCaptures.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.flpCaptures.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flpCaptures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpCaptures.Location = new System.Drawing.Point(3, 3);
            this.flpCaptures.Name = "flpCaptures";
            this.tlp.SetRowSpan(this.flpCaptures, 14);
            this.flpCaptures.Size = new System.Drawing.Size(773, 435);
            this.flpCaptures.TabIndex = 6;
            // 
            // btnRemoveSelection
            // 
            this.btnRemoveSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveSelection.AutoSize = true;
            this.btnRemoveSelection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRemoveSelection.Location = new System.Drawing.Point(782, 213);
            this.btnRemoveSelection.Name = "btnRemoveSelection";
            this.btnRemoveSelection.Size = new System.Drawing.Size(175, 23);
            this.btnRemoveSelection.TabIndex = 4;
            this.btnRemoveSelection.Text = "Remove selected captures";
            this.btnRemoveSelection.UseVisualStyleBackColor = true;
            this.btnRemoveSelection.Click += new System.EventHandler(this.btnRemoveSelection_Click);
            // 
            // btnUnselectAll
            // 
            this.btnUnselectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnselectAll.AutoSize = true;
            this.btnUnselectAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUnselectAll.Location = new System.Drawing.Point(782, 179);
            this.btnUnselectAll.Name = "btnUnselectAll";
            this.btnUnselectAll.Size = new System.Drawing.Size(175, 23);
            this.btnUnselectAll.TabIndex = 3;
            this.btnUnselectAll.Text = "Unselect all";
            this.btnUnselectAll.UseVisualStyleBackColor = true;
            this.btnUnselectAll.Click += new System.EventHandler(this.btnUnselectAll_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectAll.AutoSize = true;
            this.btnSelectAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSelectAll.Location = new System.Drawing.Point(782, 150);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(175, 23);
            this.btnSelectAll.TabIndex = 2;
            this.btnSelectAll.Text = "Select all";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // grpAutomaticCapture
            // 
            this.grpAutomaticCapture.Controls.Add(this.tlpAutomaticCapture);
            this.grpAutomaticCapture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAutomaticCapture.Location = new System.Drawing.Point(782, 37);
            this.grpAutomaticCapture.Name = "grpAutomaticCapture";
            this.grpAutomaticCapture.Size = new System.Drawing.Size(175, 102);
            this.grpAutomaticCapture.TabIndex = 1;
            this.grpAutomaticCapture.TabStop = false;
            this.grpAutomaticCapture.Text = "Automatic capture";
            // 
            // tlpAutomaticCapture
            // 
            this.tlpAutomaticCapture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpAutomaticCapture.ColumnCount = 3;
            this.tlpAutomaticCapture.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpAutomaticCapture.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAutomaticCapture.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpAutomaticCapture.Controls.Add(this.lblInterval, 0, 0);
            this.tlpAutomaticCapture.Controls.Add(this.nudCaptureInterval, 1, 0);
            this.tlpAutomaticCapture.Controls.Add(this.chkIgnoreIfSameAsPrevious, 0, 1);
            this.tlpAutomaticCapture.Controls.Add(this.btnStartStopAutomaticCapture, 0, 2);
            this.tlpAutomaticCapture.Controls.Add(this.lblIntervalMs, 2, 0);
            this.tlpAutomaticCapture.Location = new System.Drawing.Point(6, 16);
            this.tlpAutomaticCapture.Name = "tlpAutomaticCapture";
            this.tlpAutomaticCapture.RowCount = 4;
            this.tlpAutomaticCapture.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpAutomaticCapture.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpAutomaticCapture.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpAutomaticCapture.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpAutomaticCapture.Size = new System.Drawing.Size(163, 80);
            this.tlpAutomaticCapture.TabIndex = 0;
            // 
            // lblInterval
            // 
            this.lblInterval.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblInterval.AutoSize = true;
            this.lblInterval.Location = new System.Drawing.Point(3, 6);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(42, 13);
            this.lblInterval.TabIndex = 0;
            this.lblInterval.Text = "Interval";
            // 
            // nudCaptureInterval
            // 
            this.nudCaptureInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudCaptureInterval.AutoSize = true;
            this.nudCaptureInterval.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudCaptureInterval.Location = new System.Drawing.Point(51, 3);
            this.nudCaptureInterval.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.nudCaptureInterval.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudCaptureInterval.Name = "nudCaptureInterval";
            this.nudCaptureInterval.Size = new System.Drawing.Size(83, 20);
            this.nudCaptureInterval.TabIndex = 1;
            this.nudCaptureInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudCaptureInterval.ThousandsSeparator = true;
            this.nudCaptureInterval.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // chkIgnoreIfSameAsPrevious
            // 
            this.chkIgnoreIfSameAsPrevious.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkIgnoreIfSameAsPrevious.AutoSize = true;
            this.chkIgnoreIfSameAsPrevious.Checked = true;
            this.chkIgnoreIfSameAsPrevious.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tlpAutomaticCapture.SetColumnSpan(this.chkIgnoreIfSameAsPrevious, 3);
            this.chkIgnoreIfSameAsPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIgnoreIfSameAsPrevious.Location = new System.Drawing.Point(7, 29);
            this.chkIgnoreIfSameAsPrevious.Name = "chkIgnoreIfSameAsPrevious";
            this.chkIgnoreIfSameAsPrevious.Size = new System.Drawing.Size(149, 17);
            this.chkIgnoreIfSameAsPrevious.TabIndex = 2;
            this.chkIgnoreIfSameAsPrevious.Text = "Ignore if same as previous";
            this.chkIgnoreIfSameAsPrevious.UseVisualStyleBackColor = true;
            // 
            // btnStartStopAutomaticCapture
            // 
            this.btnStartStopAutomaticCapture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpAutomaticCapture.SetColumnSpan(this.btnStartStopAutomaticCapture, 3);
            this.btnStartStopAutomaticCapture.Location = new System.Drawing.Point(3, 52);
            this.btnStartStopAutomaticCapture.Name = "btnStartStopAutomaticCapture";
            this.btnStartStopAutomaticCapture.Size = new System.Drawing.Size(157, 23);
            this.btnStartStopAutomaticCapture.TabIndex = 3;
            this.btnStartStopAutomaticCapture.Text = "Start";
            this.btnStartStopAutomaticCapture.UseVisualStyleBackColor = true;
            this.btnStartStopAutomaticCapture.Click += new System.EventHandler(this.btnStartStopAutomaticCapture_Click);
            // 
            // lblIntervalMs
            // 
            this.lblIntervalMs.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIntervalMs.AutoSize = true;
            this.lblIntervalMs.Location = new System.Drawing.Point(140, 6);
            this.lblIntervalMs.Name = "lblIntervalMs";
            this.lblIntervalMs.Size = new System.Drawing.Size(20, 13);
            this.lblIntervalMs.TabIndex = 0;
            this.lblIntervalMs.Text = "ms";
            // 
            // btnCapture
            // 
            this.btnCapture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCapture.AutoSize = true;
            this.btnCapture.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCapture.Location = new System.Drawing.Point(782, 3);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(175, 23);
            this.btnCapture.TabIndex = 0;
            this.btnCapture.Text = "Capture";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.AutoSize = true;
            this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(782, 414);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(175, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grpOutput
            // 
            this.grpOutput.Controls.Add(this.tlpOutput);
            this.grpOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOutput.Location = new System.Drawing.Point(782, 247);
            this.grpOutput.Name = "grpOutput";
            this.grpOutput.Size = new System.Drawing.Size(175, 161);
            this.grpOutput.TabIndex = 5;
            this.grpOutput.TabStop = false;
            this.grpOutput.Text = "Output";
            // 
            // tlpOutput
            // 
            this.tlpOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpOutput.ColumnCount = 3;
            this.tlpOutput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpOutput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpOutput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpOutput.Controls.Add(this.lblFormat, 0, 0);
            this.tlpOutput.Controls.Add(this.nudFrameDelay, 1, 2);
            this.tlpOutput.Controls.Add(this.btnSaveSelection, 0, 4);
            this.tlpOutput.Controls.Add(this.cboFormat, 1, 0);
            this.tlpOutput.Controls.Add(this.lblPrefix, 0, 1);
            this.tlpOutput.Controls.Add(this.txtNamePrefix, 1, 1);
            this.tlpOutput.Controls.Add(this.lblFrameDelay, 0, 2);
            this.tlpOutput.Controls.Add(this.lblRepeat, 0, 3);
            this.tlpOutput.Controls.Add(this.lblFrameDelayMs, 2, 2);
            this.tlpOutput.Controls.Add(this.cboRepeat, 1, 3);
            this.tlpOutput.Location = new System.Drawing.Point(6, 19);
            this.tlpOutput.Name = "tlpOutput";
            this.tlpOutput.RowCount = 6;
            this.tlpOutput.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpOutput.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpOutput.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpOutput.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpOutput.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpOutput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpOutput.Size = new System.Drawing.Size(163, 136);
            this.tlpOutput.TabIndex = 0;
            // 
            // lblFormat
            // 
            this.lblFormat.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblFormat.AutoSize = true;
            this.lblFormat.Location = new System.Drawing.Point(28, 7);
            this.lblFormat.Name = "lblFormat";
            this.lblFormat.Size = new System.Drawing.Size(39, 13);
            this.lblFormat.TabIndex = 0;
            this.lblFormat.Text = "Format";
            // 
            // nudFrameDelay
            // 
            this.nudFrameDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudFrameDelay.AutoSize = true;
            this.nudFrameDelay.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudFrameDelay.Location = new System.Drawing.Point(73, 56);
            this.nudFrameDelay.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.nudFrameDelay.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudFrameDelay.Name = "nudFrameDelay";
            this.nudFrameDelay.Size = new System.Drawing.Size(61, 20);
            this.nudFrameDelay.TabIndex = 1;
            this.nudFrameDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudFrameDelay.ThousandsSeparator = true;
            this.nudFrameDelay.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // btnSaveSelection
            // 
            this.btnSaveSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveSelection.AutoSize = true;
            this.btnSaveSelection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpOutput.SetColumnSpan(this.btnSaveSelection, 3);
            this.btnSaveSelection.Location = new System.Drawing.Point(3, 109);
            this.btnSaveSelection.Name = "btnSaveSelection";
            this.btnSaveSelection.Size = new System.Drawing.Size(157, 23);
            this.btnSaveSelection.TabIndex = 4;
            this.btnSaveSelection.Text = "Save selected captures";
            this.btnSaveSelection.UseVisualStyleBackColor = true;
            this.btnSaveSelection.Click += new System.EventHandler(this.btnSaveSelection_Click);
            // 
            // cboFormat
            // 
            this.cboFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpOutput.SetColumnSpan(this.cboFormat, 2);
            this.cboFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFormat.FormattingEnabled = true;
            this.cboFormat.Location = new System.Drawing.Point(73, 3);
            this.cboFormat.Name = "cboFormat";
            this.cboFormat.Size = new System.Drawing.Size(87, 21);
            this.cboFormat.TabIndex = 1;
            this.cboFormat.SelectedIndexChanged += new System.EventHandler(this.cboCaptureFormat_SelectedIndexChanged);
            // 
            // lblPrefix
            // 
            this.lblPrefix.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPrefix.AutoSize = true;
            this.lblPrefix.Location = new System.Drawing.Point(4, 33);
            this.lblPrefix.Name = "lblPrefix";
            this.lblPrefix.Size = new System.Drawing.Size(63, 13);
            this.lblPrefix.TabIndex = 2;
            this.lblPrefix.Text = "Name prefix";
            this.lblPrefix.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNamePrefix
            // 
            this.txtNamePrefix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpOutput.SetColumnSpan(this.txtNamePrefix, 2);
            this.txtNamePrefix.Location = new System.Drawing.Point(73, 30);
            this.txtNamePrefix.Name = "txtNamePrefix";
            this.txtNamePrefix.Size = new System.Drawing.Size(87, 20);
            this.txtNamePrefix.TabIndex = 3;
            this.txtNamePrefix.Validating += new System.ComponentModel.CancelEventHandler(this.txtNamePrefix_Validating);
            // 
            // lblFrameDelay
            // 
            this.lblFrameDelay.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblFrameDelay.AutoSize = true;
            this.lblFrameDelay.Location = new System.Drawing.Point(3, 59);
            this.lblFrameDelay.Name = "lblFrameDelay";
            this.lblFrameDelay.Size = new System.Drawing.Size(64, 13);
            this.lblFrameDelay.TabIndex = 2;
            this.lblFrameDelay.Text = "Frame delay";
            this.lblFrameDelay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRepeat
            // 
            this.lblRepeat.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblRepeat.AutoSize = true;
            this.lblRepeat.Location = new System.Drawing.Point(25, 86);
            this.lblRepeat.Name = "lblRepeat";
            this.lblRepeat.Size = new System.Drawing.Size(42, 13);
            this.lblRepeat.TabIndex = 2;
            this.lblRepeat.Text = "Repeat";
            // 
            // lblFrameDelayMs
            // 
            this.lblFrameDelayMs.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblFrameDelayMs.AutoSize = true;
            this.lblFrameDelayMs.Location = new System.Drawing.Point(140, 59);
            this.lblFrameDelayMs.Name = "lblFrameDelayMs";
            this.lblFrameDelayMs.Size = new System.Drawing.Size(20, 13);
            this.lblFrameDelayMs.TabIndex = 2;
            this.lblFrameDelayMs.Text = "ms";
            this.lblFrameDelayMs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboRepeat
            // 
            this.cboRepeat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpOutput.SetColumnSpan(this.cboRepeat, 2);
            this.cboRepeat.FormattingEnabled = true;
            this.cboRepeat.Items.AddRange(new object[] {
            "No",
            "Indefinitely",
            "< enter value >"});
            this.cboRepeat.Location = new System.Drawing.Point(73, 82);
            this.cboRepeat.Name = "cboRepeat";
            this.cboRepeat.Size = new System.Drawing.Size(87, 21);
            this.cboRepeat.TabIndex = 1;
            this.cboRepeat.SelectedIndexChanged += new System.EventHandler(this.cboRepeat_SelectedIndexChanged);
            this.cboRepeat.Validating += new System.ComponentModel.CancelEventHandler(this.cboRepeat_Validating);
            // 
            // bwOricutronMonitoring
            // 
            this.bwOricutronMonitoring.WorkerReportsProgress = true;
            this.bwOricutronMonitoring.WorkerSupportsCancellation = true;
            this.bwOricutronMonitoring.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwSurveillanceFenêtre_DoWork);
            this.bwOricutronMonitoring.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwSurveillanceFenêtre_ProgressChanged);
            // 
            // tmrAutomaticCapture
            // 
            this.tmrAutomaticCapture.Interval = 1000;
            this.tmrAutomaticCapture.Tick += new System.EventHandler(this.tmrAutomaticCapture_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslScreenshotsFolder,
            this.tsslNumberOfCaptures,
            this.tsslNumberOfCapturesNb,
            this.tsslSelection,
            this.tsslSelectionNb});
            this.statusStrip1.Location = new System.Drawing.Point(0, 457);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(984, 24);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslScreenshotsFolder
            // 
            this.tsslScreenshotsFolder.IsLink = true;
            this.tsslScreenshotsFolder.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.tsslScreenshotsFolder.Name = "tsslScreenshotsFolder";
            this.tsslScreenshotsFolder.Size = new System.Drawing.Size(104, 19);
            this.tsslScreenshotsFolder.Text = "Screenshots folder";
            this.tsslScreenshotsFolder.Click += new System.EventHandler(this.tsslScreenshotsFolder_Click);
            // 
            // tsslNumberOfCaptures
            // 
            this.tsslNumberOfCaptures.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tsslNumberOfCaptures.Margin = new System.Windows.Forms.Padding(20, 3, 0, 2);
            this.tsslNumberOfCaptures.Name = "tsslNumberOfCaptures";
            this.tsslNumberOfCaptures.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.tsslNumberOfCaptures.Size = new System.Drawing.Size(140, 19);
            this.tsslNumberOfCaptures.Text = "Number of captures:";
            // 
            // tsslNumberOfCapturesNb
            // 
            this.tsslNumberOfCapturesNb.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsslNumberOfCapturesNb.Name = "tsslNumberOfCapturesNb";
            this.tsslNumberOfCapturesNb.Size = new System.Drawing.Size(14, 19);
            this.tsslNumberOfCapturesNb.Text = "0";
            // 
            // tsslSelection
            // 
            this.tsslSelection.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tsslSelection.Margin = new System.Windows.Forms.Padding(20, 3, 0, 2);
            this.tsslSelection.Name = "tsslSelection";
            this.tsslSelection.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.tsslSelection.Size = new System.Drawing.Size(82, 19);
            this.tsslSelection.Text = "Selection:";
            // 
            // tsslSelectionNb
            // 
            this.tsslSelectionNb.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsslSelectionNb.Name = "tsslSelectionNb";
            this.tsslSelectionNb.Size = new System.Drawing.Size(14, 19);
            this.tsslSelectionNb.Text = "0";
            // 
            // frmScreenshoterOricutron
            // 
            this.AcceptButton = this.btnCapture;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(984, 481);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tlp);
            this.MinimumSize = new System.Drawing.Size(475, 520);
            this.Name = "frmScreenshoterOricutron";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Screenshoter for Oricutron";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmScreenshoterOricutron_FormClosing);
            this.tlp.ResumeLayout(false);
            this.tlp.PerformLayout();
            this.grpAutomaticCapture.ResumeLayout(false);
            this.tlpAutomaticCapture.ResumeLayout(false);
            this.tlpAutomaticCapture.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaptureInterval)).EndInit();
            this.grpOutput.ResumeLayout(false);
            this.tlpOutput.ResumeLayout(false);
            this.tlpOutput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFrameDelay)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp;
        private System.Windows.Forms.Button btnCapture;
        private System.ComponentModel.BackgroundWorker bwOricutronMonitoring;
        private System.Windows.Forms.FlowLayoutPanel flpCaptures;
        private System.Windows.Forms.Button btnSaveSelection;
        private System.Windows.Forms.Button btnRemoveSelection;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnUnselectAll;
        private System.Windows.Forms.GroupBox grpAutomaticCapture;
        private System.Windows.Forms.TableLayoutPanel tlpAutomaticCapture;
        private System.Windows.Forms.Label lblInterval;
        private System.Windows.Forms.NumericUpDown nudCaptureInterval;
        private System.Windows.Forms.Timer tmrAutomaticCapture;
        private System.Windows.Forms.CheckBox chkIgnoreIfSameAsPrevious;
        private System.Windows.Forms.Button btnStartStopAutomaticCapture;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grpOutput;
        private System.Windows.Forms.TableLayoutPanel tlpOutput;
        private System.Windows.Forms.Label lblFormat;
        private System.Windows.Forms.ComboBox cboFormat;
        private System.Windows.Forms.Label lblPrefix;
        private System.Windows.Forms.TextBox txtNamePrefix;
        private System.Windows.Forms.Label lblIntervalMs;
        private System.Windows.Forms.NumericUpDown nudFrameDelay;
        private System.Windows.Forms.Label lblFrameDelay;
        private System.Windows.Forms.Label lblRepeat;
        private System.Windows.Forms.Label lblFrameDelayMs;
        private System.Windows.Forms.ComboBox cboRepeat;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslScreenshotsFolder;
        private System.Windows.Forms.ToolStripStatusLabel tsslNumberOfCaptures;
        private System.Windows.Forms.ToolStripStatusLabel tsslNumberOfCapturesNb;
        private System.Windows.Forms.ToolStripStatusLabel tsslSelection;
        private System.Windows.Forms.ToolStripStatusLabel tsslSelectionNb;
    }
}

