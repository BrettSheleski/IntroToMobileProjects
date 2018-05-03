using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RoundedImageDemo
{
    public class RoundedImage : Image
    {
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(float), typeof(RoundedImage), 0.0, BindingMode.TwoWay);

        public float CornerRadius
        {
            get { return (float)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
    }
}
