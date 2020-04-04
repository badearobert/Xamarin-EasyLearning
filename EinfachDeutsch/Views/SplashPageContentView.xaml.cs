using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EinfachDeutsch
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashPageContentView : ContentView
    {
        public int SweepValue { get; set; } = 0;
        public int whoFirst = 0;
        public SplashPageContentView()
        {
            InitializeComponent();
        }

        private void canvas_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            int surfaceWidth = e.Info.Width;
            int surfaceHeight = e.Info.Height;

            int strokeWidth = 25;
            float radius = (Math.Min(surfaceHeight, surfaceWidth) * 0.5f) - strokeWidth;
            canvas.Clear();

            var leftPaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke, //stroke so that it traces the outline
                Color = Color.Yellow.ToSKColor(), //make it the color red
                StrokeWidth = strokeWidth
            }; 
            var rightPaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke, //stroke so that it traces the outline
                Color = Color.Red.ToSKColor(), //make it the color red
                StrokeWidth = strokeWidth
            };

            SKRect oval = new SKRect(strokeWidth, strokeWidth, surfaceWidth - strokeWidth, surfaceHeight - strokeWidth);


            SweepValue += 3;
            if (SweepValue > 360) {
                whoFirst = (whoFirst+1) % 2;
                SweepValue = 0;
            }
            int idx = SweepValue > 180 ? 1 : 0;
            List<SKPaint> colors = new List<SKPaint>(){ leftPaint, rightPaint };
            if (whoFirst % 2 == 0)
            {
                canvas.DrawArc(oval, 90, (SweepValue % 360), false, colors[idx]);
                canvas.DrawArc(oval, 90, ((SweepValue * (-1)) % 360), false, colors[(idx + 1) % 2]);
            } else
            {
                canvas.DrawArc(oval, 90, ((SweepValue * (-1)) % 360), false, colors[idx]);
                canvas.DrawArc(oval, 90, (SweepValue % 360), false, colors[(idx + 1) % 2]);
            }
            PaintCanvasView.InvalidateSurface();
        }

    }
}