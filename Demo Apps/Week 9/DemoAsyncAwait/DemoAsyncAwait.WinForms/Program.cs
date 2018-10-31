using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoAsyncAwait.WinForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu());
        }

        public static bool SimulateDownloads { get; } = false;

        public const string DOWNLOAD_URL_100MB = "https://speed.hetzner.de/100MB.bin";
        public const string DOWNLOAD_URL_1GB = "https://speed.hetzner.de/1GB.bin";
    }
}
