namespace OricExplorer
{
    using FastColoredTextBoxNS;
    using System.Drawing;

    public static class ConstantsAndEnums
    {
        //public const string APP_VERSION_URL = "http://oric.mrandmrsdavies.com/app_version.xml";
        public const string APP_VERSION_URL = "https://github.com/laurentd75/OricExplorer/blob/master/dist/app_version.xml";

        public static readonly Color BACKGROUND = Color.FromArgb(30, 30, 30);
        public static readonly TextStyle BASIC_LINE_NUMBER_STYLE = new TextStyle(Brushes.Teal, null, FontStyle.Regular);
        public static readonly TextStyle BASIC_KEYWORD_STYLE = new TextStyle(new SolidBrush(Color.FromArgb(86, 156, 214)), null, FontStyle.Regular);
        public static readonly TextStyle BASIC_BRANCHES_STYLE = new TextStyle(new SolidBrush(Color.FromArgb(255, 255, 127)), null, FontStyle.Regular);
        public static readonly TextStyle BASIC_LOOPS_STYLE = new TextStyle(new SolidBrush(Color.White), null, FontStyle.Regular);
        public static readonly TextStyle BASIC_STRING_STYLE = new TextStyle(new SolidBrush(Color.FromArgb(214, 157, 133)), null, FontStyle.Regular);
        public static readonly TextStyle BASIC_HEX_NUMBER_STYLE = new TextStyle(new SolidBrush(Color.FromArgb(181, 206, 168)), null, FontStyle.Regular);
        public static readonly TextStyle BASIC_NUMBER_STYLE = new TextStyle(new SolidBrush(Color.FromArgb(181, 206, 168)), null, FontStyle.Regular);
        public static readonly TextStyle BASIC_DATA_KEYWORD_STYLE = new TextStyle(new SolidBrush(Color.FromArgb(78, 201, 176)), null, FontStyle.Regular);
        public static readonly TextStyle BASIC_COMMENT_STYLE = new TextStyle(new SolidBrush(Color.FromArgb(87, 166, 74)), null, FontStyle.Regular);

        public static readonly TextStyle ASSEMBLER_ADDRESS_STYLE = new TextStyle(Brushes.Teal, null, FontStyle.Regular);
        public static readonly TextStyle ASSEMBLER_HEX_STYLE = new TextStyle(Brushes.White, null, FontStyle.Regular);
        public static readonly TextStyle ASSEMBLER_MNEMONIC_STYLE = new TextStyle(Brushes.Yellow, null, FontStyle.Regular);
        public static readonly TextStyle ASSEMBLER_OPERAND_STYLE = new TextStyle(Brushes.YellowGreen, null, FontStyle.Regular);
        public static readonly TextStyle ASSEMBLER_ASCII_STYLE = new TextStyle(new SolidBrush(Color.FromArgb(120, 120, 120)), null, FontStyle.Regular);
        public static readonly TextStyle ASSEMBLER_UNKNOWN_STYLE = new TextStyle(Brushes.Red, null, FontStyle.Regular);

        public static readonly TextStyle DUMP_HEADERS_STYLE = new TextStyle(Brushes.Teal, null, FontStyle.Regular);
        public static readonly TextStyle DUMP_HEX_STYLE = new TextStyle(new SolidBrush(Color.FromArgb(240, 240, 240)), null, FontStyle.Regular);
        public static readonly TextStyle DUMP_ASCII_STYLE = new TextStyle(new SolidBrush(Color.FromArgb(120, 120, 120)), null, FontStyle.Regular);
        public static readonly TextStyle DUMP_MAIN_SELECTION_BACK_STYLE = new TextStyle(Brushes.Red, null, FontStyle.Regular);
        public static readonly TextStyle DUMP_MAIN_SELECTION_FRONT_STYLE = new TextStyle(Brushes.Yellow, null, FontStyle.Regular);
        public static readonly TextStyle DUMP_SECONDARY_SELECTION_BACK_STYLE = new TextStyle(new SolidBrush(Color.FromArgb(60, 188, 255)), null, FontStyle.Regular);

        public static readonly TextStyle[] SyntaxHighlightingDefaultValues = { BASIC_LINE_NUMBER_STYLE, BASIC_KEYWORD_STYLE, BASIC_BRANCHES_STYLE, BASIC_LOOPS_STYLE, BASIC_STRING_STYLE, BASIC_HEX_NUMBER_STYLE, BASIC_NUMBER_STYLE, BASIC_DATA_KEYWORD_STYLE, BASIC_COMMENT_STYLE, ASSEMBLER_ADDRESS_STYLE, ASSEMBLER_HEX_STYLE, ASSEMBLER_MNEMONIC_STYLE, ASSEMBLER_OPERAND_STYLE, ASSEMBLER_ASCII_STYLE, ASSEMBLER_UNKNOWN_STYLE, DUMP_HEADERS_STYLE, DUMP_HEX_STYLE, DUMP_ASCII_STYLE, DUMP_MAIN_SELECTION_BACK_STYLE, DUMP_MAIN_SELECTION_FRONT_STYLE, DUMP_SECONDARY_SELECTION_BACK_STYLE };

        public enum SyntaxHighlightingItems { BasicLineNumber, BasicKeyword, BasicBranches, BasicLoops, BasicString, BasicHexNumber, BasicNumber, BasicDataKeyword, BasicComment, AssemblerAddressStyle, AssemblerHexStyle, AssemblerMnemonicStyle, AssemblerOperandStyle, AssemblerAsciiStyle, AssemblerUnknownStyle, DumpHeadersStyle, DumpHexStyle, DumpAsciiStyle, DumpMainSelectionBackStyle, DumpMainSelectionFrontStyle, DumpSecondarySelectionBackStyle };

        public enum SortMode { SORT_BY_NAME, SORT_BY_TYPE };
        public enum MediaType { OricTape, TapeFile, OricDisk, DiskFile, ROMFile, UnknownMedia };
    }
}
