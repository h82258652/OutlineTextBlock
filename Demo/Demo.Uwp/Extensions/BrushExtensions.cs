using System;
using System.Linq;
using Windows.UI.Xaml.Media;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Brushes;

namespace Demo.Uwp.Extensions
{
    public static class BrushExtensions
    {
        public static ICanvasBrush ToCanvasBrush(this Brush brush, ICanvasResourceCreator resourceCreator)
        {
            switch (brush)
            {
                case SolidColorBrush solidColorBrush:
                    return new CanvasSolidColorBrush(resourceCreator, solidColorBrush.Color);

                case LinearGradientBrush linearGradientBrush:

                    return new CanvasLinearGradientBrush(resourceCreator, (from GradientStop gradientStop in linearGradientBrush.GradientStops
                                                                           select new CanvasGradientStop()
                                                                           {
                                                                               Color = gradientStop.Color,
                                                                               Position = (float)gradientStop.Offset
                                                                           }).ToArray());

                default:
                    throw new NotSupportedException();
            }
        }
    }
}