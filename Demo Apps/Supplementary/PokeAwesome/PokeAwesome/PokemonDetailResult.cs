using System;
using System.Collections.Generic;

namespace PokeAwesome
{
    public class PokemonDetailResult
    {
        public string name { get; set; }
        public double weight { get; set; }
        public double height { get; set; }

        public PokemonSprite sprites { get; set; }

        public List<PokemonMoveWrapper> moves { get; set; }
    }

    public class PokemonSprite{
        public string front_default { get; set; }
        public string back_default { get; set; }

    }

    public class PokemonMove{
        public string name { get; set; }
        public string url { get; set; }
    }

    public class PokemonMoveWrapper{
        public PokemonMove move { get; set; }
    }
}
