using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppTemplate.Views.Components
{
    public class Line : GraphicsView
    {
        #region Bindable properties

        public static readonly BindableProperty LineColorProperty =
            BindableProperty.Create(
                nameof(LineColor),
                typeof(Color),
                typeof(Line),
                defaultValue: Colors.Black,
                propertyChanged: BindablePropertyChanged);

        public Color LineColor
        {
            get { return (Color)GetValue(LineColorProperty); }
            set { SetValue(LineColorProperty, value); }
        }



        public static readonly BindableProperty LineThicknessProperty =
            BindableProperty.Create(
                nameof(LineThickness),
                typeof(double),
                typeof(Line),
                defaultValue: 1.0);

        public double LineThickness
        {
            get { return (double)GetValue(LineThicknessProperty); }
            set { SetValue(LineThicknessProperty, value); }
        }



        public static readonly BindableProperty OrientationProperty =
            BindableProperty.Create(
                nameof(Orientation),
                typeof(StackOrientation),
                typeof(Line),
                defaultValue: StackOrientation.Horizontal);

        public StackOrientation Orientation
        {
            get { return (StackOrientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }



        public static readonly BindableProperty LineJoinProperty =
            BindableProperty.Create(
                nameof(LineJoin),
                typeof(LineJoin),
                typeof(Line),
                defaultValue: LineJoin.Miter);

        public LineJoin LineJoin
        {
            get { return (LineJoin)GetValue(LineJoinProperty); }
            set { SetValue(LineJoinProperty, value); }
        }

        #endregion

        public Line()
        {
            base.Drawable = new LineDrawable(this);
        }

        private class LineDrawable : View, IDrawable
        {
            private readonly Line _line;

            public LineDrawable(Line line)
            {
                _line = line;
            }

            public void Draw(ICanvas canvas, RectF dirtyRect)
            {
                canvas.ResetState();

                var density = (float)DeviceDisplay.MainDisplayInfo.Density;
                canvas.StrokeColor = _line.LineColor;
                canvas.StrokeSize = (float)_line.LineThickness;
                canvas.Antialias = true;
                canvas.StrokeLineJoin = LineJoin.Round;

                var densityWidth = dirtyRect.Width * density;
                var densityHeight = dirtyRect.Height * density;

                using (PathF path = new())
                {
                    if (_line.Orientation == StackOrientation.Horizontal)
                    {
                        path.MoveTo(new PointF(0, densityHeight / 2));
                        path.LineTo(new PointF(densityWidth, densityHeight / 2));
                    }
                    else
                    {
                        path.MoveTo(new PointF(densityWidth / 2, 0));
                        path.LineTo(new PointF(densityWidth / 2, densityHeight));
                    }

                    path.Close();
                    canvas.DrawPath(path);
                }
            }
        }

        private static void BindablePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is Line line)
                line.Invalidate();
        }
    }
}
