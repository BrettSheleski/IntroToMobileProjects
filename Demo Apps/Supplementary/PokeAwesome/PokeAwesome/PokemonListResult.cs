using System;
using System.Collections.Generic;

namespace PokeAwesome
{
    public class PokemonListResult
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }

        public List<Pokemon> results { get; set; }
    }


    public class Pokemon{
        public string name { get; set; }
        public string url { get; set; }
    }
}
