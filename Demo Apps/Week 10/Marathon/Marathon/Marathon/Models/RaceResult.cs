using System;
using System.Collections.Generic;
using System.Text;

namespace Marathon.Models
{
    public class RaceResult
    {
        public int id { get; set; }
        public int race_id { get; set; }
        public string name { get; set; }

        public string time { get; set; }

        public string state { get; set; }
        public int placement { get; set; }
    }
}
