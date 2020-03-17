namespace OricExplorer
{
    using System.Collections;

    public class TeleassTokens
    {
        private readonly ArrayList m_tokenList = new ArrayList();

        public TeleassTokens()
        {
            // Build the Teleass token list
            BuildTokenList();
        }

        public int TokenCount
        {
            get { return m_tokenList.Count; }
        }

        public string GetTeleassToken(byte bToken)
        {
            return (bToken < m_tokenList.Count ? m_tokenList[bToken].ToString() : "???");
        }

        private void BuildTokenList()
        {
            m_tokenList.Add("BRK");//128
            m_tokenList.Add("CLC");//129
            m_tokenList.Add("CLD");//130
            m_tokenList.Add("CLI");//131
            m_tokenList.Add("CLV");//132
            m_tokenList.Add("DEX");//133
            m_tokenList.Add("DEY");//134
            m_tokenList.Add("INX");//135
            m_tokenList.Add("INY");//136
            m_tokenList.Add("NOP");//137
            m_tokenList.Add("PHA");//138
            m_tokenList.Add("PHP");//139
            m_tokenList.Add("PLA");//140
            m_tokenList.Add("PLP");//141
            m_tokenList.Add("RTI");//142
            m_tokenList.Add("RTS");//143
            m_tokenList.Add("SEC");//144
            m_tokenList.Add("SED");//145
            m_tokenList.Add("SEI");//146
            m_tokenList.Add("TAX");//147
            m_tokenList.Add("TAY");//148
            m_tokenList.Add("TSX");//149
            m_tokenList.Add("TXA");//150
            m_tokenList.Add("TXS");//151
            m_tokenList.Add("TYA");//152
            m_tokenList.Add("BCC");//153
            m_tokenList.Add("BCS");//154
            m_tokenList.Add("BEQ");//155
            m_tokenList.Add("BNE");//156
            m_tokenList.Add("BMI");//157
            m_tokenList.Add("BPL");//158
            m_tokenList.Add("BVC");//159
            m_tokenList.Add("BVS");//160
            m_tokenList.Add("ADC");//161
            m_tokenList.Add("AND");//162
            m_tokenList.Add("ASL");//163
            m_tokenList.Add("BIT");//164
            m_tokenList.Add("CMP");//165
            m_tokenList.Add("CPX");//166
            m_tokenList.Add("CPY");//167
            m_tokenList.Add("DEC");//168
            m_tokenList.Add("EOR");//169
            m_tokenList.Add("INC");//170
            m_tokenList.Add("JMP");//171
            m_tokenList.Add("JSR");//172
            m_tokenList.Add("LDA");//173
            m_tokenList.Add("LDX");//174
            m_tokenList.Add("LDY");//175
            m_tokenList.Add("LSR");//176
            m_tokenList.Add("ORA");//177
            m_tokenList.Add("ROL");//178
            m_tokenList.Add("ROR");//179
            m_tokenList.Add("SBC");//180
            m_tokenList.Add("STA");//181
            m_tokenList.Add("STX");//182
            m_tokenList.Add("STY");//183
            m_tokenList.Add("BYT");//184
            m_tokenList.Add("EQU");//185
            m_tokenList.Add("DBT");//186
            m_tokenList.Add("RES");//187
            m_tokenList.Add("ORG");//188
        }
    }
}
