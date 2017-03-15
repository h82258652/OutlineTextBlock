using System;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.Graphics.Canvas.Brushes;
using Microsoft.Graphics.Canvas.Geometry;
using Microsoft.Graphics.Canvas.Text;
using Microsoft.Graphics.Canvas.UI.Xaml;

namespace Demo.Uwp
{
    public class OutlineTextBlock2 : Control
    {
        private CanvasControl _canvas;

        public OutlineTextBlock2()
        {
            DefaultStyleKey = typeof(OutlineTextBlock2);
            Unloaded += OutlineTextBlock2_Unloaded;
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _canvas = (CanvasControl)GetTemplateChild("PART_Canvas");
            _canvas.Draw += Canvas_Draw;
        }

        private CanvasTextLayout _textLayout;

        public string Text
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public double StrokeThickness
        {
            get
            {
            }
            set
            { }
        }

        private void Canvas_Draw(CanvasControl sender, CanvasDrawEventArgs args)
        {
            new Compositor().

            var textFormat = new CanvasTextFormat()
            {
                FontSize = (float)FontSize,
                FontFamily = FontFamily.Source,
                FontStretch = FontStretch,
                FontWeight = FontWeight,
                FontStyle = FontStyle
            };

            _textLayout = new CanvasTextLayout(sender, Text, textFormat, (float)sender.Size.Width, (float)sender.Size.Height);

            //var canvasSolidColorBrush = new CanvasSolidColorBrush(sender, Color.FromArgb(1, 1, 1, 1));

            //args.DrawingSession.DrawGeometry(CanvasGeometry.CreateText(_textLayout), Colors.Aqua , StrokeThickness , new CanvasStrokeStyle()
            //{
            //});
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