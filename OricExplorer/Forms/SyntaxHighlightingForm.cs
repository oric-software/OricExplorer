using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OricExplorer.Configuration;
using static System.Windows.Forms.ListView;

namespace OricExplorer.Forms
{
    public partial class SyntaxHighlightingForm : Form
    {
        Configuration configuration;

        Dictionary<SyntaxHighlightingItems, TextStyle> colours;

        Color pageBackground;

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

        public SyntaxHighlightingForm()
        {
            InitializeComponent();
        }

        private void SetDefaults()
        {
            pageBackground = Color.FromArgb(30, 30, 30);

            // Text styles for Assembler Listings
            /*AddressStyle = new TextStyle(new SolidBrush(Color.FromArgb(230, 174, 13)), null, FontStyle.Regular);
            HexStyle = new TextStyle(Brushes.White, null, FontStyle.Regular);
            AssemblerStyle = new TextStyle(Brushes.Yellow, null, FontStyle.Regular);
            AssemblerStyle2 = new TextStyle(Brushes.Yellow, null, FontStyle.Regular);
            AsciiStyle = new TextStyle(new SolidBrush(Color.FromArgb(120, 120, 120)), null, FontStyle.Regular);
            UnknownStyle = new TextStyle(Brushes.Red, null, FontStyle.Regular);*/

            // Text styles for BASIC Listing
            StringStyle.ForeBrush = new SolidBrush(Color.FromArgb(214, 157, 133));
            StringStyle.FontStyle = FontStyle.Regular;

            CommentStyle.ForeBrush = new SolidBrush(Color.FromArgb(87, 166, 74));
            CommentStyle.FontStyle = FontStyle.Regular;

            DataKeywordStyle.ForeBrush = new SolidBrush(Color.FromArgb(78, 201, 176));
            DataKeywordStyle.FontStyle = FontStyle.Regular;

            LineNumberStyle.ForeBrush = new SolidBrush(Color.FromArgb(43, 145, 175));
            LineNumberStyle.FontStyle = FontStyle.Regular;

            NumberStyle.ForeBrush = new SolidBrush(Color.FromArgb(181, 206, 168));
            NumberStyle.FontStyle = FontStyle.Regular;

            HexNumberStyle.ForeBrush = new SolidBrush(Color.FromArgb(181, 206, 168));
            HexNumberStyle.FontStyle = FontStyle.Regular;

            LoopsStyle.ForeBrush = new SolidBrush(Color.White);
            LoopsStyle.FontStyle = FontStyle.Regular;

            BranchesStyle.ForeBrush = new SolidBrush(Color.White);
            BranchesStyle.FontStyle = FontStyle.Regular;

            KeywordStyle.ForeBrush = new SolidBrush(Color.FromArgb(86, 156, 214));
            KeywordStyle.FontStyle = FontStyle.Regular;
        }

        private void SetupBasicItems()
        {
            listViewItems.BeginUpdate();

            listViewItems.Items.Clear();

            ListViewItem lvItem = new ListViewItem();
            lvItem.Text = "Data Statements";
            lvItem.Tag = (SolidBrush)DataKeywordStyle.ForeBrush;
            listViewItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Strings";
            lvItem.Tag = (SolidBrush)StringStyle.ForeBrush;
            listViewItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Comments";
            lvItem.Tag = (SolidBrush)CommentStyle.ForeBrush;
            listViewItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Line Number";
            lvItem.Tag = (SolidBrush)LineNumberStyle.ForeBrush;
            listViewItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Hex Values";
            lvItem.Tag = (SolidBrush)HexNumberStyle.ForeBrush;
            listViewItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Numerics";
            lvItem.Tag = (SolidBrush)NumberStyle.ForeBrush;
            listViewItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Loops";
            lvItem.Tag = (SolidBrush)LoopsStyle.ForeBrush;
            listViewItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Branches";
            lvItem.Tag = (SolidBrush)BranchesStyle.ForeBrush;
            listViewItems.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "Keywords";
            lvItem.Tag = (SolidBrush)KeywordStyle.ForeBrush;
            listViewItems.Items.Add(lvItem);

            listViewItems.EndUpdate();
        }

        private void SetupUserColours()
        {
            pageBackground = configuration.PageBackground;
            fastColoredTextBoxSample.BackBrush = new SolidBrush(pageBackground);

            // Setup colours from Configuration
            colours = configuration.SyntaxHighlightingSettings;

            try
            {
                StringStyle = colours[SyntaxHighlightingItems.String];
                CommentStyle = colours[SyntaxHighlightingItems.Comment];
                KeywordStyle = colours[SyntaxHighlightingItems.Keyword];
                LoopsStyle = colours[SyntaxHighlightingItems.Loops];
                BranchesStyle = colours[SyntaxHighlightingItems.Branches];
                DataKeywordStyle = colours[SyntaxHighlightingItems.DataKeyword];
                LineNumberStyle = colours[SyntaxHighlightingItems.LineNumber];
                NumberStyle = colours[SyntaxHighlightingItems.Number];
                HexNumberStyle = colours[SyntaxHighlightingItems.HexNumber];

                fastColoredTextBoxSample.OnTextChanged();
            }
            catch(Exception ex)
            {
                String message = ex.Message;
            }
        }

        private void SyntaxHighlightingForm_Load(object sender, EventArgs e)
        {
            SetDefaults();

            configuration = new Configuration();

            SetupUserColours();

            radioButtonBasicListing.Checked = true;

            labelPageBackgroundColour.BackColor = pageBackground;
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

            SolidBrush tmp = (SolidBrush)LineNumberStyle.ForeBrush;
            labelForegroundColour.BackColor = tmp.Color;

            listViewItems.Items[0].Selected = true;
        }

        private void radioButtonAssemblerListing_CheckedChanged(object sender, EventArgs e)
        {
            fastColoredTextBoxSample.Text  = "$0500  4C 74 21    JMP $2174      Lt!\r\n";
            fastColoredTextBoxSample.Text += "$0503  20 51 41    JSR $4151       QA\r\n";
            fastColoredTextBoxSample.Text += "$0506  43          ???            C\r\n";
            fastColoredTextBoxSample.Text += "$0507  54          ???            T\r\n";
            fastColoredTextBoxSample.Text += "$0508  00          BRK            .\r\n";
            fastColoredTextBoxSample.Text += "$0509  16 49       ASL $49,X      .I\r\n";
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
            fastColoredTextBoxSample.LeftBracket = '(';
            fastColoredTextBoxSample.RightBracket = ')';
            fastColoredTextBoxSample.LeftBracket2 = '\x0';
            fastColoredTextBoxSample.RightBracket2 = '\x0';

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

        private void checkBoxBold_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBold.Checked)
            {
                UpdateFontStyle(FontStyle.Bold, true);
            }
            else
            {
                UpdateFontStyle(FontStyle.Bold, false);
            }
        }

        private void checkBoxItalic_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxItalic.Checked)
            {
                UpdateFontStyle(FontStyle.Italic, true);
            }
            else
            {
                UpdateFontStyle(FontStyle.Italic, false);
            }
        }

        private void checkBoxUnderline_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxUnderline.Checked)
            {
                UpdateFontStyle(FontStyle.Underline, true);
            }
            else
            {
                UpdateFontStyle(FontStyle.Underline, false);
            }
        }

        private void buttonOkay_Click(object sender, EventArgs e)
        {
            configuration.PageBackground = pageBackground;

            // Save updates
            colours[SyntaxHighlightingItems.String] = new TextStyle(StringStyle.ForeBrush, null, StringStyle.FontStyle);
            colours[SyntaxHighlightingItems.Comment] = new TextStyle(CommentStyle.ForeBrush, null, CommentStyle.FontStyle);
            colours[SyntaxHighlightingItems.Keyword] = new TextStyle(KeywordStyle.ForeBrush, null, KeywordStyle.FontStyle);
            colours[SyntaxHighlightingItems.Loops] = new TextStyle(LoopsStyle.ForeBrush, null, LoopsStyle.FontStyle);
            colours[SyntaxHighlightingItems.Branches] = new TextStyle(BranchesStyle.ForeBrush, null, BranchesStyle.FontStyle);
            colours[SyntaxHighlightingItems.DataKeyword] = new TextStyle(DataKeywordStyle.ForeBrush, null, DataKeywordStyle.FontStyle);
            colours[SyntaxHighlightingItems.LineNumber] = new TextStyle(LineNumberStyle.ForeBrush, null, LineNumberStyle.FontStyle);
            colours[SyntaxHighlightingItems.Number] = new TextStyle(NumberStyle.ForeBrush, null, NumberStyle.FontStyle);
            colours[SyntaxHighlightingItems.HexNumber] = new TextStyle(HexNumberStyle.ForeBrush, null, HexNumberStyle.FontStyle);

            configuration.SyntaxHighlightingSettings = colours;
            configuration.SaveSettings();

            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void listViewItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedIndexCollection selectedIndexes = listViewItems.SelectedIndices;

            if (selectedIndexes.Count > 0)
            {
                int index = selectedIndexes[0];

                TextStyle textStyle = (TextStyle)fastColoredTextBoxSample.Styles[index];

                SolidBrush tmp = (SolidBrush)textStyle.ForeBrush;
                labelForegroundColour.BackColor = tmp.Color;
            }
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

        private void UpdateFontStyle(FontStyle fontStyle, Boolean addFontStyle)
        {
            SelectedIndexCollection selectedIndexes = listViewItems.SelectedIndices;

            if (selectedIndexes.Count > 0)
            {
                int index = selectedIndexes[0];

                TextStyle textStyle = (TextStyle)fastColoredTextBoxSample.Styles[index];

                if (addFontStyle)
                {
                    textStyle.FontStyle |= fontStyle;
                }
                else
                {
                    textStyle.FontStyle &= ~fontStyle;
                }

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

        private void buttonDefault_Click(object sender, EventArgs e)
        {
            SetDefaults();
            SetupBasicItems();

            fastColoredTextBoxSample.OnTextChanged();
        }
    }
}
