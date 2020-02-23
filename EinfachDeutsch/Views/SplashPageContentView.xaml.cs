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
        public int SweepValue { get; set; }
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

            //outer circle
            var outerPaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke, //stroke so that it traces the outline
                Color = Color.Yellow.ToSKColor(), //make it the color red
                StrokeWidth = strokeWidth
            };

            float equalDist = (surfaceWidth - radius) / 2;

            SKRect oval = new SKRect(strokeWidth, strokeWidth, surfaceWidth - strokeWidth, surfaceHeight - strokeWidth);


            SweepValue += 1;
            canvas.DrawArc(oval, 90, (SweepValue % 360), false, outerPaint);
            PaintCanvasView.InvalidateSurface();
            //canvas.DrawCircle(surfaceWidth / 2, surfaceHeight / 2, radius, outerPaint);

            //inner circle
            /*var innerPaint = new SKPaint()
            {
                Style = SKPaintStyle.Fill,
                Color = Color.LightBlue.ToSKColor(),
            };
            canvas.DrawCircle(surfaceWidth / 2, surfaceHeight / 2, radius, innerPaint);*/
        }

    }
}