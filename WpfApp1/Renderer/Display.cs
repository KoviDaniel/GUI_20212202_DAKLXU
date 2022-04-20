using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using WpfApp1.Logic;

namespace WpfApp1.Renderer
{
    public class Display : FrameworkElement
    {
        Size mapArea;
        IGameModel model;

        public void SetupSizes(Size mapArea)
        {
            this.mapArea = mapArea;
            this.InvalidateVisual();
        }

        public void SetupModel(IGameModel model)
        {
            this.model = model;
            this.model.Changed += (sender, eventargs) => this.InvalidateVisual();
        }

        public Brush PlayerBrush
        {
            get { return Brushes.Red; } // Img brush lesz
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (mapArea.Width > 0 && mapArea.Height > 0 && model != null)
            {
                drawingContext.DrawRectangle(PlayerBrush, null, new Rect(
                    model.Player.Center.X, model.Player.Center.Y,
                    model.Player.EntityWidth, model.Player.EntityHeight
                    ));
            }
        }
    }
}
