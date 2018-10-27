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

namespace OricExplorer.User_Controls
{
    public partial class MainView : DockContent
    {
        // Text styles for Hexdump/Assembler Listings
        TextStyle AddressStyle = new TextStyle(Brushes.Teal, null, FontStyle.Regular);
        TextStyle HexStyle = new TextStyle(Brushes.Black, null, FontStyle.Regular);
        TextStyle AssemblerStyle = new TextStyle(Brushes.Maroon, null, FontStyle.Regular);
        TextStyle AssemblerStyle2 = new TextStyle(Brushes.Maroon, null, FontStyle.Regular);
        TextStyle AsciiStyle = new TextStyle(Brushes.Blue, null, FontStyle.Regular);
        TextStyle UnknownStyle = new TextStyle(Brushes.DarkGray, null, FontStyle.Regular);

        // Text styles for BASIC Listing
        TextStyle StringStyle = new TextStyle(Brushes.Maroon, null, FontStyle.Regular);
        TextStyle CommentStyle = new TextStyle(Brushes.Green, null, FontStyle.Regular);

        TextStyle KeywordStyle1 = new TextStyle(Brushes.Blue, null, FontStyle.Regular);
        TextStyle KeywordStyle2 = new TextStyle(Brushes.Blue, null, FontStyle.Regular);

        TextStyle DataKeywordStyle = new TextStyle(new SolidBrush(Color.FromArgb(43,145,175)), null, FontStyle.Regular);

        TextStyle BoldStyle = new TextStyle(null, null, FontStyle.Bold | FontStyle.Underline);
        TextStyle GrayStyle = new TextStyle(Brushes.Gray, null, FontStyle.Regular);
        TextStyle DarkGrayStyle = new TextStyle(Brushes.DarkGray, null, FontStyle.Regular);
        TextStyle MagentaStyle = new TextStyle(Brushes.Magenta, null, FontStyle.Regular);
        TextStyle MaroonStyle = new TextStyle(Brushes.Maroon, null, FontStyle.Regular);
        TextStyle brownStyle = new TextStyle(Brushes.Brown, null, FontStyle.Regular);
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

        void BuildFileInformation(OricFileInfo fileInformation)
        {
            StringBuilder fileInfoText = new StringBuilder();

            fileInfoText.AppendFormat("Address : ${0:X4} - ${1:X4}", fileInformation.StartAddress, fileInformation.EndAddress);

            if (fileInformation.Format == OricProgram.ProgramFormat.CodeFile && fileInformation.ExeAddress != 0)
            {
                fileInfoText.AppendFormat(" (Exe ${0:X4})\n", fileInformation.ExeAddress);
            }
            else
            {
                fileInfoText.Append("\n");
            }

            if (fileInformation.LengthBytes >= 1024)
            {
                fileInfoText.AppendFormat("File Size : {0:N0} bytes ({1:N1} KB)", fileInformation.LengthBytes, (float)fileInformation.LengthBytes / 1024);
            }
            else
            {
                fileInfoText.AppendFormat("File Size : {0:N0} bytes", fileInformation.LengthBytes);
            }

            if (fileInformation.MediaType == OricExplorer.MediaType.DiskFile)
            {
                fileInfoText.AppendFormat("\nDisk Usage : {0:N0} sectors", fileInformation.LengthSectors);
                fileInfoText.AppendFormat("\nStatus : {0}", fileInformation.Protection.ToString());
            }

            if (fileInformation.Format == OricProgram.ProgramFormat.BasicProgram || fileInformation.Format == OricProgram.ProgramFormat.CodeFile)
            {
                fileInfoText.AppendFormat("\nAuto Run : {0}", fileInformation.AutoRun.ToString());
            }

            labelDetails.Text = fileInfoText.ToString();
        }

        public void DisplayHex(Byte[] byteArray)
        {
            DynamicByteProvider dynamicByteProvider;
            dynamicByteProvider = new DynamicByteProvider(byteArray);

            hexBox1.ByteProvider = dynamicByteProvider;
            hexBox1.LineInfoOffset = 0x0000;
            hexBox1.ReadOnly = true;
        }

        public void DisplayData()
        {
            // Display program name and format in the information panel
            labelProgramName.Text = programInfo.ProgramName;
            labelProgramType.Text = String.Format("{0}", programInfo.FormatToString());
            labelDetails.Text = "";

            DynamicByteProvider dynamicByteProvider;
            dynamicByteProvider = new DynamicByteProvider(programData.m_programData);

            hexBox1.ByteProvider = dynamicByteProvider;
            hexBox1.LineInfoOffset = programInfo.StartAddress;
            hexBox1.ReadOnly = true;

            BuildFileInformation(programInfo);

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
                    characterSetViewer.FileInformation = labelDetails;
                    characterSetViewer.ProgramInfo = programInfo;
                    characterSetViewer.ProgramData = programData;
                    characterSetViewer.InitialiseView();
                    break;

                case MainForm.UserControls.DataFileViewer:
                    dataFileViewer.FileInformation = labelDetails;
                    dataFileViewer.ProgramInfo = programInfo;
                    dataFileViewer.ProgramData = programData;
                    dataFileViewer.InitialiseView();
                    break;

                case MainForm.UserControls.DataViewer:
                    dataViewer.FileInformation = labelDetails;
                    dataViewer.ProgramInfo = programInfo;
                    dataViewer.ProgramData = programData;
                    dataViewer.InitialiseView();
                    break;

                case MainForm.UserControls.ScreenViewer:
                    screenViewer.FileInformation = labelDetails;
                    screenViewer.ProgramInfo = programInfo;
                    screenViewer.ProgramData = programData;
                    screenViewer.InitialiseView();
                    break;

                case MainForm.UserControls.SequentialFileViewer:
                    sequentialFileViewer.FileInformation = labelDetails;
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
            e.ChangedRange.SetStyle(AssemblerStyle, @"(ADC|AND|ASL|BCC|BCS|BEQ|BMI|BNE|BPL|BVC|BVS|BIT|BRK|CLC|CLD|CLI|CLV|CMP|CPX|CPY|DEC|DEX|DEY|EOR|INC|INX|INY|JMP|JSR|LDA|LDX|LDY|LSR|NOP|ORA|PHA|PHP|PLA|PLP|ROL|ROR|RTI|RTS|SBC|SEC|SED|SEI|STA|STX|STY|TAX|TAY|TSX|TXA|TXS|TYA)|(,X)|(,Y)|ASL A", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(AssemblerStyle2, @"\$([0-9A-F]){1,4}|#\$([0-9A-F]){1,2}", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(HexStyle, @"[0-9A-F]{2}\s", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(AsciiStyle, @"\S", RegexOptions.Multiline);
        }

        private void DisplayHexDump(TextChangedEventArgs e)
        {
            // Clear style of changed range
            e.ChangedRange.ClearStyle(AddressStyle, HexStyle, AsciiStyle);

            // Address highlighting
            e.ChangedRange.SetStyle(AddressStyle, @"^\$[0-9A-F]{4}\s", RegexOptions.Multiline);
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
            e.ChangedRange.ClearStyle(DataKeywordStyle, KeywordStyle1, KeywordStyle2, BoldStyle, GrayStyle, MagentaStyle, CommentStyle, StringStyle);

            // Data highlighting
            e.ChangedRange.SetStyle(DataKeywordStyle, @"(DATA.*)", RegexOptions.Multiline);

            // String highlighting
            e.ChangedRange.SetStyle(StringStyle, @"""""|@""""|@"".*?""|(?<!@)(?<range>"".*?[^\\]"")");

            // Comment highlighting
            e.ChangedRange.SetStyle(CommentStyle, @"(REM.*|\s'\s.*)", RegexOptions.Multiline);

            // Line number highlighting
            e.ChangedRange.SetStyle(DarkGrayStyle, @"^[0-9]{1,5}", RegexOptions.Multiline);

            // Number highlighting
            e.ChangedRange.SetStyle(GrayStyle, @"\b(\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b)|#([0-9A-F]){1,4}");

            // Keyword highlighting
            e.ChangedRange.SetStyle(KeywordStyle1, @"\b(END|EDIT|STORE|RECALL|TRON|TROFF|POP|PLOT|PULL|LORES|DOKE|REPEAT|UNTIL|FOR|LLIST|LPRINT|NEXT|INPUT|DIM|CLS|READ|LET|GOTO|RUN|IF|RESTORE|GOSUB|RETURN|HIMEM|GRAB|RELEASE|TEXT|HIRES|SHOOT|EXPLODE|ZAP|PING|SOUND|MUSIC|PLAY|CURSET|CURMOV|DRAW|CIRCLE|PATTERN|FILL|CHAR|PAPER|INK|STOP|ON|WAIT|CLOAD|CSAVE)");
            e.ChangedRange.SetStyle(KeywordStyle2, @"\b(DEF|POKE|PRINT|CONT|LIST|CLEAR|GET|CALL|NEW|TAB|TO|FN|SPC|AUTO|ELSE|THEN|NOT|STEP|AND|OR|SGN|INT|ABS|USR|FRE|POS|HEX\$|SQR|RND|LN|EXP|COS|SIN|TAN|ATN|PEEK|DEEK|LOG|LEN|STR\$|VAL|ASC|CHR\$|PI|TRUE|FALSE|KEY\$|SCRN|POINT|LEFT\$|RIGHT\$|MID\$)");
        }

        private void fastColoredTextBoxHexDump_TextChanged(object sender, TextChangedEventArgs e)
        {
            DisplayHexDump(e);
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
