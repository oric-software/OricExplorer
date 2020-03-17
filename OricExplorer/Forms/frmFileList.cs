namespace OricExplorer
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using WeifenLuo.WinFormsUI.Docking;
    using static OricExplorer.ConstantsAndEnums;

    public partial class frmFileList : DockContent
    {
        private frmMainForm mMainForm;
        private bool mboolIsDoubleClick = false;
        private TreeNode mnodDestinationOverflown = null;

        public frmFileList(frmMainForm mainForm)
        {
            InitializeComponent();

            mMainForm = mainForm;
        }

        #region Drag and Drop Functions
        private void tvwFileList_ItemDrag(object sender, ItemDragEventArgs e)
        {
            TreeNode selectedNode = (TreeNode)e.Item;
            tvwFileList.SelectedNode = selectedNode;

            MediaType SourceMediaType = DragDropGetMediaType(selectedNode);

            if (SourceMediaType.In(MediaType.OricTape, MediaType.TapeFile))
            {
                DoDragDrop(e.Item, DragDropEffects.All);
            }
        }
        
        private void tvwFileList_DragOver(object sender, DragEventArgs e)
        {
            Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
            TreeNode currentNode = ((TreeView)sender).GetNodeAt(pt);
            
            TreeNode draggedNode = (e.Data.GetType().IsCOMObject ? null : (TreeNode)e.Data.GetData(typeof(TreeNode)));

            // deactivate the drop if drag came from external app or if the tag of the overflown node is null or is not a tape
            if (draggedNode == null || currentNode == null || currentNode.Tag == null || currentNode.Tag.GetType() != typeof(TapeInfo) || currentNode.Equals(draggedNode) || currentNode.Equals(draggedNode.Parent))
            {
                if (mnodDestinationOverflown != null)
                {
                    mnodDestinationOverflown.BackColor = tvwFileList.BackColor;
                    mnodDestinationOverflown.ForeColor = tvwFileList.ForeColor;
                    mnodDestinationOverflown = null;
                }

                e.Effect = DragDropEffects.None;
            }
            else
            {
                if (mnodDestinationOverflown != null && currentNode != mnodDestinationOverflown)
                {
                    mnodDestinationOverflown.BackColor = tvwFileList.BackColor;
                    mnodDestinationOverflown.ForeColor = tvwFileList.ForeColor;
                    mnodDestinationOverflown = null;
                }
                
                if (currentNode != mnodDestinationOverflown)
                {
                    mnodDestinationOverflown = currentNode;
                    mnodDestinationOverflown.BackColor = tvwFileList.ForeColor;
                    mnodDestinationOverflown.ForeColor = tvwFileList.BackColor;
                }

                e.Effect = DragDropEffects.Copy;
            }
        }

        private void tvwFileList_DragDrop(object sender, DragEventArgs e)
        {
            Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));

            TreeNode DestinationNode = ((TreeView)sender).GetNodeAt(pt);
            TreeNode SourceNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            // Obtain Source media type
            MediaType SourceMediaType = DragDropGetMediaType(SourceNode);

            // Obtain Destination media type
            MediaType DestinationMediaType = DragDropGetMediaType(DestinationNode);

            // Perform drag and drop if valid media
            switch (DestinationMediaType)
            {
                case MediaType.OricTape:
                    if (SourceMediaType.In(MediaType.TapeFile, MediaType.OricTape))
                    {
                        CopyTapeFilesToTape(SourceNode, DestinationNode);
                    }
                    break;

                default:
                    break;
            }

            if (mnodDestinationOverflown != null)
            {
                mnodDestinationOverflown.BackColor = tvwFileList.BackColor;
                mnodDestinationOverflown.ForeColor = tvwFileList.ForeColor;
                mnodDestinationOverflown = null;
            }
        }

        private MediaType DragDropGetMediaType(TreeNode fileNode)
        {
            // Initialise the media type
            MediaType MediaType = MediaType.UnknownMedia;

            // Determine the mediatype based on the Node tag
            if (fileNode.Tag == null)
            {
                //
            }
            else if (fileNode.Tag.GetType() == typeof(TapeInfo))
            {
                MediaType = MediaType.OricTape;
            }
            else if (fileNode.Tag.GetType() == typeof(OricFileInfo))
            {
                OricFileInfo programInfo = (OricFileInfo)fileNode.Tag;

                if (programInfo.MediaType == MediaType.TapeFile)
                {
                    MediaType = MediaType.TapeFile;
                }
            }

            return MediaType;
        }
        #endregion

        // Drag and Drop options
        // 1. Tape to Tape
        // 2. Tape to Disk
        // 3. Disk to Disk
        // 4. Disk to Tape

        private void CopyTapeFilesToTape(TreeNode sourceTreeNode, TreeNode destinationTreeNode)
        {
            // Retrieve details of the destination Tape
            TapeInfo destinationTapeInfo = (TapeInfo)destinationTreeNode.Tag;

            OricTape destinationTape = new OricTape();
            destinationTape.TapeName = destinationTapeInfo.FullName;// Path.Combine(destinationTapeInfo.Folder, destinationTapeInfo.Name);

            // Copy a file from a Tape
            if (sourceTreeNode.Tag.GetType() == typeof(OricFileInfo))
            {
                // Retrieve program information from the source node
                OricFileInfo programInfo = (OricFileInfo)sourceTreeNode.Tag;

                // Load the program contents from the source tape
                OricTape sourceTape = new OricTape();
                OricProgram oricProgram = sourceTape.Load(Path.Combine(programInfo.Folder, programInfo.ParentName), programInfo.ProgramName, programInfo.ProgramIndex);

                // Copy file to the end of the destination tape
                destinationTape.SaveFile(oricProgram);
            }
            // Copy a whole Tape
            else if (sourceTreeNode.Tag.GetType() == typeof(TapeInfo))
            {
                // Retrieve information about the source Tape
                TapeInfo sourceTapeInfo = (TapeInfo)sourceTreeNode.Tag;

                OricTape sourceTape = new OricTape();
                sourceTape.TapeName = sourceTapeInfo.FullName;// Path.Combine(sourceTapeInfo.Folder, sourceTapeInfo.Name);

                FileInfo fiTapeFile = new FileInfo(sourceTape.TapeName);

                // Retrieve a catalog of all the programs on the source Tape
                OricFileInfo[] tapeCatalog = sourceTape.Catalog(fiTapeFile);

                foreach (OricFileInfo programInfo in tapeCatalog)
                {
                    // Load the program contents from the source tape
                    OricProgram oricProgram = new OricProgram();
                    oricProgram = sourceTape.Load(Path.Combine(programInfo.Folder, programInfo.ParentName), programInfo.ProgramName, programInfo.ProgramIndex);

                    // Copy file to the end of the destination tape
                    destinationTape.SaveFile(oricProgram);
                }
            }

            // Get full pathname of the updated destination Tape
            FileInfo fiTape = new FileInfo(Path.Combine(Path.GetDirectoryName(destinationTapeInfo.FullName), destinationTreeNode.Text));

            // Remove destination Tape from Tree list
            destinationTreeNode.Remove();

            // Add the updated Tape to the Tree list and display the files in the Tape
            TreeNode newTreeNode = mMainForm.AddTapeToTree(fiTape);
            newTreeNode.Expand();
        }

        /*private void treeFileList_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label != null)
            {
                if (e.Label.Length > 0)
                {
                    if (e.Label.IndexOfAny(new char[] { '@', ',', '!' }) == -1)
                    {
                        TreeNode selectedNode = treeFileList.SelectedNode;

                        if (selectedNode.Tag.GetType().ToString().Equals("OricExplorer.TapeInfo"))
                        {
                            TapeInfo tapeInfo = (TapeInfo)selectedNode.Tag;
                            string strFolder = tapeInfo.Folder;

                            string sourceFileName = string.Format("{0}\\{1}", strFolder, tapeInfo.Name);
                            string destFileName = string.Format("{0}\\{1}", strFolder, e.Label);

                            try
                            {
                                File.Move(sourceFileName, destFileName);

                                // Stop editing without canceling the label change.
                                e.Node.EndEdit(false);

                                // Remove branch
                                selectedNode.Remove();

                                // Update branch
                                FileInfo fiNewFile = new FileInfo(destFileName);
                                //TreeNode tapeNode = AddTapeToTree(fiNewFile);

                                //treeFileList.SelectedNode = tapeNode;
                            }
                            catch (Exception ex)
                            {
                                // Cancel the label edit action, inform the user and place the node in edit mode again.
                                e.CancelEdit = true;

                                string errorMessage = string.Format("Failed to rename tape\n\n{0}", ex.Message);

                                MessageBox.Show(errorMessage, "Tape Rename");
                                e.Node.BeginEdit();
                            }
                        }
                        else if (selectedNode.Tag.GetType().ToString().Equals("OricExplorer.Catalog"))
                        {
                            // Renaming a file. Check if it's a disk or tape file
                            Catalog tempFile = (Catalog)selectedNode.Tag;

                            if (tempFile.MediaType == OricExplorer.MediaType.TapeFile)
                            {
                                // Rename Tape file
                                // e.Label
                            }
                            else
                            {
                                e.CancelEdit = true;
                            }
                        }
                    }
                    else
                    {
                        // Cancel the label edit action, inform the user and place the node in edit mode again.
                        e.CancelEdit = true;

                        MessageBox.Show("Invalid tree node label.\n" + "The invalid characters are: '@','.', ',', '!'", "Node Label Edit");
                        e.Node.BeginEdit();
                    }
                }
                else
                {
                    // Cancel the label edit action, inform the user and place the node in edit mode again.
                    e.CancelEdit = true;

                    MessageBox.Show("Invalid tree node label.\nThe label cannot be blank", "Node Label Edit");
                    e.Node.BeginEdit();
                }

                treeFileList.LabelEdit = false;
            }
        }*/

        private void tvwFileList_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            tvwFileList.SelectedNode = e.Node;
        }

        private void tvwFileList_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode selectedNode = tvwFileList.SelectedNode;

            if ((e.Button != MouseButtons.Left) || (selectedNode == null || selectedNode.Tag == null))
                return;

            // is selected node is a tape, launch the tape in emulator
            if (selectedNode.Tag.GetType() == typeof(TapeInfo))
            {
                mMainForm.LoadTapeInEmulator(Configuration.Persistent.DefaultMachineForTape);
            }
            // is selected node is a disk, launch it in emulator
            else if (selectedNode.Tag.GetType() == typeof(OricDiskInfo))
            {
                // determine the disk type to select the machine for emulator
                OricDiskInfo diskInfo = (OricDiskInfo)selectedNode.Tag;

                switch (diskInfo.DOSFormat)
                {
                    case OricDisk.DOSFormats.Unknown:
                        mMainForm.DisplayUnknownDisk(diskInfo);
                        break;

                    default:
                        mMainForm.LoadDiskInEmulator();
                        break;
                }
            }
            else if (selectedNode.Tag.GetType() == typeof(OricFileInfo))
            {
                OricProgram.SpecialMode specialMode = OricProgram.SpecialMode.None;
                if (selectedNode.Parent.Tag.GetType() == typeof(OricDiskInfo))
                {
                    OricDiskInfo diskInfo = (OricDiskInfo)(selectedNode.Parent.Tag);
                    specialMode = (diskInfo.DOSFormat == OricDisk.DOSFormats.StratSed ? OricProgram.SpecialMode.Telestrat : OricProgram.SpecialMode.None);
                }

                mMainForm.DisplayFileContents((OricFileInfo)selectedNode.Tag, specialMode);
            }
            else if (selectedNode.Tag.GetType() == typeof(RomInfo))
            {
                mMainForm.DisplayROMContents((RomInfo)selectedNode.Tag);
            }
            else if (selectedNode.Tag.GetType() == typeof(OtherFileInfo))
            {
                mMainForm.DisplayOtherFileContents((OtherFileInfo)selectedNode.Tag);
            }
        }

        private void tvwFileList_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            mMainForm.treeFileList_AfterLabelEdit(sender, e);
        }

        private void tvwFileList_MouseDown(object sender, MouseEventArgs e)
        {
            mboolIsDoubleClick = (e.Clicks > 1);
        }

        private void tvwFileList_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (mboolIsDoubleClick && e.Action == TreeViewAction.Expand)
                e.Cancel = true;
        }

        private void tvwFileList_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            if (mboolIsDoubleClick && e.Action == TreeViewAction.Collapse)
                e.Cancel = true;
        }
    }
}
