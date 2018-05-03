using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;

using Android.Graphics.Drawables;
using Xamarin.Forms;
using View = Android.Views.View;

namespace RoundedImageDemo.Droid
{
    public class RoundedImageRenderer : ImageRenderer
    {
        public RoundedImageRenderer(Context context) : base(context)
        {
        }

        protected override bool DrawChild(Canvas canvas, View child, long drawingTime)
        {
            if (this.Element is RoundedImage roundedImage)
            {
                GradientDrawable d = child.Background as GradientDrawable;
                d.SetCornerRadius(roundedImage.CornerRadius);
            }

            


                return base.DrawChild(canvas, child, drawingTime);
        }

        protected override void DispatchDraw(Canvas canvas)
        {
            base.DispatchDraw(canvas);
        }
    }
}