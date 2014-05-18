namespace Win8Redialer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.chkAutoStart = new System.Windows.Forms.CheckBox();
            this.chkAutoDial = new System.Windows.Forms.CheckBox();
            this.chkNoBytes = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chkHosted = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.IntegralHeight = false;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(17, 22);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(350, 175);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(14, 378);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Status Window:";
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.SystemColors.Window;
            this.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStatus.Location = new System.Drawing.Point(15, 399);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStatus.Size = new System.Drawing.Size(473, 79);
            this.txtStatus.TabIndex = 4;
            this.txtStatus.TextChanged += new System.EventHandler(this.txtStatus_TextChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Double click to open";
            this.notifyIcon1.BalloonTipTitle = "Win8 Redialer";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Win8 Redialer";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // timer2
            // 
            this.timer2.Interval = 30000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(14, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Detected Connections:";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(93)))), ((int)(((byte)(48)))));
            this.button3.BackgroundImage = global::Win8Redialer.Properties.Resources.about1;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(380, 245);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(108, 102);
            this.button3.TabIndex = 3;
            this.button3.Text = "About";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(0)))), ((int)(((byte)(36)))));
            this.button2.BackgroundImage = global::Win8Redialer.Properties.Resources.stop1;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Enabled = false;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(380, 134);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 102);
            this.button2.TabIndex = 2;
            this.button2.Text = "Stop";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(156)))), ((int)(((byte)(0)))));
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Enabled = false;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(382, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 102);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(14, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Options:";
            // 
            // chkAutoStart
            // 
            this.chkAutoStart.AutoSize = true;
            this.chkAutoStart.Location = new System.Drawing.Point(21, 218);
            this.chkAutoStart.Name = "chkAutoStart";
            this.chkAutoStart.Size = new System.Drawing.Size(148, 21);
            this.chkAutoStart.TabIndex = 7;
            this.chkAutoStart.Text = "Start with Windows";
            this.chkAutoStart.UseVisualStyleBackColor = true;
            this.chkAutoStart.CheckedChanged += new System.EventHandler(this.chkAutoStart_CheckedChanged);
            // 
            // chkAutoDial
            // 
            this.chkAutoDial.AutoSize = true;
            this.chkAutoDial.Location = new System.Drawing.Point(21, 245);
            this.chkAutoDial.Name = "chkAutoDial";
            this.chkAutoDial.Size = new System.Drawing.Size(270, 21);
            this.chkAutoDial.TabIndex = 8;
            this.chkAutoDial.Text = "Auto Start Dialing(Default Connection)";
            this.chkAutoDial.UseVisualStyleBackColor = true;
            this.chkAutoDial.CheckedChanged += new System.EventHandler(this.chkAutoDial_CheckedChanged);
            // 
            // chkNoBytes
            // 
            this.chkNoBytes.AutoSize = true;
            this.chkNoBytes.Location = new System.Drawing.Point(21, 272);
            this.chkNoBytes.Name = "chkNoBytes";
            this.chkNoBytes.Size = new System.Drawing.Size(225, 21);
            this.chkNoBytes.TabIndex = 9;
            this.chkNoBytes.Text = "Disconnect/Connect if no bytes";
            this.chkNoBytes.UseVisualStyleBackColor = true;
            this.chkNoBytes.CheckedChanged += new System.EventHandler(this.chkNoBytes_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(17, 325);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(290, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Username/Password for PPPOE connections";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(20, 345);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 22);
            this.txtUserName.TabIndex = 11;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(126, 345);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 22);
            this.txtPassword.TabIndex = 12;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(81)))), ((int)(((byte)(43)))));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(232, 345);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(108, 24);
            this.button5.TabIndex = 14;
            this.button5.Text = "Save";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 300000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chkHosted
            // 
            this.chkHosted.AutoSize = true;
            this.chkHosted.Location = new System.Drawing.Point(21, 299);
            this.chkHosted.Name = "chkHosted";
            this.chkHosted.Size = new System.Drawing.Size(180, 21);
            this.chkHosted.TabIndex = 15;
            this.chkHosted.Text = "Restart Hosted Network";
            this.chkHosted.UseVisualStyleBackColor = true;
            this.chkHosted.CheckedChanged += new System.EventHandler(this.chkHosted_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.ClientSize = new System.Drawing.Size(502, 491);
            this.Controls.Add(this.chkHosted);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkNoBytes);
            this.Controls.Add(this.chkAutoDial);
            this.Controls.Add(this.chkAutoStart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Win8 Redialer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        public System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkAutoStart;
        private System.Windows.Forms.CheckBox chkAutoDial;
        private System.Windows.Forms.CheckBox chkNoBytes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox chkHosted;
    }
}

