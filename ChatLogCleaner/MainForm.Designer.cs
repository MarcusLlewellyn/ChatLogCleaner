namespace ChatLogCleaner
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblLogTarget = new System.Windows.Forms.Label();
            this.txtLogTargetPath = new System.Windows.Forms.TextBox();
            this.btnViewerLogBrowse = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCleanLogBrowse = new System.Windows.Forms.Button();
            this.txtLogCleanedPath = new System.Windows.Forms.TextBox();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkEmptyLog = new System.Windows.Forms.CheckBox();
            this.btnShowChat = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.tabLogOptions = new System.Windows.Forms.TabPage();
            this.tabChatView = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pnlForecolor = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBackcolor = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnForecolor = new System.Windows.Forms.Button();
            this.pnlBackcolor = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtFont = new System.Windows.Forms.TextBox();
            this.btnFont = new System.Windows.Forms.Button();
            this.chkPreloadChat = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabLogOptions.SuspendLayout();
            this.tabChatView.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLogTarget
            // 
            this.lblLogTarget.AutoSize = true;
            this.lblLogTarget.Location = new System.Drawing.Point(23, 41);
            this.lblLogTarget.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLogTarget.Name = "lblLogTarget";
            this.lblLogTarget.Size = new System.Drawing.Size(78, 17);
            this.lblLogTarget.TabIndex = 0;
            this.lblLogTarget.Text = "Viewer Log";
            // 
            // txtLogTargetPath
            // 
            this.txtLogTargetPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogTargetPath.Location = new System.Drawing.Point(109, 37);
            this.txtLogTargetPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtLogTargetPath.Name = "txtLogTargetPath";
            this.txtLogTargetPath.Size = new System.Drawing.Size(162, 22);
            this.txtLogTargetPath.TabIndex = 1;
            this.txtLogTargetPath.Text = "C:\\Users\\mikey\\AppData\\Roaming\\Alchemy\\marcus_llewellyn.osgrid\\chat.txt";
            // 
            // btnViewerLogBrowse
            // 
            this.btnViewerLogBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewerLogBrowse.Location = new System.Drawing.Point(293, 37);
            this.btnViewerLogBrowse.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewerLogBrowse.Name = "btnViewerLogBrowse";
            this.btnViewerLogBrowse.Size = new System.Drawing.Size(100, 28);
            this.btnViewerLogBrowse.TabIndex = 2;
            this.btnViewerLogBrowse.Text = "Browse...";
            this.btnViewerLogBrowse.UseVisualStyleBackColor = true;
            this.btnViewerLogBrowse.Click += new System.EventHandler(this.btnViewerLogBrowse_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnCleanLogBrowse);
            this.groupBox1.Controls.Add(this.txtLogCleanedPath);
            this.groupBox1.Controls.Add(this.lblLogTarget);
            this.groupBox1.Controls.Add(this.btnViewerLogBrowse);
            this.groupBox1.Controls.Add(this.txtLogTargetPath);
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(401, 129);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chat Log Paths";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 82);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cleaned Log";
            // 
            // btnCleanLogBrowse
            // 
            this.btnCleanLogBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCleanLogBrowse.Location = new System.Drawing.Point(293, 79);
            this.btnCleanLogBrowse.Margin = new System.Windows.Forms.Padding(4);
            this.btnCleanLogBrowse.Name = "btnCleanLogBrowse";
            this.btnCleanLogBrowse.Size = new System.Drawing.Size(100, 28);
            this.btnCleanLogBrowse.TabIndex = 5;
            this.btnCleanLogBrowse.Text = "Browse...";
            this.btnCleanLogBrowse.UseVisualStyleBackColor = true;
            this.btnCleanLogBrowse.Click += new System.EventHandler(this.btnCleanLogBrowse_Click);
            // 
            // txtLogCleanedPath
            // 
            this.txtLogCleanedPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogCleanedPath.Location = new System.Drawing.Point(109, 79);
            this.txtLogCleanedPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtLogCleanedPath.Name = "txtLogCleanedPath";
            this.txtLogCleanedPath.Size = new System.Drawing.Size(162, 22);
            this.txtLogCleanedPath.TabIndex = 4;
            this.txtLogCleanedPath.Text = "C:\\temp\\cleaned.log";
            // 
            // btnStartStop
            // 
            this.btnStartStop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartStop.Location = new System.Drawing.Point(7, 7);
            this.btnStartStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(401, 54);
            this.btnStartStop.TabIndex = 4;
            this.btnStartStop.Text = "Start Cleaning";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.chkPreloadChat);
            this.groupBox2.Controls.Add(this.chkEmptyLog);
            this.groupBox2.Location = new System.Drawing.Point(7, 144);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(401, 96);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // chkEmptyLog
            // 
            this.chkEmptyLog.AutoSize = true;
            this.chkEmptyLog.Location = new System.Drawing.Point(16, 23);
            this.chkEmptyLog.Margin = new System.Windows.Forms.Padding(4);
            this.chkEmptyLog.Name = "chkEmptyLog";
            this.chkEmptyLog.Size = new System.Drawing.Size(153, 21);
            this.chkEmptyLog.TabIndex = 1;
            this.chkEmptyLog.Text = "Start with empty log";
            this.chkEmptyLog.UseVisualStyleBackColor = true;
            // 
            // btnShowChat
            // 
            this.btnShowChat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowChat.Location = new System.Drawing.Point(8, 68);
            this.btnShowChat.Name = "btnShowChat";
            this.btnShowChat.Size = new System.Drawing.Size(400, 54);
            this.btnShowChat.TabIndex = 6;
            this.btnShowChat.Text = "Show Chat";
            this.btnShowChat.UseVisualStyleBackColor = true;
            this.btnShowChat.Click += new System.EventHandler(this.btnShowChat_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabMain);
            this.tabControl1.Controls.Add(this.tabLogOptions);
            this.tabControl1.Controls.Add(this.tabChatView);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(425, 283);
            this.tabControl1.TabIndex = 7;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.btnShowChat);
            this.tabMain.Controls.Add(this.btnStartStop);
            this.tabMain.Location = new System.Drawing.Point(4, 25);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(417, 254);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Main";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // tabLogOptions
            // 
            this.tabLogOptions.Controls.Add(this.groupBox1);
            this.tabLogOptions.Controls.Add(this.groupBox2);
            this.tabLogOptions.Location = new System.Drawing.Point(4, 25);
            this.tabLogOptions.Name = "tabLogOptions";
            this.tabLogOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogOptions.Size = new System.Drawing.Size(417, 254);
            this.tabLogOptions.TabIndex = 1;
            this.tabLogOptions.Text = "Log Options";
            this.tabLogOptions.UseVisualStyleBackColor = true;
            // 
            // tabChatView
            // 
            this.tabChatView.Controls.Add(this.groupBox4);
            this.tabChatView.Controls.Add(this.groupBox3);
            this.tabChatView.Location = new System.Drawing.Point(4, 25);
            this.tabChatView.Name = "tabChatView";
            this.tabChatView.Size = new System.Drawing.Size(417, 222);
            this.tabChatView.TabIndex = 2;
            this.tabChatView.Text = "Chat View Options";
            this.tabChatView.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.pnlForecolor);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.btnBackcolor);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.btnForecolor);
            this.groupBox4.Controls.Add(this.pnlBackcolor);
            this.groupBox4.Location = new System.Drawing.Point(8, 89);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(401, 100);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Select Colors";
            // 
            // pnlForecolor
            // 
            this.pnlForecolor.BackColor = System.Drawing.Color.White;
            this.pnlForecolor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlForecolor.Location = new System.Drawing.Point(19, 53);
            this.pnlForecolor.Name = "pnlForecolor";
            this.pnlForecolor.Size = new System.Drawing.Size(43, 29);
            this.pnlForecolor.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Text Color";
            // 
            // btnBackcolor
            // 
            this.btnBackcolor.Location = new System.Drawing.Point(215, 53);
            this.btnBackcolor.Name = "btnBackcolor";
            this.btnBackcolor.Size = new System.Drawing.Size(75, 29);
            this.btnBackcolor.TabIndex = 7;
            this.btnBackcolor.Text = "Change";
            this.btnBackcolor.UseVisualStyleBackColor = true;
            this.btnBackcolor.Click += new System.EventHandler(this.btnBackcolor_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(162, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Background Color";
            // 
            // btnForecolor
            // 
            this.btnForecolor.Location = new System.Drawing.Point(68, 53);
            this.btnForecolor.Name = "btnForecolor";
            this.btnForecolor.Size = new System.Drawing.Size(75, 29);
            this.btnForecolor.TabIndex = 6;
            this.btnForecolor.Text = "Change";
            this.btnForecolor.UseVisualStyleBackColor = true;
            this.btnForecolor.Click += new System.EventHandler(this.btnForecolor_Click);
            // 
            // pnlBackcolor
            // 
            this.pnlBackcolor.BackColor = System.Drawing.Color.Black;
            this.pnlBackcolor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBackcolor.Location = new System.Drawing.Point(165, 52);
            this.pnlBackcolor.Name = "pnlBackcolor";
            this.pnlBackcolor.Size = new System.Drawing.Size(44, 29);
            this.pnlBackcolor.TabIndex = 5;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtFont);
            this.groupBox3.Controls.Add(this.btnFont);
            this.groupBox3.Location = new System.Drawing.Point(8, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(401, 80);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Select Font";
            // 
            // txtFont
            // 
            this.txtFont.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFont.Location = new System.Drawing.Point(19, 32);
            this.txtFont.Name = "txtFont";
            this.txtFont.ReadOnly = true;
            this.txtFont.Size = new System.Drawing.Size(268, 22);
            this.txtFont.TabIndex = 1;
            // 
            // btnFont
            // 
            this.btnFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFont.Location = new System.Drawing.Point(293, 32);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(102, 29);
            this.btnFont.TabIndex = 0;
            this.btnFont.Text = "Choose Font";
            this.btnFont.UseVisualStyleBackColor = true;
            this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
            // 
            // chkPreloadChat
            // 
            this.chkPreloadChat.AutoSize = true;
            this.chkPreloadChat.Location = new System.Drawing.Point(16, 56);
            this.chkPreloadChat.Name = "chkPreloadChat";
            this.chkPreloadChat.Size = new System.Drawing.Size(239, 21);
            this.chkPreloadChat.TabIndex = 2;
            this.chkPreloadChat.Text = "Populate with existing log content";
            this.chkPreloadChat.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 283);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Chat Log Cleaner";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabLogOptions.ResumeLayout(false);
            this.tabChatView.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblLogTarget;
        private System.Windows.Forms.TextBox txtLogTargetPath;
        private System.Windows.Forms.Button btnViewerLogBrowse;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCleanLogBrowse;
        private System.Windows.Forms.TextBox txtLogCleanedPath;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkEmptyLog;
        private System.Windows.Forms.Button btnShowChat;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.TabPage tabLogOptions;
        private System.Windows.Forms.TabPage tabChatView;
        private System.Windows.Forms.TextBox txtFont;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.Button btnBackcolor;
        private System.Windows.Forms.Button btnForecolor;
        private System.Windows.Forms.Panel pnlBackcolor;
        private System.Windows.Forms.Panel pnlForecolor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkPreloadChat;
    }
}

