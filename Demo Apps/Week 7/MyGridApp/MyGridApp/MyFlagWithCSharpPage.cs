using System;

using Xamarin.Forms;

namespace MyGridApp
{
    public class MyFlagWithCSharpPage : ContentPage
    {
        public MyFlagWithCSharpPage()
        {
            Grid myGrid = new Grid();

            myGrid.RowSpacing = 0;
            myGrid.ColumnSpacing = 0;
            myGrid.ColumnDefinitions.Add(new ColumnDefinition {
                Width = new GridLength(4, GridUnitType.Star)
            });

            myGrid.ColumnDefinitions.Add(new ColumnDefinition {
                Width = new GridLength(6, GridUnitType.Star)
            });


            for (int i = 0; i < 25; ++i)
            {
                myGrid.RowDefinitions.Add(new RowDefinition());

                BoxView stripe = new BoxView();

                Grid.SetRow(stripe, i);

                if (i %2 == 0)
                {
                    stripe.BackgroundColor = Color.Red;
                }
                else
                {
                    stripe.BackgroundColor = Color.White;
                }

                if (i < 7)
                {
                    Grid.SetColumn(stripe, 1);
                }
                else
                {
                    Grid.SetColumnSpan(stripe, 2);
                }

                myGrid.Children.Add(stripe);
            }

            BoxView field = new BoxView()
            {
                BackgroundColor = Color.Blue
            };

            Grid.SetRowSpan(field, 7);

            myGrid.Children.Add(field);

            this.Content = myGrid;

        }
    }
}

