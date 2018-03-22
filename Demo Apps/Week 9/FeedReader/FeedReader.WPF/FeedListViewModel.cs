using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FeedReader.Core.Models;

namespace FeedReader.WPF
{
    public class FeedListViewModel : Core.Model
    {
        public FeedListViewModel()
        {
            this.Model = new Core.Models.FeedListMvvmModel();
            this.OpenArticleCommand = new DelegateCommand<string>(OpenArticle);
        }

        public FeedListMvvmModel Model { get; }
        public ICommand OpenArticleCommand { get; }

        private void OpenArticle(string url)
        {
            Process.Start(new ProcessStartInfo(url));   
        }

    }
}
