using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Foundation;
using RoundedImageDemo;
using RoundedImageDemo.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly:ExportRenderer(typeof(RoundedImage), typeof(RoundedImageRenderer))]
namespace RoundedImageDemo.iOS
{
    public class RoundedImageRenderer : ImageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
                return;

            Draw();
        }

        void Draw()
        {
            RoundedImage roundedImage = this.Element as RoundedImage;

            if (roundedImage != null)
            {
                Control.Layer.CornerRadius = (float)roundedImage.CornerRadius;
                Control.Layer.MasksToBounds = false;
                Control.ClipsToBounds = true;
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == VisualElement.HeightProperty.PropertyName || e.PropertyName == VisualElement.WidthProperty.PropertyName || e.PropertyName == RoundedImage.CornerRadiusProperty.PropertyName)
            {
                Draw();
            }
        }
    }
}