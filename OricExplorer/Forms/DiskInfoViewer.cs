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
    public partial class DiskInfoViewerControl : DockContent
    {
        private DirectoryListColumnSorter lvwColumnSorter; 
        private OricFileInfo[] diskDirectory;

        private String diskPathName = "";

        private Byte selectedIndex = 0;

        private Image imageSectorMap0;
        private Image imageSectorMap1;

        private int gridRowHeight = 8;
        private int gridColWidth = 6;

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

        private MainForm parentForm;

        public DiskInfoViewerControl(MainForm form)
        {
            InitializeComponent();

            lvwColumnSorter = new DirectoryListColumnSorter();
            lvDirectory.ListViewItemSorter = lvwColumnSorter;

            parentForm = form;
        }

        private void SectorViewerControl_Load(object sender, EventArgs e)
        {
            checkBoxViewGroups.Checked = true;

            buttonPrintDirectory.Enabled = false;
            buttonPrintPreview.Enabled = false;
            buttonPrintSetup.Enabled = false;

            buttonJumpToSector.Enabled = false;

            InitialDisplay();

            Text = String.Format("Disk Information - {0}", diskInfo.FullName);
        }

        public void InitialDisplay()
        {
            diskInfo = new OricDiskInfo(diskPathName);
            diskInfo.BuildSectorMap();

            // Setup trackbars
            trackBarTracks.Minimum = 0;
            trackBarTracks.Maximum = diskInfo.TracksPerSide - 1;
            trackBarTracks.Value = 0;

            trackBarSectors.Minimum = 1;
            trackBarSectors.Maximum = diskInfo.SectorsPerTrack;
            trackBarSectors.Value = 1;

            BuildDirectoryList();
            SetupSectorMap();
            DisplayDiskInformation();
            DrawUsageGraph();

            UpdateDisplay();
        }

        private void DisplayDiskInformation()
        {
            infoBoxDiskName.Text = diskInfo.DiskName.Trim();
            infoBoxDiskType.Text = String.Format("{0} Disk", diskInfo.DiskType.ToString());

            infoBoxDOS.Text = String.Format("{0}\n{1}", diskInfo.DOSFormat.ToString(), diskInfo.DosVersion());

            if (diskInfo.Sides == 1)
            {
                infoBoxStructure.Text = "Single Sided";
            }
            else if (diskInfo.Sides == 2)
            {
                infoBoxStructure.Text = "Double Sided";
            }
            else
            {
                infoBoxStructure.Text = "Unknown";
            }

            infoBoxStructure.Text += String.Format("\n{0} Tracks per Side\n{1} Sectors per Track", diskInfo.TracksPerSide, diskInfo.SectorsPerTrack);

            infoBoxUsage.Text = String.Format("{0:N0} Sectors used\n{1:N0} Sectors free\nTotal of {2:N0} Sectors\n({3} Files on Disk)",
                                              diskInfo.SectorsUsed, diskInfo.SectorsFree, diskInfo.Sectors, lvDirectory.Items.Count);
        }

        private void GetSectorInfo(UInt16 index, ref String sectorFormat, ref String sectorDetails)
        {
            Byte bData = 0;
            Boolean bDescriptor = false;

            OricFileInfo programInfo;

            UInt16 sectorInfo = diskInfo.GetSectorInfo(index);

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

        private void DrawUsageGraph()
        {
            float usedSectorsPercent = 0;
            float freeSectorsPercent = 0;

            if (diskInfo.Sectors > 0)
            {
                // Calculate percentage values
                usedSectorsPercent = (float)diskInfo.SectorsUsed / (float)diskInfo.Sectors;
                usedSectorsPercent = usedSectorsPercent * 100;

                freeSectorsPercent = (float)diskInfo.SectorsFree / (float)diskInfo.Sectors;
                freeSectorsPercent = freeSectorsPercent * 100;
            }

            percentageBar1.PercentageValue = (int)usedSectorsPercent;
            percentageBar1.Text = String.Format("Used {0:N0}%, Free {1:N0}%", usedSectorsPercent, freeSectorsPercent);

            if (usedSectorsPercent > 90)
            {
                percentageBar1.PercentageBarColour = Color.Red;
            }
            else if (usedSectorsPercent > 70)
            {
                percentageBar1.PercentageBarColour = Color.Orange;
            }
            else
            {
                percentageBar1.PercentageBarColour = Color.Lime;
            }
        }

        #region Sector Map Functions
        private void SetupSectorMap()
        {
            gridRowHeight = 8;
            gridColWidth = 8;

            gridOffsetX = 23;
            gridOffsetY = 25;

            gridWidth = 0;
            gridHeight = 0;

            gridTrack = 0;
            gridSector = 1;
            gridIndex = 0;

            gridHeight = gridRowHeight * diskInfo.SectorsPerTrack;

            if (diskInfo.TracksPerSide < 43)
            {
                gridColWidth = gridColWidth + 7;
            }
            /*else if (diskInfo.TracksPerSide < 43)
            {
                gridColWidth = gridColWidth + 5;
            }*/

            gridWidth = gridColWidth * diskInfo.TracksPerSide;

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
            Graphics g;

            if(iSide == 0)
            {
                g = Graphics.FromImage(imageSectorMap0);
            }
            else
            {
                g = Graphics.FromImage(imageSectorMap1);
            }

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            // Draw ruler to show Tracks
            DrawHorizontalRuler(g);

            // Draw ruler to show Sectors
            DrawVerticalRuler(g);

            Pen gridPen = new Pen(Color.FromArgb(125, 125, 125));
            g.DrawRectangle(gridPen, gridOffsetX, gridOffsetY, gridWidth, gridHeight);

            Color cSectorColor = Color.White;

            for (int iTrack = 0; iTrack < diskInfo.TracksPerSide; iTrack++)
            {
                for(int iSector = 0; iSector < diskInfo.SectorsPerTrack; iSector++)
                {
                    Boolean bBevelled;

                    int iXPos = ((iTrack * gridColWidth) + gridOffsetX) + 1;
                    int iYPos = ((iSector * gridRowHeight) + gridOffsetY) + 1;

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

                    DrawMarker(g, iXPos, iYPos, iWidth, iHeight, cSectorColor, bBevelled);
                }
            }

            // Dispose of graphics object.
            g.Dispose();
        }

        private void DrawMarker(Graphics g, int x, int y, int w, int h, Color cr, Boolean bevelled)
        {
            Pen topleft;
            Pen bottomright;

            // Draw filled area
            g.FillRectangle(new SolidBrush(cr), x, y, w, h);

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
            g.DrawLine(topleft, x + w, y, x, y);
            g.DrawLine(topleft, x, y, x, y + h);

            // Draw black lines
            g.DrawLine(bottomright, x, y + h, x + w, y + h);
            g.DrawLine(bottomright, x + w, y + h, x + w, y);
        }

        private void DrawHorizontalRuler(Graphics g)
        {
            // Draw horizontal ruler (No. of Tracks per Side)
            int rulerOffset = 22;

            int rulerX = 10 + rulerOffset;
            int rulerY = 9;

            if(diskInfo.TracksPerSide == 80)
            {
                rulerX = 7 + rulerOffset;
            }

            int rulerWidth = (diskInfo.TracksPerSide * gridColWidth) + (gridColWidth / 2);

            g.FillRectangle(new SolidBrush(Color.FromArgb(230,230,230)), rulerOffset, 6, rulerWidth, 18);
            g.DrawRectangle(new Pen(Color.Black), rulerOffset, 6, rulerWidth, 18);

            Font objFont;
            objFont = new System.Drawing.Font("Consolas", 8);

            // Set format of string.
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Center;
            drawFormat.LineAlignment = StringAlignment.Center;

            for (int column = 0; column < diskInfo.TracksPerSide; column++)
            {
                if ((column % 5) == 0)
                {
                    String number = String.Format("{0:X2}", column);
                    g.DrawString(number, objFont, new SolidBrush(Color.Black), rulerX-2, rulerY + 4, drawFormat);
                    g.DrawLine(new Pen(Color.Black), rulerX-2, rulerY + 9, rulerX-2, rulerY + 14);
                }
                else
                {
                    g.DrawLine(new Pen(Color.Black), rulerX-2, rulerY + 11, rulerX-2, rulerY + 14);
                }

                rulerX += gridColWidth;
            }
        }

        private void DrawVerticalRuler(Graphics g)
        {
            // Draw vertical ruler (No. of Sectors per Track)
            int rulerOffset = 24;

            int rulerX = 8;
            int rulerY = 8 + rulerOffset;

            int rulerHeight = (diskInfo.SectorsPerTrack * gridRowHeight) + gridRowHeight;

            g.FillRectangle(new SolidBrush(Color.FromArgb(230, 230, 230)), 0, rulerOffset, 22, rulerHeight);
            g.DrawRectangle(new Pen(Color.Black), 0, rulerOffset, 22, rulerHeight);

            Font objFont;
            objFont = new System.Drawing.Font("Consolas", 8);

            // Set format of string.
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Center;
            drawFormat.LineAlignment = StringAlignment.Center;

            for (int row = 0; row < diskInfo.SectorsPerTrack; row++)
            {
                if ((row % 2) == 0)
                {
                    String number = String.Format("{0:X2}", row + 1);
                    g.DrawString(number, objFont, new SolidBrush(Color.Black), rulerX + 1, rulerY - 2, drawFormat);
                    g.DrawLine(new Pen(Color.Black), rulerX + 8, rulerY-3, rulerX + 13, rulerY-3);
                }
                else
                {
                    g.DrawLine(new Pen(Color.Black), rulerX + 10, rulerY-3, rulerX + 13, rulerY-3);
                }

                rulerY += gridRowHeight;
            }
        }

        private UInt16 SectorMapGetMarker(int side, int track, int sector)
        {
            int offset = side * diskInfo.TracksPerSide;

            UInt16 index = (UInt16)(((track + offset) * diskInfo.SectorsPerTrack) + sector);
            UInt16 sectorInfo = diskInfo.GetSectorInfo(index);

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
            gridTrack = (UInt16)((iXPos - gridOffsetX) / gridColWidth);

            // Calculate current Sector
            gridSector = (UInt16)(((iYPos - gridOffsetY) / gridRowHeight) + 1);

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

                infoBoxSectorMapTrack.Text = String.Format("#{0:X2} ({1:D2})", gridTrack, gridTrack);
                infoBoxSectorMapSector.Text = String.Format("#{0:X2} ({1:D2})", gridSector, gridSector);

                if (sectorDetails.Length > 0)
                {
                    infoBoxSectorMapInfo.Text = String.Format("{0} - {1}", sectorFormat, sectorDetails);
                }
                else
                {
                    infoBoxSectorMapInfo.Text = sectorFormat;
                }
            }
        }

        private void pbSectorMap_MouseLeave(object sender, EventArgs e)
        {
            infoBoxSectorMapTrack.Text = "--";
            infoBoxSectorMapSector.Text = "--";
            infoBoxSectorMapInfo.Text = "--";
        }

        private void pbSectorMap_MouseUp(object sender, MouseEventArgs e)
        {
            int iMouseXPos = e.X + 1;
            int iMouseYPos = e.Y + 1;

            int iSelectedIndex = 0;

            Rectangle rectGridLimits = new Rectangle(gridOffsetX, gridOffsetY, gridWidth, gridHeight);

            if(rectGridLimits.Contains(iMouseXPos, iMouseYPos))
            {
                Byte bCurrTrack = (Byte)((iMouseXPos - gridOffsetX) / gridColWidth);
                Byte bCurrSector = (Byte)(((iMouseYPos - gridOffsetY) / gridRowHeight));

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
                //currentTrack += 0x80;
            }
            else
            {
                iMapIndex = (UInt16)((currentTrack * diskInfo.SectorsPerTrack) + (currentSector - 1));
            }

            if (tabSides.SelectedIndex == 0)
            {
                infoBoxSelectedSide.Text = "0";
                infoBoxSelectedTrack.Text = String.Format("#{0:X2} ({1})", currentTrack, currentTrack);
            }
            else
            {
                infoBoxSelectedSide.Text = "1";
                infoBoxSelectedTrack.Text = String.Format("#{0:X2} ({1})", currentTrack & 0x7F, currentTrack & 0x7F);
            }

            infoBoxSelectedSector.Text = String.Format("#{0:X2} ({1})", currentSector, currentSector);

            String sectorFormat = "";
            String sectorDetails = "";
            GetSectorInfo(iMapIndex, ref sectorFormat, ref sectorDetails);

            infoBoxSectorDescription.Text = sectorFormat;

            if (sectorDetails.Length > 0)
            {
                infoBoxSectorDescription.Text += String.Format("\n{0}", sectorDetails);
            }

            // Read current sector
            Byte[] sectorData = diskInfo.ReadSector(currentTrack, currentSector);

            // Display current sector
            DynamicByteProvider dynamicByteProvider;
            dynamicByteProvider = new DynamicByteProvider(sectorData);

            hexBox1.ByteProvider = dynamicByteProvider;

            trackBarTracks.Value = currentTrack;
            trackBarSectors.Value = currentSector;

            UInt16 sectorInfo = diskInfo.GetSectorInfo(iMapIndex);

            switch (sectorInfo >> 8)
            {
                case 0x04:
                    if (sectorData[0] != 0x00)
                    {
                        infoBoxNextTrack.Text = String.Format("#{0:X2}", sectorData[0]);
                        infoBoxNextSector.Text = String.Format("#{0:X2}", sectorData[1]);
                        buttonJumpToSector.Enabled = true;
                    }
                    else
                    {
                        infoBoxNextSide.Text = "-";
                        infoBoxNextTrack.Text = "--";
                        infoBoxNextSector.Text = "--";
                        buttonJumpToSector.Enabled = false;
                    }
                    break;

                default:
                    infoBoxNextSide.Text = "-";
                    infoBoxNextTrack.Text = "--";
                    infoBoxNextSector.Text = "--";
                    buttonJumpToSector.Enabled = false;
                    break;
            }
        }
        #endregion

        private void buttonResetTrack_Click(object sender, EventArgs e)
        {
            trackBarTracks.Value = 0;
        }

        private void buttonResetSector_Click(object sender, EventArgs e)
        {
            trackBarSectors.Value = 1;
        }

        private void trackBarTracks_ValueChanged(object sender, EventArgs e)
        {
            currentTrack = Convert.ToByte(trackBarTracks.Value);
            UpdateDisplay();
        }

        private void trackBarSectors_ValueChanged(object sender, EventArgs e)
        {
            currentSector = Convert.ToByte(trackBarSectors.Value);
            UpdateDisplay();
        }

        private void buttonJumpToSector_Click(object sender, EventArgs e)
        {
            int track = Convert.ToInt16(infoBoxNextTrack.Text.Substring(1), 16);
            int sector = Convert.ToInt16(infoBoxNextSector.Text.Substring(1), 16);

            trackBarTracks.Value = track;
            trackBarSectors.Value = sector;
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
