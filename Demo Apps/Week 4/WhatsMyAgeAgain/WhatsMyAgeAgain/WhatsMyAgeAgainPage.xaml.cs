using Xamarin.Forms;
using System;

namespace WhatsMyAgeAgain
{
    public partial class WhatsMyAgeAgainPage : ContentPage
    {
        public WhatsMyAgeAgainPage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            string monthString = MonthEntry.Text;
            string yearString = YearEntry.Text;
            string dayString = DayEntry.Text;

            int month, year, day;


            if (int.TryParse(monthString, out month)){
                // yay! we gots a month!


                if (int.TryParse(yearString, out year))
                {

                    if (int.TryParse(dayString, out day)){
                    
                        // nice, we gots all 3.  lets do work

                        DateTime birthDate = new DateTime(year, month, day);

                        TimeSpan age = DateTime.Now - birthDate;


                        int daysOfLife = age.Days;

                        int yearsOfLife = daysOfLife / 365;

                        AgeLabel.Text = yearsOfLife.ToString();

                    }
                    else{

                        // they're really not smart, are they?
                        AgeLabel.Text = "Please specify a valid day (1-31)";
                    }
                }
                else{
                    // let the user know they are a ___
                    AgeLabel.Text = "Please specify a valid year";
                }

            }
            else{
                // :( the user input bad 
                AgeLabel.Text = "Please specify a valid month (1-12)";
            }





        }
    }
}
