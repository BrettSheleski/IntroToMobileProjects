using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Marathon
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await PopulateRacePicker();
        }

        const string RACES_INDEX_URL = "http://itweb.fvtc.edu/wetzel/marathon/races/";

        Models.RaceCollection raceCollection;

        async Task PopulateRacePicker()
        {
            string json;

            using (var client = new WebClient())
            {
                json = await client.DownloadStringTaskAsync(RACES_INDEX_URL);
            }

            raceCollection = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.RaceCollection>(json);

            RacePicker.Items.Clear();
            foreach(var race in raceCollection.races)
            {
                RacePicker.Items.Add(race.race_name);
            }
        }

        async void HandleRacePicker_SelectedItemChanged(object sender, EventArgs e)
        {
            if (raceCollection?.races != null)
            {
                if (RacePicker.SelectedIndex >= 0 && RacePicker.SelectedIndex < raceCollection.races.Length)
                {
                    Models.Race race = raceCollection.races[RacePicker.SelectedIndex];

                    await PopulateResultsListAsync(race);
                }
            }
        }

        const string RACES_RESULTS_URL_FORMAT = "http://itweb.fvtc.edu/wetzel/marathon/results/{0}/";

        async Task PopulateResultsListAsync(Models.Race race)
        {
            string url = string.Format(RACES_RESULTS_URL_FORMAT, race.id);

            string json;

            using (var client = new WebClient())
            {
                json = await client.DownloadStringTaskAsync(url);
            }
            Models.RaceResultCollection results = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.RaceResultCollection>(json);

            ResultsList.ItemsSource = results.results;
        }
    }
}
