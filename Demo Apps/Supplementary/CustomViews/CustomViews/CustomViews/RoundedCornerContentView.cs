using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CustomViews
{
    public class RoundedCornerContentView : ContentView
    {
        const double ZERO = 0.0;

        public static readonly BindableProperty TopLeftCornerRadiusProperty = BindableProperty.Create(nameof(TopLeftCornerRadius), typeof(double), typeof(RoundedCornerContentView), ZERO, BindingMode.TwoWay);
        public static readonly BindableProperty TopRightCornerRadiusProperty = BindableProperty.Create(nameof(TopRightCornerRadius), typeof(double), typeof(RoundedCornerContentView), ZERO, BindingMode.TwoWay);
        public static readonly BindableProperty BottomLeftCornerRadiusProperty = BindableProperty.Create(nameof(BottomLeftCornerRadius), typeof(double), typeof(RoundedCornerContentView), ZERO, BindingMode.TwoWay);
        public static readonly BindableProperty BottomRightCornerRadiusProperty = BindableProperty.Create(nameof(BottomRightCornerRadius), typeof(double), typeof(RoundedCornerContentView), ZERO, BindingMode.TwoWay);

        public double TopLeftCornerRadius
        {
            get { return (double)GetValue(TopLeftCornerRadiusProperty); }
            set { SetValue(TopLeftCornerRadiusProperty, value); }
        }

        public double TopRightCornerRadius
        {
            get { return (double)GetValue(TopRightCornerRadiusProperty); }
            set { SetValue(TopRightCornerRadiusProperty, value); }
        }

        public double BottomLeftCornerRadius
        {
            get { return (double)GetValue(BottomLeftCornerRadiusProperty); }
            set { SetValue(BottomLeftCornerRadiusProperty, value); }
        }

        public double BottomRightCornerRadius
        {
            get { return (double)GetValue(BottomRightCornerRadiusProperty); }
            set { SetValue(BottomRightCornerRadiusProperty, value); }
        }
    }
}
