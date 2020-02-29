namespace OricExplorer
{
    using System;
    using System.Collections;

    public class OpCodes
    {
        public struct sOpCode
        {
            public string strOpMne;
            public byte bOpMode;
            public byte bOpBytes;
        };

        private byte[] m_opCodesBuffer;
        private SortedList opCodesList;

        public OpCodes()
        {
            int iBufferLen = Properties.Resources.OpCodes.Length;

            m_opCodesBuffer = new byte[iBufferLen];

            Properties.Resources.OpCodes.CopyTo(m_opCodesBuffer, 0);

            // Create an array to hold the list of Basic tokens
            opCodesList = new SortedList();

            ushort siIndex = 0;

            while(siIndex < iBufferLen)
            {
                byte bKey = Convert.ToByte(m_opCodesBuffer[siIndex]);

                siIndex++;

                sOpCode sTmpStruct = new sOpCode();

                sTmpStruct.strOpMne = string.Format("{0}{1}{2}",
                                                    Convert.ToChar(m_opCodesBuffer[siIndex]),
                                                    Convert.ToChar(m_opCodesBuffer[siIndex+1]),
                                                    Convert.ToChar(m_opCodesBuffer[siIndex+2]));

                siIndex += 3;

                sTmpStruct.bOpMode = m_opCodesBuffer[siIndex];
                siIndex++;

                sTmpStruct.bOpBytes = m_opCodesBuffer[siIndex];
                siIndex++;

                opCodesList.Add(bKey, (sOpCode)sTmpStruct);
            }
        }

        public sOpCode FindOpInfo(byte bOpCode)
        {
            sOpCode sRtnStruct = new sOpCode();

            if (opCodesList.ContainsKey(bOpCode))
            {
                sRtnStruct = (sOpCode)opCodesList[bOpCode];
            }
            else
            {
                sRtnStruct.strOpMne = "???";
                sRtnStruct.bOpMode = 0;
                sRtnStruct.bOpBytes = 1;
            }

            return sRtnStruct;
        }
    }
}
