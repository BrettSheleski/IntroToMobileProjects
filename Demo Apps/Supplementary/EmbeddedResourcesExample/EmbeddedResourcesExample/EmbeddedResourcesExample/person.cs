using System;
using System.Collections.Generic;
using System.Text;

namespace EmbeddedResourcesExample
{
    public class person
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string country { get; set; }
        public string email { get; set; }
        public bool vip { get; set; }
        public DateTime modified { get; set; }
    }
}
