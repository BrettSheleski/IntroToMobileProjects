namespace DemoAsyncAwait.WinForms
{
    partial class DownloadAsynchronousTaskWindow
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.DownloadMultipleInParallelButton = new System.Windows.Forms.Button();
            this.StartMultipleDownloadsButton = new System.Windows.Forms.Button();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.StartDownloadButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(257, 130);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(78, 17);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "Check Me!";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // DownloadMultipleInParallelButton
            // 
            this.DownloadMultipleInParallelButton.Location = new System.Drawing.Point(393, 37);
            this.DownloadMultipleInParallelButton.Name = "DownloadMultipleInParallelButton";
            this.DownloadMultipleInParallelButton.Size = new System.Drawing.Size(142, 53);
            this.DownloadMultipleInParallelButton.TabIndex = 9;
            this.DownloadMultipleInParallelButton.Text = "Start Multiple Downloads (In Parallel)";
            this.DownloadMultipleInParallelButton.UseVisualStyleBackColor = true;
            this.DownloadMultipleInParallelButton.Click += new System.EventHandler(this.DownloadMultipleInParallelButton_Click);
            // 
            // StartMultipleDownloadsButton
            // 
            this.StartMultipleDownloadsButton.Location = new System.Drawing.Point(245, 38);
            this.StartMultipleDownloadsButton.Name = "StartMultipleDownloadsButton";
            this.StartMultipleDownloadsButton.Size = new System.Drawing.Size(142, 53);
            this.StartMultipleDownloadsButton.TabIndex = 10;
            this.StartMultipleDownloadsButton.Text = "Start Multiple Downloads (In Series)";
            this.StartMultipleDownloadsButton.UseVisualStyleBackColor = true;
            this.StartMultipleDownloadsButton.Click += new System.EventHandler(this.StartMultipleDownloadsButton_Click);
            // 
            // MessageLabel
            // 
            this.MessageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageLabel.Location = new System.Drawing.Point(46, 150);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(490, 164);
            this.MessageLabel.TabIndex = 8;
            this.MessageLabel.Text = "Idle";
            this.MessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StartDownloadButton
            // 
            this.StartDownloadButton.Location = new System.Drawing.Point(53, 37);
            this.StartDownloadButton.Name = "StartDownloadButton";
            this.StartDownloadButton.Size = new System.Drawing.Size(185, 54);
            this.StartDownloadButton.TabIndex = 7;
            this.StartDownloadButton.Text = "Start Download";
            this.StartDownloadButton.UseVisualStyleBackColor = true;
            this.StartDownloadButton.Click += new System.EventHandler(this.StartDownloadButton_Click);
            // 
            // DownloadAsynchronousTaskWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 350);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.DownloadMultipleInParallelButton);
            this.Controls.Add(this.StartMultipleDownloadsButton);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.StartDownloadButton);
            this.Name = "DownloadAsynchronousTaskWindow";
            this.Text = "DownloadAsynchronousTaskWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button DownloadMultipleInParallelButton;
        private System.Windows.Forms.Button StartMultipleDownloadsButton;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.Button StartDownloadButton;
    }
}