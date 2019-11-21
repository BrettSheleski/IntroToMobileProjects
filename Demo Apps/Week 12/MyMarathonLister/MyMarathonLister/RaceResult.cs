using System;
namespace MyMarathonLister
{
    public class RaceResult
    {
        public RaceResult()
        {
        }

        public int id { get; set; }
        public int race_id { get; set; }
        public string name { get; set; }
        public int placement { get; set; }
        public TimeSpan time { get; set; }
        public string state { get; set; }

    }
}
