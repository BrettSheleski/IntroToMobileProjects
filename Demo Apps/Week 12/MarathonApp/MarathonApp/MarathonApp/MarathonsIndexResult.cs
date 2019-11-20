using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MarathonApp
{
    class MarathonsIndexResult
    {
        public List<Race> races { get; set; }
    }

    public class Race
    {
        public int id { get; set; }
        public string race_name { get; set; }

        public async Task<List<RaceResult>> GetResultsAsync()
        {
            string url = $"http://itweb.fvtc.edu/wetzel/marathon/results/{id}/";

            string json;

            using (WebClient webClient = new WebClient())
            {
                json = await webClient.DownloadStringTaskAsync(url);
            }

            MarathonResultsApiResult results = Newtonsoft.Json.JsonConvert.DeserializeObject<MarathonResultsApiResult>(json);

            return results.results;
        }
    }

    public class MarathonResultsApiResult
    {
        public List<RaceResult> results { get; set; }
    }

    public class RaceResult
    {
        public int id { get; set; }
        public int race_id { get; set; }
        public int placement { get; set; }
        public string name { get; set; }

        public TimeSpan time { get; set; }

        public string state { get; set; }
    }
}
