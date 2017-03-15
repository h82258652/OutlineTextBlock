using System;
using System.Globalization;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace Demo.Wpf
{
    public class OutlineTextBlock2 : FrameworkElement
    {
        public static readonly DependencyProperty FontFamilyProperty = DependencyProperty.Register(nameof(FontFamily), typeof(FontFamily), typeof(OutlineTextBlock2), new PropertyMetadata(TextElement.FontFamilyProperty.DefaultMetadata.DefaultValue, OnFontFamilyChanged));

        public static readonly DependencyProperty FontSizeProperty = DependencyProperty.Register(nameof(FontSize), typeof(double), typeof(OutlineTextBlock2), new PropertyMetadata(TextElement.FontSizeProperty.DefaultMetadata.DefaultValue, OnFontSizeChanged));

        public static readonly DependencyProperty FontStretchProperty = DependencyProperty.Register(nameof(FontStretch), typeof(FontStretch), typeof(OutlineTextBlock2), new PropertyMetadata(default(FontStretch), OnFontStretchChanged));

        public static readonly DependencyProperty FontStyleProperty = DependencyProperty.Register(nameof(FontStyle), typeof(FontStyle), typeof(OutlineTextBlock2), new PropertyMetadata(default(FontStyle), OnFontStyleChanged));

        public static readonly DependencyProperty FontWeightProperty = DependencyProperty.Register(nameof(FontWeight), typeof(FontWeight), typeof(OutlineTextBlock2), new PropertyMetadata(default(FontWeight), OnFontWeightChanged));

        public static readonly DependencyProperty ForegroundProperty = DependencyProperty.Register(nameof(Foreground), typeof(Brush), typeof(OutlineTextBlock2), new PropertyMetadata(default(Brush), OnForegroundChanged));

        public static readonly DependencyProperty LineHeightProperty = DependencyProperty.Register(nameof(LineHeight), typeof(double), typeof(OutlineTextBlock2), new PropertyMetadata(default(double), OnLineHeightChanged));

        public static readonly DependencyProperty StrokeDashArrayProperty = DependencyProperty.Register(nameof(StrokeDashArray), typeof(DoubleCollection), typeof(OutlineTextBlock2), new PropertyMetadata(default(DoubleCollection), OnStrokeDashArrayChanged));

        public static readonly DependencyProperty StrokeDashOffsetProperty = DependencyProperty.Register(nameof(StrokeDashOffset), typeof(double), typeof(OutlineTextBlock2), new PropertyMetadata(default(double), OnStrokeDashOffsetChanged));

        public static readonly DependencyProperty StrokeProperty = DependencyProperty.Register(nameof(Stroke), typeof(Brush), typeof(OutlineTextBlock2), new PropertyMetadata(default(Brush), OnStrokeChanged));

        public static readonly DependencyProperty StrokeThicknessProperty = DependencyProperty.Register(nameof(StrokeThickness), typeof(double), typeof(OutlineTextBlock2), new PropertyMetadata(default(double), OnStrokeThicknessChanged));

        public static readonly DependencyProperty TextAlignmentProperty = DependencyProperty.Register(nameof(TextAlignment), typeof(TextAlignment), typeof(OutlineTextBlock2), new PropertyMetadata(default(TextAlignment), OnTextAlignmentChanged));

        public static readonly DependencyProperty TextDecorationsProperty = DependencyProperty.Register(nameof(TextDecorations), typeof(TextDecorationCollection), typeof(OutlineTextBlock2), new PropertyMetadata(default(TextDecorationCollection), OnTextDecorationsChanged));

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(OutlineTextBlock2), new PropertyMetadata(default(string), OnTextChanged));

        public static readonly DependencyProperty TextTrimmingProperty = DependencyProperty.Register(nameof(TextTrimming), typeof(TextTrimming), typeof(OutlineTextBlock2), new PropertyMetadata(default(TextTrimming), OnTextTrimmingChanged));

        private FormattedText _formattedText;

        public FontFamily FontFamily
        {
            get
            {
                return (FontFamily)GetValue(FontFamilyProperty);
            }
            set
            {
                SetValue(FontFamilyProperty, value);
            }
        }

        public double FontSize
        {
            get
            {
                return (double)GetValue(FontSizeProperty);
            }
            set
            {
                SetValue(FontSizeProperty, value);
            }
        }

        public FontStretch FontStretch
        {
            get
            {
                return (FontStretch)GetValue(FontStretchProperty);
            }
            set
            {
                SetValue(FontStretchProperty, value);
            }
        }

        public FontStyle FontStyle
        {
            get
            {
                return (FontStyle)GetValue(FontStyleProperty);
            }
            set
            {
                SetValue(FontStyleProperty, value);
            }
        }

        public FontWeight FontWeight
        {
            get
            {
                return (FontWeight)GetValue(FontWeightProperty);
            }
            set
            {
                SetValue(FontWeightProperty, value);
            }
        }

        public Brush Foreground
        {
            get
            {
                return (Brush)GetValue(ForegroundProperty);
            }
            set
            {
                SetValue(ForegroundProperty, value);
            }
        }

        public double LineHeight
        {
            get
            {
                return (double)GetValue(LineHeightProperty);
            }
            set
            {
                SetValue(LineHeightProperty, value);
            }
        }

        public Brush Stroke
        {
            get
            {
                return (Brush)GetValue(StrokeProperty);
            }
            set
            {
                SetValue(StrokeProperty, value);
            }
        }

        public DoubleCollection StrokeDashArray
        {
            get
            {
                return (DoubleCollection)GetValue(StrokeDashArrayProperty);
            }
            set
            {
                SetValue(StrokeDashArrayProperty, value);
            }
        }

        public double StrokeDashOffset
        {
            get
            {
                return (double)GetValue(StrokeDashOffsetProperty);
            }
            set
            {
                SetValue(StrokeDashOffsetProperty, value);
            }
        }

        public double StrokeThickness
        {
            get
            {
                return (double)GetValue(StrokeThicknessProperty);
            }
            set
            {
                SetValue(StrokeThicknessProperty, value);
            }
        }

        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }

        public TextAlignment TextAlignment
        {
            get
            {
                return (TextAlignment)GetValue(TextAlignmentProperty);
            }
            set
            {
                SetValue(TextAlignmentProperty, value);
            }
        }

        public TextDecorationCollection TextDecorations
        {
            get
            {
                return (TextDecorationCollection)GetValue(TextDecorationsProperty);
            }
            set
            {
                SetValue(TextDecorationsProperty, value);
            }
        }

        public TextTrimming TextTrimming
        {
            get
            {
                return (TextTrimming)GetValue(TextTrimmingProperty);
            }
            set
            {
                SetValue(TextTrimmingProperty, value);
            }
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            if (_formattedText == null)
            {
                UpdateFormattedText();
            }
            if (_formattedText != null)
            {
                _formattedText.MaxTextWidth = finalSize.Width;
                _formattedText.MaxTextHeight = finalSize.Height;
            }

            return finalSize;
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            if (_formattedText == null)
            {
                UpdateFormattedText();
            }
            if (_formattedText != null)
            {
                _formattedText.MaxTextWidth = Math.Min(double.MaxValue, availableSize.Width);
                _formattedText.MaxTextHeight = Math.Max(double.Epsilon, availableSize.Height);

                return new Size(_formattedText.Width, _formattedText.Height);
            }
            else
            {
                return Size.Empty;
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            if (_formattedText == null)
            {
                UpdateFormattedText();
            }
            if (_formattedText != null)
            {
                drawingContext.DrawGeometry(Foreground, new Pen(Stroke, StrokeThickness)
                {
                    DashStyle = new DashStyle(StrokeDashArray, StrokeDashOffset)
                }, _formattedText.BuildGeometry(new Point()));
            }
        }

        private static void OnFontFamilyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (OutlineTextBlock2)d;
            var value = (FontFamily)e.NewValue;

            var formattedText = obj._formattedText;
            if (formattedText == null)
            {
                obj.UpdateFormattedText();
            }
            else
            {
                formattedText.SetFontFamily(value);
            }

            obj.InvalidateMeasure();
            obj.InvalidateVisual();
        }

        private static void OnFontSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (OutlineTextBlock2)d;
            var value = (double)e.NewValue;

            var formattedText = obj._formattedText;
            if (formattedText == null)
            {
                obj.UpdateFormattedText();
            }
            else
            {
                formattedText.SetFontSize(value);
            }

            obj.InvalidateMeasure();
            obj.InvalidateVisual();
        }

        private static void OnFontStretchChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (OutlineTextBlock2)d;
            var value = (FontStretch)e.NewValue;

            var formattedText = obj._formattedText;
            if (formattedText == null)
            {
                obj.UpdateFormattedText();
            }
            else
            {
                formattedText.SetFontStretch(value);
            }

            obj.InvalidateMeasure();
            obj.InvalidateVisual();
        }

        private static void OnFontStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (OutlineTextBlock2)d;
            var value = (FontStyle)e.NewValue;

            var formattedText = obj._formattedText;
            if (formattedText == null)
            {
                obj.UpdateFormattedText();
            }
            else
            {
                formattedText.SetFontStyle(value);
            }

            obj.InvalidateMeasure();
            obj.InvalidateVisual();
        }

        private static void OnFontWeightChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (OutlineTextBlock2)d;
            var value = (FontWeight)e.NewValue;

            var formattedText = obj._formattedText;
            if (formattedText == null)
            {
                obj.UpdateFormattedText();
            }
            else
            {
                formattedText.SetFontWeight(value);
            }

            obj.InvalidateMeasure();
            obj.InvalidateVisual();
        }

        private static void OnForegroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (OutlineTextBlock2)d;

            obj.InvalidateVisual();
        }

        private static void OnLineHeightChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (OutlineTextBlock2)d;
            var value = (double)e.NewValue;

            var formattedText = obj._formattedText;
            if (formattedText == null)
            {
                obj.UpdateFormattedText();
            }
            else
            {
                formattedText.LineHeight = value;
            }

            obj.InvalidateMeasure();
            obj.InvalidateVisual();
        }

        private static void OnStrokeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (OutlineTextBlock2)d;

            obj.InvalidateVisual();
        }

        private static void OnStrokeDashArrayChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (OutlineTextBlock2)d;

            obj.InvalidateVisual();
        }

        private static void OnStrokeDashOffsetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (OutlineTextBlock2)d;

            obj.InvalidateVisual();
        }

        private static void OnStrokeThicknessChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (OutlineTextBlock2)d;

            obj.InvalidateVisual();
        }

        private static void OnTextAlignmentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (OutlineTextBlock2)d;
            var value = (TextAlignment)e.NewValue;

            var formattedText = obj._formattedText;
            if (formattedText == null)
            {
                obj.UpdateFormattedText();
            }
            else
            {
                formattedText.TextAlignment = value;
            }

            obj.InvalidateMeasure();
            obj.InvalidateVisual();
        }

        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (OutlineTextBlock2)d;

            obj.UpdateFormattedText();

            obj.InvalidateMeasure();
            obj.InvalidateVisual();
        }

        private static void OnTextDecorationsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (OutlineTextBlock2)d;

            obj.UpdateFormattedText();

            obj.InvalidateMeasure();
            obj.InvalidateVisual();
        }

        private static void OnTextTrimmingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (OutlineTextBlock2)d;
            var value = (TextTrimming)e.NewValue;

            var formattedText = obj._formattedText;
            if (formattedText == null)
            {
                obj.UpdateFormattedText();
            }
            else
            {
                formattedText.Trimming = value;
            }

            obj.InvalidateMeasure();
            obj.InvalidateVisual();
        }

        private void UpdateFormattedText()
        {
            if (Text == null)
            {
                _formattedText = null;
            }
            else
            {
                using (var graphics = System.Drawing.Graphics.FromHwnd(IntPtr.Zero))
                {
                    var dpi = graphics.DpiY;
                    _formattedText = new FormattedText(Text, CultureInfo.CurrentUICulture, FlowDirection, new Typeface(FontFamily, FontStyle, FontWeight, FontStretch), FontSize, new SolidColorBrush(Colors.Black), dpi / 96)
                    {
                        TextAlignment = TextAlignment,
                        Trimming = TextTrimming,
                        LineHeight = LineHeight
                    };
                    _formattedText.SetTextDecorations(TextDecorations);
                }
            }
        }
    }
}