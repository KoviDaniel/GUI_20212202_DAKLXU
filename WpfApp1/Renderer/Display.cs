using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WpfApp1.Renderer
{
    public class Display : FrameworkElement
    {
        Size windowSize;

        public void SetupSizes(Size windowSize)
        {
            this.windowSize = windowSize;
            this.InvalidateVisual();
        }

        public void SetupModel()
        {
            
        }

        public Brush PlayerBrush
        {
            get { return Brushes.Red; } // Img brush lesz
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (windowSize.Width > 0 && windowSize.Height > 0)
            {
                drawingContext.DrawRectangle(PlayerBrush, null, new Rect(windowSize.Width / 2, windowSize.Height / 2, 25, 25));
            }
        }
    }
}
