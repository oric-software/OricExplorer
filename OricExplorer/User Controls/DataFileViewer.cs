using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace OricExplorer.User_Controls
{
    public partial class DataFileViewer : UserControl
    {
        public Label FileInformation;

        private int cardIndexRecordNumber = 0;
        private int noOfRecords = 0;
        private int recordLength = 0;
        private int noOfFields = 0;

        public OricFileInfo ProgramInfo;
        public OricProgram ProgramData;

        public DataFileViewer()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;

            FileInformation = new Label();
            ProgramInfo = new OricFileInfo();
            ProgramData = new OricProgram();
            ProgramData.New();
        }

        public Boolean InitialiseView()
        {
            noOfRecords = ProgramInfo.m_ui16NoOfRecords;
            recordLength = ProgramInfo.m_ui16RecordLength;

            cardIndexRecordNumber = 0;

            // Display records in a list
            DisplayDataFile();

            // Display first record in the Card index tab
            SetupCardViewControls();
            DisplayCardIndex(0);

            SetupNavigationButtons();

            StringBuilder Information = new StringBuilder();
            Information.AppendFormat("{0:N0} Fields\n", noOfFields);
            Information.AppendFormat("{0:N0} Records\n", noOfRecords);
            Information.AppendFormat("Record Length {0:N0}\n", recordLength);
            Information.AppendFormat("{0:N0} Bytes\n", ProgramInfo.LengthBytes);
            Information.AppendFormat("File is {0}", ProgramInfo.Protection.ToString());

            FileInformation.Text = Information.ToString();

            return true;
        }

        private void AdjustColumnHeaderWidths()
        {
            for (int iIndex = 0; iIndex < listViewRecords.Columns.Count; iIndex++)
            {
                listViewRecords.Columns[iIndex].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                int iColSizeContent = listViewRecords.Columns[iIndex].Width;

                listViewRecords.Columns[iIndex].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                int iColSizeHeader = listViewRecords.Columns[iIndex].Width;

                if (iColSizeContent > iColSizeHeader)
                {
                    listViewRecords.Columns[iIndex].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                }
            }
        }

        private ArrayList ExtractFields(Byte[] recordBuffer)
        {
            ArrayList fields = new ArrayList();

            int bufferIndex = 0;

            while(bufferIndex < recordBuffer.Length)
            {
                StringBuilder fieldData = new StringBuilder();

                if (recordBuffer[bufferIndex] == 0x80)
                {
                    int fieldLength = recordBuffer[bufferIndex + 1];

                    bufferIndex += 2;

                    for (int index = 0; index < fieldLength; index++)
                    {
                        fieldData.AppendFormat("{0}", Convert.ToChar(recordBuffer[bufferIndex + index]));
                    }

                    fields.Add(fieldData.ToString());

                    bufferIndex += fieldLength;
                }
                else
                {
                    bufferIndex++;
                }
            }

            return fields;
        }

        private int CountNoOfFields(Byte[] recordBuffer)
        {
            int fieldCount = 0;
            int index = 0;

            while (index < recordBuffer.Length)
            {
                if (Convert.ToByte(recordBuffer[index]) == 0x80)
                {
                    fieldCount++;
                }

                index++;
            }

            return fieldCount;
        }

        private void DisplayDataFile()
        {
            int recordIndex = 0;
            int bufferIndex = 0;

            Byte[] buffer = new Byte[recordLength];

            while (recordIndex < noOfRecords)
            {
                // Move record into temporary buffer
                for (int index = 0; index < recordLength; index++)
                {
                    buffer[index] = ProgramData.m_programData[bufferIndex];
                    bufferIndex++;
                }

                if (recordIndex == 0)
                {
                    // Count no. of Fields in record
                    int noOfFields = CountNoOfFields(buffer);

                    // Create columns in the listview
                    for (int colIndex = 0; colIndex < noOfFields; colIndex++)
                    {
                        ColumnHeader columnHeader = new ColumnHeader();
                        columnHeader.Text = String.Format("Field {0}", colIndex + 1);
                        columnHeader.TextAlign = HorizontalAlignment.Left;
                        columnHeader.Width = 60;

                        listViewRecords.Columns.Add(columnHeader);
                    }
                }

                // Breakdown each record into it's fields and add to listView control
                ArrayList fields = ExtractFields(buffer);

                if (fields.Count > 0)
                {
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = String.Format("{0:N0}", recordIndex + 1);

                    for (int index = 0; index < fields.Count; index++)
                    {
                        listViewItem.SubItems.Add(fields[index].ToString().Trim());
                    }

                    if ((recordIndex % 2) == 0)
                    {
                        listViewItem.BackColor = Color.WhiteSmoke;
                    }

                    // Add record to the listview
                    listViewRecords.Items.Add(listViewItem);
                }

                // Increment the record counter
                recordIndex++;
            }

            AdjustColumnHeaderWidths();
        }

        private void DisplayCardIndex(int recordNo)
        {
            // Calculate position
            int bufferIndex = recordNo * recordLength;

            Byte[] buffer = new Byte[recordLength];

            // Move record into temporary buffer
            for (int index = 0; index < recordLength; index++)
            {
                buffer[index] = ProgramData.m_programData[bufferIndex];
                bufferIndex++;
            }

            // Breakdown each record into it's fields and add to listView control
            ArrayList fields = ExtractFields(buffer);

            if (fields.Count > 0)
            {
                int index = 0;

                foreach (Control c in panel1.Controls)
                {
                    if (c.GetType() == typeof(TextBox))
                    {
                        c.Text = fields[index].ToString().Trim();
                        index++;
                    }
                }
            }
        }

        private void buttonFirst_Click(object sender, EventArgs e)
        {
            cardIndexRecordNumber = 0;
            DisplayCardIndex(cardIndexRecordNumber);

            SetupNavigationButtons();
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            if (cardIndexRecordNumber > 0)
                cardIndexRecordNumber--;

            DisplayCardIndex(cardIndexRecordNumber);

            SetupNavigationButtons();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if(cardIndexRecordNumber < (noOfRecords - 1))
                cardIndexRecordNumber++;

            DisplayCardIndex(cardIndexRecordNumber);

            SetupNavigationButtons();
        }

        private void buttonLast_Click(object sender, EventArgs e)
        {
            cardIndexRecordNumber = (noOfRecords - 1);
            DisplayCardIndex(cardIndexRecordNumber);

            SetupNavigationButtons();
        }

        private void SetupNavigationButtons()
        {
            if (cardIndexRecordNumber == 0)
            {
                buttonFirst.Enabled = false;
                buttonPrev.Enabled = false;
            }
            else
            {
                buttonFirst.Enabled = true;
                buttonPrev.Enabled = true;
            }

            if (cardIndexRecordNumber == (noOfRecords - 1))
            {
                buttonLast.Enabled = false;
                buttonNext.Enabled = false;
            }
            else
            {
                buttonLast.Enabled = true;
                buttonNext.Enabled = true;
            }

            // Setup the Card view tab text
            tabPageCardView.Text = String.Format("Card View ({0} of {1})", cardIndexRecordNumber + 1, noOfRecords);
        }

        private void SetupCardViewControls()
        {
            Byte[] buffer = new Byte[recordLength];

            // Move record into temporary buffer
            for (int index = 0; index < recordLength; index++)
            {
                buffer[index] = ProgramData.m_programData[index];
            }

            // Count no. of Fields in record
            noOfFields = CountNoOfFields(buffer);

            // Get position of current label
            Point labelLocation = labelFieldID0.Location;
            Point textBoxLocation = textBoxFieldData0.Location;

            for (int controlIndex = 1; controlIndex < noOfFields; controlIndex++)
            {
                labelLocation.Y += (textBoxFieldData0.Height + 5);

                Label label = new Label();
                label.Name = String.Format("labelFieldID{0}", controlIndex);
                label.Text = String.Format("Field {0} :", controlIndex + 1);
                label.Location = labelLocation;
                label.Width = labelFieldID0.Width;
                label.Height = labelFieldID0.Height;
                label.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label.ForeColor = Color.Black;

                panel1.Controls.Add(label);

                textBoxLocation.Y += (textBoxFieldData0.Height + 5);

                TextBox textbox = new TextBox();
                textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
                textbox.Name = String.Format("textBoxFieldData{0}", controlIndex);
                textbox.Text = "";
                textbox.Location = textBoxLocation;
                textbox.Width = textBoxFieldData0.Width;
                textbox.Height = textBoxFieldData0.Height;
                textbox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                textbox.BackColor = System.Drawing.SystemColors.ControlLight;
                textbox.ReadOnly = true;

                panel1.Controls.Add(textbox);
            }
        }

        private void listViewRecords_DoubleClick(object sender, EventArgs e)
        {
            // Get selected index and display it in the card index tab
            cardIndexRecordNumber = listViewRecords.SelectedIndices[0];

            DisplayCardIndex(cardIndexRecordNumber);
            SetupNavigationButtons();

            tabControlDataFile.SelectedIndex = 1;
        }
    }
}
