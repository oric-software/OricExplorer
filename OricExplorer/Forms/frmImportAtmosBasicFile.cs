namespace OricExplorer.Forms
{
    using System;
    using System.Collections;
    using System.IO;
    using System.Windows.Forms;

    public partial class frmImportAtmosBasicFile : Form
    {
        BasicTokens basicTokens;

        public frmImportAtmosBasicFile()
        {
            InitializeComponent();

            basicTokens = new BasicTokens(BasicTokens.ROMVersion.V1_1);
        }

        private void frmImportTextFile_Shown(object sender, EventArgs e)
        {
            optNewTape.Checked = true;

            txtStartAddress.Text = "$0501";

            chkAutoRun.Checked = true;

            UpdateOKStatus();
        }

        #region Dialog Controls
        private void btnBrowseForTextFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Title = "Select the Text file to Import";
                fileDialog.DefaultExt = "txt";
                fileDialog.Filter = "Text files (*.txt)|*.txt|BASIC Source files (*.bas)|*.bas|All files (*.*)|*.*";
                fileDialog.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    // New folder selected
                    txtFileToImport.Text = fileDialog.FileName;
                }
            }
        }

        private void btnBrowseForDestinationFile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Select name of destination file";
                saveFileDialog.DefaultExt = "tap";
                saveFileDialog.Filter = "Tape files (*.tap)|*.tap";
                saveFileDialog.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
                saveFileDialog.OverwritePrompt = optNewTape.Checked;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // New folder selected
                    txtDestinationFile.Text = saveFileDialog.FileName;
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OricProgram program = new OricProgram();

            if (txtProgramName.TextLength == 0)
            {
                program.ProgramName = "NoName";
            }
            else if(txtProgramName.TextLength > 16)
            {
                program.ProgramName = txtProgramName.Text.Substring(0, 16);
            }
            else
            {
                program.ProgramName = txtProgramName.Text;
            }

            program.Format = OricProgram.ProgramFormat.BasicProgram;
            program.AutoRun = (chkAutoRun.Checked ? OricProgram.AutoRunFlag.Enabled : OricProgram.AutoRunFlag.Disabled);

            txtStartAddress.Text = txtStartAddress.Text.Replace("$", "0x");
            program.StartAddress = Convert.ToUInt16(txtStartAddress.Text, 16);
            
            // Load text file
            string[] sourceCode = File.ReadAllLines(txtFileToImport.Text);

            if (!ConvertTextToBASIC(sourceCode, ref program))
            {
                MessageBox.Show("Error converting file. It is not an Atmos BASIC file.", "Import Atmos BASIC File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    // initialize the tape
                    OricTape oricTape = new OricTape();
                    oricTape.TapeName = txtDestinationFile.Text;

                    if (optNewTape.Checked)
                    {
                        // add the program and save file
                        oricTape.SaveFile(program);
                    }
                    else
                    {
                        // read the actual tape catalog
                        FileInfo fileInfo = new FileInfo(txtDestinationFile.Text);
                        OricFileInfo[] tapeCatalog = oricTape.Catalog(fileInfo);

                        // read the programs already on the tape
                        ArrayList programList = new ArrayList();
                        for (int i = 0; i < tapeCatalog.Length; i++)
                        {
                            programList.Add(oricTape.Load(oricTape.TapeName, "", (ushort)i));
                        }
                        
                        // add the new program to the liste
                        programList.Add(program);

                        // write the program list
                        oricTape.WriteFiles(programList, FileMode.Create);
                    }

                    // file converted successfully
                    MessageBox.Show("Atmos BASIC file converted successfully", "Import Atmos BASIC File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving tape file.\r\n\r\n{ex.Message}", "Import Atmos BASIC File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void optNewTape_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void optExistingTape_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void optNewDisk_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void optExistingDisk_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtFileToImport_TextChanged(object sender, EventArgs e)
        {
            UpdateOKStatus();
        }

        private void txtDestinationFile_TextChanged(object sender, EventArgs e)
        {
            UpdateOKStatus();
        }

        private void UpdateOKStatus()
        {
            btnImport.Enabled = (txtFileToImport.TextLength > 0 && txtDestinationFile.TextLength > 0);
        }
        #endregion

        #region Text to BASIC Functions
        private bool ConvertTextToBASIC(string[] textBuffer, ref OricProgram program)
        {
            try
            {
                bool bREM = false;
                bool bDATA = false;
                bool bString = false;

                ushort ui16CurrentAddress = program.StartAddress;

                int iProgramIdx = 0;
                int iBufferIdx = 0;
                int iAddressIdx = 0;

                // Initialise the program buffer
                program.ProgramData = new byte[0xFFFF];
                program.ProgramData.Initialize();

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

                        string lineno = "";

                        // Get line no.
                        while (char.IsNumber(GetNextChar(textBuffer[iLoop], iBufferIdx)))
                        {
                            lineno += textBuffer[iLoop].Substring(iBufferIdx, 1);

                            iBufferIdx++;
                        }

                        ushort ui16LineNo = Convert.ToUInt16(lineno, 10);

                        if (ui16LineNo < 0 || ui16LineNo > 0xFFFF)
                        {
                            MessageBox.Show("Invalid line no. specified.", "Import Atmos BASIC File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                        iAddressIdx = iProgramIdx;

                        program.ProgramData[iProgramIdx] = 0xFF;
                        iProgramIdx++;

                        program.ProgramData[iProgramIdx] = 0xFE;
                        iProgramIdx++;

                        program.ProgramData[iProgramIdx] = (byte)(ui16LineNo & 0xFF);

                        iProgramIdx++;

                        program.ProgramData[iProgramIdx] = (byte)(ui16LineNo >> 8);

                        iProgramIdx++;

                        iBufferIdx = FindNextNonSpaceChar(textBuffer[iLoop], iBufferIdx);

                        bool bEndOfLine = false;

                        while (!bEndOfLine)
                        {
                            if (bREM)
                            {
                                program.ProgramData[iProgramIdx] = Convert.ToByte(textBuffer[iLoop][iBufferIdx]);
                                iBufferIdx++;
                            }
                            else if (bString)
                            {
                                if (textBuffer[iLoop][iBufferIdx] == '"')
                                    bString = false;

                                program.ProgramData[iProgramIdx] = Convert.ToByte(textBuffer[iLoop][iBufferIdx]);
                                iBufferIdx++;
                            }
                            else if (bDATA)
                            {
                                if (textBuffer[iLoop][iBufferIdx] == ':')
                                    bDATA = false;

                                program.ProgramData[iProgramIdx] = Convert.ToByte(textBuffer[iLoop][iBufferIdx]);
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
                                    program.ProgramData[iProgramIdx] = Convert.ToByte(textBuffer[iLoop][iBufferIdx]);
                                    iBufferIdx++;
                                }
                                else
                                {
                                    program.ProgramData[iProgramIdx] = Convert.ToByte(iToken);

                                    string token = basicTokens.GetBasicToken((byte)(iToken - 0x80));
                                    iBufferIdx += token.Length;
                                }
                            }

                            ui16CurrentAddress++;

                            iProgramIdx++;

                            if (iBufferIdx >= textBuffer[iLoop].Length)
                            {
                                ui16CurrentAddress += 5;

                                program.ProgramData[iAddressIdx] = (byte)(ui16CurrentAddress & 0xFF);
                                iAddressIdx++;

                                program.ProgramData[iAddressIdx] = (byte)(ui16CurrentAddress >> 8);

                                program.ProgramData[iProgramIdx] = 0x00;
                                iProgramIdx++;

                                bEndOfLine = true;
                            }
                        }
                    }
                }

                program.ProgramData[iProgramIdx] = 0x00;
                iProgramIdx++;
                program.ProgramData[iProgramIdx] = 0x00;
iProgramIdx++;
program.ProgramData[iProgramIdx] = 0x55;
                program.EndAddress = (ushort)(program.StartAddress + iProgramIdx);
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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
                tapeProgram = oricTape.Load(oricTape.TapeName, "", (ushort)iIndex);

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

        private char GetNextChar(string buffer, int index)
        {
            char chChar = Convert.ToChar(buffer.Substring(index, 1));
            return chChar;
        }

        private int FindNextNonSpaceChar(string buffer, int index)
        {
            while (char.Equals(buffer[index], ' '))
            {
                index++;
            }

            return index;
        }

        private int MatchKeyword(string buffer, int index)
        {
            int iToken = 0;

            int iLoop = 0;
            bool bTokenFound = false;

            while (iLoop < basicTokens.TokenCount && !bTokenFound)
            {
                string strToken = basicTokens.GetBasicToken((byte)(iLoop));

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
