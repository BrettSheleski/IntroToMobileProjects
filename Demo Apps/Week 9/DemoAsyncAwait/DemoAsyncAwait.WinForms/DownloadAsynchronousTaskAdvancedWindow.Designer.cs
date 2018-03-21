namespace DemoAsyncAwait.WinForms
{
    partial class DownloadAsynchronousTaskAdvancedWindow
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
            this.StartMultipleDownloadsButton = new System.Windows.Forms.Button();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.StartDownloadButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(373, 157);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(78, 17);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "Check Me!";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // StartMultipleDownloadsButton
            // 
            this.StartMultipleDownloadsButton.Location = new System.Drawing.Point(354, 88);
            this.StartMultipleDownloadsButton.Name = "StartMultipleDownloadsButton";
            this.StartMultipleDownloadsButton.Size = new System.Drawing.Size(142, 53);
            this.StartMultipleDownloadsButton.TabIndex = 15;
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
            this.MessageLabel.Location = new System.Drawing.Point(155, 200);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(490, 164);
            this.MessageLabel.TabIndex = 13;
            this.MessageLabel.Text = "Idle";
            this.MessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StartDownloadButton
            // 
            this.StartDownloadButton.Location = new System.Drawing.Point(162, 87);
            this.StartDownloadButton.Name = "StartDownloadButton";
            this.StartDownloadButton.Size = new System.Drawing.Size(185, 54);
            this.StartDownloadButton.TabIndex = 12;
            this.StartDownloadButton.Text = "Start Download";
            this.StartDownloadButton.UseVisualStyleBackColor = true;
            this.StartDownloadButton.Click += new System.EventHandler(this.StartDownloadButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(304, 367);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(221, 71);
            this.CancelButton.TabIndex = 17;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(36, 200);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(734, 23);
            this.ProgressBar.TabIndex = 18;
            // 
            // DownloadAsynchronousTaskAdvancedWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.StartMultipleDownloadsButton);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.StartDownloadButton);
            this.Name = "DownloadAsynchronousTaskAdvancedWindow";
            this.Text = "DownloadAsynchronousTaskAdvancedWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button StartMultipleDownloadsButton;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.Button StartDownloadButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.ProgressBar ProgressBar;
    }
}