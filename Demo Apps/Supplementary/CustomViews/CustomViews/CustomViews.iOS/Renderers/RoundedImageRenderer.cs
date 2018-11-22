using System;
using System.ComponentModel;
using CoreAnimation;
using CoreGraphics;
using CustomViews;
using RoundedCornersDemo.iOS.Renderers;
using UIKit;
using Xamarin.Forms.Platform.iOS;

[assembly:Xamarin.Forms.ExportRenderer(typeof(RoundedImage), typeof(RoundedImageRenderer))]
namespace RoundedCornersDemo.iOS.Renderers
{
    public class RoundedImageRenderer : ImageRenderer
    {

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == RoundedImage.TopLeftCornerRadiusProperty.PropertyName ||
                e.PropertyName == RoundedImage.TopRightCornerRadiusProperty.PropertyName ||
                e.PropertyName == RoundedImage.BottomRightCornerRadiusProperty.PropertyName ||
                e.PropertyName == RoundedImage.BottomLeftCornerRadiusProperty.PropertyName)
            {
                // tell iOS to redraw
                this.NativeView.SetNeedsDisplay();
                this.NativeView.SetNeedsLayout();
            }

        }

        public override void Draw(CGRect rect)
        {

            RoundedImage roundedImage = (RoundedImage)this.Element;

            var width = Layer.Bounds.Width / 2.0;
            var height = Layer.Bounds.Height / 2.0;


            var topLeftRect = new CGRect(0, 0, width, height);
            var topRightRect = new CGRect(width, 0, width, height);
            var bottomRightRect = new CGRect(width,height, width, height);
            var bottomLeftRect = new CGRect(0, height, width, height);


            var topLeftPath = UIBezierPath.FromRoundedRect(topLeftRect, UIRectCorner.TopLeft, new CGSize(roundedImage.TopLeftCornerRadius, roundedImage.TopLeftCornerRadius));
            var topRightPath = UIBezierPath.FromRoundedRect(topRightRect, UIRectCorner.TopRight, new CGSize(roundedImage.TopRightCornerRadius, roundedImage.TopRightCornerRadius));
            var bottomRightPath = UIBezierPath.FromRoundedRect(bottomRightRect, UIRectCorner.BottomRight, new CGSize(roundedImage.BottomRightCornerRadius, roundedImage.BottomRightCornerRadius));
            var bottomLeftPath = UIBezierPath.FromRoundedRect(bottomLeftRect, UIRectCorner.BottomLeft, new CGSize(roundedImage.BottomLeftCornerRadius, roundedImage.BottomLeftCornerRadius));


            CAShapeLayer topLeftMaskLayer = new CAShapeLayer();
            topLeftMaskLayer.Frame = Layer.Bounds;
            topLeftMaskLayer.Path = topLeftPath.CGPath;

            CAShapeLayer topRightMaskLayer = new CAShapeLayer();
            topRightMaskLayer.Frame = Layer.Bounds;
            topRightMaskLayer.Path = topRightPath.CGPath;

            CAShapeLayer bottomRightMaskLayer = new CAShapeLayer();
            bottomRightMaskLayer.Frame = Layer.Bounds;
            bottomRightMaskLayer.Path = bottomRightPath.CGPath;

            CAShapeLayer bottomLeftMaskLayer = new CAShapeLayer();
            bottomLeftMaskLayer.Frame = Layer.Bounds;
            bottomLeftMaskLayer.Path = bottomLeftPath.CGPath;


            CALayer maskLayer = new CALayer();
            maskLayer.AddSublayer(topLeftMaskLayer);
            maskLayer.AddSublayer(topRightMaskLayer);
            maskLayer.AddSublayer(bottomRightMaskLayer);
            maskLayer.AddSublayer(bottomLeftMaskLayer);

            Layer.Mask = maskLayer;

            base.Draw(rect);
        }



    }
}
