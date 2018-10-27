using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace OricExplorer.Forms
{
    public partial class ImportTextFileForm : Form
    {
        BasicTokens basicTokens;
        OricProgram program;

        public ImportTextFileForm()
        {
            InitializeComponent();

            program = new OricProgram();
            program.New();

            basicTokens = new BasicTokens(BasicTokens.ROMVersion.V1_1);
        }

        private void ImportTextFileForm_Shown(object sender, EventArgs e)
        {
            radioButtonNewTape.Checked = true;

            //textBoxDestinationFile.Enabled = false;
            //buttonBrowseForDestinationFile.Enabled = false;

            //textBoxProgramName.Enabled = false;
            //buttonReset.Enabled = false;

            //textBoxStartAddress.Enabled = false;
            textBoxStartAddress.Text = "$0501";

            //checkBoxAutoRun.Enabled = false;
            checkBoxAutoRun.Checked = true;

            //buttonImport.Enabled = false;
        }

        private String BrowseForTextFile()
        {
            String textFilePathName = "";

            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.Title = "Select the Text file to Import";
            fileDialog.DefaultExt = "txt";
            fileDialog.Filter = "Text files (*.txt)|*.txt|BASIC Source files (*.bas)|*.bas|All files (*.*)|*.*";
            fileDialog.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();

            DialogResult drResult = fileDialog.ShowDialog();

            if (drResult == DialogResult.OK)
            {
                // New folder selected
                textFilePathName = fileDialog.FileName;
            }

            return textFilePathName;
        }

        private String BrowseForTapeFile()
        {
            String tapeFilePathName = "";

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Title = "Select name of destination file";
            saveFileDialog.DefaultExt = "tap";
            saveFileDialog.Filter = "Tape files (*.tap)|*.tap";
            saveFileDialog.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();

            DialogResult drResult = saveFileDialog.ShowDialog();

            if (drResult == DialogResult.OK)
            {
                // New folder selected
                tapeFilePathName = saveFileDialog.FileName;
            }

            return tapeFilePathName;
        }

        #region Dialog Controls
        private void buttonBrowseForTextFile_Click(object sender, EventArgs e)
        {
            String textFilePathName = BrowseForTextFile();

            if (textFilePathName.Length > 0)
            {
                textBoxFileToImport.Text = textFilePathName;
            }
        }

        private void buttonBrowseForDestinationFile_Click(object sender, EventArgs e)
        {
            String tapeFilePathName = BrowseForTapeFile();

            if (tapeFilePathName.Length > 0)
            {
                textBoxDestinationFile.Text = tapeFilePathName;
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {

        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            // Disable controls
            if (textBoxProgramName.TextLength == 0)
            {
                program.ProgramName = "NoName";
            }
            else if(textBoxProgramName.TextLength > 16)
            {
                program.ProgramName = textBoxProgramName.Text.Substring(0, 16);
            }
            else
            {
                program.ProgramName = textBoxProgramName.Text;
            }

            program.Format = OricProgram.ProgramFormat.BasicProgram;

            if (checkBoxAutoRun.Checked)
            {
                program.AutoRun = OricProgram.AutoRunFlag.Enabled;
            }
            else
            {
                program.AutoRun = OricProgram.AutoRunFlag.Disabled;
            }

            textBoxStartAddress.Text = textBoxStartAddress.Text.Replace("$", "0x");
            program.StartAddress = Convert.ToUInt16(textBoxStartAddress.Text, 16);
            
            // Load text file
            String[] sourceCode = System.IO.File.ReadAllLines(textBoxFileToImport.Text);

            if (ConvertTextToBASIC(sourceCode))
            {
                // File converted successfully, now need to write it out to Tape/Disk
                MessageBox.Show("Text file converted successfully", "Import Text File", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
            else
            {
            }

            // Enable controls
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void radioButtonNewTape_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonExistingTape_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonNewDisk_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonExistingDisk_CheckedChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region Text to BASIC Functions
        private Boolean ConvertTextToBASIC(String[] textBuffer)
        {
            Boolean bREM = false;
            Boolean bDATA = false;
            Boolean bString = false;

            UInt16 ui16CurrentAddress = program.StartAddress;

            int iProgramIdx = 0;
            int iBufferIdx = 0;
            int iAddressIdx = 0;

            // Initialise the program buffer
            program.m_programData = new Byte[0xFFFF];
            program.m_programData.Initialize();

            for (int iLoop = 0; iLoop < textBuffer.Length; iLoop++)
            {
                if (textBuffer[iLoop].Length > 0)
                {
                    bREM = false;
                    bDATA = false;
                    bString = false;

                    // Find first character
                    iBufferIdx = 0;
                    iBufferIdx = FindNextNonSpaceChar(textBuffer[iLoop], iBufferIdx);

                    String lineno = "";

                    // Get line no.
                    while (char.IsNumber(GetNextChar(textBuffer[iLoop], iBufferIdx)))
                    {
                        lineno += textBuffer[iLoop].Substring(iBufferIdx, 1);

                        iBufferIdx++;
                    }

                    UInt16 ui16LineNo = Convert.ToUInt16(lineno, 10);

                    if (ui16LineNo < 0 || ui16LineNo > 0xFFFF)
                    {
                        MessageBox.Show("Invalid line no. specified.", "Line No. Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    iAddressIdx = iProgramIdx;

                    program.m_programData[iProgramIdx] = 0xFF;
                    iProgramIdx++;

                    program.m_programData[iProgramIdx] = 0xFE;
                    iProgramIdx++;

                    program.m_programData[iProgramIdx] = (Byte)(ui16LineNo & 0xFF);

                    iProgramIdx++;

                    program.m_programData[iProgramIdx] = (Byte)(ui16LineNo >> 8);

                    iProgramIdx++;

                    iBufferIdx = FindNextNonSpaceChar(textBuffer[iLoop], iBufferIdx);

                    Boolean bEndOfLine = false;

                    while (!bEndOfLine)
                    {
                        if (bREM)
                        {
                            program.m_programData[iProgramIdx] = Convert.ToByte(textBuffer[iLoop][iBufferIdx]);
                            iBufferIdx++;
                        }
                        else if (bString)
                        {
                            if (textBuffer[iLoop][iBufferIdx] == '"')
                                bString = false;

                            program.m_programData[iProgramIdx] = Convert.ToByte(textBuffer[iLoop][iBufferIdx]);
                            iBufferIdx++;
                        }
                        else if (bDATA)
                        {
                            if (textBuffer[iLoop][iBufferIdx] == ':')
                                bDATA = false;

                            program.m_programData[iProgramIdx] = Convert.ToByte(textBuffer[iLoop][iBufferIdx]);
                            iBufferIdx++;
                        }
                        else
                        {
                            int iToken = MatchKeyword(textBuffer[iLoop], iBufferIdx);

                            if (iToken == 0x9D) // || textBuffer[iLoop][iBufferIdx] == '\'')
                                bREM = true;

                            if (iToken == 0x91)
                                bDATA = true;

                            if (textBuffer[iLoop][iBufferIdx] == '"')
                                bString = true;

                            if (iToken == 0)
                            {
                                program.m_programData[iProgramIdx] = Convert.ToByte(textBuffer[iLoop][iBufferIdx]);
                                iBufferIdx++;
                            }
                            else
                            {
                                program.m_programData[iProgramIdx] = Convert.ToByte(iToken);

                                String token = basicTokens.GetBasicToken((Byte)(iToken - 0x80));
                                iBufferIdx += token.Length;
                            }
                        }

                        ui16CurrentAddress++;

                        iProgramIdx++;

                        if (iBufferIdx >= textBuffer[iLoop].Length)
                        {
                            ui16CurrentAddress += 5;

                            program.m_programData[iAddressIdx] = (Byte)(ui16CurrentAddress & 0xFF);
                            iAddressIdx++;

                            program.m_programData[iAddressIdx] = (Byte)(ui16CurrentAddress >> 8);

                            program.m_programData[iProgramIdx] = 0x00;
                            iProgramIdx++;

                            bEndOfLine = true;
                        }
                    }
                }
            }

            program.m_programData[iProgramIdx] = 0x00;
            iProgramIdx++;
            program.m_programData[iProgramIdx] = 0x00;

            program.EndAddress = (ushort)(program.StartAddress + iProgramIdx);

            FileStream fsm = new FileStream(textBoxDestinationFile.Text, FileMode.Create, FileAccess.Write);

            using (BinaryWriter binWriter = new BinaryWriter(fsm))
            {
                // Write the Tape leader
                binWriter.Write((Byte)0x16);
                binWriter.Write((Byte)0x16);
                binWriter.Write((Byte)0x16);
                binWriter.Write((Byte)0x24);
                binWriter.Write((Byte)0x00);
                binWriter.Write((Byte)0x00);

                // Write the Program format
                if (program.Format == OricProgram.ProgramFormat.BasicProgram)
                    binWriter.Write((Byte)0x00);
                else
                    binWriter.Write((Byte)0x01);

                // Write the Auto run flag
                if (program.AutoRun == OricProgram.AutoRunFlag.Enabled)
                    binWriter.Write((Byte)0x00);
                else
                    binWriter.Write((Byte)0x01);

                program.EndAddress = (ushort)(program.StartAddress + iProgramIdx);

                // Get the High and Low bytes of the End address and write to file
                Byte hi = Convert.ToByte((program.EndAddress >> 8) & 0xFF);
                Byte lo = Convert.ToByte(program.EndAddress & 0xFF);

                binWriter.Write((Byte)hi);
                binWriter.Write((Byte)lo);

                // Get the High and Low bytes of the Start address and write to file
                hi = Convert.ToByte((program.StartAddress >> 8) & 0xFF);
                lo = Convert.ToByte(program.StartAddress & 0xFF);

                binWriter.Write((Byte)hi);
                binWriter.Write((Byte)lo);

                // Write unused byte
                binWriter.Write((Byte)0x00);

                int iIndex = 0;

                // Write the Program name
                for (iIndex = 0; iIndex < program.ProgramName.Length; iIndex++)
                {
                    binWriter.Write(Convert.ToByte(program.ProgramName[iIndex]));
                }

                // NULL terminate the Program name
                binWriter.Write((Byte)0x00);

                // Write file data
                for (iIndex = 0; iIndex < iProgramIdx; iIndex++)
                {
                    binWriter.Write((Byte)program.m_programData[iIndex]);
                }
            }

            fsm.Close();

            return true;
        }

        /*private void UpdateOricTape()
        {
            //toolStripStatusLabelMain.Text = "File saved successfully.";

            // Get tape catalog
            TapeInfo tapeInfo = (TapeInfo)treeNodeSelected.Parent.Tag;

            OricTape oricTape = new OricTape();
            oricTape.TapeName = Path.Combine(tapeInfo.Folder, tapeInfo.Name);

            FileInfo fiFileInfo = new FileInfo(Path.Combine(tapeInfo.Folder, tapeInfo.Name));
            Catalog[] tapeCatalog = oricTape.Catalog(fiFileInfo);

            ArrayList programList = new ArrayList();

            // loop thru progs loading each one and adding it to an array of OricProgram
            // call WriteFiles using the array to update the Tape.
            for (int iIndex = 0; iIndex < tapeCatalog.Length; iIndex++)
            {
                OricProgram tapeProgram = new OricProgram();
                tapeProgram = oricTape.Load(oricTape.TapeName, "", (short)iIndex);

                if (iIndex == programInfo.ProgramIndex)
                {
                    programList.Add((OricProgram)oricProgram);
                }
                else
                {
                    programList.Add((OricProgram)tapeProgram);
                }
            }

            oricTape.WriteFiles(programList, FileMode.Create);

            //toolStripStatusLabelMain.Text = "File saved successfully.";
        }*/

        private char GetNextChar(String buffer, int index)
        {
            char chChar = Convert.ToChar(buffer.Substring(index, 1));
            return chChar;
        }

        private int FindNextNonSpaceChar(String buffer, int index)
        {
            while (char.Equals(buffer[index], ' '))
            {
                index++;
            }

            return index;
        }

        private int MatchKeyword(String buffer, int index)
        {
            int iToken = 0;

            int iLoop = 0;
            Boolean bTokenFound = false;

            while (iLoop < basicTokens.TokenCount && !bTokenFound)
            {
                String strToken = basicTokens.GetBasicToken((Byte)(iLoop));

                if (strToken.Length <= (buffer.Length - index))
                {
                    if (strToken == buffer.Substring(index, strToken.Length))
                    {
                        iToken = 0x80 + iLoop;
                        bTokenFound = true;
                    }
                }

                iLoop++;

            }

            return iToken;
        }
        #endregion
    }
}
