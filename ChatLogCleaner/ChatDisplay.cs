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
using System.Collections;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ChatLogCleaner
{
    public partial class ChatDisplay : Form
    {
        private string _logfile = string.Empty;
        private long previousSize = 0;
        private long newSize = 0;

        private Queue chatbuffer = new Queue(16);
        private FileSystemWatcher watcher = new FileSystemWatcher();
        private Font _chatfont = null;
        private Color _forecolor = new Color();
        private Color _backcolor = new Color();

        public string LogFile
        {
            get { return _logfile; }
            set { _logfile = value; }
        }

        public Font ChatFont
        {
            get { return _chatfont; }
            set { _chatfont = value; }
        }

        public Color Color
        {
            get { return _forecolor; }
            set { _forecolor = value; }
        }

        public Color BackgroundColor
        {
            get { return _backcolor; }
            set { _backcolor = value; }
        }

        public ChatDisplay()
        {
            InitializeComponent();
        }

        private void ChatDisplay_Load(object sender, EventArgs e)
        {
            if (!File.Exists(_logfile))
            {
                MessageBox.Show("No cleaned logfile exists yet.", "Missing Logfile", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }

            this.Size = CLC.Default.ChatSize;

            watcher.Path = Path.GetDirectoryName(_logfile);
            watcher.Filter = Path.GetFileName(_logfile);
            watcher.NotifyFilter = NotifyFilters.Size;
            watcher.Changed += new FileSystemEventHandler(watcher_OnChanged);
            watcher.EnableRaisingEvents = true;
            previousSize = new FileInfo(_logfile).Length;
        }

        private void ChatDisplay_Paint(object sender, PaintEventArgs e)
        {
            RenderText(e);
        }

        private void ChatDisplay_Resize(object sender, EventArgs e)
        {
            CLC.Default.ChatSize = this.Size;
            CLC.Default.Save();

            this.Refresh();

            Console.WriteLine(this.Size.Width.ToString() + " " + this.Size.Height.ToString());
        }

        private void watcher_OnChanged(object source, FileSystemEventArgs e)
        {
            newSize = new FileInfo(_logfile).Length;

            if (newSize > previousSize)
            {
                string text = ReadTail(_logfile, (int)(newSize - previousSize));
                Console.WriteLine("Queue: " + text);
                chatbuffer.Enqueue(text);
                try
                {
                    this.BeginInvoke((MethodInvoker)delegate { this.Refresh(); });
                }
                finally { }

                previousSize = newSize;
            }
        }

        private void RenderText(PaintEventArgs e)
        {
            string text = string.Empty;
            Rectangle rect = this.ClientRectangle;
            TextFormatFlags flags = TextFormatFlags.WordBreak | TextFormatFlags.Bottom;

            foreach (string s in chatbuffer.ToArray())
            {
                Console.WriteLine("RenderText: " + s);
                text += s;
            }

            Size size = TextRenderer.MeasureText(text, this.ChatFont, rect.Size, flags);

            if (size.Height > rect.Height)
            {
                rect.Y = rect.Height - size.Height;
                Console.WriteLine("rect.y: " + rect.Y.ToString());
                rect.Height += -(rect.Y);
            }

            TextRenderer.DrawText(e.Graphics, text, this.ChatFont, rect, this.Color, flags);
        }

        private string ReadTail(string filename, int size)
        {
            using (FileStream fs = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                fs.Seek(-size, SeekOrigin.End);
                byte[] bytes = new byte[size];
                fs.Read(bytes, 0, size);
                return Encoding.UTF8.GetString(bytes);
            }
        }
    }
}