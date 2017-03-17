using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.Graphics.Canvas.Text;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml.Hosting;
using Demo.Uwp.Extensions;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Brushes;
using Microsoft.Graphics.Canvas.Geometry;

namespace Demo.Uwp
{
    public class OutlineTextBlock2 : Control
    {
        public static readonly DependencyProperty StrokeThicknessProperty = DependencyProperty.Register(nameof(StrokeThickness), typeof(double), typeof(OutlineTextBlock2), new PropertyMetadata(default(double)));

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(OutlineTextBlock2), new PropertyMetadata(default(string), OnTextChanged));

        private CanvasControl _canvas;

        private CanvasTextLayout _textLayout;

        public OutlineTextBlock2()
        {
            DefaultStyleKey = typeof(OutlineTextBlock2);
            Unloaded += OutlineTextBlock2_Unloaded;

            StrokeThickness = 1;
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

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _canvas = (CanvasControl)GetTemplateChild("PART_Canvas");
            _canvas.Draw += Canvas_Draw;
        }

        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (OutlineTextBlock2)d;

            obj._canvas?.Invalidate();
        }

        public TextWrapping TextWrapping
        {
            get;
            set;
        } = TextWrapping.NoWrap;

        private void Canvas_Draw(CanvasControl sender, CanvasDrawEventArgs args)
        {
            var textFormat = new CanvasTextFormat()
            {
                FontSize = (float)FontSize,
                FontFamily = FontFamily.Source,
                FontStretch = FontStretch,
                FontWeight = FontWeight,
                FontStyle = FontStyle
            };
            switch (TextWrapping)
            {
                case TextWrapping.NoWrap:
                    textFormat.WordWrapping = CanvasWordWrapping.NoWrap;
                    break;

                case TextWrapping.Wrap:
                    textFormat.WordWrapping = CanvasWordWrapping.Wrap;
                    break;

                case TextWrapping.WrapWholeWords:
                    textFormat.WordWrapping = CanvasWordWrapping.WholeWord;
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(TextWrapping));
            }

            _textLayout = new CanvasTextLayout(sender, Text, textFormat, (float)sender.Size.Width, (float)sender.Size.Height);

            args.DrawingSession.DrawGeometry(CanvasGeometry.CreateText(_textLayout), Foreground.ToCanvasBrush(sender), (float)StrokeThickness);
        }

        private void OutlineTextBlock2_Unloaded(object sender, RoutedEventArgs e)
        {
            if (_canvas != null)
            {
                _canvas.RemoveFromVisualTree();
                _canvas = null;
            }
        }
    }
}