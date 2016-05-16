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
        private long PreviousSize = 0;
        private long NewSize = 0;
        private string ViewerLog = string.Empty;
        private string CleanLog = string.Empty;

        private Font ChatFont = null;
        private Color Forecolor = new Color();
        private Color Backcolor = new Color();

        private OpenFileDialog ViewerLogDialog = new OpenFileDialog();
        private SaveFileDialog CleanLogDialog = new SaveFileDialog();
        private FontDialog ChatFontDialog = new FontDialog();
        private ColorDialog ForecolorDialog = new ColorDialog();
        private ColorDialog BackcolorDialog = new ColorDialog();
        private FileSystemWatcher FileWatcher = new FileSystemWatcher();

        private ChatDisplay frmChat = new ChatDisplay();

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileWatcher.Changed += new FileSystemEventHandler(FileWatcher_OnChanged);

            ChatFont = this.Font;

            ViewerLog = CLC.Default.Target;
            CleanLog = CLC.Default.Cleaned;
            Forecolor = CLC.Default.Forecolor;
            Backcolor = CLC.Default.Backcolor;
            ChatFont = CLC.Default.Font;

            txtLogTargetPath.Text = ViewerLog;
            txtLogCleanedPath.Text = CleanLog;
            txtFont.Text = ChatFont.Name + ", " + Math.Round(ChatFont.Size).ToString();
            pnlBackcolor.BackColor = Backcolor;
            pnlForecolor.BackColor = Forecolor;
            
            if (File.Exists(ViewerLog.Trim('"')))
            {
                Console.WriteLine("Loaded");
                btnStartStop.Enabled = true;
            }
            else
            {
                btnStartStop.Enabled = false;
            }
        }

        private void btnViewerLogBrowse_Click(object sender, EventArgs e)
        {
            ViewerLogDialog.FileOk += new CancelEventHandler(LogTarget_FileOK);
            ViewerLogDialog.ShowDialog();
            txtLogTargetPath.Text = ViewerLogDialog.FileName.Trim('"');
            ViewerLog = txtLogTargetPath.Text;
            CLC.Default.Target = ViewerLog;
            CLC.Default.Save();
        }

        private void btnCleanLogBrowse_Click(object sender, EventArgs e)
        {
            CleanLogDialog.FileOk += new CancelEventHandler(LogCleaned_FileOK);
            CleanLogDialog.Filter = "Log File|*.log|Text File|*.txt";
            CleanLogDialog.Title = "Save Cleaned Log File";
            CleanLogDialog.ShowDialog();
            txtLogCleanedPath.Text = CleanLogDialog.FileName.Trim('"');
            CleanLog = txtLogCleanedPath.Text;
            CLC.Default.Cleaned = CleanLog;
            CLC.Default.Save();
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (btnStartStop.Text == "Start Cleaning")
            {
                if (chkEmptyLog.Checked)
                {
                    if (File.Exists(CleanLog))
                    {
                        File.Delete(CleanLog);
                    }
                }
                FileWatcher.Path = Path.GetDirectoryName(ViewerLog);
                FileWatcher.Filter = Path.GetFileName(ViewerLog);
                FileWatcher.NotifyFilter = NotifyFilters.Size;
                FileWatcher.EnableRaisingEvents = true;
                btnStartStop.Text = "Stop Cleaning";
                PreviousSize = new FileInfo(ViewerLog).Length;
            }
            else
            {
                FileWatcher.EnableRaisingEvents = false;
                btnStartStop.Text = "Start Cleaning";
            }
        }

        private void btnShowChat_Click(object sender, EventArgs e)
        {
            if (frmChat.IsDisposed)
            {
                frmChat = new ChatDisplay();
            }
            frmChat.LogFile = CleanLog;
            frmChat.ChatFont = ChatFont;
            frmChat.Color = Forecolor;
            frmChat.BackColor = Backcolor;
            frmChat.Show();
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            ChatFontDialog.Font = ChatFont;
            ChatFontDialog.ShowDialog();
            ChatFont = ChatFontDialog.Font;
            txtFont.Text = ChatFont.Name + ", " + Math.Round(ChatFont.Size).ToString();
            CLC.Default.Font = ChatFont;
            CLC.Default.Save();
        }

        private void btnForecolor_Click(object sender, EventArgs e)
        {
            ForecolorDialog.ShowDialog();
            Forecolor = ForecolorDialog.Color;
            pnlForecolor.BackColor = Forecolor;
            CLC.Default.Forecolor = Forecolor;
            CLC.Default.Save();
        }

        private void btnBackcolor_Click(object sender, EventArgs e)
        {
            BackcolorDialog.ShowDialog();
            Backcolor = BackcolorDialog.Color;
            pnlBackcolor.BackColor = Backcolor;
            CLC.Default.Backcolor = Backcolor;
            CLC.Default.Save();
        }

        private void LogCleaned_FileOK(object sender, CancelEventArgs e)
        {
            CleanLog = CleanLogDialog.FileName;
            if (!File.Exists(CleanLog))
            {
                File.Create(CleanLog);
            }

            if ((File.Exists(CleanLog) && (File.Exists(ViewerLog))))
            {
                btnStartStop.Enabled = true;
            }
        }

        private void LogTarget_FileOK(object sender, CancelEventArgs e)
        {
            ViewerLog = ViewerLogDialog.FileName;
            if ((File.Exists(CleanLog) && (File.Exists(ViewerLog))))
            {
                btnStartStop.Enabled = true;
            }
        }

        private void FileWatcher_OnChanged(object source, FileSystemEventArgs e)
        {
            NewSize = new FileInfo(ViewerLog).Length;
            
            if (NewSize > PreviousSize)
            {
                string text = ReadTail(ViewerLog, (int)(NewSize - PreviousSize));
                CleanLogLines(text, CleanLog);
                PreviousSize = NewSize;
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
            string[] Lines = text.Split('\n');
            foreach (string s in Lines)
            {
                string parsed = LineParse(s);

                if (parsed.Trim() == String.Empty) continue;

                using (StreamWriter sw = File.AppendText(filecleaned))
                {
                    sw.WriteLine(parsed);
                }
            }
        }

        private string LineParse(string line)
        {
            string TimeStamp = String.Empty;
            string UserName = String.Empty;
            string HGAddress = String.Empty;
            string Message = String.Empty;
            string CleanLine = String.Empty;

            line = line.TrimEnd();
            if (line == String.Empty) return String.Empty;
            if (line == Environment.NewLine) return String.Empty;

            if (line.StartsWith(" "))
            {
                // This is just a multi-line message.
                return line.Trim();
            }

            char[] Delimiters = { ':' };
            string[] Half = line.Substring(20).Split(Delimiters, 2);
            if (Half.Length <= 1) return String.Empty;

            //We need special handling for HG names.
            string[] HGTest = Half[0].Split(' ');
            if (HGTest.Length > 1)
            {
                if (HGTest[1].Contains('@'))
                {
                    string[] hg = line.Substring(20).Split(Delimiters, 3);
                    
                    UserName = hg[0].Split(' ')[0];
                    if (hg.Length == 3)
                    {
                        // This address has a port number.
                        HGAddress = hg[0].Split(' ')[1].TrimStart('@') + ":" + hg[1];
                        Message = hg[2].Trim();
                    }
                    else
                    {
                        // This address has no port number.
                        HGAddress = hg[0].Split(' ')[1].TrimStart('@');
                        Message = hg[1].Trim();
                    }
                }
                else
                {
                    // This wasn't from an HG visitor.
                    UserName = Half[0].Trim();
                    Message = Half[1].Trim();
                }
            }

            // skip grid messages, on/offline notices, and server version shouts.
            Console.WriteLine(Half[0] + Half[1]);
            if (Message == "is online.") return String.Empty;
            if (Message == "is offline.") return String.Empty;
            if (UserName.Contains("Simulator Version")) return String.Empty;
            if (UserName == "Grid") return String.Empty;

            // Reformat timestamps.
            TimeStamp = "[" + line.Substring(12, 6);

            // Look for emotes.
            if ((Message.Length > 3) && (Message.Substring(0, 3) == "/me"))
            {
                Message = Message.Substring(4, Message.Length - 4);
                if (HGAddress == String.Empty)
                {
                    CleanLine = "───\n" + TimeStamp + " " + UserName + " " + Message;
                }
                else
                {
                    CleanLine = "───\n" + TimeStamp + " " + UserName + "@" + HGAddress + " " + Message;
                }
            }
            else
            {
                if (HGAddress == String.Empty)
                {
                    CleanLine = "───\n" + TimeStamp + " <" + UserName + ">\n" + Message;
                }
                else
                {
                    CleanLine = "───\n" + TimeStamp + " <" + UserName + ">\n" + "(" + HGAddress + ")\n" + Message;
                }
            }

            return CleanLine;
        }
    }
}