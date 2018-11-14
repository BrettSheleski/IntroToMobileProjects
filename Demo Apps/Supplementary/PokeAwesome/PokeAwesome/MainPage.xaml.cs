using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PokeAwesome
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await PopulatePokemonPicker();
        }

        async Task PopulatePokemonPicker(){


            // get data from url
            string json;

            using(var webClient = new WebClient()){
                json = await webClient.DownloadStringTaskAsync("https://pokeapi.co/api/v2/pokemon/");
            }

            // process the data into a list of pokemon
            PokemonListResult pokemonListResult = Newtonsoft.Json.JsonConvert.DeserializeObject<PokemonListResult>(json);

            // set the picker's source to the list of pokemon
            PokemonPicker.ItemsSource = pokemonListResult.results.OrderBy(x => x.name).ToList();



        }

        async void Handle_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Pokemon selectedPokemon = PokemonPicker.SelectedItem as Pokemon;

            if (selectedPokemon != null){

                // navigate to the next page
                // tell the next page which pokemon to get stuff for

                PokedexPage pokemonPage = new PokedexPage(selectedPokemon);

                await Navigation.PushAsync(pokemonPage);
            }
        }
    }
}
