using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MarathonApp
{
    public class MarathonResultsPageViewModel : ViewModel
    {
        public MarathonResultsPageViewModel(INavigation navigation, Race race)
        {
            this.Navigation = navigation;
            this.Race = race;

            this.RefreshCommand = new Command(async () => await GetResultsAsync());
        }

        public ObservableCollection<RaceResult> Results { get; } = new ObservableCollection<RaceResult>();

        private bool _isGettingRaceResults;

        

        public async Task GetResultsAsync()
        {
            IsGettingRaceResults = true;

            this.Results.Clear();

            var raceResults = await this.Race.GetResultsAsync();

            foreach(var result in raceResults)
            {
                this.Results.Add(result);
            }

            IsGettingRaceResults = false;
        }

        public INavigation Navigation { get; }
        public Race Race { get; }
        public Command RefreshCommand { get; }
        public bool IsGettingRaceResults { get => _isGettingRaceResults; set => Set(ref _isGettingRaceResults, value); }
    }
}
