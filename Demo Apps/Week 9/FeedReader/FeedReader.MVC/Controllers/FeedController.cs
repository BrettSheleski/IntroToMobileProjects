using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FeedReader.MVC.Controllers
{
    public class FeedController : Controller
    {
        // GET: Feed
        public async Task<ViewResult> Index()
        {
            var vm = new Models.FeedIndexViewModel();

            await vm.InitializeAsync();

            return View(vm);
        }
    }
}