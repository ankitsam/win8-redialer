using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
namespace Win8Redialer
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            //label1.Text="Created By: Ankit Sharma" + Environment.NewLine + "Download available at: http://www.ankitsharma.info" + Environment.NewLine + "For your suggestions & bug reports email at ankit@ankitsharma.info";
            LinkLabel.Link link = new LinkLabel.Link();
            link.LinkData = "http://www.ankitsharma.info/softwares/windows8-redialer";
            linkLabel2.Links.Add(link);
            link.LinkData = "mailto:ankit@ankitsharma.info";
            linkLabel3.Links.Add(link);
            link.LinkData = "http://www.ankitsharma.info/buy-ankit-a-beer";
            linkLabel1.Links.Add(link);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData as string);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData as string);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData as string);
        }

        

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            VersionHelper versionHelper = new VersionHelper();
            if (versionHelper.CheckForNewVersion())
            {
                if (MessageBox.Show("New Version of Windows 8 Redialer is Available. Download?", "Update", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    versionHelper.DownloadNewVersion();
            }
            else
            {
                MessageBox.Show("You have latest version of Windows 8 Redialer.");
            }
        }
    }
}
