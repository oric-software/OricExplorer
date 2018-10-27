using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OricExplorer.Forms
{
    public partial class DataViewerForm : Form
    {
        DataViewerControl dataViewerControl;

        public DataViewerForm(OricFileInfo fileInfo, OricProgram programData)
        {
            InitializeComponent();

            dataViewerControl = new DataViewerControl();
            dataViewerControl.ProgramInfo = fileInfo;
            dataViewerControl.ProgramData = programData;
            dataViewerControl.InitialiseView();

            this.Controls.Add(dataViewerControl);
            this.Size = new Size(dataViewerControl.Width + 15, dataViewerControl.Height + 40);

            this.Text = String.Format("Data Viewer - {0} ({1})", fileInfo.ProgramName, Path.GetFileName(fileInfo.ParentName));
        }
    }
}
