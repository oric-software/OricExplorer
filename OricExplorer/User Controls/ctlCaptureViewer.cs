namespace OricExplorer.User_Controls
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class ctlCaptureViewer : UserControl
    {
        public ctlCaptureViewer()
        {
            InitializeComponent();
        }
        public ctlCaptureViewer(Image image, string text)
        {
            InitializeComponent();

            this.Image = image;
            this.Text = text;
        }

        public Image Image
        { 
            get
            {
                return picImage.Image;
            }
            set
            {
                picImage.Image = value;
            }
        }
        public override string Text
        { 
            get
            {
                return chkSélection.Text;
            }
            set
            {
                chkSélection.Text = value;
            }
        }
        public bool Checked
        {
            get 
            {
                return chkSélection.Checked;
            }
            set
            {
                chkSélection.Checked = value;
            }
        }

        public event EventHandler CheckChanged;

        private void chkSélection_Click(object sender, System.EventArgs e)
        {
            this.CheckChanged?.Invoke(this, e);
        }
    }
}
