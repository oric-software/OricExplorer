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
            link.LinkData = "http://web.archive.org/web/20190609120811/http://oric.mrandmrsdavies.com/";
            lklWebsite.Links.Add(link);

            // Add a link to the LinkLabel.
            link = new LinkLabel.Link();
            link.LinkData = "https://github.com/oric-software/OricExplorer";
            lklRepository.Links.Add(link);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Close the About box
            Close();
        }

        private void lklWebsiteAndRepository_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Send the URL to the operating system.
            Process.Start(e.Link.LinkData as string);
        }

        private void rtbContributors_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }

        private void rtbContributors_Enter(object sender, EventArgs e)
        {
            btnOK.Focus();
        }
    }
}
