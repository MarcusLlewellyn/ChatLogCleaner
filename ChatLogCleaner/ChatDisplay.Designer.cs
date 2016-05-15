namespace ChatLogCleaner
{
    partial class ChatDisplay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatDisplay));
            this.SuspendLayout();
            // 
            // ChatDisplay
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(232, 625);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChatDisplay";
            this.Text = "ChatDisplay";
            this.Load += new System.EventHandler(this.ChatDisplay_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ChatDisplay_Paint);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.ChatDisplay_Layout);
            this.ResumeLayout(false);

        }

        #endregion
    }
}