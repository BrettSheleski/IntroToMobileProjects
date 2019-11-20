using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MarathonApp
{
    public class MainPageViewModel : ViewModel
    {
        public MainPageViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            this.GetMarathonsCommand = new Command(async () => await GetMarathonsAsync());
        }

        const string MARATHONS_INDEX = "http://itweb.fvtc.edu/wetzel/marathon/races/";

        public ObservableCollection<RaceViewModel> Races { get; } = new ObservableCollection<RaceViewModel>();
        public INavigation Navigation { get; }
        public Command GetMarathonsCommand { get; }
        public bool IsGettingMarathons { get => _isGettingMarathons; set => Set(ref _isGettingMarathons, value); }

        private bool _isGettingMarathons;

        public async Task GetMarathonsAsync()
        {
            IsGettingMarathons = true;
            Races.Clear();

            string json;

            using (WebClient webClient = new WebClient())
            {
                json = await webClient.DownloadStringTaskAsync(MARATHONS_INDEX);
            }

            MarathonsIndexResult result = Newtonsoft.Json.JsonConvert.DeserializeObject<MarathonsIndexResult>(json);

            foreach (var race in result.races)
            {
                Races.Add(new RaceViewModel(this.Navigation, race));

                await Task.Delay(100);
            }

            IsGettingMarathons = false;
        }
    }
}