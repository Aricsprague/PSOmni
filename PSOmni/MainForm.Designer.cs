namespace PSOmni
{
    partial class MainForm
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
            statusStrip1 = new StatusStrip();
            statusStripLabel = new ToolStripStatusLabel();
            statusProgressBar = new ToolStripProgressBar();
            pullButton = new Button();
            pushButton = new Button();
            profileLabel = new Label();
            activeProfileLabel = new Label();
            statusIndicatorImage = new PictureBox();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)statusIndicatorImage).BeginInit();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusStripLabel, statusProgressBar });
            statusStrip1.Location = new Point(0, 239);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(284, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusStripLabel
            // 
            statusStripLabel.Name = "statusStripLabel";
            statusStripLabel.Size = new Size(118, 17);
            statusStripLabel.Text = "toolStripStatusLabel1";
            // 
            // statusProgressBar
            // 
            statusProgressBar.Name = "statusProgressBar";
            statusProgressBar.Size = new Size(100, 16);
            // 
            // pullButton
            // 
            pullButton.Location = new Point(12, 78);
            pullButton.Name = "pullButton";
            pullButton.Size = new Size(260, 61);
            pullButton.TabIndex = 1;
            pullButton.Text = "Sync to PC";
            pullButton.UseVisualStyleBackColor = true;
            pullButton.Click += PullButton_Click;
            // 
            // pushButton
            // 
            pushButton.Location = new Point(12, 175);
            pushButton.Name = "pushButton";
            pushButton.Size = new Size(260, 61);
            pushButton.TabIndex = 2;
            pushButton.Text = "Sync to Device";
            pushButton.UseVisualStyleBackColor = true;
            pushButton.Click += PushButton_Click;
            // 
            // profileLabel
            // 
            profileLabel.AutoSize = true;
            profileLabel.Location = new Point(12, 9);
            profileLabel.Name = "profileLabel";
            profileLabel.Size = new Size(44, 15);
            profileLabel.TabIndex = 5;
            profileLabel.Text = "Profile:";
            // 
            // activeProfileLabel
            // 
            activeProfileLabel.AutoSize = true;
            activeProfileLabel.Font = new Font("Segoe UI", 13F);
            activeProfileLabel.Location = new Point(33, 23);
            activeProfileLabel.Name = "activeProfileLabel";
            activeProfileLabel.Size = new Size(54, 25);
            activeProfileLabel.TabIndex = 6;
            activeProfileLabel.Text = "temp";
            // 
            // statusIndicatorImage
            // 
            statusIndicatorImage.Location = new Point(12, 24);
            statusIndicatorImage.Name = "statusIndicatorImage";
            statusIndicatorImage.Size = new Size(24, 24);
            statusIndicatorImage.TabIndex = 7;
            statusIndicatorImage.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 261);
            Controls.Add(statusIndicatorImage);
            Controls.Add(activeProfileLabel);
            Controls.Add(profileLabel);
            Controls.Add(pushButton);
            Controls.Add(pullButton);
            Controls.Add(statusStrip1);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PS Omni Save Sync";
            Load += MainForm_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)statusIndicatorImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusStripLabel;
        private Button pullButton;
        private Button pushButton;
        private Label profileLabel;
        private Label activeProfileLabel;
        private ToolStripProgressBar statusProgressBar;
        private PictureBox statusIndicatorImage;
    }
}
