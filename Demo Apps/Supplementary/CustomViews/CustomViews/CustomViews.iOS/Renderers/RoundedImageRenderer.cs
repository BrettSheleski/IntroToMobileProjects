using System;
using System.ComponentModel;
using CoreAnimation;
using CoreGraphics;
using CustomViews;
using CustomViews.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly:ExportRenderer(typeof(RoundedImage), typeof(RoundedImageRenderer))]
namespace CustomViews.iOS.Renderers
{
    public class RoundedImageRenderer : ImageRenderer
    {



        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (Element != null){

            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == RoundedImage.TopLeftCornerRadiusProperty.PropertyName ||
                e.PropertyName == RoundedImage.TopRightCornerRadiusProperty.PropertyName ||
                e.PropertyName == RoundedImage.BottomLeftCornerRadiusProperty.PropertyName ||
                e.PropertyName == RoundedImage.BottomRightCornerRadiusProperty.PropertyName)
            {
                if (this.NativeView != null){
                    this.NativeView.SetNeedsDisplay();
                    this.NativeView.SetNeedsLayout();
                }
            }
        }

        public override void Draw(CGRect rect)
        {


            this.LayoutIfNeeded();

            RoundedImage roundedImage = (RoundedImage)Element;


            var topLeftPath = UIBezierPath.FromRoundedRect(Layer.Bounds, UIRectCorner.TopLeft, new CGSize(roundedImage.TopLeftCornerRadius, roundedImage.TopLeftCornerRadius));
            var topRightPath = UIBezierPath.FromRoundedRect(Layer.Bounds, UIRectCorner.TopRight, new CGSize(roundedImage.TopRightCornerRadius, roundedImage.TopRightCornerRadius));
            var bottomLeftPath = UIBezierPath.FromRoundedRect(Layer.Bounds, UIRectCorner.BottomLeft, new CGSize(roundedImage.BottomLeftCornerRadius, roundedImage.BottomLeftCornerRadius));
            var bottomRightPath = UIBezierPath.FromRoundedRect(Layer.Bounds, UIRectCorner.BottomRight, new CGSize(roundedImage.BottomRightCornerRadius, roundedImage.BottomRightCornerRadius));





            CAShapeLayer topLeftMaskLayer = new CAShapeLayer();
            topLeftMaskLayer.Frame = Layer.Bounds;
            topLeftMaskLayer.Path = topLeftPath.CGPath;

            CAShapeLayer topRightMaskLayer = new CAShapeLayer();
            topRightMaskLayer.Frame = Layer.Bounds;
            topRightMaskLayer.Path = topRightPath.CGPath;


            CAShapeLayer bottomLeftMaskLayer = new CAShapeLayer();
            bottomLeftMaskLayer.Frame = Layer.Bounds;
            bottomLeftMaskLayer.Path = bottomLeftPath.CGPath;


            CAShapeLayer bottomRightMaskLayer = new CAShapeLayer();
            bottomRightMaskLayer.Frame = Layer.Bounds;
            bottomRightMaskLayer.Path = bottomRightPath.CGPath;

            CALayer maskLayer = new CALayer();
            maskLayer.Frame = Layer.Bounds;
            maskLayer.AddSublayer(topLeftMaskLayer);


            //maskLayer.AddSublayer(topRightMaskLayer);
            //maskLayer.AddSublayer(bottomRightMaskLayer);
            //maskLayer.AddSublayer(bottomLeftMaskLayer);


            Layer.Mask = maskLayer;


            base.Draw(rect);
        }

    }
}
