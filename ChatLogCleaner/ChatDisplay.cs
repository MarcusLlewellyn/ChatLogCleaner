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
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ChatLogCleaner
{
    public partial class ChatDisplay : Form
    {
        private long PreviousSize = 0;
        private long NewSize = 0;
        private int BufferSize = 128;
        private CircularBuffer<string> ChatBuffer = new CircularBuffer<string>();
        private FileSystemWatcher FileWatcher = new FileSystemWatcher();
        private Font _chatfont = null;
        private Color _forecolor = new Color();
        private Color _backcolor = new Color();
        private string _logfile = string.Empty;

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
            ChatBuffer.Size = BufferSize;

            FileWatcher.Path = Path.GetDirectoryName(_logfile);
            FileWatcher.Filter = Path.GetFileName(_logfile);
            FileWatcher.NotifyFilter = NotifyFilters.Size;
            FileWatcher.Changed += new FileSystemEventHandler(FileWatcher_OnChanged);
            FileWatcher.EnableRaisingEvents = true;
            PreviousSize = new FileInfo(_logfile).Length;
        }

        private void ChatDisplay_Paint(object sender, PaintEventArgs e)
        {
            DrawTextBuffer();
        }

        private void ChatDisplay_Resize(object sender, EventArgs e)
        {
            CLC.Default.ChatSize = this.Size;
            CLC.Default.Save();

            //this.Refresh();
            DrawTextBuffer();

            Console.WriteLine(this.Size.Width.ToString() + " " + this.Size.Height.ToString());
        }

        private void FileWatcher_OnChanged(object source, FileSystemEventArgs e)
        {
            NewSize = new FileInfo(_logfile).Length;

            if (NewSize > PreviousSize)
            {
                string text = ReadTail(_logfile, (int)(NewSize - PreviousSize));
                Console.WriteLine("Queue: " + text);
                ChatBuffer.Enqueue(text);
                DrawTextBuffer();
                PreviousSize = NewSize;
            }
        }

        public void DrawTextBuffer() // Control control, Font font)
        {
            if (ChatBuffer == null) { return; }
            if (ChatBuffer.Count == 0) { return; }

            string[] ArrayBuffer = ChatBuffer.ToArray();
            string text = string.Empty;
            int i = ChatBuffer.Count - 1;
            SizeF tempsize = new SizeF();

            Rectangle FormRect = this.ClientRectangle;
            BufferedGraphicsContext currentcontext = BufferedGraphicsManager.Current;
            BufferedGraphics controlbuffer = currentcontext.Allocate(this.CreateGraphics(), this.DisplayRectangle);

            controlbuffer.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            do
            {
                text = ArrayBuffer[i] + text;
                tempsize = controlbuffer.Graphics.MeasureString(text, this.ChatFont, FormRect.Size.Width, new StringFormat(StringFormat.GenericTypographic));
                i--;
            }
            while ((FormRect.Size.Height > tempsize.Height) && (i >= 0));

            SizeF textsize = controlbuffer.Graphics.MeasureString(text, this.ChatFont, FormRect.Size.Width, new StringFormat(StringFormat.GenericTypographic));

            if (textsize.Height > FormRect.Height)
            {
                FormRect.Y = FormRect.Height - (int)textsize.Height;
                FormRect.Height += -(FormRect.Y);
            }

            controlbuffer.Graphics.DrawString(text, this.ChatFont, new SolidBrush(this.Color), FormRect);
            controlbuffer.Render();

            controlbuffer.Dispose();
            currentcontext.Dispose();
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