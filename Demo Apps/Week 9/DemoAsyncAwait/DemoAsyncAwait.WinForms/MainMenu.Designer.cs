namespace DemoAsyncAwait.WinForms
{
    partial class MainMenu
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
            this.DownloadSynchronousButton = new System.Windows.Forms.Button();
            this.DownloadAsynchronousButton = new System.Windows.Forms.Button();
            this.DownloadAsynchronousWithTasksButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DownloadSynchronousButton
            // 
            this.DownloadSynchronousButton.Location = new System.Drawing.Point(12, 12);
            this.DownloadSynchronousButton.Name = "DownloadSynchronousButton";
            this.DownloadSynchronousButton.Size = new System.Drawing.Size(224, 49);
            this.DownloadSynchronousButton.TabIndex = 0;
            this.DownloadSynchronousButton.Text = "Download Synchronous";
            this.DownloadSynchronousButton.UseVisualStyleBackColor = true;
            this.DownloadSynchronousButton.Click += new System.EventHandler(this.DownloadSynchronousButton_Click);
            // 
            // DownloadAsynchronousButton
            // 
            this.DownloadAsynchronousButton.Location = new System.Drawing.Point(12, 67);
            this.DownloadAsynchronousButton.Name = "DownloadAsynchronousButton";
            this.DownloadAsynchronousButton.Size = new System.Drawing.Size(224, 49);
            this.DownloadAsynchronousButton.TabIndex = 0;
            this.DownloadAsynchronousButton.Text = "Download Asynchronous";
            this.DownloadAsynchronousButton.UseVisualStyleBackColor = true;
            this.DownloadAsynchronousButton.Click += new System.EventHandler(this.DownloadAsynchronousButton_Click);
            // 
            // DownloadAsynchronousWithTasksButton
            // 
            this.DownloadAsynchronousWithTasksButton.Location = new System.Drawing.Point(12, 168);
            this.DownloadAsynchronousWithTasksButton.Name = "DownloadAsynchronousWithTasksButton";
            this.DownloadAsynchronousWithTasksButton.Size = new System.Drawing.Size(224, 49);
            this.DownloadAsynchronousWithTasksButton.TabIndex = 0;
            this.DownloadAsynchronousWithTasksButton.Text = "Download Asynchronous With Tasks";
            this.DownloadAsynchronousWithTasksButton.UseVisualStyleBackColor = true;
            this.DownloadAsynchronousWithTasksButton.Click += new System.EventHandler(this.DownloadAsynchronousWithTasksButton_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 380);
            this.Controls.Add(this.DownloadAsynchronousWithTasksButton);
            this.Controls.Add(this.DownloadAsynchronousButton);
            this.Controls.Add(this.DownloadSynchronousButton);
            this.Name = "MainMenu";
            this.Text = "Main Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DownloadSynchronousButton;
        private System.Windows.Forms.Button DownloadAsynchronousButton;
        private System.Windows.Forms.Button DownloadAsynchronousWithTasksButton;
    }
}

