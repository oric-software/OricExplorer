namespace OricExplorer.Forms
{
    using System;
    using System.Linq;
    using System.Windows.Forms;

    public partial class frmEditTape : Form
    {
        private bool init = false;

        // Tape settings
        public string TapeName { get; set; }
        public string TapeFolder { get; set; }
        public OricFileInfo[] TapeCatalog { get; set; }
        
        public frmEditTape()
        {
            InitializeComponent();
        }

        private void frmEditTape_Load(object sender, EventArgs e)
        {
            txtTapeName.Text = TapeName;
            txtTapeFolder.Text = TapeFolder;

            BuildProgramList();

            btnMoveUp.Enabled = false;
            btnMoveDown.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;

            if (lvwPrograms.Items.Count > 0)
            {
                lvwPrograms.Items[0].Selected = true;
            }
        }

        private void lvwPrograms_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateListsButtonsStatus();

            bool selection = lvwPrograms.SelectedItems.Count > 0;

            foreach (Control control in new Control[] { txtProgramName, chkAutoRun, nudStartAddress, nudEndAddress, lblProgramLength} )
            {
                control.Enabled = selection;
            }

            init = true;
            if (selection)
            {
                OricFileInfo programInfo = (OricFileInfo)lvwPrograms.SelectedItems[0].Tag;
                txtProgramName.Text = programInfo.ProgramName;
                (programInfo.Format == OricProgram.ProgramFormat.AtmosBasicProgram ? optBasic : optCodeData).Checked = true;
                chkAutoRun.Checked = (programInfo.AutoRun == OricProgram.AutoRunFlag.Enabled);
                nudStartAddress.Value = programInfo.StartAddress;
                nudStartAddress.Maximum = 65535 - programInfo.LengthBytes;
                nudEndAddress.Value = programInfo.EndAddress;
                lblProgramLength.Text = programInfo.LengthBytes.ToString();
            }
            else
            {
                txtProgramName.Clear();
                optBasic.Checked = false;
                optCodeData.Checked = false;
                chkAutoRun.Checked = false;
                nudStartAddress.Value = 0;
                nudEndAddress.Value = 0;
                lblProgramLength.Text = string.Empty;
            }
            init = false;

            txtProgramName.Tag = txtProgramName.Text;
            chkAutoRun.Tag = chkAutoRun.Checked;
            nudStartAddress.Tag = nudStartAddress.Value;

            btnUpdate.Enabled = false;
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            int selectedItemIndex = lvwPrograms.SelectedIndices[0];
            ListViewItem listViewItem = lvwPrograms.Items[selectedItemIndex];

            lvwPrograms.Items.RemoveAt(selectedItemIndex);
            lvwPrograms.Items.Insert(selectedItemIndex - 1, listViewItem);

            btnSave.Enabled = true;
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            int selectedItemIndex = lvwPrograms.SelectedIndices[0];
            ListViewItem listViewItem = lvwPrograms.Items[selectedItemIndex];

            lvwPrograms.Items.RemoveAt(selectedItemIndex);
            lvwPrograms.Items.Insert(selectedItemIndex + 1, listViewItem);

            btnSave.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedItemIndex = lvwPrograms.SelectedIndices[0];
            ListViewItem listViewItem = lvwPrograms.Items[selectedItemIndex];

            DialogResult result = MessageBox.Show(string.Format("Are you sure you want to delete '{0}' from the Tape?", listViewItem.Text), "Delete Program", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if(result == DialogResult.Yes)
            {
                lvwPrograms.Items.RemoveAt(selectedItemIndex);
                btnSave.Enabled = true;
            }
        }

        private void txtProgramName_TextChanged(object sender, EventArgs e)
        {
            if (!init)
            {
                UpdateUpdateButtonStatus();
            }
        }

        private void chkAutoRun_CheckedChanged(object sender, EventArgs e)
        {
            if (!init)
            {
                UpdateUpdateButtonStatus();
            }
        }

        private void nudStartAddress_ValueChanged(object sender, EventArgs e)
        {
            if (!init)
            {
                UpdateUpdateButtonStatus();
                nudEndAddress.Value = nudStartAddress.Value + int.Parse(lblProgramLength.Text);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            lvwPrograms.SelectedItems[0].Text = txtProgramName.Text;

            OricFileInfo programInfo = (OricFileInfo)lvwPrograms.SelectedItems[0].Tag;
            programInfo.ProgramName = txtProgramName.Text;
            programInfo.AutoRun = (chkAutoRun.Checked ? OricProgram.AutoRunFlag.Enabled : OricProgram.AutoRunFlag.Disabled);
            programInfo.StartAddress = (ushort)nudStartAddress.Value;
            programInfo.EndAddress = (ushort)nudEndAddress.Value;

            txtProgramName.Tag = txtProgramName.Text;
            chkAutoRun.Tag = chkAutoRun.Checked;
            nudStartAddress.Tag = nudStartAddress.Value;

            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TapeCatalog = new OricFileInfo[lvwPrograms.Items.Count];
            Enumerable.Range(0, TapeCatalog.Length).Select(i => TapeCatalog[i] = (OricFileInfo)lvwPrograms.Items[i].Tag).ToList();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BuildProgramList()
        {
            // Disable refreshing of the list
            lvwPrograms.BeginUpdate();

            // Remove any items currently in the list
            lvwPrograms.Items.Clear();

            // Add each program to the list
            foreach (OricFileInfo programInfo in TapeCatalog)
            {
                ListViewItem listItem = new ListViewItem
                {
                    Text = programInfo.ProgramName,
                    Tag = programInfo
                };
                lvwPrograms.Items.Add(listItem);
            }

            // Enable refreshing of the list
            lvwPrograms.EndUpdate();
        }

        private void UpdateUpdateButtonStatus()
        {
            bool programNameModified = (txtProgramName.TextLength > 0 && txtProgramName.Text != txtProgramName.Tag.ToString());
            bool autoRunModified = (chkAutoRun.Checked != (bool)chkAutoRun.Tag);
            bool startAddessModified = (nudStartAddress.Value != int.Parse(nudStartAddress.Tag.ToString()));

            btnUpdate.Enabled = (programNameModified || autoRunModified || startAddessModified);
        }

        private void UpdateListsButtonsStatus()
        {
            int selectedItemIndex = (lvwPrograms.SelectedItems.Count == 0 ? -1 : lvwPrograms.SelectedIndices[0]);

            btnMoveUp.Enabled = (selectedItemIndex > 0);
            btnMoveDown.Enabled = (selectedItemIndex > -1 && selectedItemIndex < lvwPrograms.Items.Count - 1);
            btnDelete.Enabled = (selectedItemIndex > -1);

            //buttonMoveUp.Enabled = buttonMoveDown.Enabled = buttonDelete.Enabled = false;
        }
    }
}
