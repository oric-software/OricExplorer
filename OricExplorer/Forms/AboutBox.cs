using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;

namespace OricExplorer
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
        }

        private void AboutBox_Load(object sender, EventArgs e)
        {
            // Add a link to the LinkLabel.
            LinkLabel.Link link = new LinkLabel.Link();
            link.LinkData = "http://oric.mrandmrsdavies.com/";
            linkLabel3.Links.Add(link);

            // Add a link to the LinkLabel.
            link = new LinkLabel.Link();
            link.LinkData = "mailto:yicker419@gmail.com?Subject=Oric%20Explorer%20Feedback";
            linkLabel4.Links.Add(link);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Close the About box
            Close();
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Send the URL to the operating system.
            Process.Start(e.Link.LinkData as string);
        }
    }
}
