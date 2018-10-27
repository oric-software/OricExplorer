using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace OricExplorer.Forms
{
    public partial class EditTapeForm : Form
    {
        // Tape settings
        public String tapeName = "";
        public String tapeFolder = "";

        // Program settings
        UInt16 startAddress = 0x0000;
        UInt16 endAddress = 0x0000;
        Boolean autoRun = false;
        OricProgram.ProgramFormat programFormat = OricProgram.ProgramFormat.BasicProgram;

        public OricFileInfo[] tapeCatalog;

        public EditTapeForm()
        {
            InitializeComponent();
        }

        private void EditTapeForm_Load(object sender, EventArgs e)
        {
            textBoxTapeName.Text = tapeName;
            textBoxTapeFolder.Text = tapeFolder;

            buildProgramList();

            buttonMoveUp.Enabled = false;
            buttonMoveDown.Enabled = false;
            buttonUpdate.Enabled = false;
            buttonDelete.Enabled = false;
            buttonSave.Enabled = false;
        }

        private void buildProgramList()
        {
            // Disable refreshing of the list
            listViewPrograms.BeginUpdate();

            // Remove any items currently in the list
            listViewPrograms.Items.Clear();

            // Add each program to the list
            foreach (OricFileInfo programInfo in tapeCatalog)
            {
                ListViewItem listItem = new ListViewItem();
                listItem.Text = programInfo.ProgramName;
                listItem.Tag = programInfo;
                listViewPrograms.Items.Add(listItem);
            }

            // Enable refreshing of the list
            listViewPrograms.EndUpdate();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void textBoxProgramName_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonCodeData_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonBasic_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxAutoRun_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDownStartAddress_ValueChanged(object sender, EventArgs e)
        {

        }

        private void buttonMoveUp_Click(object sender, EventArgs e)
        {
            int selectedItemIndex = 0;

            if (listViewPrograms.SelectedItems.Count > 0)
            {
                selectedItemIndex = listViewPrograms.SelectedIndices[0];

                ListViewItem listViewItem = listViewPrograms.Items[selectedItemIndex];

                listViewPrograms.Items.RemoveAt(selectedItemIndex);
                listViewPrograms.Items.Insert(selectedItemIndex - 1, listViewItem);
            }
        }

        private void buttonMoveDown_Click(object sender, EventArgs e)
        {

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            ListViewItem listViewItem = listViewPrograms.SelectedItems[0];
            int selectedIndex = listViewPrograms.Items.IndexOf(listViewPrograms.SelectedItems[0]);

            DialogResult result = MessageBox.Show(String.Format("Are you sure you want to delete '{0}' from the Tape?", listViewItem.Text), "Delete Program", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if(result == DialogResult.Yes)
            {
                listViewPrograms.Items.RemoveAt(selectedIndex);
            }
        }

        private void listViewPrograms_Click(object sender, EventArgs e)
        {

        }

        private void listViewPrograms_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem listViewItem = listViewPrograms.SelectedItems[0];

        }

        private void listViewPrograms_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedItemIndex = -1;

            if (listViewPrograms.SelectedItems.Count > 0)
            {
                selectedItemIndex = listViewPrograms.SelectedIndices[0];
                buttonDelete.Enabled = true;
            }
            else
            {
                buttonDelete.Enabled = false;
            }

            if (selectedItemIndex < 1 || listViewPrograms.Items.Count < 2)
            {
                buttonMoveUp.Enabled = false;
            }
            else
            {
                buttonMoveUp.Enabled = true;
            }

            if ((selectedItemIndex + 1) >= listViewPrograms.Items.Count)
            {
                buttonMoveDown.Enabled = false;
            }
            else
            {
                buttonMoveDown.Enabled = true;
            }
        }
    }
}
