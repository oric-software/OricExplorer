namespace OricExplorer.Forms
{
    using FastColoredTextBoxNS;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    public partial class frmSyntaxHighlighting : Form
    {
        private Color pageBackground;
        
        private Dictionary<ConstantsAndEnums.SyntaxHighlightingItems, TextStyle> syntaxHighlightingStyles;

        // Text styles for Dump Listings
        private TextStyle dumpHeadersStyle;
        private TextStyle dumpHexStyle;
        private TextStyle dumpAsciiStyle;
        private TextStyle dumpMainSelectionBackStyle;
        private TextStyle dumpMainSelectionFrontStyle;
        private TextStyle dumpSecondarySelectionBackStyle;

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
        private TextStyle basicBrancheStyle;
        private TextStyle basicLoopStyle;
        private TextStyle basicStringStyle;
        private TextStyle basicNumberStyle;
        private TextStyle basicDataKeywordStyle;
        private TextStyle basicCommentStyle;

        // Text styles for HYPERBASIC Listing
        private TextStyle hyperbasicAddressStyle;
        private TextStyle hyperbasicLabelStyle;
        private TextStyle hyperbasicNumberStyle;
        private TextStyle hyperbasicStringStyle;
        private TextStyle hyperbasicLoopStyle;
        private TextStyle hyperbasicBrancheStyle;
        private TextStyle hyperbasicCodeStyle;
        private TextStyle hyperbasicCommentStyle;

        // Text styles for TELEASS Listing
        private TextStyle teleassAddressStyle;
        private TextStyle teleassLabelStyle;
        private TextStyle teleassMnemonicStyle;
        private TextStyle teleassOperandStyle;
        private TextStyle teleassCommentStyle;

        //private MarkerStyle SameWordsStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(40, Color.Gray)));

        public frmSyntaxHighlighting()
        {
            InitializeComponent();
        }

        private void frmSyntaxHighlighting_Load(object sender, EventArgs e)
        {
            SetupUserColours();

            optHexDumpListing.Checked = true;
        }

        private void SetupUserColours()
        {
            pageBackground = Configuration.Persistent.PageBackground;
            fcSample.BackBrush = new SolidBrush(pageBackground);
            lblPageBackgroundColor.BackColor = pageBackground;

            // Setup colours from Configuration
            syntaxHighlightingStyles = Configuration.Persistent.SyntaxHighlightingStyles;

            dumpHeadersStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpHeadersStyle].ForeBrush, null, FontStyle.Regular);
            dumpHexStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpHexStyle].ForeBrush, null, FontStyle.Regular);
            dumpAsciiStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpAsciiStyle].ForeBrush, null, FontStyle.Regular);
            dumpMainSelectionBackStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpMainSelectionBackStyle].ForeBrush, null, FontStyle.Regular);
            dumpMainSelectionFrontStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpMainSelectionFrontStyle].ForeBrush, null, FontStyle.Regular);
            dumpSecondarySelectionBackStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpSecondarySelectionBackStyle].ForeBrush, null, FontStyle.Regular);

            assemblerAddressStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerAddressStyle].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerAddressStyle].FontStyle);
            assemblerHexStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerHexStyle].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerHexStyle].FontStyle);
            assemblerMnemonicStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerMnemonicStyle].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerMnemonicStyle].FontStyle);
            assemblerOperandStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerOperandStyle].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerOperandStyle].FontStyle);
            assemblerAsciiStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerAsciiStyle].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerAsciiStyle].FontStyle);
            assemblerUnknownStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerUnknownStyle].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerUnknownStyle].FontStyle);

            basicLineNumberStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicLineNumber].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicLineNumber].FontStyle);
            basicKeywordStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicKeyword].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicKeyword].FontStyle);
            basicBrancheStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicBranches].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicBranches].FontStyle);
            basicLoopStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicLoops].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicLoops].FontStyle);
            basicStringStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicString].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicString].FontStyle);
            basicNumberStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicNumber].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicNumber].FontStyle);
            basicDataKeywordStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicDataKeyword].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicDataKeyword].FontStyle);
            basicCommentStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicComment].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicComment].FontStyle);

            hyperbasicAddressStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.HyperbasicAddressStyle].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.HyperbasicAddressStyle].FontStyle);
            hyperbasicLabelStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.HyperbasicLabelStyle].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.HyperbasicLabelStyle].FontStyle);
            hyperbasicNumberStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.HyperbasicNumberStyle].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.HyperbasicNumberStyle].FontStyle);
            hyperbasicStringStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.HyperbasicStringStyle].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.HyperbasicStringStyle].FontStyle);
            hyperbasicLoopStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.HyperbasicLoopStyle].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.HyperbasicLoopStyle].FontStyle);
            hyperbasicBrancheStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.HyperbasicBrancheStyle].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.HyperbasicBrancheStyle].FontStyle);
            hyperbasicCodeStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.HyperbasicCodeStyle].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.HyperbasicCodeStyle].FontStyle);
            hyperbasicCommentStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.HyperbasicCommentStyle].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.HyperbasicCommentStyle].FontStyle);
            
            teleassAddressStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.TeleassAddressStyle].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.TeleassAddressStyle].FontStyle);
            teleassLabelStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.TeleassLabelStyle].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.TeleassLabelStyle].FontStyle);
            teleassMnemonicStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.TeleassMnemonicStyle].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.TeleassMnemonicStyle].FontStyle);
            teleassOperandStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.TeleassOperandStyle].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.TeleassOperandStyle].FontStyle);
            teleassCommentStyle = new TextStyle(syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.TeleassCommentStyle].ForeBrush, null, syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.TeleassCommentStyle].FontStyle);

            fcSample.OnTextChanged();
        }

        private void optHexDumpListing_CheckedChanged(object sender, EventArgs e)
        {
            fcSample.Text = "     00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F\r\n\r\n";
            fcSample.Text += "$00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  ................\r\n";
            fcSample.Text += "$10  10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10  ................\r\n";
            fcSample.Text += "$20  20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20                  \r\n";
            fcSample.Text += "$30  30 30 30 30 30 30 30 30 30 30 30 30 30 30 30 30  0000000000000000\r\n";
            fcSample.Text += "$40  40 40 40 40 40 40 40 40 40 40 40 40 40 40 40 40  @@@@@@@@@@@@@@@@\r\n";
            fcSample.Text += "$50  40 40 40 40 40 40 40 40 40 40 40 40 40 40 40 40  @@@@@@@@@@@@@@@@\r\n";
            fcSample.Text += "$60  40 40 40 40 40 40 40 40 40 40 40 40 40 40 40 40  @@@@@@@@@@@@@@@@\r\n";
            fcSample.Text += "$70  40 40 40 40 40 40 40 40 40 40 40 40 40 40 40 40  @@@@@@@@@@@@@@@@\r\n";
            fcSample.Text += "$80  40 40 40 40 40 40 40 40 40 40 40 40 40 40 40 40  @@@@@@@@@@@@@@@@\r\n";
            fcSample.Text += "$90  40 40 40 40 40 40 40 40 40 40 40 40 40 40 40 40  @@@@@@@@@@@@@@@@\r\n";

            SetupHexDumpItems();

            chkStyleBold.Enabled = chkStyleItalic.Enabled = chkStyleUnderline.Enabled = false;
        }

        private void optAssemblerListing_CheckedChanged(object sender, EventArgs e)
        {
            fcSample.Text  = "$0500  4C 74 21    JMP $2174      Lt!\r\n";
            fcSample.Text += "$0503  20 51 41    JSR $4151       QA\r\n";
            fcSample.Text += "$0506  43          ???            C\r\n";
            fcSample.Text += "$0507  54          ???            T\r\n";
            fcSample.Text += "$0508  00          BRK            .\r\n";
            fcSample.Text += "$0509  16 49       ASL $49,X      .I\r\n";

            SetupAssemblerItems();
        
            chkStyleBold.Enabled = chkStyleItalic.Enabled = chkStyleUnderline.Enabled = true;
        }

        private void optBasicListing_CheckedChanged(object sender, EventArgs e)
        {
            fcSample.Text  = "100 REM Syntax Highlight Test Program\r\n";
            fcSample.Text += "110 LET A=10\r\n";
            fcSample.Text += "120 REPEAT\r\n";
            fcSample.Text += "130 :  B=B+#0F\r\n";
            fcSample.Text += "140 :  PRINT \"Hello\",HEX$(B)\r\n";
            fcSample.Text += "150 GOSUB 500\r\n";
            fcSample.Text += "160 UNTIL A>10\r\n";
            fcSample.Text += "170 END\r\n";
            fcSample.Text += "500 REM Subroutine\r\n";
            fcSample.Text += "510 PRINT \"Subroutine\"\r\n";
            fcSample.Text += "520 RETURN\r\n";
            fcSample.Text += "1000 DATA 1,2,3,4\r\n";
            fcSample.Text += "1010 DATA Oric,Atmos,Oric-1\r\n";
            fcSample.Text += "1020 DATA #A1,#B4,#0A\r\n";

            SetupBasicItems();

            chkStyleBold.Enabled = chkStyleItalic.Enabled = chkStyleUnderline.Enabled = true;
        }

        private void optHyperbasicListing_CheckedChanged(object sender, EventArgs e)
        {
            fcSample.Text = "     0 ]DUMP ' Affichage des canaux utilises\r\n";
            fcSample.Text += "    10   DIM P$(20)\r\n";
            fcSample.Text += "    20   GOSUB CHAINES\r\n";
            fcSample.Text += "    30   FOR I=#02AE TO #02BA STEP 4\r\n";
            fcSample.Text += "    40    PRINT (I-#2AE)/4;\":\";\r\n";
            fcSample.Text += "    50    FOR J=0 TO 3\r\n";
            fcSample.Text += "    60     P=PEEK(I+J)-#80:IF P<0 THEN P=20\r\n";
            fcSample.Text += "    70     PRINT R$;\" \";P$(P):PRINT \"   \";\r\n";
            fcSample.Text += "    80    NEXT J\r\n";
            fcSample.Text += "    90    PRINT \r\n";
            fcSample.Text += "   100   NEXT I\r\n";
            fcSample.Text += "   110 END\r\n";
            fcSample.Text += "   200 ]CHAINES\r\n";
            fcSample.Text += "   210   P$(0)=\"Clavier, Joystick, Souris\"\r\n";
            fcSample.Text += "   220   P$(1)=\"Joystick\"\r\n";

            SetupHyperbasicItems();

            chkStyleBold.Enabled = chkStyleItalic.Enabled = chkStyleUnderline.Enabled = true;
        }

        private void optTeleassListing_CheckedChanged(object sender, EventArgs e)
        {
            fcSample.Text = "    10        ORG $3FB0' ORIGINE ADDRESS\r\n";
            fcSample.Text += "    20 '\r\n";
            fcSample.Text += "    30 START  LDA ADIOB+4\r\n";
            fcSample.Text += "    40        LDY ADIOB+5\r\n";
            fcSample.Text += "    50        STA LIT+1\r\n";
            fcSample.Text += "    60        STY LIT+2\r\n";
            fcSample.Text += "    70        LDA #<MODARR\r\n";
            fcSample.Text += "    80        LDY #>MODARR\r\n";
            fcSample.Text += "    90        STA ADIOB+4\r\n";
            fcSample.Text += "   100        STY ADIOB+5\r\n";
            fcSample.Text += "   110        RTS\r\n";
            fcSample.Text += "   120 MODFLC JSR READ\r\n";
            fcSample.Text += "   130        BCS END\r\n";
            fcSample.Text += "   140        CMP #$1B\r\n";

            SetupTeleassItems();

            chkStyleBold.Enabled = chkStyleItalic.Enabled = chkStyleUnderline.Enabled = true;
        }

        private void SetupHexDumpItems()
        {
            lvwDisplayItems.BeginUpdate();

            lvwDisplayItems.Items.Clear();

            ListViewItem lvItem = new ListViewItem();
            lvItem.Text = "Headers";
            lvItem.Tag = dumpHeadersStyle;
            lvwDisplayItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Hex";
            lvItem.Tag = dumpHexStyle;
            lvwDisplayItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Ascii";
            lvItem.Tag = dumpAsciiStyle;
            lvwDisplayItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Main selection (backcolor)";
            lvItem.Tag = dumpMainSelectionBackStyle;
            lvwDisplayItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Main selection (frontcolor)";
            lvItem.Tag = dumpMainSelectionFrontStyle;
            lvwDisplayItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Secondary selection (backcolor)";
            lvItem.Tag = dumpSecondarySelectionBackStyle;
            lvwDisplayItems.Items.Add(lvItem);

            lvwDisplayItems.EndUpdate();

            lvwDisplayItems.Items[0].Selected = true;
            lvwDisplayItems_SelectedIndexChanged(null, null);
        }

        private void SetupAssemblerItems()
        {
            lvwDisplayItems.BeginUpdate();

            lvwDisplayItems.Items.Clear();

            ListViewItem lvItem = new ListViewItem();
            lvItem.Text = "Address";
            lvItem.Tag = assemblerAddressStyle;
            lvwDisplayItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Hex";
            lvItem.Tag = assemblerHexStyle;
            lvwDisplayItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Mnemonic";
            lvItem.Tag = assemblerMnemonicStyle;
            lvwDisplayItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Operand";
            lvItem.Tag = assemblerOperandStyle;
            lvwDisplayItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Ascii";
            lvItem.Tag = assemblerAsciiStyle;
            lvwDisplayItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Unknown";
            lvItem.Tag = assemblerUnknownStyle;
            lvwDisplayItems.Items.Add(lvItem);

            lvwDisplayItems.EndUpdate();

            lvwDisplayItems.Items[0].Selected = true;
            lvwDisplayItems_SelectedIndexChanged(null, null);
        }

        private void SetupBasicItems()
        {
            lvwDisplayItems.BeginUpdate();

            lvwDisplayItems.Items.Clear();

            ListViewItem lvItem = new ListViewItem();
            lvItem.Text = "Line Number";
            lvItem.Tag = basicLineNumberStyle;
            lvwDisplayItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "String";
            lvItem.Tag = basicStringStyle;
            lvwDisplayItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Number";
            lvItem.Tag = basicNumberStyle;
            lvwDisplayItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Keyword";
            lvItem.Tag = basicKeywordStyle;
            lvwDisplayItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Loop";
            lvItem.Tag = basicLoopStyle;
            lvwDisplayItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Branche";
            lvItem.Tag = basicBrancheStyle;
            lvwDisplayItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Data Statement";
            lvItem.Tag = basicDataKeywordStyle;
            lvwDisplayItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Comment";
            lvItem.Tag = basicCommentStyle;
            lvwDisplayItems.Items.Add(lvItem);

            lvwDisplayItems.EndUpdate();

            lvwDisplayItems.Items[0].Selected = true;
            lvwDisplayItems_SelectedIndexChanged(null, null);
        }

        private void SetupHyperbasicItems()
        {
            lvwDisplayItems.BeginUpdate();

            lvwDisplayItems.Items.Clear();

            ListViewItem lvItem = new ListViewItem();
            lvItem.Text = "Address";
            lvItem.Tag = hyperbasicAddressStyle;
            lvwDisplayItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Label";
            lvItem.Tag = hyperbasicLabelStyle;
            lvwDisplayItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Number";
            lvItem.Tag = hyperbasicNumberStyle;
            lvwDisplayItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "String";
            lvItem.Tag = hyperbasicStringStyle;
            lvwDisplayItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Loop";
            lvItem.Tag = hyperbasicLoopStyle;
            lvwDisplayItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Branche";
            lvItem.Tag = hyperbasicBrancheStyle;
            lvwDisplayItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Code";
            lvItem.Tag = hyperbasicCodeStyle;
            lvwDisplayItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Comment";
            lvItem.Tag = hyperbasicCommentStyle;
            lvwDisplayItems.Items.Add(lvItem);

            lvwDisplayItems.EndUpdate();

            lvwDisplayItems.Items[0].Selected = true;
            lvwDisplayItems_SelectedIndexChanged(null, null);
        }

        private void SetupTeleassItems()
        {
            lvwDisplayItems.BeginUpdate();

            lvwDisplayItems.Items.Clear();

            ListViewItem lvItem = new ListViewItem();
            lvItem.Text = "Address";
            lvItem.Tag = teleassAddressStyle;
            lvwDisplayItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Label";
            lvItem.Tag = teleassLabelStyle;
            lvwDisplayItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Mnemonic";
            lvItem.Tag = teleassMnemonicStyle;
            lvwDisplayItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Operand";
            lvItem.Tag = teleassOperandStyle;
            lvwDisplayItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Comment";
            lvItem.Tag = teleassCommentStyle;
            lvwDisplayItems.Items.Add(lvItem);

            lvwDisplayItems.EndUpdate();

            lvwDisplayItems.Items[0].Selected = true;
            lvwDisplayItems_SelectedIndexChanged(null, null);
        }

        private void DisplayHexDumpListing(TextChangedEventArgs e)
        {
            // Clear style of changed range
            fcSample.ClearStylesBuffer();

            e.ChangedRange.SetStyle(dumpHeadersStyle, @"^(\$[0-9A-F]{2}\s)|(\s\s\s\s\s[0-9A-F]{2}(\s[0-9A-F]{2}){15})", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(dumpHexStyle, @"\s\s[0-9A-F]{2}(\s[0-9A-F]{2}){15}\s\s", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(dumpAsciiStyle, @"\s\s\S{16}", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(dumpMainSelectionBackStyle, "", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(dumpMainSelectionFrontStyle, "", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(dumpSecondarySelectionBackStyle, "", RegexOptions.Multiline);
        }

        private void DisplayAssemblerListing(TextChangedEventArgs e)
        {
            // Clear style of changed range
            fcSample.ClearStylesBuffer();

            e.ChangedRange.SetStyle(assemblerAddressStyle, @"^\$[0-9A-F]{4}\s", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(assemblerUnknownStyle, @"[?]{3}", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(assemblerOperandStyle, @"#{0,1}\({0,1}\$([0-9A-F]){2,4}\){0,1}(,Y|,X){0,1}\){0,1}", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(assemblerMnemonicStyle, @"(ADC|AND|ASL A|ASL|BCC|BCS|BEQ|BMI|BNE|BPL|BVC|BVS|BIT|BRK|CLC|CLD|CLI|CLV|CMP|CPX|CPY|DEC|DEX|DEY|EOR|INC|INX|INY|JMP|JSR|LDA|LDX|LDY|LSR A|LSR|NOP|ORA|PHA|PHP|PLA|PLP|ROL A|ROL|ROR A|ROR|RTI|RTS|SBC|SEC|SED|SEI|STA|STX|STY|TAX|TAY|TSX|TXA|TXS|TYA)", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(assemblerHexStyle, @"[0-9A-F]{2}\s", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(assemblerAsciiStyle, @"\S", RegexOptions.Multiline);
        }

        private void DisplayBasicListing(TextChangedEventArgs e)
        {
            fcSample.LeftBracket = '(';
            fcSample.RightBracket = ')';
            fcSample.LeftBracket2 = '\x0';
            fcSample.RightBracket2 = '\x0';

            // Clear style of changed range
            fcSample.ClearStylesBuffer();

            e.ChangedRange.SetStyle(basicDataKeywordStyle, @"(DATA.*)", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(basicStringStyle, @"""""|@""""|@"".*?""|(?<!@)(?<range>"".*?[^\\]"")");
            e.ChangedRange.SetStyle(basicCommentStyle, @"(REM|\s').*$", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(basicLineNumberStyle, @"^[0-9]{1,5}", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(basicNumberStyle, @"#(([0-9A-Fa-f]){1,4})|(\d+[\.]?\d*([eE]\-?\d+)?)");
            e.ChangedRange.SetStyle(basicLoopStyle, @"(REPEAT|UNTIL|FOR|NEXT)");
            e.ChangedRange.SetStyle(basicBrancheStyle, @"(GOSUB|GOTO|ON|RETURN)");
            e.ChangedRange.SetStyle(basicKeywordStyle, @"(POP|PULL|RESTORE|STEP|PING|EXPLODE|DEF|POKE|PRINT|CONT|LIST|CLEAR|GET|CALL|NEW|TAB|TO|FN|SPC|AUTO|ELSE|THEN|NOT|AND|OR|SGN|INT|ABS|USR|FRE|POS|HEX\$|SQR|RND|LN|EXP|COS|SIN|TAN|ATN|PEEK|DEEK|LOG|LEN|STR\$|VAL|ASC|CHR\$|PI|TRUE|FALSE|KEY\$|SCRN|POINT|LEFT\$|RIGHT\$|MID\$|END|EDIT|STORE|RECALL|TRON|TROFF|PLOT|LORES|DOKE|LLIST|LPRINT|INPUT|DIM|CLS|READ|LET|RUN|IF|HIMEM|GRAB|RELEASE|TEXT|HIRES|SHOOT|ZAP|SOUND|MUSIC|PLAY|CURSET|CURMOV|DRAW|CIRCLE|PATTERN|FILL|CHAR|PAPER|INK|STOP|ON|WAIT|CLOAD|CSAVE)");
        }

        private void DisplayHyperbasicListing(TextChangedEventArgs e)
        {
            fcSample.LeftBracket = '(';
            fcSample.RightBracket = ')';
            fcSample.LeftBracket2 = '\x0';
            fcSample.RightBracket2 = '\x0';

            // Clear style of changed range
            fcSample.ClearStylesBuffer();

            e.ChangedRange.SetStyle(hyperbasicAddressStyle, @"^[ 0-9]{6} ", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(hyperbasicCommentStyle, @"(REM|'\s).*$", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(hyperbasicLabelStyle, @"\]\w*", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(hyperbasicNumberStyle, @"#(([0-9A-Fa-f]){1,4})|(\d+[\.]?\d*([eE]\-?\d+)?)");
            e.ChangedRange.SetStyle(hyperbasicStringStyle, @"""""|@""""|@"".*?""|(?<!@)(?<range>"".*?[^\\]"")");
            e.ChangedRange.SetStyle(hyperbasicLoopStyle, @"(REPEAT|UNTIL|FOR|TO|NEXT|STEP|WHILE|WEND|COUNT|UNCOUNT)");
            e.ChangedRange.SetStyle(hyperbasicBrancheStyle, @"(GOSUB|GOTO|ON|RETURN)");
            e.ChangedRange.SetStyle(hyperbasicCodeStyle, @"\S", RegexOptions.Multiline);
        }

        private void DisplayTeleassListing(TextChangedEventArgs e)
        {
            // Clear style of changed range
            fcSample.ClearStylesBuffer();

            e.ChangedRange.SetStyle(teleassAddressStyle, @"^[ 0-9]{6} ", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(teleassLabelStyle, @"^((.){6}) [^'].{0,6}", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(teleassMnemonicStyle, @"^((.){6}) [^'].{0,9}", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(teleassCommentStyle, @"\'.*$", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(teleassOperandStyle, @"\S", RegexOptions.Multiline);
        }

        private void lvwDisplayItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwDisplayItems.SelectedItems.Count > 0)
            {
                TextStyle textStyle = (TextStyle)lvwDisplayItems.SelectedItems[0].Tag;

                lblForegroundColor.BackColor = ((SolidBrush)textStyle.ForeBrush).Color;

                chkStyleBold.Checked = (textStyle.FontStyle & FontStyle.Bold) > 0;
                chkStyleItalic.Checked = (textStyle.FontStyle & FontStyle.Italic) > 0;
                chkStyleUnderline.Checked = (textStyle.FontStyle & FontStyle.Underline) > 0;

                lblForegroundColor.Enabled = chkStyleBold.Enabled = chkStyleItalic.Enabled = chkStyleUnderline.Enabled = true;
            }
            else
            {
                lblForegroundColor.BackColor = Color.Gainsboro;
                lblForegroundColor.Enabled = chkStyleBold.Enabled = chkStyleItalic.Enabled = chkStyleUnderline.Enabled = false;
            }
        }

        private void chkStyleBold_Click(object sender, EventArgs e)
        {
            UpdateFontStyle();
        }

        private void chkStyleItalic_Click(object sender, EventArgs e)
        {
            UpdateFontStyle();
        }

        private void chkStyleUnderline_Click(object sender, EventArgs e)
        {
            UpdateFontStyle();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Configuration.Persistent.PageBackground = pageBackground;

            // Save updates

            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpHeadersStyle] = new TextStyle(dumpHeadersStyle.ForeBrush, null, FontStyle.Regular);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpHexStyle] = new TextStyle(dumpHexStyle.ForeBrush, null, FontStyle.Regular);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpAsciiStyle] = new TextStyle(dumpAsciiStyle.ForeBrush, null, FontStyle.Regular);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpMainSelectionBackStyle] = new TextStyle(dumpMainSelectionBackStyle.ForeBrush, null, FontStyle.Regular);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpMainSelectionFrontStyle] = new TextStyle(dumpMainSelectionFrontStyle.ForeBrush, null, FontStyle.Regular);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpSecondarySelectionBackStyle] = new TextStyle(dumpSecondarySelectionBackStyle.ForeBrush, null, FontStyle.Regular);

            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerAddressStyle] = new TextStyle(assemblerAddressStyle.ForeBrush, null, assemblerAddressStyle.FontStyle);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerHexStyle] = new TextStyle(assemblerHexStyle.ForeBrush, null, assemblerHexStyle.FontStyle);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerMnemonicStyle] = new TextStyle(assemblerMnemonicStyle.ForeBrush, null, assemblerMnemonicStyle.FontStyle);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerOperandStyle] = new TextStyle(assemblerOperandStyle.ForeBrush, null, assemblerOperandStyle.FontStyle);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerAsciiStyle] = new TextStyle(assemblerAsciiStyle.ForeBrush, null, assemblerAsciiStyle.FontStyle);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.AssemblerUnknownStyle] = new TextStyle(assemblerUnknownStyle.ForeBrush, null, assemblerUnknownStyle.FontStyle);
            
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicLineNumber] = new TextStyle(basicLineNumberStyle.ForeBrush, null, basicLineNumberStyle.FontStyle);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicKeyword] = new TextStyle(basicKeywordStyle.ForeBrush, null, basicKeywordStyle.FontStyle);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicBranches] = new TextStyle(basicBrancheStyle.ForeBrush, null, basicBrancheStyle.FontStyle);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicLoops] = new TextStyle(basicLoopStyle.ForeBrush, null, basicLoopStyle.FontStyle);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicString] = new TextStyle(basicStringStyle.ForeBrush, null, basicStringStyle.FontStyle);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicNumber] = new TextStyle(basicNumberStyle.ForeBrush, null, basicNumberStyle.FontStyle);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicDataKeyword] = new TextStyle(basicDataKeywordStyle.ForeBrush, null, basicDataKeywordStyle.FontStyle);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.BasicComment] = new TextStyle(basicCommentStyle.ForeBrush, null, basicCommentStyle.FontStyle);

            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.HyperbasicAddressStyle] = new TextStyle(hyperbasicAddressStyle.ForeBrush, null, hyperbasicAddressStyle.FontStyle);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.HyperbasicLabelStyle] = new TextStyle(hyperbasicLabelStyle.ForeBrush, null, hyperbasicLabelStyle.FontStyle);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.HyperbasicNumberStyle] = new TextStyle(hyperbasicNumberStyle.ForeBrush, null, hyperbasicNumberStyle.FontStyle);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.HyperbasicStringStyle] = new TextStyle(hyperbasicStringStyle.ForeBrush, null, hyperbasicStringStyle.FontStyle);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.HyperbasicLoopStyle] = new TextStyle(hyperbasicLoopStyle.ForeBrush, null, hyperbasicLoopStyle.FontStyle);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.HyperbasicBrancheStyle] = new TextStyle(hyperbasicBrancheStyle.ForeBrush, null, hyperbasicBrancheStyle.FontStyle);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.HyperbasicCodeStyle] = new TextStyle(hyperbasicCodeStyle.ForeBrush, null, hyperbasicCodeStyle.FontStyle);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.HyperbasicCommentStyle] = new TextStyle(hyperbasicCommentStyle.ForeBrush, null, hyperbasicCommentStyle.FontStyle);

            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.TeleassAddressStyle] = new TextStyle(teleassAddressStyle.ForeBrush, null, teleassAddressStyle.FontStyle);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.TeleassLabelStyle] = new TextStyle(teleassLabelStyle.ForeBrush, null, teleassLabelStyle.FontStyle);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.TeleassMnemonicStyle] = new TextStyle(teleassMnemonicStyle.ForeBrush, null, teleassMnemonicStyle.FontStyle);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.TeleassOperandStyle] = new TextStyle(teleassOperandStyle.ForeBrush, null, teleassOperandStyle.FontStyle);
            syntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.TeleassCommentStyle] = new TextStyle(teleassCommentStyle.ForeBrush, null, teleassCommentStyle.FontStyle);

            Configuration.Persistent.SyntaxHighlightingStyles = syntaxHighlightingStyles;
            Configuration.Persistent.Save();

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            SetDefaults();

            fcSample.BackBrush = new SolidBrush(pageBackground);
            lblPageBackgroundColor.BackColor = pageBackground;

            if (optHexDumpListing.Checked)
            {
                SetupHexDumpItems();
            }
            else if (optAssemblerListing.Checked)
            {
                SetupAssemblerItems();
            }
            else if (optBasicListing.Checked)
            {
                SetupBasicItems();
            }
            else if (optHyperbasicListing.Checked)
            {
                SetupHyperbasicItems();
            }
            else if (optTeleassListing.Checked)
            {
                SetupTeleassItems();
            }

            fcSample.OnTextChanged();
        }

        private void SetDefaults()
        {
            pageBackground = ConstantsAndEnums.BACKGROUND;

            // Text styles for dump listings
            dumpHeadersStyle = new TextStyle(ConstantsAndEnums.DUMP_HEADER_STYLE.ForeBrush, null, FontStyle.Regular);
            dumpHexStyle = new TextStyle(ConstantsAndEnums.DUMP_HEX_STYLE.ForeBrush, null, FontStyle.Regular);
            dumpAsciiStyle = new TextStyle(ConstantsAndEnums.DUMP_ASCII_STYLE.ForeBrush, null, FontStyle.Regular);
            dumpMainSelectionBackStyle = new TextStyle(ConstantsAndEnums.DUMP_MAIN_SELECTION_BACK_STYLE.ForeBrush, null, FontStyle.Regular);
            dumpMainSelectionFrontStyle = new TextStyle(ConstantsAndEnums.DUMP_MAIN_SELECTION_FRONT_STYLE.ForeBrush, null, FontStyle.Regular);
            dumpSecondarySelectionBackStyle = new TextStyle(ConstantsAndEnums.DUMP_SECONDARY_SELECTION_BACK_STYLE.ForeBrush, null, FontStyle.Regular);

            // Text styles for assembler listings
            assemblerAddressStyle = new TextStyle(ConstantsAndEnums.ASSEMBLER_ADDRESS_STYLE.ForeBrush, null, ConstantsAndEnums.ASSEMBLER_ADDRESS_STYLE.FontStyle);
            assemblerHexStyle = new TextStyle(ConstantsAndEnums.ASSEMBLER_HEX_STYLE.ForeBrush, null, ConstantsAndEnums.ASSEMBLER_HEX_STYLE.FontStyle);
            assemblerMnemonicStyle = new TextStyle(ConstantsAndEnums.ASSEMBLER_MNEMONIC_STYLE.ForeBrush, null, ConstantsAndEnums.ASSEMBLER_MNEMONIC_STYLE.FontStyle);
            assemblerOperandStyle = new TextStyle(ConstantsAndEnums.ASSEMBLER_OPERAND_STYLE.ForeBrush, null, ConstantsAndEnums.ASSEMBLER_OPERAND_STYLE.FontStyle);
            assemblerAsciiStyle = new TextStyle(ConstantsAndEnums.ASSEMBLER_ASCII_STYLE.ForeBrush, null, ConstantsAndEnums.ASSEMBLER_ASCII_STYLE.FontStyle);
            assemblerUnknownStyle = new TextStyle(ConstantsAndEnums.ASSEMBLER_UNKNOWN_STYLE.ForeBrush, null, ConstantsAndEnums.ASSEMBLER_UNKNOWN_STYLE.FontStyle);

            // Text styles for BASIC listing
            basicLineNumberStyle = new TextStyle(ConstantsAndEnums.BASIC_LINE_NUMBER_STYLE.ForeBrush, null, ConstantsAndEnums.BASIC_LINE_NUMBER_STYLE.FontStyle);
            basicKeywordStyle = new TextStyle(ConstantsAndEnums.BASIC_KEYWORD_STYLE.ForeBrush, null, ConstantsAndEnums.BASIC_KEYWORD_STYLE.FontStyle);
            basicBrancheStyle = new TextStyle(ConstantsAndEnums.BASIC_BRANCHE_STYLE.ForeBrush, null, ConstantsAndEnums.BASIC_BRANCHE_STYLE.FontStyle); 
            basicLoopStyle = new TextStyle(ConstantsAndEnums.BASIC_LOOP_STYLE.ForeBrush, null, ConstantsAndEnums.BASIC_LOOP_STYLE.FontStyle);
            basicStringStyle = new TextStyle(ConstantsAndEnums.BASIC_STRING_STYLE.ForeBrush, null, ConstantsAndEnums.BASIC_STRING_STYLE.FontStyle);
            basicNumberStyle = new TextStyle(ConstantsAndEnums.BASIC_NUMBER_STYLE.ForeBrush, null, ConstantsAndEnums.BASIC_NUMBER_STYLE.FontStyle); 
            basicDataKeywordStyle = new TextStyle(ConstantsAndEnums.BASIC_DATA_KEYWORD_STYLE.ForeBrush, null, ConstantsAndEnums.BASIC_DATA_KEYWORD_STYLE.FontStyle);
            basicCommentStyle = new TextStyle(ConstantsAndEnums.BASIC_COMMENT_STYLE.ForeBrush, null, ConstantsAndEnums.BASIC_COMMENT_STYLE.FontStyle);

            hyperbasicAddressStyle = new TextStyle(ConstantsAndEnums.HYPERBASIC_ADDRESS_STYLE.ForeBrush, null, ConstantsAndEnums.HYPERBASIC_ADDRESS_STYLE.FontStyle);
            hyperbasicLabelStyle = new TextStyle(ConstantsAndEnums.HYPERBASIC_LABEL_STYLE.ForeBrush, null, ConstantsAndEnums.HYPERBASIC_LABEL_STYLE.FontStyle);
            hyperbasicNumberStyle = new TextStyle(ConstantsAndEnums.HYPERBASIC_NUMBER_STYLE.ForeBrush, null, ConstantsAndEnums.HYPERBASIC_NUMBER_STYLE.FontStyle);
            hyperbasicStringStyle = new TextStyle(ConstantsAndEnums.HYPERBASIC_STRING_STYLE.ForeBrush, null, ConstantsAndEnums.HYPERBASIC_STRING_STYLE.FontStyle);
            hyperbasicLoopStyle = new TextStyle(ConstantsAndEnums.HYPERBASIC_LOOP_STYLE.ForeBrush, null, ConstantsAndEnums.HYPERBASIC_LOOP_STYLE.FontStyle);
            hyperbasicBrancheStyle = new TextStyle(ConstantsAndEnums.HYPERBASIC_BRANCHE_STYLE.ForeBrush, null, ConstantsAndEnums.HYPERBASIC_BRANCHE_STYLE.FontStyle);
            hyperbasicCodeStyle = new TextStyle(ConstantsAndEnums.HYPERBASIC_CODE_STYLE.ForeBrush, null, ConstantsAndEnums.HYPERBASIC_CODE_STYLE.FontStyle);
            hyperbasicCommentStyle = new TextStyle(ConstantsAndEnums.HYPERBASIC_COMMENT_STYLE.ForeBrush, null, ConstantsAndEnums.HYPERBASIC_COMMENT_STYLE.FontStyle);

            teleassAddressStyle = new TextStyle(ConstantsAndEnums.TELEASS_ADDRESS_STYLE.ForeBrush, null, ConstantsAndEnums.TELEASS_ADDRESS_STYLE.FontStyle);
            teleassLabelStyle = new TextStyle(ConstantsAndEnums.TELEASS_LABEL_STYLE.ForeBrush, null, ConstantsAndEnums.TELEASS_LABEL_STYLE.FontStyle);
            teleassMnemonicStyle = new TextStyle(ConstantsAndEnums.TELEASS_MNEMONIC_STYLE.ForeBrush, null, ConstantsAndEnums.TELEASS_MNEMONIC_STYLE.FontStyle);
            teleassOperandStyle = new TextStyle(ConstantsAndEnums.TELEASS_OPERAND_STYLE.ForeBrush, null, ConstantsAndEnums.TELEASS_OPERAND_STYLE.FontStyle);
            teleassCommentStyle = new TextStyle(ConstantsAndEnums.TELEASS_COMMENT_STYLE.ForeBrush, null, ConstantsAndEnums.TELEASS_COMMENT_STYLE.FontStyle);
        }

        private void UpdateForeColor(Color foreColor)
        {
            TextStyle textStyle = (TextStyle)lvwDisplayItems.SelectedItems[0].Tag;
            textStyle.ForeBrush = new SolidBrush(foreColor);

            fcSample.OnTextChanged();
        }

        private void UpdateFontStyle()
        {
            TextStyle textStyle = (TextStyle)lvwDisplayItems.SelectedItems[0].Tag;
            textStyle.FontStyle = (chkStyleBold.Checked ? FontStyle.Bold : FontStyle.Regular) |
                                  (chkStyleItalic.Checked ? FontStyle.Italic : FontStyle.Regular) |
                                  (chkStyleUnderline.Checked ? FontStyle.Underline : FontStyle.Regular);

            fcSample.OnTextChanged();
        }

        private void lblForegroundColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.Color = lblForegroundColor.BackColor;

                DialogResult result = colorDialog.ShowDialog();

                if(result == DialogResult.OK)
                {
                    Color selectedColor = colorDialog.Color;
                    UpdateForeColor(selectedColor);
                    lblForegroundColor.BackColor = selectedColor;
                }
            }
        }

        private void lblPageBackgroundColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.Color = lblPageBackgroundColor.BackColor;

                DialogResult result = colorDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    Color selectedColor = colorDialog.Color;
                    pageBackground = selectedColor;
                    lblPageBackgroundColor.BackColor = selectedColor;

                    fcSample.BackBrush = new SolidBrush(selectedColor);
                    fcSample.OnTextChanged();
                }
            }
        }

        private void fcSample_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (optHexDumpListing.Checked)
            {
                DisplayHexDumpListing(e);
            }
            else if (optAssemblerListing.Checked)
            {
                DisplayAssemblerListing(e);
            }
            else if (optBasicListing.Checked)
            {
                DisplayBasicListing(e);
            }
            else if (optHyperbasicListing.Checked)
            {
                DisplayHyperbasicListing(e);
            }
            else if (optTeleassListing.Checked)
            {
                DisplayTeleassListing(e);
            }
        }
    }
}
