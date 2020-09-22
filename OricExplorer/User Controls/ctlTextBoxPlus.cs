namespace OricExplorer
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class TextBoxPlus : TextBox
    {
        public TextBoxPlus()
        {
            InitializeComponent();

            this.ClearButton = false;

            this.Resize += TextBoxPlus_Resize;
        }

        public bool ClearButton { get { return picClear.Visible; } set { picClear.Visible = value; } }

        private void TextBoxPlus_Resize(object sender, EventArgs e)
        {
            picClear.Location = new Point(this.Width - picClear.Width - picClear.Margin.Right - 3, (this.Height - picClear.Height - 3) / 2);
        }

        private void picClear_MouseEnter(object sender, EventArgs e)
        {
            picClear.Image = picClear.ErrorImage;
        }
        private void picClear_MouseLeave(object sender, EventArgs e)
        {
            picClear.Image = picClear.InitialImage;
        }
        private void picClear_Click(object sender, EventArgs e)
        {
            this.Text = string.Empty;
        }
    }
}
