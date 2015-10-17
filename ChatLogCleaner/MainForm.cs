#region BSD License

// Copyright (c) 2015, Michael Bailey (Marcus Llewellyn)
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
//
// 1. Redistributions of source code must retain the above copyright notice,
//    this list of conditions and the following disclaimer.
//
// 2. Redistributions in binary form must reproduce the above copyright notice,
//    this list of conditions and the following disclaimer in the documentation
//    and/or other materials provided with the distribution.
//
// 3. Neither the name of the copyright holder nor the names of its
//    contributors may be used to endorse or promote products derived from this
//    software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
// ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE
// LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
// CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
// SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
// INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
// CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
// ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
// POSSIBILITY OF SUCH DAMAGE.

#endregion BSD License

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChatLogCleaner
{
    public partial class MainForm : Form
    {
        private long previousSize = 0;
        private long newSize = 0;
        private string viewerlog = string.Empty;
        private string cleanlog = string.Empty;

        private Font chatfont = null;
        private Color forecolor = new Color();
        private Color backcolor = new Color();

        private OpenFileDialog LogTarget = new OpenFileDialog();
        private SaveFileDialog LogCleaned = new SaveFileDialog();
        private FontDialog chatfontdialog = new FontDialog();
        private ColorDialog forecolordialog = new ColorDialog();
        private ColorDialog backcolordialog = new ColorDialog();
        private FileSystemWatcher watcher = new FileSystemWatcher();

        private ChatDisplay frmChat = new ChatDisplay();

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            watcher.Changed += new FileSystemEventHandler(watcher_OnChanged);

            chatfont = this.Font;

            viewerlog = CLC.Default.Target;
            cleanlog = CLC.Default.Cleaned;
            forecolor = CLC.Default.Forecolor;
            backcolor = CLC.Default.Backcolor;
            chatfont = CLC.Default.Font;

            txtLogTargetPath.Text = viewerlog;
            txtLogCleanedPath.Text = cleanlog;
            txtFont.Text = chatfont.Name + ", " + Math.Round(chatfont.Size).ToString();
            pnlBackcolor.BackColor = backcolor;
            pnlForecolor.BackColor = forecolor;

            //Console.WriteLine(txtLogTargetPath.Text.Trim('"'));
            //if (File.Exists(txtLogTargetPath.Text.Trim('"'))) Console.WriteLine("Target Exists");
            //Console.WriteLine(txtLogCleanedPath.Text.Trim('"'));
            //if (File.Exists(txtLogCleanedPath.Text.Trim('"'))) Console.WriteLine("Cleaned Exists");
            if (File.Exists(viewerlog.Trim('"')))
            {
                Console.WriteLine("Loaded");
                btnStartStop.Enabled = true;
            }
            else
            {
                btnStartStop.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogTarget.FileOk += new CancelEventHandler(LogTarget_FileOK);
            LogTarget.ShowDialog();
            txtLogTargetPath.Text = LogTarget.FileName.Trim('"');
            viewerlog = txtLogTargetPath.Text;
            CLC.Default.Target = viewerlog;
            CLC.Default.Save();
            //Console.WriteLine("Filename: " + LogTarget.FileName);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            LogCleaned.FileOk += new CancelEventHandler(LogCleaned_FileOK);
            LogCleaned.Filter = "Log File|*.log|Text File|*.txt";
            LogCleaned.Title = "Save Cleaned Log File";
            LogCleaned.ShowDialog();
            txtLogCleanedPath.Text = LogCleaned.FileName.Trim('"');
            cleanlog = txtLogCleanedPath.Text;
            CLC.Default.Cleaned = cleanlog;
            CLC.Default.Save();
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (btnStartStop.Text == "Start Cleaning")
            {
                if (chkEmptyLog.Checked)
                {
                    if (File.Exists(cleanlog))
                    {
                        File.Delete(cleanlog);
                    }
                }
                watcher.Path = Path.GetDirectoryName(viewerlog);
                watcher.Filter = Path.GetFileName(viewerlog);
                watcher.NotifyFilter = NotifyFilters.Size;
                watcher.EnableRaisingEvents = true;
                btnStartStop.Text = "Stop Cleaning";
                previousSize = new FileInfo(viewerlog).Length;
            }
            else
            {
                watcher.EnableRaisingEvents = false;
                btnStartStop.Text = "Start Cleanings";
            }
        }

        private void btnShowChat_Click(object sender, EventArgs e)
        {
            if (frmChat.IsDisposed)
            {
                frmChat = new ChatDisplay();
            }
            frmChat.LogFile = cleanlog;
            frmChat.ChatFont = chatfont;
            frmChat.Color = forecolor;
            frmChat.BackColor = backcolor;
            frmChat.Show();
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            chatfontdialog.Font = chatfont;
            chatfontdialog.ShowDialog();
            chatfont = chatfontdialog.Font;
            txtFont.Text = chatfont.Name + ", " + Math.Round(chatfont.Size).ToString();
            CLC.Default.Font = chatfont;
            CLC.Default.Save();
        }

        private void btnForecolor_Click(object sender, EventArgs e)
        {
            forecolordialog.ShowDialog();
            forecolor = forecolordialog.Color;
            pnlForecolor.BackColor = forecolor;
            CLC.Default.Forecolor = forecolor;
            CLC.Default.Save();
        }

        private void btnBackcolor_Click(object sender, EventArgs e)
        {
            backcolordialog.ShowDialog();
            backcolor = backcolordialog.Color;
            pnlBackcolor.BackColor = backcolor;
            CLC.Default.Backcolor = backcolor;
            CLC.Default.Save();
        }

        private void LogCleaned_FileOK(object sender, CancelEventArgs e)
        {
            cleanlog = LogCleaned.FileName;
            if (!File.Exists(cleanlog))
            {
                File.Create(cleanlog);
            }

            if ((File.Exists(cleanlog) && (File.Exists(viewerlog))))
            {
                btnStartStop.Enabled = true;
            }
        }

        private void LogTarget_FileOK(object sender, CancelEventArgs e)
        {
            //Console.WriteLine("FileOK");
            viewerlog = LogTarget.FileName;
            if ((File.Exists(cleanlog) && (File.Exists(viewerlog))))
            {
                btnStartStop.Enabled = true;
            }
        }

        private void watcher_OnChanged(object source, FileSystemEventArgs e)
        {
            //Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
            //CleanLogLine(txtLogTargetPath.Text, txtLogCleanedPath.Text);

            newSize = new FileInfo(viewerlog).Length;
            //Console.WriteLine(String.Format("newSize: {0} previousSize: {1}", newSize, previousSize));

            if (newSize > previousSize)
            {
                //Console.WriteLine("Bigger by: " + (newSize - previousSize).ToString() + "bytes.");

                string text = ReadTail(viewerlog, (int)(newSize - previousSize));
                //Console.WriteLine("text: " + text);
                CleanLogLines(text, cleanlog);
                previousSize = newSize;
            }
        }

        private string ReadTail(string filename, int size)
        {
            using (FileStream fs = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                fs.Seek(-size, SeekOrigin.End);
                byte[] bytes = new byte[size];
                fs.Read(bytes, 0, size);
                return Encoding.Default.GetString(bytes);
            }
        }

        private void CleanLogLines(string text, string filecleaned)
        {
            string[] lines = text.Split('\n');
            foreach (string s in lines)
            {
                if (s.Trim() == String.Empty) continue;
                //Console.WriteLine("LineParse: " + LineParse(s));
                using (StreamWriter sw = File.AppendText(filecleaned))
                {
                    sw.WriteLine(LineParse(s));
                }
            }
        }

        private string LineParse(string line)
        {
            string tstamp = String.Empty;
            string username = String.Empty;
            string hgaddress = String.Empty;
            string message = String.Empty;
            string cleanline = String.Empty;

            line = line.TrimEnd();
            if (line == String.Empty) return String.Empty;
            if (line == Environment.NewLine) return String.Empty;

            if (line.StartsWith(" "))
            {
                // This is just a multi-line message.
                return line.Trim();
            }

            char[] delims = { ':' };
            string[] half = line.Substring(20).Split(delims, 2);
            //Console.WriteLine(half.Length.ToString());
            if (half.Length <= 1) return String.Empty;

            //We need special handling for HG names.
            //Console.WriteLine("half[1]: " + half[0]);
            string[] hgtest = half[0].Split(' ');
            if (hgtest.Length > 1)
            {
                if (hgtest[1].Contains('@'))
                {
                    //Console.WriteLine("HG name detected: " + hgtest[1]);
                    string[] hg = line.Substring(20).Split(delims, 3);
                    //Console.WriteLine("1 " + hg[0]);
                    //Console.WriteLine("2 " + hg[1]);
                    if (hg.Length == 3) Console.WriteLine("3 " + hg[2]);
                    username = hg[0].Split(' ')[0];
                    if (hg.Length == 3)
                    {
                        // This address has a port number.
                        hgaddress = hg[0].Split(' ')[1].TrimStart('@') + ":" + hg[1];
                        message = hg[2].Trim();
                    }
                    else
                    {
                        // This address has no port number.
                        hgaddress = hg[0].Split(' ')[1].TrimStart('@');
                        message = hg[1].Trim();
                    }
                }
                else
                {
                    // This wasn't from an HG visitor.
                    username = half[0].Trim();
                    message = half[1].Trim();
                }
            }

            // skip grid messages, on/offline notices, and server version shouts.
            Console.WriteLine(half[0] + half[1]);
            if (message == "is online.") return String.Empty;
            if (message == "is offline.") return String.Empty;
            if (username.Contains("Simulator Version")) return String.Empty;
            if (username == "Grid") return String.Empty;

            // Reformat timestamps.
            tstamp = "[" + line.Substring(12, 6);

            // Look for emotes.
            if ((message.Length > 3) && (message.Substring(0, 3) == "/me"))
            {
                message = message.Substring(4, message.Length - 4);
                if (hgaddress == String.Empty)
                {
                    cleanline = "───\n" + tstamp + " " + username + " " + message;
                }
                else
                {
                    cleanline = "───\n" + tstamp + " " + username + "@" + hgaddress + " " + message;
                }
            }
            else
            {
                if (hgaddress == String.Empty)
                {
                    cleanline = "───\n" + tstamp + " <" + username + ">\n" + message;
                }
                else
                {
                    cleanline = "───\n" + tstamp + " <" + username + ">\n" + "(" + hgaddress + ")\n" + message;
                }
            }

            return cleanline;
        }
    }
}