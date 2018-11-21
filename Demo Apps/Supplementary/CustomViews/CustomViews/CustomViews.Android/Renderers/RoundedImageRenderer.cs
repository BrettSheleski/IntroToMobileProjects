using Android.Content;
using Android.Graphics;
using Android.Util;
using CustomViews;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(RoundedImage), typeof(CustomViews.Droid.Renderers.RoundedImageRenderer))]
namespace CustomViews.Droid.Renderers
{
    public class RoundedImageRenderer : ImageRenderer
    {
        public RoundedImageRenderer(Context context) : base(context)
        {

        }


        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == RoundedImage.TopLeftCornerRadiusProperty.PropertyName ||
                e.PropertyName == RoundedImage.TopRightCornerRadiusProperty.PropertyName ||
                e.PropertyName == RoundedImage.BottomLeftCornerRadiusProperty.PropertyName ||
                e.PropertyName == RoundedImage.BottomRightCornerRadiusProperty.PropertyName)
            {
                this.Invalidate();
            }
        }

        protected override bool DrawChild(Canvas canvas, Android.Views.View child, long drawingTime)
        {
            RoundedImage roundedImage = (RoundedImage)Element;

            this.SetClipChildren(true);
            Control.ClipToOutline = true;

            float[] radii = new float[8];

            radii[0] = DpToPixels(this.Context, (float)roundedImage.TopLeftCornerRadius) * 10;
            radii[1] = radii[0];

            radii[2] = DpToPixels(this.Context, (float)roundedImage.TopRightCornerRadius) * 10;
            radii[3] = radii[2];

            radii[4] = DpToPixels(this.Context, (float)roundedImage.BottomRightCornerRadius) * 10;
            radii[5] = radii[4];

            radii[6] = DpToPixels(this.Context, (float)roundedImage.BottomLeftCornerRadius) * 10;
            radii[7] = radii[6];

            


            Path path = new Path();

            {
                int radius = Math.Min(Width, Height) / 2;

                path.AddRoundRect(0, 0, Width, Height, radii, Path.Direction.Ccw);
                canvas.Save();
                canvas.ClipPath(path);
                
                
                var result = base.DrawChild(canvas, child, drawingTime);

                path.Dispose();

                return result;
            }
        }

        public static float DpToPixels(Context context, float valueInDp)
        {
            DisplayMetrics metrics = context.Resources.DisplayMetrics;
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
        }
    }
}