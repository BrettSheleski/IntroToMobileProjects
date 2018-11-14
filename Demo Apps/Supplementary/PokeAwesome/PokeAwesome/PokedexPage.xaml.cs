using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PokeAwesome
{
    public partial class PokedexPage : ContentPage
    {
        private Pokemon selectedPokemon;

        public PokedexPage(Pokemon pokemon)
        {
            InitializeComponent();

            this.selectedPokemon = pokemon;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await GetPokemonDetailsAsync();
        }

        private async Task GetPokemonDetailsAsync()
        {
            // make web request and get json
            string json;

            using(WebClient webClient = new WebClient()){
                json = await webClient.DownloadStringTaskAsync(selectedPokemon.url);

            }

            // deserialize the json to an object
            PokemonDetailResult details = Newtonsoft.Json.JsonConvert.DeserializeObject<PokemonDetailResult>(json);

            // display stuff
            this.BindingContext = details;


        }
    }
}
