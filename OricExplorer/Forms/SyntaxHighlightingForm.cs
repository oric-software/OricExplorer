namespace OricExplorer.Forms
{
    using FastColoredTextBoxNS;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using static global::OricExplorer.Configuration;
    using static System.Windows.Forms.ListView;

    public partial class SyntaxHighlightingForm : Form
    {
        //Configuration configuration;

        private Color pageBackground;
        
        private Dictionary<ConstantsAndEnums.SyntaxHighlightingItems, TextStyle> syntaxHighlightingStyles;

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
        private TextStyle assemblerAsciiStyle;
        private TextStyle assemblerUnknownStyle;

        // Text styles for Dump Listings
        private TextStyle dumpHeadersStyle;
        private TextStyle dumpHexStyle;
        private TextStyle dumpAsciiStyle;
        private TextStyle dumpMainSelectionBackStyle;
        private TextStyle dumpMainSelectionFrontStyle;
        private TextStyle dumpSecondarySelectionBackStyle;

        //private MarkerStyle SameWordsStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(40, Color.Gray)));

        public SyntaxHighlightingForm()
        {
            InitializeComponent();
        }

        private void SyntaxHighlightingForm_Load(object sender, EventArgs e)
        {
            SetupUserColours();

            radioButtonBasicListing.Checked = true;
        }

        private void SetupUserColours()
        {
            pageBackground = Configuration.Persistent.PageBackground;
            fastColoredTextBoxSample.BackBrush = new SolidBrush(pageBackground);
            labelPageBackgroundColour.BackColor = pageBackground;

            // Setup colours from Configuration
            syntaxHighlightingStyles = Configuration.Persistent.SyntaxHighlightingStyles;

            basicLineNumberStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicLineNumber].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicLineNumber].FontStyle);
            basicKeywordStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicKeyword].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicKeyword].FontStyle);
            basicBranchesStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicBranches].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicBranches].FontStyle);
            basicLoopsStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicLoops].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicLoops].FontStyle);
            basicStringStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicString].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicString].FontStyle);
            basicHexNumberStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicHexNumber].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicHexNumber].FontStyle);
            basicNumberStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicNumber].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicNumber].FontStyle);
            basicDataKeywordStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicDataKeyword].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicDataKeyword].FontStyle);
            basicCommentStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicComment].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicComment].FontStyle);

            assemblerAddressStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerAddressStyle].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerAddressStyle].FontStyle);
            assemblerHexStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerHexStyle].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerHexStyle].FontStyle);
            assemblerMnemonicStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerMnemonicStyle].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerMnemonicStyle].FontStyle);
            assemblerOperandStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerOperandStyle].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerOperandStyle].FontStyle);
            assemblerAsciiStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerAsciiStyle].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerAsciiStyle].FontStyle);
            assemblerUnknownStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerUnknownStyle].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerUnknownStyle].FontStyle);

            dumpHeadersStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpHeadersStyle].ForeBrush, null, FontStyle.Regular);
            dumpHexStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpHexStyle].ForeBrush, null, FontStyle.Regular);
            dumpAsciiStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpAsciiStyle].ForeBrush, null, FontStyle.Regular);
            dumpMainSelectionBackStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpMainSelectionBackStyle].ForeBrush, null, FontStyle.Regular);
            dumpMainSelectionFrontStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpMainSelectionFrontStyle].ForeBrush, null, FontStyle.Regular);
            dumpSecondarySelectionBackStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpSecondarySelectionBackStyle].ForeBrush, null, FontStyle.Regular);

            fastColoredTextBoxSample.OnTextChanged();
        }

        private void radioButtonBasicListing_CheckedChanged(object sender, EventArgs e)
        {
            fastColoredTextBoxSample.Text  = "100 REM Syntax Highlight Test Program\r\n";
            fastColoredTextBoxSample.Text += "110 LET A=10\r\n";
            fastColoredTextBoxSample.Text += "120 REPEAT\r\n";
            fastColoredTextBoxSample.Text += "130 :  B=B+#0F\r\n";
            fastColoredTextBoxSample.Text += "140 :  PRINT \"Hello\",HEX$(B)\r\n";
            fastColoredTextBoxSample.Text += "150 GOSUB 500\r\n";
            fastColoredTextBoxSample.Text += "160 UNTIL A>10\r\n";
            fastColoredTextBoxSample.Text += "170 END\r\n";
            fastColoredTextBoxSample.Text += "500 REM Subroutine\r\n";
            fastColoredTextBoxSample.Text += "510 PRINT \"Subroutine\"\r\n";
            fastColoredTextBoxSample.Text += "520 RETURN\r\n";
            fastColoredTextBoxSample.Text += "1000 DATA 1,2,3,4\r\n";
            fastColoredTextBoxSample.Text += "1010 DATA Oric,Atmos,Oric-1\r\n";
            fastColoredTextBoxSample.Text += "1020 DATA #A1,#B4,#0A\r\n";

            SetupBasicItems();

            checkBoxBold.Enabled = checkBoxItalic.Enabled = checkBoxUnderline.Enabled = true;
        }

        private void radioButtonAssemblerListing_CheckedChanged(object sender, EventArgs e)
        {
            fastColoredTextBoxSample.Text  = "$0500  4C 74 21    JMP $2174      Lt!\r\n";
            fastColoredTextBoxSample.Text += "$0503  20 51 41    JSR $4151       QA\r\n";
            fastColoredTextBoxSample.Text += "$0506  43          ???            C\r\n";
            fastColoredTextBoxSample.Text += "$0507  54          ???            T\r\n";
            fastColoredTextBoxSample.Text += "$0508  00          BRK            .\r\n";
            fastColoredTextBoxSample.Text += "$0509  16 49       ASL $49,X      .I\r\n";

            SetupAssemblerItems();
        
            checkBoxBold.Enabled = checkBoxItalic.Enabled = checkBoxUnderline.Enabled = true;
        }

        private void radioButtonHexDump_CheckedChanged(object sender, EventArgs e)
        {
            fastColoredTextBoxSample.Text  = "     00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F\r\n\r\n";
            fastColoredTextBoxSample.Text += "$00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  ................\r\n";
            fastColoredTextBoxSample.Text += "$10  10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10  ................\r\n";
            fastColoredTextBoxSample.Text += "$20  20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20                  \r\n";
            fastColoredTextBoxSample.Text += "$30  30 30 30 30 30 30 30 30 30 30 30 30 30 30 30 30  0000000000000000\r\n";
            fastColoredTextBoxSample.Text += "$40  40 40 40 40 40 40 40 40 40 40 40 40 40 40 40 40  @@@@@@@@@@@@@@@@\r\n";

            SetupDumpItems();
        
            checkBoxBold.Enabled = checkBoxItalic.Enabled = checkBoxUnderline.Enabled = false;
        }

        private void SetupBasicItems()
        {
            listViewItems.BeginUpdate();

            listViewItems.Items.Clear();

            ListViewItem lvItem = new ListViewItem();
            lvItem.Text = "Data Statements";
            lvItem.Tag = basicDataKeywordStyle;
            listViewItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Strings";
            lvItem.Tag = basicStringStyle;
            listViewItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Comments";
            lvItem.Tag = basicCommentStyle;
            listViewItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Line Number";
            lvItem.Tag = basicLineNumberStyle;
            listViewItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Hex Values";
            lvItem.Tag = basicHexNumberStyle;
            listViewItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Numerics";
            lvItem.Tag = basicNumberStyle;
            listViewItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Loops";
            lvItem.Tag = basicLoopsStyle;
            listViewItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Branches";
            lvItem.Tag = basicBranchesStyle;
            listViewItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Keywords";
            lvItem.Tag = basicKeywordStyle;
            listViewItems.Items.Add(lvItem);

            listViewItems.EndUpdate();

            listViewItems.Items[0].Selected = true;
            listViewItems_SelectedIndexChanged(null, null);
        }

        private void SetupAssemblerItems()
        {
            listViewItems.BeginUpdate();

            listViewItems.Items.Clear();

            ListViewItem lvItem = new ListViewItem();
            lvItem.Text = "Address";
            lvItem.Tag = assemblerAddressStyle;
            listViewItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Unknown";
            lvItem.Tag = assemblerUnknownStyle;
            listViewItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Operand";
            lvItem.Tag = assemblerOperandStyle;
            listViewItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Mnemonic";
            lvItem.Tag = assemblerMnemonicStyle;
            listViewItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Hex";
            lvItem.Tag = assemblerHexStyle;
            listViewItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Ascii";
            lvItem.Tag = assemblerAsciiStyle;
            listViewItems.Items.Add(lvItem);

            listViewItems.EndUpdate();

            listViewItems.Items[0].Selected = true;
            listViewItems_SelectedIndexChanged(null, null);
        }

        private void SetupDumpItems()
        {
            listViewItems.BeginUpdate();

            listViewItems.Items.Clear();

            ListViewItem lvItem = new ListViewItem();
            lvItem.Text = "Headers";
            lvItem.Tag = dumpHeadersStyle;
            listViewItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Hex";
            lvItem.Tag = dumpHexStyle;
            listViewItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Ascii";
            lvItem.Tag = dumpAsciiStyle;
            listViewItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Main selection (backcolor)";
            lvItem.Tag = dumpMainSelectionBackStyle;
            listViewItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Main selection (frontcolor)";
            lvItem.Tag = dumpMainSelectionFrontStyle;
            listViewItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Secondary selection (backcolor)";
            lvItem.Tag = dumpSecondarySelectionBackStyle;
            listViewItems.Items.Add(lvItem);

            listViewItems.EndUpdate();

            listViewItems.Items[0].Selected = true;
            listViewItems_SelectedIndexChanged(null, null);
        }

        private void DisplayBasicListing(TextChangedEventArgs e)
        {
            fastColoredTextBoxSample.LeftBracket = '(';
            fastColoredTextBoxSample.RightBracket = ')';
            fastColoredTextBoxSample.LeftBracket2 = '\x0';
            fastColoredTextBoxSample.RightBracket2 = '\x0';

            // Clear style of changed range
            fastColoredTextBoxSample.ClearStylesBuffer();

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

        private void DisplayAssemblerListing(TextChangedEventArgs e)
        {
            // Clear style of changed range
            fastColoredTextBoxSample.ClearStylesBuffer();

            e.ChangedRange.SetStyle(assemblerAddressStyle, @"^\$[0-9A-F]{4}\s", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(assemblerUnknownStyle, @"[?]{3}", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(assemblerOperandStyle, @"#{0,1}\({0,1}\$([0-9A-F]){2,4}\){0,1}(,Y|,X){0,1}\){0,1}", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(assemblerMnemonicStyle, @"(ADC|AND|ASL A|ASL|BCC|BCS|BEQ|BMI|BNE|BPL|BVC|BVS|BIT|BRK|CLC|CLD|CLI|CLV|CMP|CPX|CPY|DEC|DEX|DEY|EOR|INC|INX|INY|JMP|JSR|LDA|LDX|LDY|LSR A|LSR|NOP|ORA|PHA|PHP|PLA|PLP|ROL A|ROL|ROR A|ROR|RTI|RTS|SBC|SEC|SED|SEI|STA|STX|STY|TAX|TAY|TSX|TXA|TXS|TYA)", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(assemblerHexStyle, @"[0-9A-F]{2}\s", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(assemblerAsciiStyle, @"\S", RegexOptions.Multiline);
        }

        private void DisplayDumpListing(TextChangedEventArgs e)
        {
            // Clear style of changed range
            fastColoredTextBoxSample.ClearStylesBuffer();

            e.ChangedRange.SetStyle(dumpHeadersStyle, @"^(\$[0-9A-F]{2}\s)|(\s\s\s\s\s[0-9A-F]{2}(\s[0-9A-F]{2}){15})", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(dumpHexStyle, @"\s\s[0-9A-F]{2}(\s[0-9A-F]{2}){15}\s\s", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(dumpAsciiStyle, @"\s\s\S{16}", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(dumpMainSelectionBackStyle, "", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(dumpMainSelectionFrontStyle, "", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(dumpSecondarySelectionBackStyle, "", RegexOptions.Multiline);
        }

        private void listViewItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedIndexCollection selectedIndexes = listViewItems.SelectedIndices;

            if (selectedIndexes.Count > 0)
            {
                TextStyle textStyle = (TextStyle)listViewItems.SelectedItems[0].Tag;

                labelForegroundColour.BackColor = ((SolidBrush)textStyle.ForeBrush).Color;

                checkBoxBold.Checked = (textStyle.FontStyle & FontStyle.Bold) > 0;
                checkBoxItalic.Checked = (textStyle.FontStyle & FontStyle.Italic) > 0;
                checkBoxUnderline.Checked = (textStyle.FontStyle & FontStyle.Underline) > 0;
            }
        }

        private void checkBoxBold_Click(object sender, EventArgs e)
        {
            UpdateFontStyle();
        }

        private void checkBoxItalic_Click(object sender, EventArgs e)
        {
            UpdateFontStyle();
        }

        private void checkBoxUnderline_Click(object sender, EventArgs e)
        {
            UpdateFontStyle();
        }

        private void buttonOkay_Click(object sender, EventArgs e)
        {
            Configuration.Persistent.PageBackground = pageBackground;

            // Save updates
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicLineNumber] = new TextStyle(basicLineNumberStyle.ForeBrush, null, basicLineNumberStyle.FontStyle);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicKeyword] = new TextStyle(basicKeywordStyle.ForeBrush, null, basicKeywordStyle.FontStyle);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicBranches] = new TextStyle(basicBranchesStyle.ForeBrush, null, basicBranchesStyle.FontStyle);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicLoops] = new TextStyle(basicLoopsStyle.ForeBrush, null, basicLoopsStyle.FontStyle);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicString] = new TextStyle(basicStringStyle.ForeBrush, null, basicStringStyle.FontStyle);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicHexNumber] = new TextStyle(basicHexNumberStyle.ForeBrush, null, basicHexNumberStyle.FontStyle);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicNumber] = new TextStyle(basicNumberStyle.ForeBrush, null, basicNumberStyle.FontStyle);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicDataKeyword] = new TextStyle(basicDataKeywordStyle.ForeBrush, null, basicDataKeywordStyle.FontStyle);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicComment] = new TextStyle(basicCommentStyle.ForeBrush, null, basicCommentStyle.FontStyle);

            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerAddressStyle] = new TextStyle(assemblerAddressStyle.ForeBrush, null, assemblerAddressStyle.FontStyle);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerHexStyle] = new TextStyle(assemblerHexStyle.ForeBrush, null, assemblerHexStyle.FontStyle);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerMnemonicStyle] = new TextStyle(assemblerMnemonicStyle.ForeBrush, null, assemblerMnemonicStyle.FontStyle);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerOperandStyle] = new TextStyle(assemblerOperandStyle.ForeBrush, null, assemblerOperandStyle.FontStyle);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerAsciiStyle] = new TextStyle(assemblerAsciiStyle.ForeBrush, null, assemblerAsciiStyle.FontStyle);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerUnknownStyle] = new TextStyle(assemblerUnknownStyle.ForeBrush, null, assemblerUnknownStyle.FontStyle);

            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpHeadersStyle] = new TextStyle(dumpHeadersStyle.ForeBrush, null, FontStyle.Regular);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpHexStyle] = new TextStyle(dumpHexStyle.ForeBrush, null, FontStyle.Regular);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpAsciiStyle] = new TextStyle(dumpAsciiStyle.ForeBrush, null, FontStyle.Regular);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpMainSelectionBackStyle] = new TextStyle(dumpMainSelectionBackStyle.ForeBrush, null, FontStyle.Regular);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpMainSelectionFrontStyle] = new TextStyle(dumpMainSelectionFrontStyle.ForeBrush, null, FontStyle.Regular);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpSecondarySelectionBackStyle] = new TextStyle(dumpSecondarySelectionBackStyle.ForeBrush, null, FontStyle.Regular);

            Configuration.Persistent.SyntaxHighlightingStyles = syntaxHighlightingStyles;
            Configuration.Persistent.Save();

            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonDefault_Click(object sender, EventArgs e)
        {
            SetDefaults();

            fastColoredTextBoxSample.BackBrush = new SolidBrush(pageBackground);
            labelPageBackgroundColour.BackColor = pageBackground;

            if (radioButtonBasicListing.Checked)
            {
                SetupBasicItems();
            }
            else if (radioButtonAssemblerListing.Checked)
            {
                SetupAssemblerItems();
            }
            else if (radioButtonHexDumpListing.Checked)
            {
                SetupDumpItems();
            }

            fastColoredTextBoxSample.OnTextChanged();
        }

        private void SetDefaults()
        {
            pageBackground = ConstantsAndEnums.BACKGROUND;

            // Text styles for BASIC listing
            basicLineNumberStyle = new TextStyle(ConstantsAndEnums.BASIC_LINE_NUMBER_STYLE.ForeBrush, null, ConstantsAndEnums.BASIC_LINE_NUMBER_STYLE.FontStyle);
            basicKeywordStyle = new TextStyle(ConstantsAndEnums.BASIC_KEYWORD_STYLE.ForeBrush, null, ConstantsAndEnums.BASIC_KEYWORD_STYLE.FontStyle);
            basicBranchesStyle = new TextStyle(ConstantsAndEnums.BASIC_BRANCHES_STYLE.ForeBrush, null, ConstantsAndEnums.BASIC_BRANCHES_STYLE.FontStyle); 
            basicLoopsStyle = new TextStyle(ConstantsAndEnums.BASIC_LOOPS_STYLE.ForeBrush, null, ConstantsAndEnums.BASIC_LOOPS_STYLE.FontStyle);
            basicStringStyle = new TextStyle(ConstantsAndEnums.BASIC_STRING_STYLE.ForeBrush, null, ConstantsAndEnums.BASIC_STRING_STYLE.FontStyle);
            basicHexNumberStyle = new TextStyle(ConstantsAndEnums.BASIC_HEX_NUMBER_STYLE.ForeBrush, null, ConstantsAndEnums.BASIC_HEX_NUMBER_STYLE.FontStyle);
            basicNumberStyle = new TextStyle(ConstantsAndEnums.BASIC_NUMBER_STYLE.ForeBrush, null, ConstantsAndEnums.BASIC_NUMBER_STYLE.FontStyle); 
            basicDataKeywordStyle = new TextStyle(ConstantsAndEnums.BASIC_DATA_KEYWORD_STYLE.ForeBrush, null, ConstantsAndEnums.BASIC_DATA_KEYWORD_STYLE.FontStyle);
            basicCommentStyle = new TextStyle(ConstantsAndEnums.BASIC_COMMENT_STYLE.ForeBrush, null, ConstantsAndEnums.BASIC_COMMENT_STYLE.FontStyle);

            // Text styles for assembler listings
            assemblerAddressStyle = new TextStyle(ConstantsAndEnums.ASSEMBLER_ADDRESS_STYLE.ForeBrush, null, ConstantsAndEnums.ASSEMBLER_ADDRESS_STYLE.FontStyle);
            assemblerHexStyle = new TextStyle(ConstantsAndEnums.ASSEMBLER_HEX_STYLE.ForeBrush, null, ConstantsAndEnums.ASSEMBLER_HEX_STYLE.FontStyle);
            assemblerMnemonicStyle = new TextStyle(ConstantsAndEnums.ASSEMBLER_MNEMONIC_STYLE.ForeBrush, null, ConstantsAndEnums.ASSEMBLER_MNEMONIC_STYLE.FontStyle);
            assemblerOperandStyle = new TextStyle(ConstantsAndEnums.ASSEMBLER_OPERAND_STYLE.ForeBrush, null, ConstantsAndEnums.ASSEMBLER_OPERAND_STYLE.FontStyle);
            assemblerAsciiStyle = new TextStyle(ConstantsAndEnums.ASSEMBLER_ASCII_STYLE.ForeBrush, null, ConstantsAndEnums.ASSEMBLER_ASCII_STYLE.FontStyle);
            assemblerUnknownStyle = new TextStyle(ConstantsAndEnums.ASSEMBLER_UNKNOWN_STYLE.ForeBrush, null, ConstantsAndEnums.ASSEMBLER_UNKNOWN_STYLE.FontStyle);

            // Text styles for dump listings
            dumpHeadersStyle = new TextStyle(ConstantsAndEnums.DUMP_HEADERS_STYLE.ForeBrush, null, FontStyle.Regular);
            dumpHexStyle = new TextStyle(ConstantsAndEnums.DUMP_HEX_STYLE.ForeBrush, null, FontStyle.Regular);
            dumpAsciiStyle = new TextStyle(ConstantsAndEnums.DUMP_ASCII_STYLE.ForeBrush, null, FontStyle.Regular);
            dumpMainSelectionBackStyle = new TextStyle(ConstantsAndEnums.DUMP_MAIN_SELECTION_BACK_STYLE.ForeBrush, null, FontStyle.Regular);
            dumpMainSelectionFrontStyle = new TextStyle(ConstantsAndEnums.DUMP_MAIN_SELECTION_FRONT_STYLE.ForeBrush, null, FontStyle.Regular);
            dumpSecondarySelectionBackStyle = new TextStyle(ConstantsAndEnums.DUMP_SECONDARY_SELECTION_BACK_STYLE.ForeBrush, null, FontStyle.Regular);
        }

        private void UpdateForeColor(Color foreColor)
        {
            SelectedIndexCollection selectedIndexes = listViewItems.SelectedIndices;

            if (selectedIndexes.Count > 0)
            {
                int index = selectedIndexes[0];

                TextStyle textStyle = (TextStyle)fastColoredTextBoxSample.Styles[index];

                textStyle.ForeBrush = new SolidBrush(foreColor);
            }

            fastColoredTextBoxSample.OnTextChanged();
        }

        private void UpdateFontStyle()
        {
            SelectedIndexCollection selectedIndexes = listViewItems.SelectedIndices;

            if (selectedIndexes.Count > 0)
            {
                int index = selectedIndexes[0];

                TextStyle textStyle = (TextStyle)fastColoredTextBoxSample.Styles[index];

                textStyle.FontStyle = (checkBoxBold.Checked ? FontStyle.Bold : FontStyle.Regular) |
                                      (checkBoxItalic.Checked ? FontStyle.Italic : FontStyle.Regular) |
                                      (checkBoxUnderline.Checked ? FontStyle.Underline : FontStyle.Regular);

                fastColoredTextBoxSample.OnTextChanged();
            }
        }

        private void labelForegroundColour_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.Color = labelForegroundColour.BackColor;

                DialogResult result = colorDialog.ShowDialog();

                if(result == DialogResult.OK)
                {
                    Color selectedColor = colorDialog.Color;
                    UpdateForeColor(selectedColor);
                    labelForegroundColour.BackColor = selectedColor;
                }
            }
        }

        private void labelPageBackgroundColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.Color = labelPageBackgroundColour.BackColor;

                DialogResult result = colorDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    Color selectedColor = colorDialog.Color;
                    pageBackground = selectedColor;
                    labelPageBackgroundColour.BackColor = selectedColor;

                    fastColoredTextBoxSample.BackBrush = new SolidBrush(selectedColor);
                    fastColoredTextBoxSample.OnTextChanged();
                }
            }
        }

        private void fastColoredTextBoxSample_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (radioButtonBasicListing.Checked)
            {
                DisplayBasicListing(e);
            }
            else if (radioButtonAssemblerListing.Checked)
            {
                DisplayAssemblerListing(e);
            }
            else if (radioButtonHexDumpListing.Checked)
            {
                DisplayDumpListing(e);
            }
        }
    }
}
