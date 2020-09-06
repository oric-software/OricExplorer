namespace OricExplorer.User_Controls
{
    using Be.Windows.Forms;
    using System;
    using System.Collections;
    using System.Drawing;
    using System.Windows.Forms;
    using WeifenLuo.WinFormsUI.Docking;

    public partial class frmDiskInfoViewer : DockContent
    {
        private DirectoryListColumnSorter lvwColumnSorter; 
        private OricFileInfo[] diskDirectory;

        private string diskPathName = "";

        private byte selectedIndex = 0;

        private Image imageSectorMap0;
        private Image imageSectorMap1;

        private int gridRowHeight = 8;
        private int gridColWidth = 6;

        private int gridOffsetX = 1;
        private int gridOffsetY = 1;

        private int gridWidth = 0;
        private int gridHeight = 0;

        private ushort gridTrack = 0;
        private ushort gridSector = 1;
        private ushort gridIndex = 0;

        private byte currentTrack = 0;
        private byte currentSector = 1;

        private OricDiskInfo diskInfo;

        private frmMainForm parentForm;

        public frmDiskInfoViewer(frmMainForm form)
        {
            InitializeComponent();

            lvwColumnSorter = new DirectoryListColumnSorter();
            lvwDirectory.ListViewItemSorter = lvwColumnSorter;

            parentForm = form;
        }

        private void frmDiskInfoViewer_Load(object sender, EventArgs e)
        {
            chkViewGroups.Checked = true;

            btnPrintDirectory.Enabled = false;
            btnPrintPreview.Enabled = false;
            btnPrintSetup.Enabled = false;

            btnJumpToSector.Enabled = false;

            hxbSectorData.BackColor = Configuration.Persistent.PageBackground;
            hxbSectorData.InfoForeColor = ((SolidBrush)Configuration.Persistent.SyntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpHeadersStyle].ForeBrush).Color;
            hxbSectorData.ForeColor = ((SolidBrush)Configuration.Persistent.SyntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpHexStyle].ForeBrush).Color;
            hxbSectorData.StringViewColour = ((SolidBrush)Configuration.Persistent.SyntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpAsciiStyle].ForeBrush).Color;
            hxbSectorData.SelectionBackColor = ((SolidBrush)Configuration.Persistent.SyntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpMainSelectionBackStyle].ForeBrush).Color;
            hxbSectorData.SelectionForeColor = ((SolidBrush)Configuration.Persistent.SyntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpMainSelectionFrontStyle].ForeBrush).Color;
            hxbSectorData.ShadowSelectionColor = ((SolidBrush)Configuration.Persistent.SyntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpSecondarySelectionBackStyle].ForeBrush).Color;
            hxbSectorData.ShadowSelectionColor = Color.FromArgb(100, hxbSectorData.ShadowSelectionColor.R, hxbSectorData.ShadowSelectionColor.G, hxbSectorData.ShadowSelectionColor.B);

            InitialDisplay();

            Text = string.Format("Disk Information - {0}", diskInfo.FullName);
        }

        public void InitialDisplay()
        {
            diskInfo = new OricDiskInfo(diskPathName);
            diskInfo.BuildSectorMap();

            // Setup trackbars
            tkbTracks.Minimum = 0;
            tkbTracks.Maximum = diskInfo.TracksPerSide - 1;
            tkbTracks.Value = 0;

            tkbSectors.Minimum = 1;
            tkbSectors.Maximum = diskInfo.SectorsPerTrack;
            tkbSectors.Value = 1;

            BuildDirectoryList();
            SetupSectorMap();
            DisplayDiskInformation();
            DrawUsageGraph();

            UpdateDisplay();
        }

        private void DisplayDiskInformation()
        {
            ibxDiskName.Text = diskInfo.DiskName.Trim();
            ibxDiskType.Text = string.Format("{0} Disk", diskInfo.DiskType.ToString());

            ibxDOS.Text = string.Format("{0}\n{1}", diskInfo.DOSFormat.ToString(), diskInfo.DosVersion());

            if (diskInfo.Sides == 1)
            {
                ibxStructure.Text = "Single Sided";
            }
            else if (diskInfo.Sides == 2)
            {
                ibxStructure.Text = "Double Sided";
            }
            else
            {
                ibxStructure.Text = "Unknown";
            }

            ibxStructure.Text += string.Format("\n{0} Tracks per Side\n{1} Sectors per Track", diskInfo.TracksPerSide, diskInfo.SectorsPerTrack);

            ibxUsage.Text = string.Format("{0:N0} Sectors used\n{1:N0} Sectors free\nTotal of {2:N0} Sectors\n({3} Files on Disk)",
                                              diskInfo.SectorsUsed, diskInfo.SectorsFree, diskInfo.Sectors, lvwDirectory.Items.Count);
        }

        private void GetSectorInfo(ushort index, ref string sectorFormat, ref string sectorDetails)
        {
            byte bData = 0;
            bool bDescriptor = false;

            OricFileInfo programInfo;

            ushort sectorInfo = diskInfo.GetSectorInfo(index);

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

                    switch ((byte)(sectorInfo - 0x0100))
                    {
                        case 0x01:
                            sectorDetails = "Version Information";
                            break;

                        case 0x02:
                            sectorDetails = "Copyright Details";
                            break;

                        case 0x03:
                            sectorDetails = "Boot Code";
                            break;

                        default: 
                            sectorDetails = ""; 
                            break;
                    }
                    break;

                // Bitmap
                case 0x02:
                    sectorDetails = "";

                    bData = (byte)(sectorInfo - 0x0200);

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

                    bData = (byte)(sectorInfo - 0x0400);
                    sectorDetails = string.Format("{0} Entries", bData);

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
                        sectorDetails += string.Format(" ({0} Free)", 15 - bData);
                    }
                    break;

                // SedOric Disk Operating System
                case 0x08:
                    sectorFormat = "Disk Operating System";

                    bData = (byte)(sectorInfo - 0x0800);

                    if ((bData & 0x80) == 0x80)
                    {
                        bDescriptor = true;
                        bData = (byte)(bData ^ 0x80);
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

                        sectorDetails += string.Format("Bank {0}", bData);

                        if (!bDescriptor)
                            sectorDetails += " Data";
                    }
                    break;

                // File Descriptor
                case 0x11:
                    sectorFormat = "File Descriptor";

                    bData = (byte)(sectorInfo - 0x1100);
                    programInfo = (OricFileInfo)diskDirectory[bData - 1];
                    sectorDetails = programInfo.ProgramName;
                    break;

                // File/Program Data
                default:
                    sectorFormat = "File/Program Data";

                    bData = (byte)(sectorInfo - 0x1000);
                    programInfo = (OricFileInfo)diskDirectory[bData - 1];
                    sectorDetails = programInfo.ProgramName;
                    break;
            }
        }

        public string DiskPath
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

            pbUsage.PercentageValue = (int)usedSectorsPercent;
            pbUsage.Text = string.Format("Used {0:N0}%, Free {1:N0}%", usedSectorsPercent, freeSectorsPercent);

            if (usedSectorsPercent > 90)
            {
                pbUsage.PercentageBarColour = Color.Red;
            }
            else if (usedSectorsPercent > 70)
            {
                pbUsage.PercentageBarColour = Color.Orange;
            }
            else
            {
                pbUsage.PercentageBarColour = Color.Lime;
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
                tabSides.TabPages.Remove(tabpSide1);
            }
            else
            {
                if (tabSides.TabCount == 1)
                {
                    tabSides.TabPages.Add(tabpSide1);
                }
            }

            imageSectorMap0 = new Bitmap(picSectorMapSide0.Width, picSectorMapSide0.Height);
            imageSectorMap1 = new Bitmap(picSectorMapSide1.Width, picSectorMapSide1.Height);

            DrawSectorMap(0);
            picSectorMapSide0.Image = imageSectorMap0;

            if (diskInfo.Sides == 2)
            {
                DrawSectorMap(1);
                picSectorMapSide1.Image = imageSectorMap1;
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
                    bool bBevelled;

                    int iXPos = ((iTrack * gridColWidth) + gridOffsetX) + 1;
                    int iYPos = ((iSector * gridRowHeight) + gridOffsetY) + 1;

                    int iWidth = gridColWidth - 1;
                    int iHeight = gridRowHeight - 1;

                    byte bByte = (byte)(SectorMapGetMarker(iSide, iTrack, iSector) >> 8);

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
                            byte bData = (byte)(SectorMapGetMarker(iSide, iTrack, iSector) - 0x0800);

                            if ((bData & 0x80) == 0x80)
                                cSectorColor = Color.FromArgb(0, 220, 220);
                            else
                                cSectorColor = Color.Cyan;

                            bBevelled = true;
                            break;

                        // File Descriptor
                        case 0x11:
                            if ((byte)(SectorMapGetMarker(iSide, iTrack, iSector) - 0x1000) == selectedIndex)
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
                            if ((byte)(SectorMapGetMarker(iSide, iTrack, iSector) - 0x1000) == selectedIndex)
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

        private void DrawMarker(Graphics g, int x, int y, int w, int h, Color cr, bool bevelled)
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
                    string number = string.Format("{0:X2}", column);
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
                    string number = string.Format("{0:X2}", row + 1);
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

        private ushort SectorMapGetMarker(int side, int track, int sector)
        {
            int offset = side * diskInfo.TracksPerSide;

            ushort index = (ushort)(((track + offset) * diskInfo.SectorsPerTrack) + sector);
            ushort sectorInfo = diskInfo.GetSectorInfo(index);

            return sectorInfo;
        }

        private ushort SectorMapGetMarker(int track, int sector)
        {
            int side = 0;
            ushort index = 0;

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
                index = (ushort)((track * diskInfo.SectorsPerTrack) + sector);
            }
            else
            {
                index = (ushort)(((track + diskInfo.TracksPerSide) * diskInfo.SectorsPerTrack) + sector);
            }

            ushort sectorInfo = diskInfo.GetSectorInfo(index);

            /*if (diskSectorMap == null || index > diskSectorMap.Length)
            {
                return 0xFFFF;
            }*/

            return sectorInfo;
        }

        private void CalcGridValues(int iXPos, int iYPos)
        {
            // Calculate current Track
            gridTrack = (ushort)((iXPos - gridOffsetX) / gridColWidth);

            // Calculate current Sector
            gridSector = (ushort)(((iYPos - gridOffsetY) / gridRowHeight) + 1);

            // Calculate index offset
            int iOffset = tabSides.SelectedIndex * diskInfo.TracksPerSide;

            gridIndex = (ushort)(((gridTrack + iOffset) * diskInfo.SectorsPerTrack) + (gridSector - 1));
        }

        private void picSectorMap_MouseMove(object sender, MouseEventArgs e)
        {
            int iMouseXPos = e.X + 1;
            int iMouseYPos = e.Y + 1;

            Rectangle rectGridLimits = new Rectangle(gridOffsetX, gridOffsetY, gridWidth, gridHeight);

            if(rectGridLimits.Contains(iMouseXPos, iMouseYPos))
            {
                CalcGridValues(iMouseXPos, iMouseYPos);

                string sectorFormat = "";
                string sectorDetails = "";

                GetSectorInfo(gridIndex, ref sectorFormat, ref sectorDetails);

                ibxSectorMapTrack.Text = string.Format("#{0:X2} ({1:D2})", gridTrack, gridTrack);
                ibxSectorMapSector.Text = string.Format("#{0:X2} ({1:D2})", gridSector, gridSector);

                if (sectorDetails.Length > 0)
                {
                    ibxSectorMapInfo.Text = string.Format("{0} - {1}", sectorFormat, sectorDetails);
                }
                else
                {
                    ibxSectorMapInfo.Text = sectorFormat;
                }
            }
        }

        private void picSectorMap_MouseLeave(object sender, EventArgs e)
        {
            ibxSectorMapTrack.Text = "--";
            ibxSectorMapSector.Text = "--";
            ibxSectorMapInfo.Text = "--";
        }

        private void picSectorMap_MouseUp(object sender, MouseEventArgs e)
        {
            int iMouseXPos = e.X + 1;
            int iMouseYPos = e.Y + 1;

            int iSelectedIndex = 0;

            Rectangle rectGridLimits = new Rectangle(gridOffsetX, gridOffsetY, gridWidth, gridHeight);

            if(rectGridLimits.Contains(iMouseXPos, iMouseYPos))
            {
                byte bCurrTrack = (byte)((iMouseXPos - gridOffsetX) / gridColWidth);
                byte bCurrSector = (byte)(((iMouseYPos - gridOffsetY) / gridRowHeight));

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
                currentSector = (byte)(bCurrSector + 1);
                UpdateDisplay();

                byte bMarker = (byte)(SectorMapGetMarker(bCurrTrack, bCurrSector) >> 8);

                if (bMarker.In((byte)0x10, (byte)0x11))
                {
                    if (bMarker == 0x10)
                        iSelectedIndex = ((SectorMapGetMarker(bCurrTrack, bCurrSector) - 0x1000) - 1);
                    else
                        iSelectedIndex = ((SectorMapGetMarker(bCurrTrack, bCurrSector) - 0x1100) - 1);

                    foreach (ListViewItem lvItem in lvwDirectory.Items)
                    {
                        if (Convert.ToInt16(lvItem.Tag) == iSelectedIndex)
                        {
                            lvwDirectory.Focus();

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
                picSectorMapSide0.Image = imageSectorMap0;

                if (diskInfo.Sides == 2)
                {
                    DrawSectorMap(1);
                    picSectorMapSide1.Image = imageSectorMap1;
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
            lvwDirectory.BeginUpdate();

            // Remove any items currently in the list
            lvwDirectory.Items.Clear();

            if (diskDirectory != null)
            {
                if (diskDirectory.Length > 0)
                {
                    foreach (OricFileInfo programInfo in diskDirectory)
                    {
                        ushort ui16GroupIndex;
                        Color colItemColour;
                        string strFormat;

                        switch (programInfo.Format)
                        {
                            case OricProgram.ProgramFormat.BasicProgram:
                                strFormat = "BASIC program";
                                colItemColour = Color.Black;
                                ui16GroupIndex = 0;
                                break;

                            case OricProgram.ProgramFormat.HyperbasicProgram:
                                strFormat = "HYPERBASIC source";
                                colItemColour = Color.Black;
                                ui16GroupIndex = 1;
                                break;

                            case OricProgram.ProgramFormat.TeleassSource:
                                strFormat = "TELEASS source";
                                colItemColour = Color.Black;
                                ui16GroupIndex = 1;
                                break;

                            case OricProgram.ProgramFormat.BinaryFile:
                                strFormat = "Code/Data file";
                                colItemColour = Color.Black;
                                ui16GroupIndex = 1;
                                break;

                            case OricProgram.ProgramFormat.TextScreen:
                                strFormat = "TEXT screen";
                                colItemColour = Color.Gray;
                                ui16GroupIndex = 2;
                                break;

                            case OricProgram.ProgramFormat.HiresScreen:
                                strFormat = "HIRES screen";
                                colItemColour = Color.Gray;
                                ui16GroupIndex = 3;
                                break;

                            case OricProgram.ProgramFormat.CharacterSet:
                                strFormat = "Character set";
                                colItemColour = Color.Gray;
                                ui16GroupIndex = 4;
                                break;

                            case OricProgram.ProgramFormat.WindowFile:
                                strFormat = "Window file";
                                colItemColour = Color.Gray;
                                ui16GroupIndex = 5;
                                break;

                            case OricProgram.ProgramFormat.SequentialFile:
                                strFormat = "Sequential data file";
                                colItemColour = Color.Green;
                                ui16GroupIndex = 6;
                                break;

                            case OricProgram.ProgramFormat.DirectAccessFile:
                                strFormat = "Direct access file";
                                colItemColour = Color.Green;
                                ui16GroupIndex = 7;
                                break;

                            case OricProgram.ProgramFormat.UnknownFile:
                                strFormat = "Unknown format";
                                colItemColour = Color.DarkRed;
                                ui16GroupIndex = 8;
                                break;

                            default:
                                strFormat = "Unknown format";
                                colItemColour = Color.DarkRed;
                                ui16GroupIndex = 8;
                                break;

                            case OricProgram.ProgramFormat.HelpFile:
                                strFormat = "HELP screen";
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
                        lvItem.Group = lvwDirectory.Groups[ui16GroupIndex];

                        lvItem.SubItems.Add(strFormat);

                        lvItem.SubItems.Add(string.Format("{0}", programInfo.LengthSectors));
                        lvItem.SubItems.Add(string.Format("{0:N0}", programInfo.LengthBytes));
                        lvItem.SubItems.Add(string.Format("${0:X4}", programInfo.StartAddress));
                        lvItem.SubItems.Add(string.Format("${0:X4}", programInfo.EndAddress));

                        if (programInfo.StartAddress != programInfo.ExeAddress && programInfo.ExeAddress != 0x0000)
                        {
                            lvItem.SubItems.Add(string.Format("${0:X4}", programInfo.ExeAddress));
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
                        lvItem.Tag = lvwDirectory.Items.Count;

                        // Add details to the list
                        lvwDirectory.Items.Add(lvItem);
                    }
                }
            }

            // Adjust column widths to fit their contents
            AdjustListViewColumnHeaderWidths(lvwDirectory);

            // Allow the listview to refresh it's data
            lvwDirectory.EndUpdate();

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

        private void lvwDirectory_MouseClick(object sender, MouseEventArgs e)
        {
            int iSelectedCount = lvwDirectory.SelectedItems.Count;

            if(iSelectedCount > 0)
            {
                ListViewItem lvSelected = lvwDirectory.SelectedItems[0];

                int iIndex = Convert.ToInt16(lvSelected.Tag);

                selectedIndex = Convert.ToByte(iIndex);
                selectedIndex++;

                OricFileInfo programInfo = (OricFileInfo)diskDirectory[iIndex];

                byte bTrack = programInfo.FirstTrack;
                byte bSector = programInfo.FirstSector;

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
                picSectorMapSide0.Image = imageSectorMap0;

                // Only redraw Side 2 if double sided disk
                if (diskInfo.Sides == 2)
                {
                    DrawSectorMap(1);
                    picSectorMapSide1.Image = imageSectorMap1;
                }

                int iMapIndex = 0;

                if((bTrack & 0x80) == 0x80)
                {
                    bTrack = (byte)(bTrack & 0x7F);
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

        private void lvwDirectory_ColumnClick(object sender, ColumnClickEventArgs e)
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
            lvwDirectory.Sort();
        }

        private void chkViewGroups_CheckedChanged(object sender, EventArgs e)
        {
            lvwDirectory.ShowGroups = chkViewGroups.Checked;
        }
        #endregion

        #region Directory Print Functions
        private void btnPrintDirectory_Click(object sender, EventArgs e)
        {

        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {

        }

        private void btnPrintSetup_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Sector Hexdump Functions
        private void UpdateDisplay()
        {
            ushort iMapIndex = 0;

            if (tabSides.SelectedIndex > 0)
            {
                iMapIndex = (ushort)(((currentTrack + diskInfo.TracksPerSide) * diskInfo.SectorsPerTrack) + (currentSector - 1));
                //currentTrack += 0x80;
            }
            else
            {
                iMapIndex = (ushort)((currentTrack * diskInfo.SectorsPerTrack) + (currentSector - 1));
            }

            if (tabSides.SelectedIndex == 0)
            {
                ibxSelectedSide.Text = "0";
                ibxSelectedTrack.Text = string.Format("#{0:X2} ({1})", currentTrack, currentTrack);
            }
            else
            {
                ibxSelectedSide.Text = "1";
                ibxSelectedTrack.Text = string.Format("#{0:X2} ({1})", currentTrack & 0x7F, currentTrack & 0x7F);
            }

            ibxSelectedSector.Text = string.Format("#{0:X2} ({1})", currentSector, currentSector);

            string sectorFormat = "";
            string sectorDetails = "";
            GetSectorInfo(iMapIndex, ref sectorFormat, ref sectorDetails);

            ibxSectorDescription.Text = sectorFormat;

            if (sectorDetails.Length > 0)
            {
                ibxSectorDescription.Text += string.Format("\n{0}", sectorDetails);
            }

            // Read current sector
            byte[] sectorData = diskInfo.ReadSector(currentTrack, currentSector);

            // Display current sector
            DynamicByteProvider dynamicByteProvider;
            dynamicByteProvider = new DynamicByteProvider(sectorData);

            hxbSectorData.ByteProvider = dynamicByteProvider;

            tkbTracks.Value = currentTrack;
            tkbSectors.Value = currentSector;

            ushort sectorInfo = diskInfo.GetSectorInfo(iMapIndex);

            switch (sectorInfo >> 8)
            {
                case 0x04:
                    if (sectorData[0] != 0x00)
                    {
                        ibxNextTrack.Text = string.Format("#{0:X2}", sectorData[0]);
                        ibxNextSector.Text = string.Format("#{0:X2}", sectorData[1]);
                        btnJumpToSector.Enabled = true;
                    }
                    else
                    {
                        ibxNextSide.Text = "-";
                        ibxNextTrack.Text = "--";
                        ibxNextSector.Text = "--";
                        btnJumpToSector.Enabled = false;
                    }
                    break;

                default:
                    ibxNextSide.Text = "-";
                    ibxNextTrack.Text = "--";
                    ibxNextSector.Text = "--";
                    btnJumpToSector.Enabled = false;
                    break;
            }
        }
        #endregion

        private void btnResetTrack_Click(object sender, EventArgs e)
        {
            tkbTracks.Value = 0;
        }

        private void btnResetSector_Click(object sender, EventArgs e)
        {
            tkbSectors.Value = 1;
        }

        private void tkbTracks_ValueChanged(object sender, EventArgs e)
        {
            currentTrack = Convert.ToByte(tkbTracks.Value);
            UpdateDisplay();
        }

        private void tkbSectors_ValueChanged(object sender, EventArgs e)
        {
            currentSector = Convert.ToByte(tkbSectors.Value);
            UpdateDisplay();
        }

        private void btnJumpToSector_Click(object sender, EventArgs e)
        {
            int track = Convert.ToInt16(ibxNextTrack.Text.Substring(1), 16);
            int sector = Convert.ToInt16(ibxNextSector.Text.Substring(1), 16);

            tkbTracks.Value = track;
            tkbSectors.Value = sector;
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
            if (ColumnToSort.In(2, 3))
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
