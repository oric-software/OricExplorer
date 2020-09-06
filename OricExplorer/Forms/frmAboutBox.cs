namespace OricExplorer
{
    using System;
    using System.Diagnostics;
    using System.Windows.Forms;

    partial class frmAboutBox : Form
    {
        public frmAboutBox()
        {
            InitializeComponent();
        }

        private void frmAboutBox_Load(object sender, EventArgs e)
        {
            // Add a link to the LinkLabel.
            LinkLabel.Link link = new LinkLabel.Link();
            link.LinkData = "http://oric.mrandmrsdavies.com/";
            lklWebsite.Links.Add(link);

            // Add a link to the LinkLabel.
            link = new LinkLabel.Link();
            link.LinkData = "mailto:yicker419@gmail.com?Subject=Oric%20Explorer%20Feedback";
            lklContact.Links.Add(link);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Close the About box
            Close();
        }

        private void lklWebsiteAndContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Send the URL to the operating system.
            Process.Start(e.Link.LinkData as string);
        }
    }
}
