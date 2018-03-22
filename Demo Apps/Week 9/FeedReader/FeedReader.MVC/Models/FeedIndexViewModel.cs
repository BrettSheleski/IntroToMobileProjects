using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FeedReader.MVC.Models
{
    public class FeedIndexViewModel
    {
        public Core.Models.FeedListMvvmModel Model { get; } = new Core.Models.FeedListMvvmModel();


        public async Task InitializeAsync()
        {
            await Model.InitializeAsync();
        }

    }
}