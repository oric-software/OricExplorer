using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace OricExplorer
{
    public class OpCodes
    {
        public struct sOpCode
        {
            public String strOpMne;
            public Byte bOpMode;
            public Byte bOpBytes;
        };

        private Byte[] m_opCodesBuffer;
        private SortedList opCodesList;

        public OpCodes()
        {
            int iBufferLen = Properties.Resources.OpCodes.Length;

            m_opCodesBuffer = new byte[iBufferLen];

            Properties.Resources.OpCodes.CopyTo(m_opCodesBuffer, 0);

            // Create an array to hold the list of Basic tokens
            opCodesList = new SortedList();

            short siIndex = 0;

            while(siIndex < iBufferLen)
            {
                Byte bKey = Convert.ToByte(m_opCodesBuffer[siIndex]);

                siIndex++;

                sOpCode sTmpStruct = new sOpCode();

                sTmpStruct.strOpMne = String.Format("{0}{1}{2}",
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

        public sOpCode FindOpInfo(Byte bOpCode)
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
