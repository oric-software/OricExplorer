using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using WeifenLuo.WinFormsUI.Docking;
using Be.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace OricExplorer.User_Controls
{
    public partial class SectorViewerControl : DockContent
    {
        private DirectoryListColumnSorter lvwColumnSorter; 
        private OricFileInfo[] diskDirectory;

        private String diskPathName = "";

        private Byte selectedIndex = 0;

        private Image imageSectorMap0;
        private Image imageSectorMap1;

        private int gridRowHeight = 6;
        private int gridColWidth = 8;

        private int gridOffsetX = 1;
        private int gridOffsetY = 1;

        private int gridWidth = 0;
        private int gridHeight = 0;

        private UInt16 gridTrack = 0;
        private UInt16 gridSector = 1;
        private UInt16 gridIndex = 0;

        private Byte currentTrack = 0;
        private Byte currentSector = 1;

        private OricDiskInfo diskInfo;

        public SectorViewerControl()
        {
            InitializeComponent();

            lvwColumnSorter = new DirectoryListColumnSorter();
            lvDirectory.ListViewItemSorter = lvwColumnSorter;
        }

        private void SectorViewerControl_Load(object sender, EventArgs e)
        {
            checkBoxViewGroups.Checked = true;

            buttonPrintDirectory.Enabled = false;
            buttonPrintPreview.Enabled = false;
            buttonPrintSetup.Enabled = false;
        }

        public void InitialDisplay()
        {
            diskInfo = new OricDiskInfo(diskPathName);

            // Setup trackbars
            trackBarTracks.Minimum = 0;
            trackBarTracks.Maximum = diskInfo.TracksPerSide - 1;
            trackBarTracks.Value = 0;

            trackBarSectors.Minimum = 1;
            trackBarSectors.Maximum = diskInfo.SectorsPerTrack;
            trackBarSectors.Value = 1;

            DisplayDiskInformation();
            SetupPieChart();
            BuildDirectoryList();
            SetupSectorMap();
            UpdateDisplay();
        }

        private void DisplayDiskInformation()
        {
            labelDiskName.Text = diskInfo.DiskName.Trim();
            labelDiskType.Text = String.Format("{0} Disk", diskInfo.DiskType.ToString());
            labelDiskFolder.Text = Path.GetDirectoryName(diskInfo.FullName);

            labelDOSFormat.Text = diskInfo.DOSFormat.ToString();
            labelDosVersion.Text = diskInfo.DOSVersion.ToString();

            labelTracksPerSide.Text = String.Format("{0} tracks per side", diskInfo.TracksPerSide);
            labelSectorsPerTrack.Text = String.Format("{0} sectors per track", diskInfo.SectorsPerTrack);
            labelSectorSize.Text = "256 bytes";

            labelFileCount.Text = String.Format("{0}", diskInfo.FileCount);

            if (diskInfo.Sides == 1)
            {
                labelSides.Text = "Single Sided";
            }
            else if (diskInfo.Sides == 2)
            {
                labelSides.Text = "Double Sided";
            }
            else
            {
                labelSides.Text = "Unknown";
            }

            labelSectorsUsed.Text = String.Format("{0:N0} sectors", diskInfo.SectorsUsed);
            labelSectorsFree.Text = String.Format("{0:N0} sectors", diskInfo.SectorsFree);
            labelSectorTotal.Text = String.Format("{0:N0} sectors", diskInfo.Sectors);

            //labelCreated.Text = String.Format("{0} at {1}", diskInfo.CreationTime.ToLongDateString(), diskInfo.CreationTime.ToLongTimeString());
            //labelModified.Text = String.Format("{0} at {1}", diskInfo.LastWriteTime.ToLongDateString(), diskInfo.LastWriteTime.ToLongTimeString());
        }

        private void SetupPieChart()
        {
            chart1.SuspendLayout();

            float usedSectorsPercent = (float)diskInfo.SectorsUsed / (float)diskInfo.Sectors;
            usedSectorsPercent = usedSectorsPercent * 100;

            float freeSectorsPercent = (float)diskInfo.SectorsFree / (float)diskInfo.Sectors;
            freeSectorsPercent = freeSectorsPercent * 100;

            chart1.Series[0].Points[0].YValues[0] = usedSectorsPercent;
            chart1.Series[0].Points[0].AxisLabel = String.Format("Used - {0:N0}%", usedSectorsPercent);

            chart1.Series[0].Points[1].YValues[0] = freeSectorsPercent;
            chart1.Series[0].Points[1].AxisLabel = String.Format("Free - {0:N0}%", freeSectorsPercent);

            chart1.ResumeLayout();
            chart1.Invalidate();
        }

        private void GetSectorInfo(UInt16 index, ref String sectorFormat, ref String sectorDetails)
        {
            Byte bData = 0;
            Boolean bDescriptor = false;

            OricFileInfo programInfo;

            UInt16 sectorInfo = diskInfo.GetSectorInfo(index);

            /*if (diskSectorMap == null)
            {
                sectorFormat = "-- Unknown --";
                sectorDetails = "Unknown";
                return;
            }*/

            switch (sectorInfo >> 8)
            {
                // Unused Sector
                case 0xFF:
                    sectorFormat = "Unused Sector";
                    sectorDetails = "";
                    break;

                // System sector
                case 0x01:
                    sectorFormat = "System Sector";

                    switch ((Byte)(sectorInfo - 0x0100))
                    {
                        case 0x01: sectorDetails = "Version Information"; break;
                        case 0x02: sectorDetails = "Copyright Details"; break;
                        case 0x03: sectorDetails = "Boot Code"; break;
                        default: sectorDetails = ""; break;
                    }
                    break;

                // Bitmap
                case 0x02:
                    sectorDetails = "";

                    bData = (Byte)(sectorInfo - 0x0200);

                    if (bData == 0x01)
                        sectorFormat = "1st Bitmap";
                    else if (bData == 0x02)
                        sectorFormat = "2nd Bitmap";
                    else
                        sectorFormat = "";
                    break;

                // Directory
                case 0x04:
                    sectorFormat = "Directory";

                    bData = (Byte)(sectorInfo - 0x0400);
                    sectorDetails = String.Format("{0} Entries", bData);

                    if (bData == 0x00)
                    {
                        sectorDetails += " (Empty)";
                    }
                    else if (bData == 0x0F)
                    {
                        sectorDetails += " (Full)";
                    }
                    else
                    {
                        sectorDetails += String.Format(" ({0} Free)", 15 - bData);
                    }

                    break;

                // SedOric Disk Operating System
                case 0x08:
                    sectorFormat = "Disk Operating System";

                    bData = (Byte)(sectorInfo - 0x0800);

                    if ((bData & 0x80) == 0x80)
                    {
                        bDescriptor = true;
                        bData = (Byte)(bData ^ 0x80);
                    }
                    else
                        bDescriptor = false;

                    if (bData == 0)
                    {
                        sectorDetails = "DOS Kernel";

                        if (bDescriptor)
                            sectorDetails += " Descriptor";
                    }
                    else
                    {
                        if (bDescriptor)
                            sectorDetails = "Descriptor for ";

                        sectorDetails += String.Format("Bank {0}", bData);

                        if (!bDescriptor)
                            sectorDetails += " Data";
                    }
                    break;

                // File Descriptor
                case 0x11:
                    sectorFormat = "File Descriptor";

                    bData = (Byte)(sectorInfo - 0x1100);
                    programInfo = (OricFileInfo)diskDirectory[bData - 1];
                    sectorDetails = programInfo.ProgramName;
                    break;

                // File/Program Data
                default:
                    sectorFormat = "File/Program Data";

                    bData = (Byte)(sectorInfo - 0x1000);
                    programInfo = (OricFileInfo)diskDirectory[bData - 1];
                    sectorDetails = programInfo.ProgramName;
                    break;
            }
        }

        public String DiskPath
        {
            set { diskPathName = value; }
        }

        #region Sector Map Functions
        private void SetupSectorMap()
        {
            gridRowHeight = 6;
            gridColWidth = 8;

            gridOffsetX = 1;
            gridOffsetY = 1;

            gridWidth = 0;
            gridHeight = 0;

            gridTrack = 0;
            gridSector = 1;
            gridIndex = 0;

            gridWidth = gridColWidth * diskInfo.SectorsPerTrack;

            if (diskInfo.TracksPerSide < 42)
            {
                gridRowHeight = gridRowHeight * 2;
            }
            else if (diskInfo.TracksPerSide < 43)
            {
                gridRowHeight = gridRowHeight + 5;
            }

            gridHeight = gridRowHeight * diskInfo.TracksPerSide;

            if (diskInfo.Sides == 1)
            {
                tabSides.TabPages.Remove(tabPageSide1);
            }
            else
            {
                if (tabSides.TabCount == 1)
                {
                    tabSides.TabPages.Add(tabPageSide1);
                }
            }

            imageSectorMap0 = new Bitmap(pbSectorMapSide0.Width, pbSectorMapSide0.Height);
            imageSectorMap1 = new Bitmap(pbSectorMapSide1.Width, pbSectorMapSide1.Height);

            DrawSectorMap(0);
            pbSectorMapSide0.Image = imageSectorMap0;

            if (diskInfo.Sides == 2)
            {
                DrawSectorMap(1);
                pbSectorMapSide1.Image = imageSectorMap1;
            }
        }

        private void DrawSectorMap(int iSide)
        {
            Graphics newGraphics;

            if(iSide == 0)
            {
                newGraphics = Graphics.FromImage(imageSectorMap0);
            }
            else
            {
                newGraphics = Graphics.FromImage(imageSectorMap1);
            }

            newGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            Pen gridPen = new Pen(Color.FromArgb(125, 125, 125));
            newGraphics.DrawRectangle(gridPen, gridOffsetX, gridOffsetY, gridWidth, gridHeight);

            Color cSectorColor = Color.White;

            for (int iTrack = 0; iTrack < diskInfo.TracksPerSide; iTrack++)
            {
                for(int iSector = 0; iSector < diskInfo.SectorsPerTrack; iSector++)
                {
                    Boolean bBevelled;

                    int iXPos = ((iSector * gridColWidth) + gridOffsetX) + 1;
                    int iYPos = ((iTrack * gridRowHeight) + gridOffsetY) + 1;

                    int iWidth = gridColWidth - 1;
                    int iHeight = gridRowHeight - 1;

                    Byte bByte = (Byte)(SectorMapGetMarker(iSide, iTrack, iSector) >> 8);

                    switch(bByte)
                    {
                        // Sector is unused
                        case 0xFF:
                            cSectorColor = Color.FromArgb(240, 240, 240);
                            bBevelled = true;
                            break;

                        // System sector
                        case 0x01:
                            cSectorColor = Color.FromArgb(255, 165, 0);
                            bBevelled = true;
                            break;

                        // Bitmap sector
                        case 0x02:
                            cSectorColor = Color.FromArgb(255, 0, 255);
                            bBevelled = true;
                            break;

                        // Directory sector
                        case 0x04:
                            cSectorColor = Color.FromArgb(0, 0, 220);
                            bBevelled = true;
                            break;

                        // DOS
                        case 0x08:
                            // Is it a descriptor or actual data
                            Byte bData = (Byte)(SectorMapGetMarker(iSide, iTrack, iSector) - 0x0800);

                            if ((bData & 0x80) == 0x80)
                                cSectorColor = Color.FromArgb(0, 220, 220);
                            else
                                cSectorColor = Color.Cyan;

                            bBevelled = true;
                            break;

                        // File Descriptor
                        case 0x11:
                            if ((Byte)(SectorMapGetMarker(iSide, iTrack, iSector) - 0x1000) == selectedIndex)
                            {
                                cSectorColor = Color.FromArgb(180, 0, 0);
                                bBevelled = false;
                            }
                            else
                            {
                                cSectorColor = Color.FromArgb(0, 220, 0);
                                bBevelled = true;
                            }
                            break;

                        // File/Data Sector
                        default:
                            if ((Byte)(SectorMapGetMarker(iSide, iTrack, iSector) - 0x1000) == selectedIndex)
                            {
                                cSectorColor = Color.FromArgb(255, 0, 0);
                                bBevelled = false;
                            }
                            else
                            {
                                cSectorColor = Color.FromArgb(0, 255, 0);
                                bBevelled = true;
                            }
                            break;
                    }

                    DrawMarker(newGraphics, iXPos, iYPos, iWidth, iHeight, cSectorColor, bBevelled);
                }
            }

            // Dispose of graphics object.
            newGraphics.Dispose();
        }

        private void DrawMarker(Graphics gr, int x, int y, int w, int h, Color cr, Boolean bevelled)
        {
            Pen topleft;
            Pen bottomright;

            // Draw filled area
            gr.FillRectangle(new SolidBrush(cr), x, y, w, h);

            if (bevelled)
            {
                topleft = new Pen(Color.White);
                bottomright = new Pen(Color.Black);
            }
            else
            {
                topleft = new Pen(Color.Black);
                bottomright = new Pen(Color.White);
            }
            
            // Draw white lines
            gr.DrawLine(topleft, x + w, y, x, y);
            gr.DrawLine(topleft, x, y, x, y + h);

            // Draw black lines
            gr.DrawLine(bottomright, x, y + h, x + w, y + h);
            gr.DrawLine(bottomright, x + w, y + h, x + w, y);
        }

        private UInt16 SectorMapGetMarker(int side, int track, int sector)
        {
            int offset = side * diskInfo.TracksPerSide;

            UInt16 index = (UInt16)(((track + offset) * diskInfo.SectorsPerTrack) + sector);
            UInt16 sectorInfo = diskInfo.GetSectorInfo(index);

            /*if (diskSectorMap == null || index >= diskSectorMap.Length)
            {
                return 0xFFFF;
            }*/

            return sectorInfo;
        }

        private UInt16 SectorMapGetMarker(int track, int sector)
        {
            int side = 0;
            UInt16 index = 0;

            if (tabSides.SelectedIndex == 0)
            {
                side = 0;
            }
            else
            {
                side = 1;
            }

            if(side == 0)
            {
                index = (UInt16)((track * diskInfo.SectorsPerTrack) + sector);
            }
            else
            {
                index = (UInt16)(((track + diskInfo.TracksPerSide) * diskInfo.SectorsPerTrack) + sector);
            }

            UInt16 sectorInfo = diskInfo.GetSectorInfo(index);

            /*if (diskSectorMap == null || index > diskSectorMap.Length)
            {
                return 0xFFFF;
            }*/

            return sectorInfo;
        }

        private void CalcGridValues(int iXPos, int iYPos)
        {
            // Calculate current Track
            gridTrack = (UInt16)((iYPos - gridOffsetY) / gridRowHeight);

            // Calculate current Sector
            gridSector = (UInt16)(((iXPos - gridOffsetX) / gridColWidth) + 1);

            // Calculate index offset
            int iOffset = tabSides.SelectedIndex * diskInfo.TracksPerSide;

            gridIndex = (UInt16)(((gridTrack + iOffset) * diskInfo.SectorsPerTrack) + (gridSector - 1));
        }

        private void pbSectorMap_MouseMove(object sender, MouseEventArgs e)
        {
            int iMouseXPos = e.X + 1;
            int iMouseYPos = e.Y + 1;

            Rectangle rectGridLimits = new Rectangle(gridOffsetX, gridOffsetY, gridWidth, gridHeight);

            if(rectGridLimits.Contains(iMouseXPos, iMouseYPos))
            {
                CalcGridValues(iMouseXPos, iMouseYPos);

                String sectorFormat = "";
                String sectorDetails = "";

                GetSectorInfo(gridIndex, ref sectorFormat, ref sectorDetails);

                labelSectorMapSide.Text = String.Format("{0:D2}", tabSides.SelectedIndex);
                labelSectorMapTrack.Text = String.Format("{0:D2}", gridTrack);
                labelSectorMapSector.Text = String.Format("{0:D2}", gridSector);

                labelSectorMapTrackHex.Text = String.Format("{0:X2}", gridTrack);
                labelSectorMapSectorHex.Text = String.Format("{0:X2}", gridSector);

                if (sectorDetails.Length > 0)
                {
                    labelSectorMapInfo.Text = String.Format("{0}\n{1}", sectorFormat, sectorDetails);
                }
                else
                {
                    labelSectorMapInfo.Text = sectorFormat;
                }
            }
        }

        private void pbSectorMap_MouseLeave(object sender, EventArgs e)
        {
            labelSectorMapSide.Text = "";
            labelSectorMapTrack.Text = "";
            labelSectorMapTrackHex.Text = "";
            labelSectorMapSector.Text = "";
            labelSectorMapSectorHex.Text = "";
            labelSectorMapInfo.Text = "";
        }

        private void pbSectorMap_MouseUp(object sender, MouseEventArgs e)
        {
            int iMouseXPos = e.X + 1;
            int iMouseYPos = e.Y + 1;

            int iSelectedIndex = 0;

            Rectangle rectGridLimits = new Rectangle(gridOffsetX, gridOffsetY, gridWidth, gridHeight);

            if(rectGridLimits.Contains(iMouseXPos, iMouseYPos))
            {
                Byte bCurrSector = (Byte)((iMouseXPos - gridOffsetX) / gridColWidth);
                Byte bCurrTrack = (Byte)(((iMouseYPos - gridOffsetY) / gridRowHeight));

                int iIndex = 0;

                if (tabSides.SelectedIndex == 0)
                {
                    iIndex = (bCurrTrack * diskInfo.SectorsPerTrack) + bCurrSector;
                }
                else
                {
                    iIndex = ((bCurrTrack + diskInfo.TracksPerSide) * diskInfo.SectorsPerTrack) + bCurrSector;
                }
                
                // Display sector data as a Hexdump
                currentTrack = bCurrTrack;
                currentSector = (Byte)(bCurrSector + 1);
                UpdateDisplay();

                Byte bMarker = (Byte)(SectorMapGetMarker(bCurrTrack, bCurrSector) >> 8);

                if (bMarker == 0x10 || bMarker == 0x11)
                {
                    if (bMarker == 0x10)
                        iSelectedIndex = ((SectorMapGetMarker(bCurrTrack, bCurrSector) - 0x1000) - 1);
                    else
                        iSelectedIndex = ((SectorMapGetMarker(bCurrTrack, bCurrSector) - 0x1100) - 1);

                    foreach (ListViewItem lvItem in lvDirectory.Items)
                    {
                        if (Convert.ToInt16(lvItem.Tag) == iSelectedIndex)
                        {
                            lvDirectory.Focus();

                            lvItem.Selected = true;
                            lvItem.EnsureVisible();

                            DisplayProgramsSectorList(iSelectedIndex);
                        }
                    }

                    selectedIndex = Convert.ToByte(iSelectedIndex + 1);
                }
                else
                {
                    selectedIndex = 0;
                }

                DrawSectorMap(0);
                pbSectorMapSide0.Image = imageSectorMap0;

                if (diskInfo.Sides == 2)
                {
                    DrawSectorMap(1);
                    pbSectorMapSide1.Image = imageSectorMap1;
                }
            }
        }
        #endregion

        #region Directory Listing Functions
        private void BuildDirectoryList()
        {
            // Display the Wait/Busy cursor
            //Cursor.Current = Cursors.WaitCursor;

            diskDirectory = diskInfo.GetFiles();

            // Prevent the listview from refreshing whilst we update it
            lvDirectory.BeginUpdate();

            // Remove any items currently in the list
            lvDirectory.Items.Clear();

            if (diskDirectory != null)
            {
                if (diskDirectory.Length > 0)
                {
                    foreach (OricFileInfo programInfo in diskDirectory)
                    {
                        UInt16 ui16GroupIndex;
                        Color colItemColour;
                        String strFormat;

                        switch (programInfo.Format)
                        {
                            case OricProgram.ProgramFormat.BasicProgram:
                                strFormat = "BASIC Program";
                                colItemColour = Color.Black;
                                ui16GroupIndex = 0;
                                break;

                            case OricProgram.ProgramFormat.CodeFile:
                                strFormat = "Code/Data File";
                                colItemColour = Color.Black;
                                ui16GroupIndex = 1;
                                break;

                            case OricProgram.ProgramFormat.TextScreen:
                                strFormat = "TEXT Screen";
                                colItemColour = Color.Gray;
                                ui16GroupIndex = 2;
                                break;

                            case OricProgram.ProgramFormat.HiresScreen:
                                strFormat = "HIRES Screen";
                                colItemColour = Color.Gray;
                                ui16GroupIndex = 3;
                                break;

                            case OricProgram.ProgramFormat.CharacterSet:
                                strFormat = "Character Set";
                                colItemColour = Color.Gray;
                                ui16GroupIndex = 4;
                                break;

                            case OricProgram.ProgramFormat.WindowFile:
                                strFormat = "Window File";
                                colItemColour = Color.Gray;
                                ui16GroupIndex = 5;
                                break;

                            case OricProgram.ProgramFormat.SequentialFile:
                                strFormat = "Sequential Data File";
                                colItemColour = Color.Green;
                                ui16GroupIndex = 6;
                                break;

                            case OricProgram.ProgramFormat.DirectAccessFile:
                                strFormat = "Direct Access File";
                                colItemColour = Color.Green;
                                ui16GroupIndex = 7;
                                break;

                            case OricProgram.ProgramFormat.UnknownFile:
                                strFormat = "Unknown Format";
                                colItemColour = Color.DarkRed;
                                ui16GroupIndex = 8;
                                break;

                            default:
                                strFormat = "Unknown Format";
                                colItemColour = Color.DarkRed;
                                ui16GroupIndex = 8;
                                break;

                            case OricProgram.ProgramFormat.HelpFile:
                                strFormat = "HELP Screen";
                                colItemColour = Color.Gray;
                                ui16GroupIndex = 9;
                                break;
                        }

                        // Col 0 - Filename
                        // Col 1 - Format
                        // Col 2 - No. of Sectors
                        // Col 3 - Size (bytes)
                        // Col 4 - Start
                        // Col 5 - End
                        // Col 6 - Exe
                        // Col 7 - Auto Run
                        // Col 8 - Protection

                        ListViewItem lvItem = new ListViewItem();

                        lvItem.ForeColor = colItemColour;
                        lvItem.Text = programInfo.ProgramName;
                        lvItem.Group = lvDirectory.Groups[ui16GroupIndex];

                        lvItem.SubItems.Add(strFormat);

                        lvItem.SubItems.Add(String.Format("{0}", programInfo.LengthSectors));
                        lvItem.SubItems.Add(String.Format("{0:N0}", programInfo.LengthBytes));
                        lvItem.SubItems.Add(String.Format("${0:X4}", programInfo.StartAddress));
                        lvItem.SubItems.Add(String.Format("${0:X4}", programInfo.EndAddress));

                        if (programInfo.StartAddress != programInfo.ExeAddress && programInfo.ExeAddress != 0x0000)
                        {
                            lvItem.SubItems.Add(String.Format("${0:X4}", programInfo.ExeAddress));
                        }
                        else
                        {
                            lvItem.SubItems.Add("");
                        }

                        if (programInfo.AutoRun == OricProgram.AutoRunFlag.Enabled)
                        {
                            lvItem.SubItems.Add("Enabled");
                        }
                        else
                        {
                            lvItem.SubItems.Add("Disabled");
                        }

                        lvItem.SubItems.Add(programInfo.Protection.ToString());

                        // Setup the tag value with the current index
                        lvItem.Tag = lvDirectory.Items.Count;

                        // Add details to the list
                        lvDirectory.Items.Add(lvItem);
                    }
                }
            }

            // Adjust column widths to fit their contents
            AdjustListViewColumnHeaderWidths(lvDirectory);

            // Allow the listview to refresh it's data
            lvDirectory.EndUpdate();

            // Return the cursor back to the default
            //Cursor.Current = Cursors.Default;
        }

        private void AdjustListViewColumnHeaderWidths(ListView listView)
        {
            for (int iIndex = 0; iIndex < listView.Columns.Count; iIndex++)
            {
                if (listView.Columns[iIndex].Text.Length > 0)
                {
                    listView.Columns[iIndex].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    int iColSizeContent = listView.Columns[iIndex].Width;

                    listView.Columns[iIndex].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                    int iColSizeHeader = listView.Columns[iIndex].Width;

                    if (iColSizeContent > iColSizeHeader)
                    {
                        listView.Columns[iIndex].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    }
                }
                else
                {
                    listView.Columns[iIndex].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                }
            }
        }

        private void lvDirectory_MouseClick(object sender, MouseEventArgs e)
        {
            int iSelectedCount = lvDirectory.SelectedItems.Count;

            if(iSelectedCount > 0)
            {
                ListViewItem lvSelected = lvDirectory.SelectedItems[0];

                int iIndex = Convert.ToInt16(lvSelected.Tag);

                selectedIndex = Convert.ToByte(iIndex);
                selectedIndex++;

                OricFileInfo programInfo = (OricFileInfo)diskDirectory[iIndex];

                Byte bTrack = programInfo.FirstTrack;
                Byte bSector = programInfo.FirstSector;

                if((bTrack & 0x80) == 0x80)
                {
                    // Track is on Side 1
                    if(tabSides.SelectedIndex != 1)
                        tabSides.SelectedIndex = 1;
                }
                else
                {
                    // Track is on Side 0
                    if(tabSides.SelectedIndex != 0)
                        tabSides.SelectedIndex = 0;
                }

                // Redraw the Sector maps
                DrawSectorMap(0);
                pbSectorMapSide0.Image = imageSectorMap0;

                // Only redraw Side 2 if double sided disk
                if (diskInfo.Sides == 2)
                {
                    DrawSectorMap(1);
                    pbSectorMapSide1.Image = imageSectorMap1;
                }

                int iMapIndex = 0;

                if((bTrack & 0x80) == 0x80)
                {
                    bTrack = (Byte)(bTrack & 0x7F);
                    iMapIndex = ((bTrack + diskInfo.TracksPerSide) * diskInfo.SectorsPerTrack) + bSector;
                }
                else
                {
                    iMapIndex = (bTrack * diskInfo.SectorsPerTrack) + bSector;
                }

                currentTrack = bTrack;
                currentSector = bSector;
                UpdateDisplay();

                DisplayProgramsSectorList(iIndex);
            }
        }

        private void lvDirectory_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if(e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if(lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            lvDirectory.Sort();
        }

        private void checkBoxViewGroups_CheckedChanged(object sender, EventArgs e)
        {
            lvDirectory.ShowGroups = checkBoxViewGroups.Checked;
        }
        #endregion

        #region Directory Print Functions
        private void buttonPrintDirectory_Click(object sender, EventArgs e)
        {

        }

        private void buttonPrintPreview_Click(object sender, EventArgs e)
        {

        }

        private void buttonPrintSetup_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Sector Hexdump Functions
        private void UpdateDisplay()
        {
            UInt16 iMapIndex = 0;

            if (tabSides.SelectedIndex > 0)
            {
                iMapIndex = (UInt16)(((currentTrack + diskInfo.TracksPerSide) * diskInfo.SectorsPerTrack) + (currentSector - 1));
                currentTrack += 0x80;
            }
            else
            {
                iMapIndex = (UInt16)((currentTrack * diskInfo.SectorsPerTrack) + (currentSector - 1));
            }

            if (tabSides.SelectedIndex == 0)
            {
                label6.Text = String.Format("Side 0, Track {0}, Sector {1}", currentTrack, currentSector);
            }
            else
            {
                label6.Text = String.Format("Side 1, Track {0:G2}, Sector {1,2}", currentTrack & 0x7F, currentSector);
            }

            String sectorFormat = "";
            String sectorDetails = "";
            GetSectorInfo(iMapIndex, ref sectorFormat, ref sectorDetails);

            label7.Text = sectorFormat;

            if (sectorDetails.Length > 0)
            {
                label7.Text += String.Format(" - {0}", sectorDetails);
            }

            // Read current sector
            Byte[] byteArray = diskInfo.ReadSector(currentTrack, currentSector);

            // Display current sector
            DynamicByteProvider dynamicByteProvider;
            dynamicByteProvider = new DynamicByteProvider(byteArray);

            hexBoxSectorView.ByteProvider = dynamicByteProvider;

            trackBarTracks.Value = currentTrack & 0x7F;
            trackBarSectors.Value = currentSector;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            currentTrack = Convert.ToByte(trackBarTracks.Value);
            UpdateDisplay();

            listViewSectorList.Items.Clear();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            currentSector = Convert.ToByte(trackBarSectors.Value);
            UpdateDisplay();

            listViewSectorList.Items.Clear();
        }
        #endregion

        private void DisplayProgramsSectorList(int iSelectedIndex)
        {
            OricFileInfo programInfo = diskDirectory[iSelectedIndex];

            listViewSectorList.BeginUpdate();
            listViewSectorList.Items.Clear();

            OricDos oricDosDisk = new OricDos();
            oricDosDisk.LoadDisk(programInfo.ParentName);

            UInt16 fileSide = 0x00;

            UInt16 fileTrack2 = 0x00;
            UInt16 fileTrack = programInfo.FirstTrack;
            UInt16 fileSector = programInfo.FirstSector;

            UInt16 nextTrack = 0x00;
            UInt16 nextSector = 0x00;

            while (fileSector != 0)
            {
                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = String.Format("{0}", listViewSectorList.Items.Count+1);

                if ((fileTrack & 0x80) == 0x80)
                {
                    fileTrack2 = (UInt16)(fileTrack & 0x7F);
                    fileSide = 1;
                }
                else
                {
                    fileTrack2 = fileTrack;
                    fileSide = 0;
                }

                if (checkBoxDisplayAsHex.Checked)
                {
                    lvItem.SubItems.Add(String.Format("{0:X2}", fileSide));
                    lvItem.SubItems.Add(String.Format("{0:X2}", fileTrack2));
                    lvItem.SubItems.Add(String.Format("{0:X2}", fileSector));
                }
                else
                {
                    lvItem.SubItems.Add(String.Format("{0:D2}", fileSide));
                    lvItem.SubItems.Add(String.Format("{0:D2}", fileTrack2));
                    lvItem.SubItems.Add(String.Format("{0:D2}", fileSector));
                }

                if (listViewSectorList.Items.Count % 2 == 0)
                {
                    lvItem.BackColor = Color.White;
                }
                else
                {
                    lvItem.BackColor = Color.WhiteSmoke;
                }

                listViewSectorList.Items.Add(lvItem);

                // Read next sector
                oricDosDisk.ReadSector(fileTrack, fileSector, ref nextTrack, ref nextSector);

                fileTrack = nextTrack;
                fileSector = nextSector;
            }

            // Adjust column widths to fit their contents
            AdjustListViewColumnHeaderWidths(listViewSectorList);

            listViewSectorList.EndUpdate();
        }

        private void listViewSectorList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem lvSelected = listViewSectorList.SelectedItems[0];

            Byte side = Convert.ToByte(lvSelected.SubItems[1].Text);
            Byte track = Convert.ToByte(lvSelected.SubItems[2].Text);
            Byte sector = Convert.ToByte(lvSelected.SubItems[3].Text);

            // Display sector data as a Hexdump
            if (tabSides.SelectedIndex != side)
            {
                tabSides.SelectedIndex = side;
            }

            currentTrack = track;
            currentSector = sector;
            UpdateDisplay();
        }

        private void checkBoxDisplayAsHex_CheckedChanged(object sender, EventArgs e)
        {

        }
    }

	public class DirectoryListColumnSorter : IComparer
	{
		private int ColumnToSort;
		private SortOrder OrderOfSort;
		private CaseInsensitiveComparer ObjectCompare;

        public DirectoryListColumnSorter()
		{
			// Initialize the column to '0'
			ColumnToSort = 0;

			// Initialize the sort order to 'none'
			OrderOfSort = SortOrder.None;

			// Initialize the CaseInsensitiveComparer object
			ObjectCompare = new CaseInsensitiveComparer();
		}

		public int Compare(object x, object y)
		{
			int compareResult = 0;

			// Cast the objects to be compared to ListViewItem objects
            ListViewItem listviewX = (ListViewItem)x;
            ListViewItem listviewY = (ListViewItem)y;

			// Compare the two items
            if (ColumnToSort == 2 || ColumnToSort == 3)
                compareResult = decimal.Compare(Convert.ToDecimal(listviewX.SubItems[ColumnToSort].Text), Convert.ToDecimal(listviewY.SubItems[ColumnToSort].Text));
            else
                compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);

			// Calculate correct return value based on object comparison
			if (OrderOfSort == SortOrder.Ascending)
				return compareResult;
			else if (OrderOfSort == SortOrder.Descending)
				return (-compareResult);
			else
				return 0;
		}

		public int SortColumn
	    {
    		set { ColumnToSort = value; }
    		get { return ColumnToSort; }
    	}

	    public SortOrder Order
	    {
		    set { OrderOfSort = value; }
		    get { return OrderOfSort; }
	    }
    }
}
