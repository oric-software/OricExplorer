namespace OricExplorer.User_Controls
{
    using Be.Windows.Forms;
    using FastColoredTextBoxNS;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using WeifenLuo.WinFormsUI.Docking;
    using static OricExplorer.ConstantsAndEnums;

    public partial class frmMainView : DockContent
    {

        // Text styles for Assembler Listings
        private TextStyle assemblerAddressStyle;
        private TextStyle assemblerHexStyle;
        private TextStyle assemblerMnemonicStyle;
        private TextStyle assemblerOperandStyle;
        private TextStyle assemblerAsciiStyle;
        private TextStyle assemblerUnknownStyle;

        
        // Text styles for BASIC Listing
        private TextStyle basicLineNumberStyle;
        private TextStyle basicKeywordStyle;
        private TextStyle basicBranchesStyle;
        private TextStyle basicLoopsStyle;
        private TextStyle basicStringStyle;
        private TextStyle basicNumberStyle;
        private TextStyle basicDataKeywordStyle;
        private TextStyle basicCommentStyle;

        // Text styles for HYPERBASIC Listing
        private TextStyle hyperbasicAddressStyle;
        private TextStyle hyperbasicLabelStyle;
        private TextStyle hyperbasicNumberStyle;
        private TextStyle hyperbasicStringStyle;
        private TextStyle hyperbasicLoopsStyle;
        private TextStyle hyperbasicBranchesStyle;
        private TextStyle hyperbasicCodeStyle;
        private TextStyle hyperbasicCommentStyle;

        // Text styles for TELEASS Listing
        private TextStyle teleassAddressStyle;
        private TextStyle teleassLabelStyle;
        private TextStyle teleassMnemonicStyle;
        private TextStyle teleassOperandStyle;
        private TextStyle teleassCommentStyle;


        //MarkerStyle SameWordsStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(40, Color.Gray)));

        public UserControls UserControl { get; set; }
        public OricProgram ProgramData { get; set; }
        public OricFileInfo ProgramInfo { get; set; }
        public bool ShowSourceCode { get; set; } = false;

        private ctlDataViewerControl dataViewer;
        private ctlScreenViewerControl screenViewer;
        private ctlDataFileViewer dataFileViewer;
        private ctlCharacterSetViewerControl characterSetViewer;
        private ctlSequentialFileViewer sequentialFileViewer;
        private frmMainForm mMainForm;

        public frmMainView(frmMainForm mainForm)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            this.mMainForm = mainForm;

            Dictionary<SyntaxHighlightingItems, TextStyle> syntaxHighlightingStyles = Configuration.Persistent.SyntaxHighlightingStyles;

            hxbDump.BackColor = Configuration.Persistent.PageBackground;
            hxbDump.InfoForeColor = ((SolidBrush)syntaxHighlightingStyles[SyntaxHighlightingItems.DumpHeadersStyle].ForeBrush).Color;
            hxbDump.ForeColor = ((SolidBrush)syntaxHighlightingStyles[SyntaxHighlightingItems.DumpHexStyle].ForeBrush).Color;
            hxbDump.StringViewColour = ((SolidBrush)syntaxHighlightingStyles[SyntaxHighlightingItems.DumpAsciiStyle].ForeBrush).Color;
            hxbDump.SelectionBackColor = ((SolidBrush)syntaxHighlightingStyles[SyntaxHighlightingItems.DumpMainSelectionBackStyle].ForeBrush).Color;
            hxbDump.SelectionForeColor = ((SolidBrush)syntaxHighlightingStyles[SyntaxHighlightingItems.DumpMainSelectionFrontStyle].ForeBrush).Color;
            hxbDump.ShadowSelectionColor = ((SolidBrush)syntaxHighlightingStyles[SyntaxHighlightingItems.DumpSecondarySelectionBackStyle].ForeBrush).Color;
            hxbDump.ShadowSelectionColor = Color.FromArgb(100, hxbDump.ShadowSelectionColor.R, hxbDump.ShadowSelectionColor.G, hxbDump.ShadowSelectionColor.B);

            assemblerAddressStyle = syntaxHighlightingStyles[SyntaxHighlightingItems.AssemblerAddressStyle];
            assemblerHexStyle = syntaxHighlightingStyles[SyntaxHighlightingItems.AssemblerHexStyle];
            assemblerMnemonicStyle = syntaxHighlightingStyles[SyntaxHighlightingItems.AssemblerMnemonicStyle];
            assemblerOperandStyle = syntaxHighlightingStyles[SyntaxHighlightingItems.AssemblerOperandStyle];
            assemblerAsciiStyle = syntaxHighlightingStyles[SyntaxHighlightingItems.AssemblerAsciiStyle];
            assemblerUnknownStyle = syntaxHighlightingStyles[SyntaxHighlightingItems.AssemblerUnknownStyle];
            
            basicLineNumberStyle = syntaxHighlightingStyles[SyntaxHighlightingItems.BasicLineNumber];
            basicKeywordStyle = syntaxHighlightingStyles[SyntaxHighlightingItems.BasicKeyword];
            basicBranchesStyle = syntaxHighlightingStyles[SyntaxHighlightingItems.BasicBranches];
            basicLoopsStyle = syntaxHighlightingStyles[SyntaxHighlightingItems.BasicLoops];
            basicStringStyle = syntaxHighlightingStyles[SyntaxHighlightingItems.BasicString];
            basicNumberStyle = syntaxHighlightingStyles[SyntaxHighlightingItems.BasicNumber];
            basicDataKeywordStyle = syntaxHighlightingStyles[SyntaxHighlightingItems.BasicDataKeyword];
            basicCommentStyle = syntaxHighlightingStyles[SyntaxHighlightingItems.BasicComment];

            hyperbasicAddressStyle = syntaxHighlightingStyles[SyntaxHighlightingItems.HyperbasicAddressStyle];
            hyperbasicLabelStyle = syntaxHighlightingStyles[SyntaxHighlightingItems.HyperbasicLabelStyle];
            hyperbasicNumberStyle = syntaxHighlightingStyles[SyntaxHighlightingItems.HyperbasicNumberStyle];
            hyperbasicStringStyle = syntaxHighlightingStyles[SyntaxHighlightingItems.HyperbasicStringStyle];
            hyperbasicLoopsStyle = syntaxHighlightingStyles[SyntaxHighlightingItems.HyperbasicLoopStyle];
            hyperbasicBranchesStyle = syntaxHighlightingStyles[SyntaxHighlightingItems.HyperbasicBrancheStyle];
            hyperbasicCodeStyle = syntaxHighlightingStyles[SyntaxHighlightingItems.HyperbasicCodeStyle];
            hyperbasicCommentStyle = syntaxHighlightingStyles[SyntaxHighlightingItems.HyperbasicCommentStyle];

            teleassAddressStyle = syntaxHighlightingStyles[SyntaxHighlightingItems.TeleassAddressStyle];
            teleassLabelStyle = syntaxHighlightingStyles[SyntaxHighlightingItems.TeleassLabelStyle];
            teleassMnemonicStyle = syntaxHighlightingStyles[SyntaxHighlightingItems.TeleassMnemonicStyle];
            teleassOperandStyle = syntaxHighlightingStyles[SyntaxHighlightingItems.TeleassOperandStyle];
            teleassCommentStyle = syntaxHighlightingStyles[SyntaxHighlightingItems.TeleassCommentStyle];

            fctSourceCode.BackColor = Configuration.Persistent.PageBackground;
        }

        public void InitialiseView()
        {
            if (ShowSourceCode)
            {
                if (!tabMainView.Contains(tabpSourceCode))
                {
                    tabMainView.AddTab(tabpSourceCode);
                }
            }
            else
            {
                if (tabMainView.Contains(tabpSourceCode))
                {
                    tabMainView.RemoveTab(tabpSourceCode);
                }
            }

            if (UserControl == UserControls.None)
            {
                // Remove Data view tab
                if (tabMainView.Contains(tabpDataViewer))
                {
                    tabMainView.RemoveTab(tabpDataViewer);
                }
            }
            else
            {
                if (!tabMainView.Contains(tabpDataViewer))
                {
                    //int tabCount = tabControlMainView.TabPages.Count;
                    tabMainView.AddTab(tabpDataViewer);
                }

                // Determine which control we are going to display

                if (UserControl != UserControls.DataViewer)
                {
                    if (dataViewer != null)
                    {
                        tabpDataViewer.Controls.Remove(dataViewer);
                        dataViewer = null;
                    }
                }

                if (UserControl != UserControls.ScreenViewer)
                {
                    if (screenViewer != null)
                    {
                        tabpDataViewer.Controls.Remove(screenViewer);
                        screenViewer = null;
                    }
                }

                if (UserControl != UserControls.CharacterSetViewer)
                {
                    if (characterSetViewer != null)
                    {
                        tabpDataViewer.Controls.Remove(characterSetViewer);
                        characterSetViewer = null;
                    }
                }

                if (UserControl != UserControls.DataFileViewer)
                {
                    if (dataFileViewer != null)
                    {
                        tabpDataViewer.Controls.Remove(dataFileViewer);
                        dataFileViewer = null;
                    }
                }

                if (UserControl != UserControls.SequentialFileViewer)
                {
                    if (sequentialFileViewer != null)
                    {
                        tabpDataViewer.Controls.Remove(sequentialFileViewer);
                        sequentialFileViewer = null;
                    }
                }

                switch (UserControl)
                {
                    case UserControls.DataViewer:
                        if (dataViewer == null)
                        {
                            dataViewer = new ctlDataViewerControl();
                            tabpDataViewer.Controls.Add(dataViewer);

                            // Rename the tab header
                            tabpDataViewer.Title = "Data Viewer";
                        }
                        break;

                    case UserControls.ScreenViewer:
                        if (screenViewer == null)
                        {
                            screenViewer = new ctlScreenViewerControl();
                            tabpDataViewer.Controls.Add(screenViewer);

                            // Rename the tab header
                            tabpDataViewer.Title = "Screen Viewer";
                        }
                        break;

                    case UserControls.CharacterSetViewer:
                        if (characterSetViewer == null)
                        {
                            characterSetViewer = new ctlCharacterSetViewerControl();
                            tabpDataViewer.Controls.Add(characterSetViewer);

                            // Rename the tab header
                            tabpDataViewer.Title = "Character Set Viewer";
                        }
                        break;

                    case UserControls.DataFileViewer:
                        if (dataFileViewer == null)
                        {
                            dataFileViewer = new ctlDataFileViewer();
                            tabpDataViewer.Controls.Add(dataFileViewer);

                            // Rename the tab header
                            tabpDataViewer.Title = "Data File Viewer";
                        }
                        break;

                    case UserControls.SequentialFileViewer:
                        if (sequentialFileViewer == null)
                        {
                            sequentialFileViewer = new ctlSequentialFileViewer();
                            tabpDataViewer.Controls.Add(sequentialFileViewer);

                            // Rename the tab header
                            tabpDataViewer.Title = "Sequential File Viewer";
                        }
                        break;

                    case UserControls.None:
                        break;

                    default:
                        break;
                }
            }
            
            Invalidate();
        }

        public void DisplayData(OricProgram.SpecialMode specialMode = OricProgram.SpecialMode.None)
        {
            DynamicByteProvider dynamicByteProvider;
            dynamicByteProvider = new DynamicByteProvider(ProgramData.ProgramData);

            hxbDump.ByteProvider = dynamicByteProvider;
            hxbDump.LineInfoOffset = ProgramInfo.StartAddress;
            hxbDump.ReadOnly = true;

            mMainForm.programInfoForm.DisplayProgramInformation(ProgramInfo);

            if (ShowSourceCode)
            {
                // Display the programs sourcecode
                if (ProgramInfo.Format == OricProgram.ProgramFormat.BinaryFile)
                {
                    fctSourceCode.Text = ProgramData.ListAssembler(specialMode);
                }
                else if (ProgramInfo.Format == OricProgram.ProgramFormat.BasicProgram)
                {
                    fctSourceCode.Text = ProgramData.ListBasicSourceAsText();
                }
                else if (ProgramInfo.Format == OricProgram.ProgramFormat.HyperbasicProgram)
                {
                    fctSourceCode.Text = ProgramData.ListHyperbasicSourceAsText();
                } 
                else if (ProgramInfo.Format == OricProgram.ProgramFormat.TeleassSource)
                {
                    fctSourceCode.Text = ProgramData.ListTeleassSourceAsText();
                }
                else if (ProgramInfo.Format == OricProgram.ProgramFormat.OrixProgram)
                {
                    fctSourceCode.Text = ProgramData.ListAssembler(specialMode);
                }
            }

            switch (UserControl)
            {
                case UserControls.CharacterSetViewer:
                    characterSetViewer.ProgramInfo = ProgramInfo;
                    characterSetViewer.ProgramData = ProgramData;
                    characterSetViewer.InitialiseView();
                    break;

                case UserControls.DataFileViewer:
                    dataFileViewer.ProgramInfo = ProgramInfo;
                    dataFileViewer.ProgramData = ProgramData;
                    dataFileViewer.InitialiseView();
                    break;

                case UserControls.DataViewer:
                    dataViewer.ProgramInfo = ProgramInfo;
                    dataViewer.ProgramData = ProgramData;
                    dataViewer.InitialiseView();
                    break;

                case UserControls.ScreenViewer:
                    screenViewer.ProgramInfo = ProgramInfo;
                    screenViewer.ProgramData = ProgramData;
                    screenViewer.InitialiseView();
                    break;

                case UserControls.SequentialFileViewer:
                    sequentialFileViewer.ProgramInfo = ProgramInfo;
                    sequentialFileViewer.ProgramData = ProgramData;
                    sequentialFileViewer.InitialiseView();
                    break;

                case UserControls.None:
                    break;

                default:
                    break;
            }
        }

        private void DisplayAssemblerListing(TextChangedEventArgs e)
        {
            // Clear style of changed range
            fctSourceCode.ClearStylesBuffer();

            // Address highlighting
            e.ChangedRange.SetStyle(assemblerAddressStyle, @"^\$[0-9A-F]{4}\s", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(assemblerUnknownStyle, @"[?]{3}", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(assemblerOperandStyle, @"#{0,1}\({0,1}\$([0-9A-F]){2,4}\){0,1}(,Y|,X){0,1}\){0,1}", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(assemblerMnemonicStyle, @"(ADC|AND|ASL A|ASL|BCC|BCS|BEQ|BMI|BNE|BPL|BVC|BVS|BIT|BRK|CLC|CLD|CLI|CLV|CMP|CPX|CPY|DEC|DEX|DEY|EOR|INC|INX|INY|JMP|JSR|LDA|LDX|LDY|LSR A|LSR|NOP|ORA|PHA|PHP|PLA|PLP|ROL A|ROL|ROR A|ROR|RTI|RTS|SBC|SEC|SED|SEI|STA|STX|STY|TAX|TAY|TSX|TXA|TXS|TYA)", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(assemblerHexStyle, @"[0-9A-F]{2}\s", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(assemblerAsciiStyle, @"\S", RegexOptions.Multiline);
        }

        private void DisplayBasicListing(TextChangedEventArgs e)
        {
            fctSourceCode.LeftBracket = '(';
            fctSourceCode.RightBracket = ')';
            fctSourceCode.LeftBracket2 = '\x0';
            fctSourceCode.RightBracket2 = '\x0';

            // Clear style of changed range
            fctSourceCode.ClearStylesBuffer();

            e.ChangedRange.SetStyle(basicDataKeywordStyle, @"(DATA.*)", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(basicStringStyle, @"""""|@""""|@"".*?""|(?<!@)(?<range>"".*?[^\\]"")");
            e.ChangedRange.SetStyle(basicCommentStyle, @"(REM.*|\s'.*)", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(basicLineNumberStyle, @"^[0-9]{1,5}", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(basicNumberStyle, @"\d+[\.]?\d*([eE]\-?\d+)?");
            e.ChangedRange.SetStyle(basicLoopsStyle, @"(REPEAT|UNTIL|FOR|NEXT)");
            e.ChangedRange.SetStyle(basicBranchesStyle, @"(GOSUB|GOTO|ON|RETURN)");
            e.ChangedRange.SetStyle(basicKeywordStyle, @"(POP|PULL|RESTORE|STEP|PING|EXPLODE|DEF|POKE|PRINT|CONT|LIST|CLEAR|GET|CALL|NEW|TAB|TO|FN|SPC|AUTO|ELSE|THEN|NOT|AND|OR|SGN|INT|ABS|USR|FRE|POS|HEX\$|SQR|RND|LN|EXP|COS|SIN|TAN|ATN|PEEK|DEEK|LOG|LEN|STR\$|VAL|ASC|CHR\$|PI|TRUE|FALSE|KEY\$|SCRN|POINT|LEFT\$|RIGHT\$|MID\$|END|EDIT|STORE|RECALL|TRON|TROFF|PLOT|LORES|DOKE|LLIST|LPRINT|INPUT|DIM|CLS|READ|LET|RUN|IF|HIMEM|GRAB|RELEASE|TEXT|HIRES|SHOOT|ZAP|SOUND|MUSIC|PLAY|CURSET|CURMOV|DRAW|CIRCLE|PATTERN|FILL|CHAR|PAPER|INK|STOP|ON|WAIT|CLOAD|CSAVE)");
        }

        private void DisplayHyperbasicListing(TextChangedEventArgs e)
        {
            fctSourceCode.LeftBracket = '(';
            fctSourceCode.RightBracket = ')';
            fctSourceCode.LeftBracket2 = '\x0';
            fctSourceCode.RightBracket2 = '\x0';

            // Clear style of changed range
            fctSourceCode.ClearStylesBuffer();

            e.ChangedRange.SetStyle(hyperbasicAddressStyle, @"^[ 0-9]{6} ", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(hyperbasicCommentStyle, @"(REM|'\s).*$", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(hyperbasicLabelStyle, @"\]\w*", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(hyperbasicNumberStyle, @"#(([0-9A-Fa-f]){1,4})|(\d+[\.]?\d*([eE]\-?\d+)?)");
            e.ChangedRange.SetStyle(hyperbasicStringStyle, @"""""|@""""|@"".*?""|(?<!@)(?<range>"".*?[^\\]"")");
            e.ChangedRange.SetStyle(hyperbasicLoopsStyle, @"(REPEAT|UNTIL|FOR|TO|NEXT|STEP|WHILE|WEND|COUNT|UNCOUNT)");
            e.ChangedRange.SetStyle(hyperbasicBranchesStyle, @"(GOSUB|GOTO|ON|RETURN)");
            e.ChangedRange.SetStyle(hyperbasicCodeStyle, @"\S", RegexOptions.Multiline);
        }

        private void DisplayTeleassListing(TextChangedEventArgs e)
        {
            // Clear style of changed range
            fctSourceCode.ClearStylesBuffer();

            e.ChangedRange.SetStyle(teleassAddressStyle, @"^[ 0-9]{6} ", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(teleassLabelStyle, @"^((.){6}) [^'].{0,6}", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(teleassMnemonicStyle, @"^((.){6}) [^'].{0,9}", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(teleassCommentStyle, @"\'.*$", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(teleassOperandStyle, @"\S", RegexOptions.Multiline);
        }

        private void fctSourceCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ProgramInfo != null)
            {
                switch (ProgramInfo.Format)
                {
                    case OricProgram.ProgramFormat.BinaryFile:
                    case OricProgram.ProgramFormat.OrixProgram:
                        DisplayAssemblerListing(e);
                        break;

                    case OricProgram.ProgramFormat.BasicProgram:
                        DisplayBasicListing(e);
                        break;

                    case OricProgram.ProgramFormat.HyperbasicProgram:
                        DisplayHyperbasicListing(e);
                        break;

                    case OricProgram.ProgramFormat.TeleassSource:
                        DisplayTeleassListing(e);
                        break;
                }
            }
        }
    }
}
