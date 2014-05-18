using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DotRas;
using System.Collections.ObjectModel;
using System.Net.Sockets;
using System.IO;
using System.Diagnostics;
using Win8Redialer;
using Microsoft.Win32;
using System.Threading;
namespace Win8Redialer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        RasConnectionWatcher watcher;
        Thread oThread;
        private volatile bool _shouldStop;
        int[] isPPPOE;
        private void Form1_Load(object sender, EventArgs e)
        {
            //declarations
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\RAS AutoDial\\Default\\", true);
            watcher = new RasConnectionWatcher();
            Form1.CheckForIllegalCrossThreadCalls = false;

            //load config file
            PersistentSettings.Instance.Load("win8redialer.config");
            chkAutoStart.Checked = bool.Parse(PersistentSettings.Instance.GetValue("AutoStart", "false"));
            chkAutoDial.Checked = bool.Parse(PersistentSettings.Instance.GetValue("AutoDial", "false"));
            chkNoBytes.Checked = bool.Parse(PersistentSettings.Instance.GetValue("NoBytes", "false"));
            chkHosted.Checked = bool.Parse(PersistentSettings.Instance.GetValue("RestartHostedNetwork", "false"));

            txtUserName.Text = PersistentSettings.Instance.GetValue("Username","" );
            txtPassword.Text = PersistentSettings.Instance.GetValue("Password", "");

            // get list of connections
            try
            {
                RasPhoneBook pbk = new RasPhoneBook();
                pbk.Open(RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.User));
                isPPPOE = new int[pbk.Entries.Count];
                int i=0;
                foreach (RasEntry entry in pbk.Entries)
                {
                    if (entry.DialMode == DotRas.RasDialMode.None)
                        isPPPOE[i] = 1;
                    else
                        isPPPOE[i] = 0;

                    i++;
                    listBox1.Items.Add(entry.Name);
                }
            }
            catch (Exception er)
            {
                appendLog(er.Message);
            }

            //detect default connection
            try
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    if (rkApp != null)
                    {
                        if (listBox1.Items[i].ToString() == rkApp.GetValue("DefaultInternet").ToString())
                        {
                            listBox1.SelectedIndex = i;
                            break;
                        }
                    }
                    else
                    {
                        appendLog("Unable to detect Default connection.");
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                appendLog(ex.Message);
            }
            //Auto dial
            if (chkAutoDial.Checked == true)
            {
                button1_Click(sender, e);
            }
        }
        public void checkUpdate()
        {
            VersionHelper versionHelper = new VersionHelper();
            if (versionHelper.CheckForNewVersion())
            {
                if (MessageBox.Show("New Version of Windows 8 Redialer is Available. Download?", "Update", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    versionHelper.DownloadNewVersion();
            }
        }
        public void appendLog(string str)
        {
            if (txtStatus.Text =="")
                txtStatus.AppendText("[" + DateTime.Now.ToString() + "]:" + str);
            else
                txtStatus.AppendText(Environment.NewLine + "[" + DateTime.Now.ToString() + "]:" + str);

            using (StreamWriter sw = File.AppendText("log.txt"))
            {
                sw.WriteLine("[" + DateTime.Now.ToString() + "]:" + str);
            }
        }
        public void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                appendLog("Select a connection...");
            }
            else
            {
                try
                {
                    appendLog("Win8 Redialer Started...");
                    button1.Enabled = false;
                    button2.Enabled = true;

                    Begin();

                    RasConnection r = RasConnection.GetActiveConnectionByName(listBox1.Items[listBox1.SelectedIndex].ToString(), RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.User));
                    if (r == null)
                    {
                        _shouldStop = false;
                        oThread = new Thread(new ThreadStart(connect));
                        oThread.Start();

                    }
                }
                catch (Exception er)
                {
                    appendLog(er.Message);
                }
            }
        }

        public void Begin()
        {
            try
            {
                if (chkNoBytes.Checked)
                    timer2.Enabled = true;

                watcher.Connected += new EventHandler<RasConnectionEventArgs>(this.watcher_Connected);
                watcher.Disconnected += new EventHandler<RasConnectionEventArgs>(this.watcher_Disconnected);
                watcher.EnableRaisingEvents = true;
            }
            catch (Exception er)
            {
                appendLog(er.Message);
            }
        }
        public void Stop()
        {
            try
            {
                watcher.EnableRaisingEvents = false;
                timer2.Enabled = false;
                RequestStop();
            }
            catch (Exception er)
            {
                appendLog(er.Message);
            }
        }
        private void watcher_Connected(object sender, RasConnectionEventArgs e)
        {
            // A connection has successfully connected.

        }
        public void connect()
        {

        retry:

            try
            {
                if (!_shouldStop)
                {
                    using (RasDialer dialer = new RasDialer())
                    {
                        appendLog("Connecting...");

                        dialer.EntryName = listBox1.Items[listBox1.SelectedIndex].ToString();
                        dialer.PhoneBookPath = RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.User);

                        if (isPPPOE[listBox1.SelectedIndex] == 1)
                            dialer.Credentials = new System.Net.NetworkCredential(txtUserName.Text, txtPassword.Text);

                        dialer.Dial();
                        appendLog("Connected...");

                        if (chkHosted.Checked)
                            RunCmdFile();
                    }
                }
            }
            catch (Exception er)
            {
                appendLog(er.Message);
                appendLog("Trying in 10 secs...");
                Thread.Sleep(1000 * 10);
                goto retry;
            }
        }
        public void RequestStop()
        {
            _shouldStop = true;
        }
        private void RunCmdFile()
        {
            //run command file to reinstall app.
            var p = new Process();
            p.StartInfo = new ProcessStartInfo("cmd.exe", "/c hosted.cmd");
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            //p.WaitForExit();
        }
        private void watcher_Disconnected(object sender, RasConnectionEventArgs e)
        {
            appendLog("Disconnected...");
            _shouldStop = false;
            oThread = new Thread(new ThreadStart(connect));
            oThread.Start();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedIndex != -1)
                {
                    RasConnection r = RasConnection.GetActiveConnectionByName(listBox1.Items[listBox1.SelectedIndex].ToString(), RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.User));
                    if (r == null)
                        appendLog("Current Status:Disconnected");
                    else
                        appendLog("Current Status:" + r.GetConnectionStatus().ConnectionState);

                    if (button1.Enabled == false)
                        button1.Enabled = true;
                }
            }
            catch (Exception er)
            {
                appendLog(er.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            appendLog("Win8 Redialer Stopped...");
            button1.Enabled = true;
            button2.Enabled = false;
            Stop();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {

            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(500);
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (chkNoBytes.Checked == true)
            {
                RasConnection r = RasConnection.GetActiveConnectionByName(listBox1.Items[listBox1.SelectedIndex].ToString(), RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.User));
                if (r != null)
                {
                    using (TcpClient tcp = new TcpClient())
                    {
                        IAsyncResult ar = tcp.BeginConnect("google.com", 80, null, null);
                        System.Threading.WaitHandle wh = ar.AsyncWaitHandle;
                        try
                        {
                            if (!ar.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(5), false))
                            {
                                tcp.Close();
                                appendLog("No Bytes. Disconnecting...");
                                r.HangUp();
                            }

                            //tcp.EndConnect(ar);
                        }
                        finally
                        {
                            wh.Close();
                        }
                    }
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Created By: Ankit Sharma" + Environment.NewLine + "Download available at: http://www.ankitsharma.info" + Environment.NewLine + "For your suggestions & bug reports email at ankit@ankitsharma.info", "About Win8 Redialer", MessageBoxButtons.OK);
            About about = new About();
            about.ShowDialog();
        }

        private void txtStatus_TextChanged(object sender, EventArgs e)
        {
            //File.WriteAllText("log.txt", txtStatus.Text);
        }

        private void chkAutoStart_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (chkAutoStart.Checked == true)
                rkApp.SetValue("Win8 Redialer", Application.ExecutablePath.ToString());
            else
                rkApp.DeleteValue("Win8 Redialer", false);

            PersistentSettings.Instance.SetValue("AutoStart", chkAutoStart.Checked.ToString());
            PersistentSettings.Instance.Save();
        }

        private void chkAutoDial_CheckedChanged(object sender, EventArgs e)
        {
            PersistentSettings.Instance.SetValue("AutoDial", chkAutoDial.Checked.ToString());
            PersistentSettings.Instance.Save();
        }

        private void chkNoBytes_CheckedChanged(object sender, EventArgs e)
        {
            PersistentSettings.Instance.SetValue("NoBytes", chkNoBytes.Checked.ToString());
            PersistentSettings.Instance.Save();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PersistentSettings.Instance.SetValue("Username", txtUserName.Text);
            PersistentSettings.Instance.SetValue("Password", txtPassword.Text);
            PersistentSettings.Instance.Save();
            MessageBox.Show("Saved!");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            checkUpdate();
            timer1.Enabled = false;
        }

        private void chkHosted_CheckedChanged(object sender, EventArgs e)
        {
            PersistentSettings.Instance.SetValue("RestartHostedNetwork", chkHosted.Checked.ToString());
            PersistentSettings.Instance.Save();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit the application?", "Exit Win8 Redialer?",
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question);

            e.Cancel = (result == DialogResult.No);
        }

    }
}
