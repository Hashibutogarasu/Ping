
namespace Ping
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.PingLevel = new System.Windows.Forms.PictureBox();
            this.NowPing = new System.Windows.Forms.Label();
            this.NoticeIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.MainContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ExitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.PingLevel)).BeginInit();
            this.MainContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new System.Drawing.Point(16, 15);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(43, 15);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Ping：";
            // 
            // PingLevel
            // 
            this.PingLevel.Location = new System.Drawing.Point(98, 12);
            this.PingLevel.Name = "PingLevel";
            this.PingLevel.Size = new System.Drawing.Size(32, 32);
            this.PingLevel.TabIndex = 4;
            this.PingLevel.TabStop = false;
            // 
            // NowPing
            // 
            this.NowPing.AutoSize = true;
            this.NowPing.Location = new System.Drawing.Point(65, 15);
            this.NowPing.Name = "NowPing";
            this.NowPing.Size = new System.Drawing.Size(22, 15);
            this.NowPing.TabIndex = 5;
            this.NowPing.Text = "?%";
            // 
            // NoticeIcon
            // 
            this.NoticeIcon.Text = "notifyIcon1";
            this.NoticeIcon.Visible = true;
            this.NoticeIcon.Click += new System.EventHandler(this.NotifyIconClick);
            // 
            // MainContext
            // 
            this.MainContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitItem,
            this.ShowItem});
            this.MainContext.Name = "MainContext";
            this.MainContext.Size = new System.Drawing.Size(104, 48);
            this.MainContext.Text = "設定";
            // 
            // ExitItem
            // 
            this.ExitItem.Name = "ExitItem";
            this.ExitItem.Size = new System.Drawing.Size(180, 22);
            this.ExitItem.Text = "Exit";
            this.ExitItem.Click += new System.EventHandler(this.ExitItem_Click);
            // 
            // ShowItem
            // 
            this.ShowItem.Name = "ShowItem";
            this.ShowItem.Size = new System.Drawing.Size(180, 22);
            this.ShowItem.Text = "Show";
            this.ShowItem.Click += new System.EventHandler(this.ShowItemClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 64);
            this.Controls.Add(this.NowPing);
            this.Controls.Add(this.PingLevel);
            this.Controls.Add(this.TitleLabel);
            this.Name = "Form1";
            this.Text = "Ping";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.PingLevel)).EndInit();
            this.MainContext.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.PictureBox PingLevel;
        private System.Windows.Forms.Label NowPing;
        private System.Windows.Forms.NotifyIcon NoticeIcon;
        private System.Windows.Forms.ContextMenuStrip MainContext;
        private System.Windows.Forms.ToolStripMenuItem ExitItem;
        private System.Windows.Forms.ToolStripMenuItem ShowItem;
    }
}

