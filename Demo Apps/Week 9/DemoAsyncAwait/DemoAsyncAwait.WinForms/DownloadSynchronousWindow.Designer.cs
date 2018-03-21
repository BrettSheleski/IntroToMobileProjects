namespace DemoAsyncAwait.WinForms
{
    partial class DownloadSynchronousWindow
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
            this.StartDownloadButton = new System.Windows.Forms.Button();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.StartMultipleDownloadsButton = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // StartDownloadButton
            // 
            this.StartDownloadButton.Location = new System.Drawing.Point(19, 12);
            this.StartDownloadButton.Name = "StartDownloadButton";
            this.StartDownloadButton.Size = new System.Drawing.Size(185, 54);
            this.StartDownloadButton.TabIndex = 0;
            this.StartDownloadButton.Text = "Start Download";
            this.StartDownloadButton.UseVisualStyleBackColor = true;
            this.StartDownloadButton.Click += new System.EventHandler(this.StartDownloadButton_Click);
            // 
            // MessageLabel
            // 
            this.MessageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageLabel.Location = new System.Drawing.Point(12, 125);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(424, 94);
            this.MessageLabel.TabIndex = 1;
            this.MessageLabel.Text = "Idle";
            this.MessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StartMultipleDownloadsButton
            // 
            this.StartMultipleDownloadsButton.Location = new System.Drawing.Point(211, 13);
            this.StartMultipleDownloadsButton.Name = "StartMultipleDownloadsButton";
            this.StartMultipleDownloadsButton.Size = new System.Drawing.Size(225, 53);
            this.StartMultipleDownloadsButton.TabIndex = 2;
            this.StartMultipleDownloadsButton.Text = "Start Multiple Downloads";
            this.StartMultipleDownloadsButton.UseVisualStyleBackColor = true;
            this.StartMultipleDownloadsButton.Click += new System.EventHandler(this.StartMultipleDownloadsButton_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(175, 95);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(78, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Check Me!";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // DownloadSynchronousWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 269);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.StartMultipleDownloadsButton);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.StartDownloadButton);
            this.Name = "DownloadSynchronousWindow";
            this.Text = "DownloadSynchronousWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartDownloadButton;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.Button StartMultipleDownloadsButton;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}