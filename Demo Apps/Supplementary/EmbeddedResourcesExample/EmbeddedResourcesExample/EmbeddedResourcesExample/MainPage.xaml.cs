using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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





        void Foo()
        {



            int sum = Add(2, 3);


            Func<int, int, int> SomeMethodThatTakesInTwoIntsAndReturnAnInt = Add;

            sum = SomeMethodThatTakesInTwoIntsAndReturnAnInt(10, 20);

            Func<int, int, double> someMethod = Divide;


            someMethod = delegate (int x, int y)
            {
                return x / (double)y;
            };


            someMethod = (q, p) => q / (double)p;

            someMethod = (x1, x2) =>
            {
                Console.WriteLine($"Dividing {x1} by {x2}");

                return x1 / (double)x2;
            };



            Expression<Func<int, int, double>> myLambda;

            myLambda = (x, y) => x / (double)y;


            //myLambda.




            IQueryable<person> allPeopleInTheDatabase = GetAllPeopleSOmehow(); // SELECT * FROM person_table

            IQueryable<person> peopleWhosLastNameStartsWithA = allPeopleInTheDatabase.Where(p => p.last_name.StartsWith("A")); // SELECT * FROM person_table WHERE last_name LIKE 'A%'

            IQueryable<person> gimmeJust100Records = peopleWhosLastNameStartsWithA.Take(100); // SELECT TOP 100 * FROM person_table WHERE last_name LIKE 'A%'

            //var people = GetAllPeopleSOmehow().ToList().Where(p => p.last_name.StartsWith("A")).Take(100);

            var mySTuff = peopleWhosLastNameStartsWithA.Select(p => new
            {
                FirstName = p.first_name,
                LastName = p.last_name
            });



            List<person> peopleInMemory = gimmeJust100Records.ToList();

            foreach (var person in gimmeJust100Records)
            {


            }





        }

        private IQueryable<person> GetAllPeopleSOmehow()
        {
            throw new NotImplementedException();
        }

        int Add(int a, int b)
        {
            return a + b;

        }

        double Divide(int a, int b)
        {
            return a / (double)b;
        }



    }



}
