using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyMarathonLister
{
    public class MainPageViewModel : ViewModel
    {
        public MainPageViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            GetRacesCommand = new Command( async () => await GetRaces());
        }

        public INavigation Navigation { get; }
        public ObservableCollection<RaceViewModel> Races { get; } = new ObservableCollection<RaceViewModel>();

        public Command GetRacesCommand { get; }

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }

        public async Task GetRaces()
        {
            IsRefreshing = true;

            Races.Clear();

            string url = "http://itweb.fvtc.edu/wetzel/marathon/races/";
            string json;

            using (System.Net.WebClient webClient = new System.Net.WebClient())
            {
                json = await webClient.DownloadStringTaskAsync(url);
            }

            GetRacesApiResult result =
                Newtonsoft.Json.JsonConvert.DeserializeObject<GetRacesApiResult>(json);

            foreach (Race race in result.races)
            {
                RaceViewModel vm = new RaceViewModel(this.Navigation)
                {
                    Race = race
                };

                this.Races.Add(vm);

            }

            IsRefreshing = false;
        }

        public class RaceViewModel
        {

            public RaceViewModel(INavigation navigation)
            {
                this.Navigation = navigation;
                SelectCommand = new Command(Select);
            }

            INavigation Navigation { get; }

            public Race Race { get; set; }

            public Command SelectCommand { get; }

            async void Select()
            {
                var page = new RaceResultsPage();
                var vm = new RaceResultsPageViewModel();
                vm.Race = this.Race;

                page.BindingContext = vm;

                await Navigation.PushAsync(page);

                await vm.GetRaceResultsAsync();
            }
        }

    }
}
