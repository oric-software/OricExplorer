namespace OricExplorer
{
    using System.Collections;

    public class BasicTokens
    {
		public enum ROMVersion { V1_0, V1_1, Unknown };

        private readonly ArrayList m_tokenList;
		private readonly ROMVersion m_romVers;

        public BasicTokens(ROMVersion RomVers)
        {
			m_romVers = RomVers;

            // Create an array to hold the list of Basic tokens
            m_tokenList = new ArrayList();

            // Build the Basic token list
            BuildTokenList();
        }

        public int TokenCount
        {
            get { return m_tokenList.Count; }
        }

        public string GetBasicToken(byte bToken)
        {
            return m_tokenList[bToken].ToString();
        }

        private void BuildTokenList()
        {
            m_tokenList.Add("END");
            m_tokenList.Add("EDIT");

			if(m_romVers == ROMVersion.V1_1)
			{
            	m_tokenList.Add("STORE");
            	m_tokenList.Add("RECALL");
			}
			else
			{
				m_tokenList.Add("INVERSE");
				m_tokenList.Add("NORMAL");
			}

            m_tokenList.Add("TRON");
            m_tokenList.Add("TROFF");
            m_tokenList.Add("POP");
            m_tokenList.Add("PLOT");
            m_tokenList.Add("PULL");
            m_tokenList.Add("LORES");
            m_tokenList.Add("DOKE");
            m_tokenList.Add("REPEAT");
            m_tokenList.Add("UNTIL");
            m_tokenList.Add("FOR");
            m_tokenList.Add("LLIST");
            m_tokenList.Add("LPRINT");
            m_tokenList.Add("NEXT");
            m_tokenList.Add("DATA");
            m_tokenList.Add("INPUT");
            m_tokenList.Add("DIM");
            m_tokenList.Add("CLS");
            m_tokenList.Add("READ");
            m_tokenList.Add("LET");
            m_tokenList.Add("GOTO");
            m_tokenList.Add("RUN");
            m_tokenList.Add("IF");
            m_tokenList.Add("RESTORE");
            m_tokenList.Add("GOSUB");
            m_tokenList.Add("RETURN");
            m_tokenList.Add("REM");
            m_tokenList.Add("HIMEM");
            m_tokenList.Add("GRAB");
            m_tokenList.Add("RELEASE");
            m_tokenList.Add("TEXT");
            m_tokenList.Add("HIRES");
            m_tokenList.Add("SHOOT");
            m_tokenList.Add("EXPLODE");
            m_tokenList.Add("ZAP");
            m_tokenList.Add("PING");
            m_tokenList.Add("SOUND");
            m_tokenList.Add("MUSIC");
            m_tokenList.Add("PLAY");
            m_tokenList.Add("CURSET");
            m_tokenList.Add("CURMOV");
            m_tokenList.Add("DRAW");
            m_tokenList.Add("CIRCLE");
            m_tokenList.Add("PATTERN");
            m_tokenList.Add("FILL");
            m_tokenList.Add("CHAR");
            m_tokenList.Add("PAPER");
            m_tokenList.Add("INK");
            m_tokenList.Add("STOP");
            m_tokenList.Add("ON");
            m_tokenList.Add("WAIT");
            m_tokenList.Add("CLOAD");
            m_tokenList.Add("CSAVE");
            m_tokenList.Add("DEF");
            m_tokenList.Add("POKE");
            m_tokenList.Add("PRINT");
            m_tokenList.Add("CONT");
            m_tokenList.Add("LIST");
            m_tokenList.Add("CLEAR");
            m_tokenList.Add("GET");
            m_tokenList.Add("CALL");
            m_tokenList.Add("!");
            m_tokenList.Add("NEW");
            m_tokenList.Add("TAB(");
            m_tokenList.Add("TO");
            m_tokenList.Add("FN");
            m_tokenList.Add("SPC(");
            m_tokenList.Add("@");
            m_tokenList.Add("AUTO");
            m_tokenList.Add("ELSE");
            m_tokenList.Add("THEN");
            m_tokenList.Add("NOT");
            m_tokenList.Add("STEP");
            m_tokenList.Add("+");
            m_tokenList.Add("-");
            m_tokenList.Add("*");
            m_tokenList.Add("/");
            m_tokenList.Add("^");
            m_tokenList.Add("AND");
            m_tokenList.Add("OR");
            m_tokenList.Add(">");
            m_tokenList.Add("=");
            m_tokenList.Add("<");
            m_tokenList.Add("SGN");
            m_tokenList.Add("INT");
            m_tokenList.Add("ABS");
            m_tokenList.Add("USR");
            m_tokenList.Add("FRE");
            m_tokenList.Add("POS");
            m_tokenList.Add("HEX$");
            m_tokenList.Add("&");
            m_tokenList.Add("SQR");
            m_tokenList.Add("RND");
            m_tokenList.Add("LN");
            m_tokenList.Add("EXP");
            m_tokenList.Add("COS");
            m_tokenList.Add("SIN");
            m_tokenList.Add("TAN");
            m_tokenList.Add("ATN");
            m_tokenList.Add("PEEK");
            m_tokenList.Add("DEEK");
            m_tokenList.Add("LOG");
            m_tokenList.Add("LEN");
            m_tokenList.Add("STR$");
            m_tokenList.Add("VAL");
            m_tokenList.Add("ASC");
            m_tokenList.Add("CHR$");
            m_tokenList.Add("PI");
            m_tokenList.Add("TRUE");
            m_tokenList.Add("FALSE");
            m_tokenList.Add("KEY$");
            m_tokenList.Add("SCRN");
            m_tokenList.Add("POINT");
            m_tokenList.Add("LEFT$");
            m_tokenList.Add("RIGHT$");
            m_tokenList.Add("MID$");
            //m_tokenList.Add("Unknown");
        }
    }
}
