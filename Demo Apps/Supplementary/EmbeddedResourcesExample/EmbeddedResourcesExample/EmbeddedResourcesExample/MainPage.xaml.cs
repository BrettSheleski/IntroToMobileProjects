using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EmbeddedResourcesExample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();


            string theJson = "{}";


            var assembly = typeof(MainPage).Assembly;


            const string myDataJsonResourceName = "EmbeddedResourcesExample.mydata.json";


            using (var resourceStream = assembly.GetManifestResourceStream(myDataJsonResourceName))
                using (var reader = new System.IO.StreamReader(resourceStream))
            {

                theJson = reader.ReadToEnd();
            }



            List<person> people = Newtonsoft.Json.JsonConvert.DeserializeObject<List<person>>(theJson);



            MyList.ItemsSource = people;
        }
    }
}
