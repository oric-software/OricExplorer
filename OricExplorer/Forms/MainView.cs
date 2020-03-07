namespace OricExplorer.User_Controls
{
    using Be.Windows.Forms;
    using FastColoredTextBoxNS;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using WeifenLuo.WinFormsUI.Docking;

    public partial class MainView : DockContent
    {
        // Text styles for BASIC Listing
        private TextStyle basicLineNumberStyle;
        private TextStyle basicKeywordStyle;
        private TextStyle basicBranchesStyle;
        private TextStyle basicLoopsStyle;
        private TextStyle basicStringStyle;
        private TextStyle basicHexNumberStyle;
        private TextStyle basicNumberStyle;
        private TextStyle basicDataKeywordStyle;
        private TextStyle basicCommentStyle;

        // Text styles for Assembler Listings
        private TextStyle assemblerAddressStyle;
        private TextStyle assemblerHexStyle;
        private TextStyle assemblerMnemonicStyle;
        private TextStyle assemblerOperandStyle;
        private TextStyle assemberAsciiStyle;
        private TextStyle assemblerUnknownStyle;

        //MarkerStyle SameWordsStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(40, Color.Gray)));

        public MainForm.UserControls userControl;

        public OricProgram programData;
        public OricFileInfo programInfo;

        private DataViewerControl dataViewer;
        private ScreenViewerControl screenViewer;
        private DataFileViewer dataFileViewer;
        private CharacterSetViewerControl characterSetViewer;
        private SequentialFileViewer sequentialFileViewer;

        public bool showSourceCode = false;

        private MainForm parentForm;

        public MainView(MainForm parentForm)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            this.parentForm = parentForm;

            Dictionary<ConstantsAndEnums.SyntaxHighlightingItems, TextStyle> syntaxHighlightingStyles = Configuration.Persistent.SyntaxHighlightingStyles;
            
            basicLineNumberStyle = syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicLineNumber];
            basicKeywordStyle = syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicKeyword];
            basicBranchesStyle = syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicBranches];
            basicLoopsStyle = syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicLoops];
            basicStringStyle = syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicString];
            basicHexNumberStyle = syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicHexNumber];
            basicNumberStyle = syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicNumber];
            basicDataKeywordStyle = syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicDataKeyword];
            basicCommentStyle = syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicComment];

            assemblerAddressStyle = syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerAddressStyle];
            assemblerHexStyle = syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerHexStyle];
            assemblerMnemonicStyle = syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerMnemonicStyle];
            assemblerOperandStyle = syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerOperandStyle];
            assemberAsciiStyle = syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerAsciiStyle];
            assemblerUnknownStyle = syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerUnknownStyle];

            hexBox1.BackColor = Configuration.Persistent.PageBackground;
            hexBox1.InfoForeColor = ((SolidBrush)syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpHeadersStyle].ForeBrush).Color;
            hexBox1.ForeColor = ((SolidBrush)syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpHexStyle].ForeBrush).Color;
            hexBox1.StringViewColour = ((SolidBrush)syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpAsciiStyle].ForeBrush).Color;
            hexBox1.SelectionBackColor = ((SolidBrush)syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpMainSelectionBackStyle].ForeBrush).Color;
            hexBox1.SelectionForeColor = ((SolidBrush)syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpMainSelectionFrontStyle].ForeBrush).Color;
            hexBox1.ShadowSelectionColor = ((SolidBrush)syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpSecondarySelectionBackStyle].ForeBrush).Color;
            hexBox1.ShadowSelectionColor = Color.FromArgb(100, hexBox1.ShadowSelectionColor.R, hexBox1.ShadowSelectionColor.G, hexBox1.ShadowSelectionColor.B);
        
            fastColoredTextBoxSourceCode.BackColor = Configuration.Persistent.PageBackground;
        }

        public void InitialiseView()
        {
            if (showSourceCode)
            {
                if (!tabControlMainView.Contains(tabPageSourceCodeView))
                {
                    tabControlMainView.AddTab(tabPageSourceCodeView);
                }
            }
            else
            {
                if (tabControlMainView.Contains(tabPageSourceCodeView))
                {
                    tabControlMainView.RemoveTab(tabPageSourceCodeView);
                }
            }

            if (userControl == MainForm.UserControls.None)
            {
                // Remove Data view tab
                if (tabControlMainView.Contains(tabPageDataView))
                {
                    tabControlMainView.RemoveTab(tabPageDataView);
                }
            }
            else
            {
                if (!tabControlMainView.Contains(tabPageDataView))
                {
                    //int tabCount = tabControlMainView.TabPages.Count;
                    tabControlMainView.AddTab(tabPageDataView);
                }

                // Determine which control we are going to display

                if (userControl != MainForm.UserControls.DataViewer)
                {
                    if (dataViewer != null)
                    {
                        tabPageDataView.Controls.Remove(dataViewer);
                        dataViewer = null;
                    }
                }

                if (userControl != MainForm.UserControls.ScreenViewer)
                {
                    if (screenViewer != null)
                    {
                        tabPageDataView.Controls.Remove(screenViewer);
                        screenViewer = null;
                    }
                }

                if (userControl != MainForm.UserControls.CharacterSetViewer)
                {
                    if (characterSetViewer != null)
                    {
                        tabPageDataView.Controls.Remove(characterSetViewer);
                        characterSetViewer = null;
                    }
                }

                if (userControl != MainForm.UserControls.DataFileViewer)
                {
                    if (dataFileViewer != null)
                    {
                        tabPageDataView.Controls.Remove(dataFileViewer);
                        dataFileViewer = null;
                    }
                }

                if (userControl != MainForm.UserControls.SequentialFileViewer)
                {
                    if (sequentialFileViewer != null)
                    {
                        tabPageDataView.Controls.Remove(sequentialFileViewer);
                        sequentialFileViewer = null;
                    }
                }

                switch (userControl)
                {
                    case MainForm.UserControls.DataViewer:
                        if (dataViewer == null)
                        {
                            dataViewer = new DataViewerControl();
                            tabPageDataView.Controls.Add(dataViewer);

                            // Rename the tab header
                            tabPageDataView.Title = "Data Viewer";
                        }
                        break;

                    case MainForm.UserControls.ScreenViewer:
                        if (screenViewer == null)
                        {
                            screenViewer = new ScreenViewerControl();
                            tabPageDataView.Controls.Add(screenViewer);

                            // Rename the tab header
                            tabPageDataView.Title = "Screen Viewer";
                        }
                        break;

                    case MainForm.UserControls.CharacterSetViewer:
                        if (characterSetViewer == null)
                        {
                            characterSetViewer = new CharacterSetViewerControl();
                            tabPageDataView.Controls.Add(characterSetViewer);

                            // Rename the tab header
                            tabPageDataView.Title = "Character Set Viewer";
                        }
                        break;

                    case MainForm.UserControls.DataFileViewer:
                        if (dataFileViewer == null)
                        {
                            dataFileViewer = new DataFileViewer();
                            tabPageDataView.Controls.Add(dataFileViewer);

                            // Rename the tab header
                            tabPageDataView.Title = "Data File Viewer";
                        }
                        break;

                    case MainForm.UserControls.SequentialFileViewer:
                        if (sequentialFileViewer == null)
                        {
                            sequentialFileViewer = new SequentialFileViewer();
                            tabPageDataView.Controls.Add(sequentialFileViewer);

                            // Rename the tab header
                            tabPageDataView.Title = "Sequential File Viewer";
                        }
                        break;

                    case MainForm.UserControls.None:
                        break;

                    default:
                        break;
                }
            }
            
            Invalidate();
        }

        public void DisplayData()
        {
            DynamicByteProvider dynamicByteProvider;
            dynamicByteProvider = new DynamicByteProvider(programData.m_programData);

            hexBox1.ByteProvider = dynamicByteProvider;
            hexBox1.LineInfoOffset = programInfo.StartAddress;
            hexBox1.ReadOnly = true;

            parentForm.programInfoForm.DisplayProgramInformation(programInfo);

            if (showSourceCode)
            {
                // Display the programs sourcecode
                if (programInfo.Format == OricProgram.ProgramFormat.BasicProgram)
                {
                    fastColoredTextBoxSourceCode.Text = programData.ListAsText();
                }
                else if (programInfo.Format == OricProgram.ProgramFormat.CodeFile)
                {
                    fastColoredTextBoxSourceCode.Text = programData.Assembly();
                }
            }

            switch (userControl)
            {
                case MainForm.UserControls.CharacterSetViewer:
                    //characterSetViewer.FileInformation = labelDetails;
                    characterSetViewer.ProgramInfo = programInfo;
                    characterSetViewer.ProgramData = programData;
                    characterSetViewer.InitialiseView();
                    break;

                case MainForm.UserControls.DataFileViewer:
                    //dataFileViewer.FileInformation = labelDetails;
                    dataFileViewer.ProgramInfo = programInfo;
                    dataFileViewer.ProgramData = programData;
                    dataFileViewer.InitialiseView();
                    break;

                case MainForm.UserControls.DataViewer:
                    //dataViewer.FileInformation = labelDetails;
                    dataViewer.ProgramInfo = programInfo;
                    dataViewer.ProgramData = programData;
                    dataViewer.InitialiseView();
                    break;

                case MainForm.UserControls.ScreenViewer:
                    //screenViewer.FileInformation = labelDetails;
                    screenViewer.ProgramInfo = programInfo;
                    screenViewer.ProgramData = programData;
                    screenViewer.InitialiseView();
                    break;

                case MainForm.UserControls.SequentialFileViewer:
                    //sequentialFileViewer.FileInformation = labelDetails;
                    sequentialFileViewer.ProgramInfo = programInfo;
                    sequentialFileViewer.ProgramData = programData;
                    sequentialFileViewer.InitialiseView();
                    break;

                case MainForm.UserControls.None:
                    break;

                default:
                    break;
            }
        }

        private void DisplayAssemblerListing(TextChangedEventArgs e)
        {
            // Clear style of changed range
            fastColoredTextBoxSourceCode.ClearStylesBuffer();

            // Address highlighting
            e.ChangedRange.SetStyle(assemblerAddressStyle, @"^\$[0-9A-F]{4}\s", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(assemblerUnknownStyle, @"[?]{3}", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(assemblerOperandStyle, @"#{0,1}\({0,1}\$([0-9A-F]){2,4}\){0,1}(,Y|,X){0,1}\){0,1}", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(assemblerMnemonicStyle, @"(ADC|AND|ASL A|ASL|BCC|BCS|BEQ|BMI|BNE|BPL|BVC|BVS|BIT|BRK|CLC|CLD|CLI|CLV|CMP|CPX|CPY|DEC|DEX|DEY|EOR|INC|INX|INY|JMP|JSR|LDA|LDX|LDY|LSR A|LSR|NOP|ORA|PHA|PHP|PLA|PLP|ROL A|ROL|ROR A|ROR|RTI|RTS|SBC|SEC|SED|SEI|STA|STX|STY|TAX|TAY|TSX|TXA|TXS|TYA)", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(assemblerHexStyle, @"[0-9A-F]{2}\s", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(assemberAsciiStyle, @"\S", RegexOptions.Multiline);
        }

        private void DisplayBasicListing(TextChangedEventArgs e)
        {
            fastColoredTextBoxSourceCode.LeftBracket = '(';
            fastColoredTextBoxSourceCode.RightBracket = ')';
            fastColoredTextBoxSourceCode.LeftBracket2 = '\x0';
            fastColoredTextBoxSourceCode.RightBracket2 = '\x0';

            // Clear style of changed range
            fastColoredTextBoxSourceCode.ClearStylesBuffer();

            e.ChangedRange.SetStyle(basicDataKeywordStyle, @"(DATA.*)", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(basicStringStyle, @"""""|@""""|@"".*?""|(?<!@)(?<range>"".*?[^\\]"")");
            e.ChangedRange.SetStyle(basicCommentStyle, @"(REM.*|\s'.*)", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(basicLineNumberStyle, @"^[0-9]{1,5}", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(basicHexNumberStyle, @"#([0-9A-Fa-f]){1,4}");
            e.ChangedRange.SetStyle(basicNumberStyle, @"\d+[\.]?\d*([eE]\-?\d+)?");
            e.ChangedRange.SetStyle(basicLoopsStyle, @"(REPEAT|UNTIL|FOR|NEXT)");
            e.ChangedRange.SetStyle(basicBranchesStyle, @"(GOSUB|GOTO|ON|RETURN)");
            e.ChangedRange.SetStyle(basicKeywordStyle, @"(POP|PULL|RESTORE|STEP|PING|EXPLODE|DEF|POKE|PRINT|CONT|LIST|CLEAR|GET|CALL|NEW|TAB|TO|FN|SPC|AUTO|ELSE|THEN|NOT|AND|OR|SGN|INT|ABS|USR|FRE|POS|HEX\$|SQR|RND|LN|EXP|COS|SIN|TAN|ATN|PEEK|DEEK|LOG|LEN|STR\$|VAL|ASC|CHR\$|PI|TRUE|FALSE|KEY\$|SCRN|POINT|LEFT\$|RIGHT\$|MID\$|END|EDIT|STORE|RECALL|TRON|TROFF|PLOT|LORES|DOKE|LLIST|LPRINT|INPUT|DIM|CLS|READ|LET|RUN|IF|HIMEM|GRAB|RELEASE|TEXT|HIRES|SHOOT|ZAP|SOUND|MUSIC|PLAY|CURSET|CURMOV|DRAW|CIRCLE|PATTERN|FILL|CHAR|PAPER|INK|STOP|ON|WAIT|CLOAD|CSAVE)");
        }

        private void fastColoredTextBoxSourceCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (programInfo != null)
            {
                switch (programInfo.Format)
                {
                    case OricProgram.ProgramFormat.BasicProgram:
                        DisplayBasicListing(e);
                        break;

                    case OricProgram.ProgramFormat.CodeFile:
                        DisplayAssemblerListing(e);
                        break;
                }
            }
        }
    }
}
