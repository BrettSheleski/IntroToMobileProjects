using System.Threading.Tasks;
using Xamarin.Forms;

namespace MarathonApp
{
    public class RaceViewModel : ViewModel
    {
        public RaceViewModel(INavigation navigation, Race race)
        {
            this.Navigation = navigation;
            this.Race = race;

            this.SelectCommand = new Command(async () => await SelectAsync());
        }

        private async Task SelectAsync()
        {
            var page = new RaceResultsPage();

            var vm = new MarathonResultsPageViewModel(this.Navigation, this.Race);

            page.BindingContext = vm;

            await this.Navigation.PushAsync(page);

            await vm.GetResultsAsync();
        }

        public INavigation Navigation { get; }
        public Race Race { get; }
        public Command SelectCommand { get; }
    }
}
