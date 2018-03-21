using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoAsyncAwait.WinForms
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void DownloadSynchronousButton_Click(object sender, EventArgs e)
        {
            ShowWindow<DownloadSynchronousWindow>();
        }
        
        private void DownloadAsynchronousButton_Click(object sender, EventArgs e)
        {
            ShowWindow<DownloadAsynchronousWindow>();
        }

        private void DownloadAsynchronousWithTasksButton_Click(object sender, EventArgs e)
        {
            ShowWindow<DownloadAsynchronousTaskWindow>();
        }

        private void AdvancedAsyncTasks_Click(object sender, EventArgs e)
        {
            ShowWindow<DownloadAsynchronousTaskAdvancedWindow>();
        }

        public void ShowWindow<T>() where T : Form, new()
        {
            var window = new T();
            window.Show();
        }
    }
}
