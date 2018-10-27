using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using System.Text.RegularExpressions;
using WeifenLuo.WinFormsUI.Docking;
using Be.Windows.Forms;
using OricExplorer.Forms;
using System.IO;
using static OricExplorer.Configuration;

namespace OricExplorer.User_Controls
{
    public partial class MainView : DockContent
    {
        // Text styles for Assembler Listings
        TextStyle AddressStyle = new TextStyle(new SolidBrush(Color.FromArgb(230, 174, 13)), null, FontStyle.Regular);
        TextStyle HexStyle = new TextStyle(Brushes.White, null, FontStyle.Regular);
        TextStyle AssemblerStyle = new TextStyle(Brushes.Yellow, null, FontStyle.Regular);
        TextStyle AssemblerStyle2 = new TextStyle(Brushes.Yellow, null, FontStyle.Regular);
        TextStyle AsciiStyle = new TextStyle(new SolidBrush(Color.FromArgb(120, 120, 120)), null, FontStyle.Regular);
        TextStyle UnknownStyle = new TextStyle(Brushes.Red, null, FontStyle.Regular);

        // Text styles for BASIC Listing
        TextStyle StringStyle = new TextStyle(new SolidBrush(Color.FromArgb(214, 157, 133)), null, FontStyle.Regular);
        TextStyle CommentStyle = new TextStyle(new SolidBrush(Color.FromArgb(87, 166, 74)), null, FontStyle.Regular);
        TextStyle DataKeywordStyle = new TextStyle(new SolidBrush(Color.FromArgb(78, 201, 176)), null, FontStyle.Regular);
        TextStyle LineNumberStyle = new TextStyle(new SolidBrush(Color.FromArgb(43, 145, 175)), null, FontStyle.Regular);
        TextStyle NumberStyle = new TextStyle(new SolidBrush(Color.FromArgb(181, 206, 168)), null, FontStyle.Regular);
        TextStyle HexNumberStyle = new TextStyle(new SolidBrush(Color.FromArgb(181, 206, 168)), null, FontStyle.Regular);
        TextStyle KeywordStyle = new TextStyle(new SolidBrush(Color.FromArgb(86, 156, 214)), null, FontStyle.Regular);
        TextStyle BranchesStyle = new TextStyle(new SolidBrush(Color.White), null, FontStyle.Regular);
        TextStyle LoopsStyle = new TextStyle(new SolidBrush(Color.White), null, FontStyle.Regular);

        MarkerStyle SameWordsStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(40, Color.Gray)));

        public MainForm.UserControls userControl;

        public OricProgram programData;
        public OricFileInfo programInfo;

        private DataViewerControl dataViewer;
        private ScreenViewerControl screenViewer;
        private DataFileViewer dataFileViewer;
        private CharacterSetViewerControl characterSetViewer;
        private SequentialFileViewer sequentialFileViewer;

        public Boolean showSourceCode = false;

        private MainForm parentForm;

        public MainView(MainForm parentForm)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            this.parentForm = parentForm;

            //SetupSyntaxHighlighting();
        }

        private void SetupSyntaxHighlighting()
        {
            fastColoredTextBoxSourceCode.BackColor = Properties.Settings.Default.PageBackground;

            foreach (SyntaxHighlightingItems item in Enum.GetValues(typeof(SyntaxHighlightingItems)))
            {
                try
                {
                    Color foreColor = (Color)Properties.Settings.Default["Basic" + item.ToString() + "Color"];
                    String[] style = Properties.Settings.Default["Basic" + item.ToString() + "Style"].ToString().Split('|');

                    FontStyle fontStyle = new FontStyle();

                    foreach (String s in style)
                    {
                        switch (s)
                        {
                            case "Regular":
                                fontStyle |= FontStyle.Regular;
                                break;

                            case "Bold":
                                fontStyle |= FontStyle.Bold;
                                break;

                            case "Italic":
                                fontStyle |= FontStyle.Italic;
                                break;

                            case "Underline":
                                fontStyle |= FontStyle.Underline;
                                break;

                            default:
                                break;
                        }
                    }

                    TextStyle textStyle = new TextStyle(new SolidBrush(foreColor), null, fontStyle);

                    switch(item)
                    {
                        case SyntaxHighlightingItems.Comment:
                            CommentStyle = textStyle;
                            break;

                        case SyntaxHighlightingItems.DataKeyword:
                            DataKeywordStyle = textStyle;
                            break;

                        case SyntaxHighlightingItems.HexNumber:
                            HexNumberStyle = textStyle;
                            break;

                        case SyntaxHighlightingItems.LineNumber:
                            LineNumberStyle = textStyle;
                            break;

                        case SyntaxHighlightingItems.Number:
                            NumberStyle = textStyle;
                            break;

                        case SyntaxHighlightingItems.String:
                            StringStyle = textStyle;
                            break;

                        case SyntaxHighlightingItems.Keyword:
                            KeywordStyle = textStyle;
                            break;

                        case SyntaxHighlightingItems.Loops:
                            LoopsStyle = textStyle;
                            break;

                        case SyntaxHighlightingItems.Branches:
                            BranchesStyle = textStyle;
                            break;

                        default:
                            break;
                    }
                }
                catch(Exception ex)
                {
                    String message = ex.Message;
                }
            }
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
            e.ChangedRange.ClearStyle(AddressStyle, HexStyle, AssemblerStyle, AssemblerStyle2, AsciiStyle, UnknownStyle);

            // Address highlighting
            e.ChangedRange.SetStyle(AddressStyle, @"^\$[0-9A-F]{4}\s", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(UnknownStyle, @"[?]{3}", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(AssemblerStyle2, @"#{0,1}\({0,1}\$([0-9A-F]){2,4}\){0,1}(,Y|,X){0,1}\){0,1}", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(AssemblerStyle, @"(ADC|AND|ASL A|ASL|BCC|BCS|BEQ|BMI|BNE|BPL|BVC|BVS|BIT|BRK|CLC|CLD|CLI|CLV|CMP|CPX|CPY|DEC|DEX|DEY|EOR|INC|INX|INY|JMP|JSR|LDA|LDX|LDY|LSR A|LSR|NOP|ORA|PHA|PHP|PLA|PLP|ROL A|ROL|ROR A|ROR|RTI|RTS|SBC|SEC|SED|SEI|STA|STX|STY|TAX|TAY|TSX|TXA|TXS|TYA)", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(HexStyle, @"[0-9A-F]{2}\s", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(AsciiStyle, @"\S", RegexOptions.Multiline);
        }

        private void DisplayBasicListing(TextChangedEventArgs e)
        {
            fastColoredTextBoxSourceCode.LeftBracket = '(';
            fastColoredTextBoxSourceCode.RightBracket = ')';
            fastColoredTextBoxSourceCode.LeftBracket2 = '\x0';
            fastColoredTextBoxSourceCode.RightBracket2 = '\x0';

            // Clear style of changed range
            e.ChangedRange.ClearStyle(DataKeywordStyle, KeywordStyle, LoopsStyle, BranchesStyle, CommentStyle, StringStyle, LineNumberStyle, NumberStyle, HexNumberStyle);

            // Data highlighting
            e.ChangedRange.SetStyle(DataKeywordStyle, @"(DATA.*)", RegexOptions.Multiline);

            // String highlighting
            e.ChangedRange.SetStyle(StringStyle, @"""""|@""""|@"".*?""|(?<!@)(?<range>"".*?[^\\]"")");

            // Comment highlighting
            e.ChangedRange.SetStyle(CommentStyle, @"(REM.*|\s'.*)", RegexOptions.Multiline);

            // Line number highlighting
            e.ChangedRange.SetStyle(LineNumberStyle, @"^[0-9]{1,5}", RegexOptions.Multiline);

            // Hex number highlighting
            e.ChangedRange.SetStyle(HexNumberStyle, @"#([0-9A-Fa-f]){1,4}");

            // Number highlighting
            e.ChangedRange.SetStyle(NumberStyle, @"\d+[\.]?\d*([eE]\-?\d+)?");

            // Loops highlighting
            e.ChangedRange.SetStyle(LoopsStyle, @"(REPEAT|UNTIL|FOR|NEXT)");

            // Branches highlighting
            e.ChangedRange.SetStyle(BranchesStyle, @"(GOSUB|GOTO|ON|RETURN)");

            // Keyword highlighting
            e.ChangedRange.SetStyle(KeywordStyle, @"(POP|PULL|RESTORE|STEP|PING|EXPLODE|DEF|POKE|PRINT|CONT|LIST|CLEAR|GET|CALL|NEW|TAB|TO|FN|SPC|AUTO|ELSE|THEN|NOT|AND|OR|SGN|INT|ABS|USR|FRE|POS|HEX\$|SQR|RND|LN|EXP|COS|SIN|TAN|ATN|PEEK|DEEK|LOG|LEN|STR\$|VAL|ASC|CHR\$|PI|TRUE|FALSE|KEY\$|SCRN|POINT|LEFT\$|RIGHT\$|MID\$|END|EDIT|STORE|RECALL|TRON|TROFF|PLOT|LORES|DOKE|LLIST|LPRINT|INPUT|DIM|CLS|READ|LET|RUN|IF|HIMEM|GRAB|RELEASE|TEXT|HIRES|SHOOT|ZAP|SOUND|MUSIC|PLAY|CURSET|CURMOV|DRAW|CIRCLE|PATTERN|FILL|CHAR|PAPER|INK|STOP|ON|WAIT|CLOAD|CSAVE)");
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
