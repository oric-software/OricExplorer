using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;

namespace OricExplorer
{
    public partial class FileListForm : DockContent
    {
        MainForm pParent;

        public FileListForm(MainForm mainForm)
        {
            InitializeComponent();

            pParent = mainForm;
        }

        #region Drag and Drop Functions
        private void treeFileList_DragEnter(object sender, DragEventArgs e)
        {
            // If SHIFT key is pressed then we do a MOVE
            if ((e.KeyState & 4) == 4)
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.Copy;
        }

        private void treeFileList_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.All);
        }

        private void treeFileList_DragOver(object sender, DragEventArgs e)
        {
            Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
            TreeNode currentNode = ((TreeView)sender).GetNodeAt(pt);

            // Make sure the next visible node is in view
            if (currentNode.NextVisibleNode != null)
                currentNode.NextVisibleNode.EnsureVisible();

            // Ensure the previous visible node is in view too!
            if (currentNode.PrevVisibleNode != null)
                currentNode.PrevVisibleNode.EnsureVisible();
        }

        private void treeFileList_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));

                TreeNode DestinationNode = ((TreeView)sender).GetNodeAt(pt);
                TreeNode SourceNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");

                // Obtain Source media type
                OricExplorer.MediaType SourceMediaType = DragDropGetMediaType(SourceNode);

                // Obtain Destination media type
                OricExplorer.MediaType DestinationMediaType = DragDropGetMediaType(DestinationNode);

                // Perform drag and drop if valid media
                switch (DestinationMediaType)
                {
                    case OricExplorer.MediaType.OricTape:
                    case OricExplorer.MediaType.TapeFile:
                        if (DestinationMediaType == OricExplorer.MediaType.TapeFile)
                        {
                            DestinationNode = DestinationNode.Parent;
                        }

                        if (SourceMediaType == OricExplorer.MediaType.TapeFile || SourceMediaType == OricExplorer.MediaType.OricTape)
                        {
                            CopyTapeFilesToTape(SourceNode, DestinationNode);
                        }
                        break;

                    default:
                        break;
                }
            }
        }

        private OricExplorer.MediaType DragDropGetMediaType(TreeNode fileNode)
        {
            // Initialise the media type
            OricExplorer.MediaType MediaType = OricExplorer.MediaType.UnknownMedia;

            // Determine the mediatype based on the Node tag
            if (fileNode.Tag.GetType().ToString().Equals("OricExplorer.TapeInfo"))
            {
                MediaType = OricExplorer.MediaType.OricTape;
            }
            else if (fileNode.Tag.GetType().ToString().Equals("OricExplorer.Catalog"))
            {
                OricFileInfo programInfo = new OricFileInfo();
                programInfo = (OricFileInfo)fileNode.Tag;

                if (programInfo.MediaType == OricExplorer.MediaType.TapeFile)
                {
                    MediaType = OricExplorer.MediaType.TapeFile;
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
            destinationTape.TapeName = Path.Combine(destinationTapeInfo.Folder, destinationTapeInfo.Name);

            // Copy a file from a Tape
            if (sourceTreeNode.Tag.GetType().ToString().Equals("OricExplorer.Catalog"))
            {
                // Retrieve program information from the source node
                OricFileInfo programInfo = (OricFileInfo)sourceTreeNode.Tag;

                // Load the program contents from the source tape
                OricProgram oricProgram = new OricProgram();

                OricTape sourceTape = new OricTape();
                oricProgram = sourceTape.Load(Path.Combine(programInfo.Folder, programInfo.ParentName), programInfo.ProgramName, programInfo.ProgramIndex);

                // Copy file to the end of the destination tape
                destinationTape.SaveFile(oricProgram);
            }

            // Copy a whole Tape
            if (sourceTreeNode.Tag.GetType().ToString().Equals("OricExplorer.TapeInfo"))
            {
                // Retrieve information about the source Tape
                TapeInfo sourceTapeInfo = (TapeInfo)sourceTreeNode.Tag;

                OricTape sourceTape = new OricTape();
                sourceTape.TapeName = Path.Combine(sourceTapeInfo.Folder, sourceTapeInfo.Name);

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
            FileInfo fiTape = new FileInfo(Path.Combine(destinationTapeInfo.Folder, destinationTreeNode.Text));

            // Remove destination Tape from Tree list
            destinationTreeNode.Remove();

            // Add the updated Tape to the Tree list and display the files in the Tape
            TreeNode newTreeNode = pParent.AddTapeToTree(fiTape);
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
                            String strFolder = tapeInfo.Folder;

                            String sourceFileName = String.Format("{0}\\{1}", strFolder, tapeInfo.Name);
                            String destFileName = String.Format("{0}\\{1}", strFolder, e.Label);

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

                                String errorMessage = String.Format("Failed to rename tape\n\n{0}", ex.Message);

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

        private void treeFileList_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            treeFileList.SelectedNode = selectedNode;

            if ((e.Button != MouseButtons.Left) || (selectedNode == null || selectedNode.Tag == null))
                return;

            String nodeTag = selectedNode.Tag.GetType().ToString();

            switch (nodeTag)
            {
                // Program has been selected so display the hex view/source code
                case "OricExplorer.OricFileInfo":
                    pParent.DisplayFileContents((OricFileInfo)selectedNode.Tag);
                    break;

                // Disk of Unknown format selected, display file contents
                case "OricExplorer.OricDiskInfo":
                    OricDiskInfo diskInfo = (OricDiskInfo)selectedNode.Tag;

                    if(diskInfo.DOSFormat == OricDisk.DOSFormats.Unknown)
                    {
                        pParent.DisplayUnknownDisk(diskInfo);
                    }
                    break;

                case "System.String":
                    pParent.DisplayROMContents((String)selectedNode.Tag);
                    break;

                default:
                    break;
            }
        }

        private void treeFileList_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            treeFileList.SelectedNode = selectedNode;

            if ((e.Button != MouseButtons.Left) || (selectedNode == null || selectedNode.Tag == null))
                return;

            String nodeTag = selectedNode.Tag.GetType().ToString();

            switch (nodeTag)
            {
                // Tape display will have it's own user control (yet to be defined)
                case "OricExplorer.TapeInfo":
                    foreach (TreeNode fileNode in selectedNode.Nodes)
                    {
                        pParent.DisplayFileContents((OricFileInfo)fileNode.Tag);
                    }
                    break;

                default:
                    break;
            }
        }
    }
}
