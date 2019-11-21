using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;

namespace MyMarathonLister
{
    public class RaceResultsPageViewModel : ViewModel
    {
        public RaceResultsPageViewModel()
        {
        }

        public Race Race { get; set; }

        public ObservableCollection<RaceResult> Results { get; } = new ObservableCollection<RaceResult>();

        public async Task GetRaceResultsAsync()
        {
            string url = $"http://itweb.fvtc.edu/wetzel/marathon/results/{Race.id}/";
            string json;

            using (WebClient webClient = new WebClient())
            {
                json = await webClient.DownloadStringTaskAsync(url);
            }

            GetRaceResultsApiResult result =
                Newtonsoft.Json.JsonConvert.DeserializeObject<GetRaceResultsApiResult>(json);

            foreach(var raceResult in result.results)
            {
                this.Results.Add(raceResult);
            }
        }

    }
}
