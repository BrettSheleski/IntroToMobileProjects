//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//using Android.App;
//using Android.Content;
//using Android.OS;
//using Android.Runtime;
//using Android.Views;
//using Android.Widget;
//using cv = CustomViews;
//using Xamarin.Forms;
//using Xamarin.Forms.Platform.Android;
//using System.ComponentModel;
//using Android.Graphics;
//using Android.Graphics.Drawables;

//using AButton = Android.Widget.Button;
//using ACanvas = Android.Graphics.Canvas;
//using GlobalResource = Android.Resource;

//[assembly:ExportRenderer(typeof(cv.RoundedCornerContentView), typeof(CustomViews.Droid.Renderers.RoundedCornerContentViewRenderer))]
//namespace CustomViews.Droid.Renderers
//{
//    public class RoundedCornerContentViewRenderer : VisualElementRenderer<cv.RoundedCornerContentView>
//    {

//        // I Stole most of this code from:  https://github.com/xamarin/Xamarin.Forms/blob/master/Xamarin.Forms.Platform.Android/Renderers/FrameRenderer.cs
//        bool _disposed;
      
//        public RoundedCornerContentViewRenderer(Context context) : base(context)
//        {
//        }

//        [Obsolete("This constructor is obsolete as of version 2.5. Please use FrameRenderer(Context) instead.")]
//        public RoundedCornerContentViewRenderer()
//        {
//            AutoPackage = false;
//        }

//        protected override void Dispose(bool disposing)
//        {
//            base.Dispose(disposing);

//            if (disposing && !_disposed)
//            {
//                Background.Dispose();
//                _disposed = true;
//            }
//        }

//        public override bool OnTouchEvent(MotionEvent e)
//        {
//            if (base.OnTouchEvent(e))
//                return true;

//            //return _motionEventHelper.HandleMotionEvent(Parent, e);
//        }

//        protected override void OnElementChanged(ElementChangedEventArgs<RoundedCornerContentView> e)
//        {
//            base.OnElementChanged(e);

//            if (e.NewElement != null && e.OldElement == null)
//            {
//                UpdateBackground();
//                //_motionEventHelper.UpdateElement(e.NewElement);
//            }
//        }

//        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
//        {
//            base.OnElementPropertyChanged(sender, e);
//            if (e.PropertyName == VisualElement.BackgroundColorProperty.PropertyName 
//                || e.PropertyName == RoundedCornerContentView.TopRightCornerRadiusProperty.PropertyName
//                || e.PropertyName == RoundedCornerContentView.TopLeftCornerRadiusProperty.PropertyName
//                || e.PropertyName == RoundedCornerContentView.BottomRightCornerRadiusProperty.PropertyName
//                || e.PropertyName == RoundedCornerContentView.BottomLeftCornerRadiusProperty.PropertyName)
//            {
//                UpdateBackground();
//            }
//        }

//        void UpdateBackground()
//        {
//            this.SetBackground(new RoundedCornerContentViewDrawable(Element, Context.ToPixels));
//        }

//        class RoundedCornerContentViewDrawable : Drawable
//        {
//            readonly RoundedCornerContentView _frame;
//            readonly Func<double, float> _convertToPixels;

//            bool _isDisposed;
//            Bitmap _normalBitmap;

//            public RoundedCornerContentViewDrawable(RoundedCornerContentView frame, Func<double, float> convertToPixels)
//            {
//                _frame = frame;
//                _convertToPixels = convertToPixels;
//                frame.PropertyChanged += FrameOnPropertyChanged;
//            }

//            public override bool IsStateful
//            {
//                get { return false; }
//            }

//            public override int Opacity
//            {
//                get { return 0; }
//            }

//            public override void Draw(ACanvas canvas)
//            {
//                int width = Bounds.Width();
//                int height = Bounds.Height();

//                if (width <= 0 || height <= 0)
//                {
//                    if (_normalBitmap != null)
//                    {
//                        _normalBitmap.Dispose();
//                        _normalBitmap = null;
//                    }
//                    return;
//                }

//                if (_normalBitmap == null || _normalBitmap.Height != height || _normalBitmap.Width != width)
//                {
//                    // If the user changes the orientation of the screen, make sure to destroy reference before
//                    // reassigning a new bitmap reference.
//                    if (_normalBitmap != null)
//                    {
//                        _normalBitmap.Dispose();
//                        _normalBitmap = null;
//                    }

//                    _normalBitmap = CreateBitmap(false, width, height);
//                }
//                Bitmap bitmap = _normalBitmap;
//                using (var paint = new Paint())
//                    canvas.DrawBitmap(bitmap, 0, 0, paint);
//            }

//            public override void SetAlpha(int alpha)
//            {
//            }

//            public override void SetColorFilter(ColorFilter cf)
//            {
//            }

//            protected override void Dispose(bool disposing)
//            {
//                if (disposing && !_isDisposed)
//                {
//                    if (_normalBitmap != null)
//                    {
//                        _normalBitmap.Dispose();
//                        _normalBitmap = null;
//                    }

//                    _isDisposed = true;
//                }

//                base.Dispose(disposing);
//            }

//            protected override bool OnStateChange(int[] state)
//            {
//                return false;
//            }

//            Bitmap CreateBitmap(bool pressed, int width, int height)
//            {
//                Bitmap bitmap;
//                using (Bitmap.Config config = Bitmap.Config.Argb8888)
//                    bitmap = Bitmap.CreateBitmap(width, height, config);

//                using (var canvas = new ACanvas(bitmap))
//                {
//                    DrawCanvas(canvas, width, height, pressed);
//                }

//                return bitmap;
//            }

//            void DrawBackground(ACanvas canvas, int width, int height, float cornerRadius, bool pressed)
//            {
//                using (var paint = new Paint { AntiAlias = true })
//                using (var path = new Path())
//                using (Path.Direction direction = Path.Direction.Cw)
//                using (Paint.Style style = Paint.Style.Fill)
//                using (var rect = new RectF(0, 0, width, height))
//                {
//                    float rx = _convertToPixels(cornerRadius);
//                    float ry = _convertToPixels(cornerRadius);
//                    path.AddRoundRect(rect, rx, ry, direction);

//                    global::Android.Graphics.Color color = _frame.BackgroundColor.ToAndroid();

//                    paint.SetStyle(style);
//                    paint.Color = color;

//                    canvas.DrawPath(path, paint);
//                }
//            }
            
//            void FrameOnPropertyChanged(object sender, PropertyChangedEventArgs e)
//            {
//                if (e.PropertyName == VisualElement.BackgroundColorProperty.PropertyName
//                    || e.PropertyName == RoundedCornerContentView.TopLeftCornerRadiusProperty.PropertyName
//                    || e.PropertyName == RoundedCornerContentView.TopRightCornerRadiusProperty.PropertyName
//                    || e.PropertyName == RoundedCornerContentView.BottomLeftCornerRadiusProperty.PropertyName
//                    || e.PropertyName == RoundedCornerContentView.BottomRightCornerRadiusProperty.PropertyName)
//                {
//                    if (_normalBitmap == null)
//                        return;

//                    using (var canvas = new ACanvas(_normalBitmap))
//                    {
//                        int width = Bounds.Width();
//                        int height = Bounds.Height();
//                        canvas.DrawColor(global::Android.Graphics.Color.Black, PorterDuff.Mode.Clear);
//                        DrawCanvas(canvas, width, height, false);
//                    }
//                    InvalidateSelf();
//                }
//            }

//            void DrawCanvas(ACanvas canvas, int width, int height, bool pressed)
//            {
//                float cornerRadius = _frame.CornerRadius;

//                if (cornerRadius == -1f)
//                    cornerRadius = 5f; // default corner radius

//                DrawBackground(canvas, width, height, cornerRadius, pressed);
                
//            }
//        }
//    }
//}