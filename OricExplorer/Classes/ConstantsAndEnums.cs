namespace OricExplorer
{
    using FastColoredTextBoxNS;
    using System.Drawing;

    public static class ConstantsAndEnums
    {
        public const string APP_VERSION_URL = "https://github.com/oric-software/OricExplorer/raw/master/dist/app_version.xml";
        public const string UPDATE_EXTENSION = ".update";

        public static readonly Color BACKGROUND = Color.FromArgb(30, 30, 30);

        public static readonly TextStyle DUMP_HEADER_STYLE = new TextStyle(Brushes.Teal, null, FontStyle.Regular);
        public static readonly TextStyle DUMP_HEX_STYLE = new TextStyle(Brushes.Gainsboro, null, FontStyle.Regular);
        public static readonly TextStyle DUMP_ASCII_STYLE = new TextStyle(Brushes.Gray, null, FontStyle.Regular);
        public static readonly TextStyle DUMP_MAIN_SELECTION_BACK_STYLE = new TextStyle(Brushes.Red, null, FontStyle.Regular);
        public static readonly TextStyle DUMP_MAIN_SELECTION_FRONT_STYLE = new TextStyle(Brushes.Yellow, null, FontStyle.Regular);
        public static readonly TextStyle DUMP_SECONDARY_SELECTION_BACK_STYLE = new TextStyle(Brushes.DarkBlue, null, FontStyle.Regular);

        public static readonly TextStyle ASSEMBLER_ADDRESS_STYLE = new TextStyle(Brushes.Teal, null, FontStyle.Regular);
        public static readonly TextStyle ASSEMBLER_HEX_STYLE = new TextStyle(Brushes.Gainsboro, null, FontStyle.Regular);
        public static readonly TextStyle ASSEMBLER_MNEMONIC_STYLE = new TextStyle(Brushes.Yellow, null, FontStyle.Regular);
        public static readonly TextStyle ASSEMBLER_OPERAND_STYLE = new TextStyle(Brushes.YellowGreen, null, FontStyle.Regular);
        public static readonly TextStyle ASSEMBLER_UNKNOWN_STYLE = new TextStyle(Brushes.Red, null, FontStyle.Regular);
        public static readonly TextStyle ASSEMBLER_ASCII_STYLE = new TextStyle(Brushes.Gray, null, FontStyle.Regular);

        public static readonly TextStyle BASIC_LINE_NUMBER_STYLE = new TextStyle(Brushes.Teal, null, FontStyle.Regular);
        public static readonly TextStyle BASIC_NUMBER_STYLE = new TextStyle(Brushes.Cyan, null, FontStyle.Regular);
        public static readonly TextStyle BASIC_STRING_STYLE = new TextStyle(Brushes.Tan, null, FontStyle.Regular);
        public static readonly TextStyle BASIC_LOOP_STYLE = new TextStyle(Brushes.Magenta, null, FontStyle.Regular);
        public static readonly TextStyle BASIC_BRANCHE_STYLE = new TextStyle(Brushes.Yellow, null, FontStyle.Regular);
        public static readonly TextStyle BASIC_KEYWORD_STYLE = new TextStyle(Brushes.Blue, null, FontStyle.Regular);
        public static readonly TextStyle BASIC_DATA_KEYWORD_STYLE = new TextStyle(Brushes.GreenYellow, null, FontStyle.Regular);
        public static readonly TextStyle BASIC_COMMENT_STYLE = new TextStyle(Brushes.Green, null, FontStyle.Regular);

        public static readonly TextStyle HYPERBASIC_ADDRESS_STYLE = new TextStyle(Brushes.Teal, null, FontStyle.Regular);
        public static readonly TextStyle HYPERBASIC_LABEL_STYLE = new TextStyle(Brushes.Orange, null, FontStyle.Regular);
        public static readonly TextStyle HYPERBASIC_NUMBER_STYLE = new TextStyle(Brushes.Cyan, null, FontStyle.Regular);
        public static readonly TextStyle HYPERBASIC_STRING_STYLE = new TextStyle(Brushes.Tan, null, FontStyle.Regular);
        public static readonly TextStyle HYPERBASIC_LOOP_STYLE = new TextStyle(Brushes.Magenta, null, FontStyle.Regular);
        public static readonly TextStyle HYPERBASIC_BRANCHE_STYLE = new TextStyle(Brushes.Yellow, null, FontStyle.Regular);
        public static readonly TextStyle HYPERBASIC_CODE_STYLE = new TextStyle(Brushes.Gainsboro, null, FontStyle.Regular);
        public static readonly TextStyle HYPERBASIC_COMMENT_STYLE = new TextStyle(Brushes.Green, null, FontStyle.Regular);

        public static readonly TextStyle TELEASS_ADDRESS_STYLE = new TextStyle(Brushes.Teal, null, FontStyle.Regular);
        public static readonly TextStyle TELEASS_LABEL_STYLE = new TextStyle(Brushes.Orange, null, FontStyle.Regular);
        public static readonly TextStyle TELEASS_MNEMONIC_STYLE = new TextStyle(Brushes.Yellow, null, FontStyle.Regular);
        public static readonly TextStyle TELEASS_OPERAND_STYLE = new TextStyle(Brushes.YellowGreen, null, FontStyle.Regular);
        public static readonly TextStyle TELEASS_COMMENT_STYLE = new TextStyle(Brushes.Green, null, FontStyle.Regular);


        public static readonly TextStyle[] SyntaxHighlightingDefaultValues = { DUMP_HEADER_STYLE, DUMP_HEX_STYLE, DUMP_ASCII_STYLE, DUMP_MAIN_SELECTION_BACK_STYLE, DUMP_MAIN_SELECTION_FRONT_STYLE, DUMP_SECONDARY_SELECTION_BACK_STYLE, ASSEMBLER_ADDRESS_STYLE, ASSEMBLER_HEX_STYLE, ASSEMBLER_MNEMONIC_STYLE, ASSEMBLER_OPERAND_STYLE, ASSEMBLER_ASCII_STYLE, ASSEMBLER_UNKNOWN_STYLE, BASIC_LINE_NUMBER_STYLE, BASIC_KEYWORD_STYLE, BASIC_BRANCHE_STYLE, BASIC_LOOP_STYLE, BASIC_STRING_STYLE, BASIC_NUMBER_STYLE, BASIC_DATA_KEYWORD_STYLE, BASIC_COMMENT_STYLE, HYPERBASIC_ADDRESS_STYLE, HYPERBASIC_LABEL_STYLE, HYPERBASIC_NUMBER_STYLE, HYPERBASIC_STRING_STYLE, HYPERBASIC_LOOP_STYLE, HYPERBASIC_BRANCHE_STYLE, HYPERBASIC_CODE_STYLE, HYPERBASIC_COMMENT_STYLE, TELEASS_ADDRESS_STYLE, TELEASS_LABEL_STYLE, TELEASS_MNEMONIC_STYLE, TELEASS_OPERAND_STYLE, TELEASS_COMMENT_STYLE };

        public enum SyntaxHighlightingItems { DumpHeadersStyle, DumpHexStyle, DumpAsciiStyle, DumpMainSelectionBackStyle, DumpMainSelectionFrontStyle, DumpSecondarySelectionBackStyle, AssemblerAddressStyle, AssemblerHexStyle, AssemblerMnemonicStyle, AssemblerOperandStyle, AssemblerAsciiStyle, AssemblerUnknownStyle, BasicLineNumber, BasicKeyword, BasicBranches, BasicLoops, BasicString, BasicNumber, BasicDataKeyword, BasicComment, HyperbasicAddressStyle, HyperbasicLabelStyle, HyperbasicNumberStyle, HyperbasicStringStyle, HyperbasicLoopStyle, HyperbasicBrancheStyle, HyperbasicCodeStyle, HyperbasicCommentStyle, TeleassAddressStyle, TeleassLabelStyle, TeleassMnemonicStyle, TeleassOperandStyle, TeleassCommentStyle };

        public enum SortMode { SORT_BY_NAME, SORT_BY_TYPE };
        public enum Machine { Oric1, Atmos, Pravetz, Telestrat };
        public enum MediaType { OricTape, TapeFile, OricDisk, DiskFile, ROMFile, UnknownMedia };
        public enum UserControls { MainView, DataViewer, SectorViewer, ScreenViewer, CharacterSetViewer, DataFileViewer, SequentialFileViewer, None };
        public enum ExportTo { Tape, Text, Raw };
    }
}
