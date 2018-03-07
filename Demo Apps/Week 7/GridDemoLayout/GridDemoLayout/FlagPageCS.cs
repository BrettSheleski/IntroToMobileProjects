using System;

using Xamarin.Forms;

namespace GridDemoLayout
{
    public class FlagPageCS : ContentPage
    {
        public FlagPageCS()
        {
            Grid theGrid = new Grid();

            theGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100) });
            theGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

            BoxView blueBox = new BoxView
            {
                Color = Color.Blue
            };

            const int blueBoxRowSpan = 7;

            Grid.SetRow(blueBox, 0);
            Grid.SetColumn(blueBox, 0);
            Grid.SetRowSpan(blueBox, blueBoxRowSpan);

            theGrid.Children.Add(blueBox);

            BoxView stripeBox;
            for (int i = 0; i < 13; ++i){
                theGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });

                stripeBox = new BoxView
                {
                    Color = i % 2 == 0 ? Color.Red : Color.White
                };

                Grid.SetRow(stripeBox, i);

                if (i < blueBoxRowSpan){
                    Grid.SetColumn(stripeBox, 1);
                    Grid.SetColumnSpan(stripeBox, 1);
                }
                else{
                    Grid.SetColumn(stripeBox, 0);
                    Grid.SetColumnSpan(stripeBox, 2);
                }


                theGrid.Children.Add(stripeBox);
            }


            Content = theGrid;
        }
    }
}

