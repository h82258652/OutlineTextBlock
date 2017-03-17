using Windows.Foundation;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Microsoft.Graphics.Canvas.Text;
using Microsoft.Graphics.Canvas.UI.Xaml;

namespace Demo.Uwp
{
    //public class OutlineTextBlock : FrameworkElement
    //{
    //    public static readonly DependencyProperty FontFamilyProperty = DependencyProperty.Register(nameof(FontFamily), typeof(FontFamily), typeof(OutlineTextBlock), new PropertyMetadata(default(FontFamily)));

    //    protected override Size ArrangeOverride(Size finalSize)
    //    {
    //        var canvasTextFormat = new CanvasTextFormat()
    //        {
    //            FontSize = (float)FontSize,
    //            FontStyle = FontStyle,
    //            FontWeight = FontWeight,
    //            FontFamily = FontFamily.Source,
    //            FontStretch = FontStretch
    //        };

    //        var canvasControl = new CanvasControl();
    //        canvasControl.Invalidate();

    //        var f = new CanvasTextLayout(null, Text, canvasTextFormat, 0, 0);

    //        return base.ArrangeOverride(finalSize);
    //    }

    //    public FontFamily FontFamily
    //    {
    //        get
    //        {
    //            return (FontFamily)GetValue(FontFamilyProperty);
    //        }
    //        set
    //        {
    //            SetValue(FontFamilyProperty, value);
    //        }
    //    }

    //    public double FontSize
    //    {
    //        get
    //        {
    //            return (double)GetValue(FontSizeProperty);
    //        }
    //        set
    //        {
    //            SetValue(FontSizeProperty, value);
    //        }
    //    }

    //    public static readonly DependencyProperty FontSizeProperty = DependencyProperty.Register(nameof(FontSize), typeof(double), typeof(OutlineTextBlock), new PropertyMetadata(default(double)));

    //    public FontStretch FontStretch { get { } set { } }

    //    public FontStyle FontStyle { get { } set { } }

    //    public FontWeight FontWeight { get { } set { } }

    //    public Brush Foreground { get { } set { } }

    //    public double LineHeight { get { } set { } }

    //    public Brush Stroke
    //    {
    //        get { }
    //        set
    //        { }
    //    }

    //    public DoubleCollection StrokeDashArray { get { } set { } }
    //    public double StrokeDashOffset { get { } set { } }
    //    public string Text { get { } set { } }

    //    public double StrokeThickness { get { } set { } }
    //    public TextTrimming TextTrimming { get { } set { } }

    //    public TextAlignment TextAlignment
    //    {
    //        get { }
    //        set
    //        { }
    //    }
    //}
}