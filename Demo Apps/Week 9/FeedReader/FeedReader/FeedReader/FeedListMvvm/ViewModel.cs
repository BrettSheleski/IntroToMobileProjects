using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FeedReader.FeedListMvvm
{
    public class ViewModel : FeedReader.Core.Model
    {

        public FeedReader.Core.Models.FeedListMvvmModel Model { get; } = new Core.Models.FeedListMvvmModel();
        public string Title
        {
            get => _title; set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        private string _title;
        public ViewModel()
        {
            Title = "THIS IS THE TITLE";
        }


        public async Task InitializeAsync()
        {
            await this.Model.InitializeAsync();
        }
    }
}