namespace OricExplorer
{
    using System.Collections.Generic;

    public class HyperbasicTokens
    {
        private readonly Dictionary<ushort, string> m_tokenList = new Dictionary<ushort, string>();

        public HyperbasicTokens()
        {
            // Build the Hyperbasic token list
            BuildTokenList();
        }

        public int TokenCount
        {
            get { return m_tokenList.Count; }
        }

        public string GetKeyword(ushort bToken)
        {
            return (m_tokenList.ContainsKey(bToken) ? m_tokenList[bToken] : $"?{bToken}/{bToken:X2}?");
        }

        private void BuildTokenList()
        {
            m_tokenList.Add(0x00, "]");
            m_tokenList.Add(0x01, "RETURN");
            m_tokenList.Add(0x03, "END");
            m_tokenList.Add(0x04, "STOP");
            m_tokenList.Add(0x05, "' ");
            m_tokenList.Add(0x08, "FOR ");
            m_tokenList.Add(0x09, "REPEAT ");
            m_tokenList.Add(0x0A, "COUNT ");
            m_tokenList.Add(0x0B, "WHILE ");
            m_tokenList.Add(0x0D, "NEXT ");
            m_tokenList.Add(0x0E, "UNTIL ");
            m_tokenList.Add(0x0F, "UNCOUNT");
            m_tokenList.Add(0x10, "WEND");
            m_tokenList.Add(0x12, "^");
            m_tokenList.Add(0x13, "*");
            m_tokenList.Add(0x14, "/");
            m_tokenList.Add(0x15, "+");
            m_tokenList.Add(0x16, "-");
            m_tokenList.Add(0x17, "=");
            m_tokenList.Add(0x18, ">=");
            m_tokenList.Add(0x19, "<=");
            m_tokenList.Add(0x1A, "<>");
            m_tokenList.Add(0x1B, ">");
            m_tokenList.Add(0x1C, "<");
            m_tokenList.Add(0x1D, " XOR ");
            m_tokenList.Add(0x1E, " AND ");
            m_tokenList.Add(0x1F, " OR ");

            m_tokenList.Add(0x20, ":");
            m_tokenList.Add(0x21, ",");
            m_tokenList.Add(0x22, ",");
            m_tokenList.Add(0x23, ";");
            m_tokenList.Add(0x24, "");
            m_tokenList.Add(0x25, "");
            m_tokenList.Add(0x26, "");
            m_tokenList.Add(0x28, "");
            m_tokenList.Add(0x2A, "");
            m_tokenList.Add(0x2C, "=");
            m_tokenList.Add(0x2D, "(");
            m_tokenList.Add(0x2E, ")");
            m_tokenList.Add(0x2F, "");

            m_tokenList.Add(0x30, "");
            m_tokenList.Add(0x31, "");
            m_tokenList.Add(0x32, "");
            m_tokenList.Add(0x33, "");
            m_tokenList.Add(0x34, "");
            m_tokenList.Add(0x36, "");
            m_tokenList.Add(0x37, "");
            m_tokenList.Add(0x38, "");
            m_tokenList.Add(0x3A, "");
            m_tokenList.Add(0x3B, ",");
            m_tokenList.Add(0x3C, ",");
            m_tokenList.Add(0x3D, "");
            m_tokenList.Add(0x3F, "]");
            m_tokenList.Add(0x40, "");
            m_tokenList.Add(0x42, ",");
            m_tokenList.Add(0x43, "");
            m_tokenList.Add(0x44, "@");

            m_tokenList.Add(0x80, "COS");
            m_tokenList.Add(0x81, "SIN");
            m_tokenList.Add(0x82, "ABS");
            m_tokenList.Add(0x83, "ATN");
            m_tokenList.Add(0x84, "DEEK");
            m_tokenList.Add(0x85, "DEG");
            m_tokenList.Add(0x86, "EXP");
            m_tokenList.Add(0x87, "LN");
            m_tokenList.Add(0x88, "LOG");
            m_tokenList.Add(0x89, "PEEK");
            m_tokenList.Add(0x8A, "RAD");
            m_tokenList.Add(0x8B, "RND");
            m_tokenList.Add(0x8C, "SQR");
            m_tokenList.Add(0x8D, "TAN");
            m_tokenList.Add(0x8E, "LOB$");
            m_tokenList.Add(0x8F, "LO$");
            m_tokenList.Add(0x90, "UP$");
            m_tokenList.Add(0x91, "BIN$");
            m_tokenList.Add(0x92, "CHR$");
            m_tokenList.Add(0x93, "HEX$");
            m_tokenList.Add(0x94, "SPC$");
            m_tokenList.Add(0x95, "STR$");
            m_tokenList.Add(0x96, "ASC");
            m_tokenList.Add(0x97, "LEN");
            m_tokenList.Add(0x98, "VAL");
            m_tokenList.Add(0x99, "TRUE");
            m_tokenList.Add(0x9A, "FALSE");
            m_tokenList.Add(0x9B, "PI");
            m_tokenList.Add(0x9C, "SGN");
            m_tokenList.Add(0x9D, "INT");
            m_tokenList.Add(0x9E, "KEY$");
            m_tokenList.Add(0x9F, "RAND");
            m_tokenList.Add(0xA0, "REM ");
            m_tokenList.Add(0xA1, "GOTO ");
            m_tokenList.Add(0xA2, "GOSUB ");
            m_tokenList.Add(0xA3, "CLS");
            m_tokenList.Add(0xA4, "PRINT ");
            m_tokenList.Add(0xA5, "LPRINT ");
            m_tokenList.Add(0xA6, "SPRINT ");
            m_tokenList.Add(0xA7, "MPRINT ");
            m_tokenList.Add(0xA8, "GET ");
            m_tokenList.Add(0xA9, "INPUT ");
            m_tokenList.Add(0xAA, "");
            m_tokenList.Add(0xAB, "IF ");
            m_tokenList.Add(0xAC, "ERRGOTO ");
            m_tokenList.Add(0xAD, "MID$");
            m_tokenList.Add(0xAE, "LEFT$");
            m_tokenList.Add(0xAF, "RIGHT$");

            m_tokenList.Add(0xB0, "SET");
            m_tokenList.Add(0xB1, "OFF");
            m_tokenList.Add(0xB2, " TO ");
            m_tokenList.Add(0xB3, " STEP ");
            m_tokenList.Add(0xB4, " ELSE ");
            m_tokenList.Add(0xB5, " THEN ");
            m_tokenList.Add(0xBB, "AUTO");

            m_tokenList.Add(0xC000, "HIRES");
            m_tokenList.Add(0xC001, "TEXT");
            m_tokenList.Add(0xC002, "LIST ");
            m_tokenList.Add(0xC003, "TRACE ");
            m_tokenList.Add(0xC004, "WORD");
            m_tokenList.Add(0xC005, "NEW");
            m_tokenList.Add(0xC007, "RUN ");
            m_tokenList.Add(0xC008, "OUPS");
            m_tokenList.Add(0xC009, "HELP ");
            m_tokenList.Add(0xC00A, "POKE ");
            m_tokenList.Add(0xC00B, "DOKE ");
            m_tokenList.Add(0xC00C, "CALL ");
            m_tokenList.Add(0xC00F, "PING");
            m_tokenList.Add(0xC010, "SHOOT");
            m_tokenList.Add(0xC011, "EXPLODE");
            m_tokenList.Add(0xC012, "ZAP");
            m_tokenList.Add(0xC013, "NMI");
            m_tokenList.Add(0xC014, "RESET");
            m_tokenList.Add(0xC015, "WIDTH ");
            m_tokenList.Add(0xC016, "LWIDTH ");
            m_tokenList.Add(0xC017, "GRAB");
            m_tokenList.Add(0xC018, "RELEASE");
            m_tokenList.Add(0xC019, "LLIST ");
            m_tokenList.Add(0xC01A, "MLIST ");
            m_tokenList.Add(0xC01B, "SLIST ");
            m_tokenList.Add(0xC01C, "LFEED ");
            m_tokenList.Add(0xC01D, "AIDE");
            m_tokenList.Add(0xC01E, "FUNCTION ");
            m_tokenList.Add(0xC01F, "MOVE ");
            m_tokenList.Add(0xC020, "HIMEM ");
            m_tokenList.Add(0xC021, "CURSOR ");
            m_tokenList.Add(0xC022, "LOUT ");
            m_tokenList.Add(0xC023, "WAIT ");
            m_tokenList.Add(0xC024, "PATTERN ");
            m_tokenList.Add(0xC027, "DRV$");
            m_tokenList.Add(0xC029, "EXT$");
            m_tokenList.Add(0xC02A, "EXT ");
            m_tokenList.Add(0xC02B, "TCOPY");
            m_tokenList.Add(0xC02C, "HCOPY");
            m_tokenList.Add(0xC034, "AZERTY");
            m_tokenList.Add(0xC035, "QWERTY");
            m_tokenList.Add(0xC036, "FRENCH");
            m_tokenList.Add(0xC037, "ACCENT ");
            m_tokenList.Add(0xC038, "DELETE ");
            m_tokenList.Add(0xC03D, "ASCII");
            m_tokenList.Add(0xC03E, "TALK ");
            m_tokenList.Add(0xC048, "CLOCKOFF");
            m_tokenList.Add(0xC049, "CLOCKSET ");
            m_tokenList.Add(0xC04A, "SSPEED ");
            m_tokenList.Add(0xC04B, "SMODE ");
            m_tokenList.Add(0xC04C, "ERRLIST");
            m_tokenList.Add(0xC04D, "TIME ");
            m_tokenList.Add(0xC04E, "TIME$");
            m_tokenList.Add(0xC04F, "LBUF ");
            m_tokenList.Add(0xC050, "SRBUF ");
            m_tokenList.Add(0xC051, "SEBUF ");
            m_tokenList.Add(0xC052, "PLOT ");
            m_tokenList.Add(0xC053, "POP");
            m_tokenList.Add(0xC054, "SSAVEA ");
            m_tokenList.Add(0xC055, "SLOADA ");
            m_tokenList.Add(0xC056, "SLOAD ");
            m_tokenList.Add(0xC057, "SSAVE ");
            m_tokenList.Add(0xC058, "SDUMP");
            m_tokenList.Add(0xC05A, "CONSOLE");
            m_tokenList.Add(0xC05B, "MLOADA ");
            m_tokenList.Add(0xC05C, "MSAVEA ");
            m_tokenList.Add(0xC05D, "MLOAD ");
            m_tokenList.Add(0xC05E, "MSAVE ");
            m_tokenList.Add(0xC05F, "RING");
            m_tokenList.Add(0xC060, "CONNECT");
            m_tokenList.Add(0xC061, "WCXFIN");
            m_tokenList.Add(0xC062, "UNCONNECT");
            m_tokenList.Add(0xC063, "SOUT ");
            m_tokenList.Add(0xC064, "MOUT ");
            m_tokenList.Add(0xC065, "POS ");
            m_tokenList.Add(0xC068, "DIR ");
            m_tokenList.Add(0xC06A, "DELBAK ");
            m_tokenList.Add(0xC070, "DEL ");
            m_tokenList.Add(0xC071, "PROT ");
            m_tokenList.Add(0xC072, "UNPROT ");
            m_tokenList.Add(0xC033, "INIT ");
            m_tokenList.Add(0xC074, "LOAD ");
            m_tokenList.Add(0xC075, "SAVEM ");
            m_tokenList.Add(0xC076, "SAVEO ");
            m_tokenList.Add(0xC077, "SAVEU ");
            m_tokenList.Add(0xC078, "SAVE ");
            m_tokenList.Add(0xC079, "BACKUP ");
            m_tokenList.Add(0xC07B, "LDIR ");
            m_tokenList.Add(0xC07C, "DNAME ");
            m_tokenList.Add(0xC07D, "COPYO ");
            m_tokenList.Add(0xC07E, "COPYM ");
            m_tokenList.Add(0xC07F, "COPY ");
            m_tokenList.Add(0xC080, "REN ");
            m_tokenList.Add(0xC083, "ESAVE ");
            m_tokenList.Add(0xC084, "OPEN ");
            m_tokenList.Add(0xC085, "CLOSE ");
            m_tokenList.Add(0xC086, "PUT ");
            m_tokenList.Add(0xC087, "TAKE ");
            m_tokenList.Add(0xC088, "JUMP ");
            m_tokenList.Add(0xC089, "APPEND ");
            m_tokenList.Add(0xC08A, "REWIND ");
            m_tokenList.Add(0xC08B, "SPUT ");
            m_tokenList.Add(0xC08C, "STAKE ");
            m_tokenList.Add(0xC08F, "FST");
            m_tokenList.Add(0xC090, "FILE ");
            m_tokenList.Add(0xC091, "MERGE ");
            m_tokenList.Add(0xC0A0, "CURSET ");
            m_tokenList.Add(0xC0A1, "CURMOV ");
            m_tokenList.Add(0xC0A2, "DRAW ");
            m_tokenList.Add(0xC0A3, "ADRAW ");
            m_tokenList.Add(0xC0A4, "CIRCLE ");
            m_tokenList.Add(0xC0A5, "BOX ");
            m_tokenList.Add(0xC0A6, "ABOX ");
            m_tokenList.Add(0xC0A7, "PAPER ");
            m_tokenList.Add(0xC0A8, "INK ");
            m_tokenList.Add(0xC0A9, "RADIAN");
            m_tokenList.Add(0xC0AA, "DEGRE");
            m_tokenList.Add(0xC0AC, "CLCH ");
            m_tokenList.Add(0xC0AD, "OPCH ");
            m_tokenList.Add(0xC0AE, "CROSSX ");
            m_tokenList.Add(0xC0AF, "CROSS ");
            m_tokenList.Add(0xC0B0, "RANDOM");
            m_tokenList.Add(0xC0B1, "WINDOW ");
            m_tokenList.Add(0xC0B2, "PLAY ");
            m_tokenList.Add(0xC0B3, "SOUND ");
            m_tokenList.Add(0xC0B4, "MUSIC ");
            m_tokenList.Add(0xC0B6, "LORES ");
            m_tokenList.Add(0xC0B7, "LPR ");
            m_tokenList.Add(0xC0B8, "SEI");
            m_tokenList.Add(0xC0B9, "CLI");
            m_tokenList.Add(0xC0C0, "ERRNB ");
            m_tokenList.Add(0xC0C1, "ERRNL ");
            m_tokenList.Add(0xC0C2, "ERROR ");
            m_tokenList.Add(0xC0C3, "RESUME");
            m_tokenList.Add(0xC0C4, "ERROFF");
            m_tokenList.Add(0xC0C5, "CLEAR");
            m_tokenList.Add(0xC0C6, "VCOPY");
            m_tokenList.Add(0xC0CC, "DIM ");
            m_tokenList.Add(0xC0CD, "FRE");
            m_tokenList.Add(0xC0CE, "PAGE$");
            m_tokenList.Add(0xC0CF, "SERVEUR ");
            m_tokenList.Add(0xC0D0, "MINITEL");
            m_tokenList.Add(0xC0D1, "APLIC ");
            m_tokenList.Add(0xC0D2, "TINPUT ");
            m_tokenList.Add(0xC0D4, "MIDDLE$");
            m_tokenList.Add(0xC0D5, "NOT ");
            m_tokenList.Add(0xC0D6, "FILL ");
            m_tokenList.Add(0xC0D7, "CHAR ");
            m_tokenList.Add(0xC0D8, "SCHAR ");
            m_tokenList.Add(0xC0D9, "CONT");
        }
    }
}
