using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
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
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/pirate.png", UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush TopWallBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/back_decor.png", UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush BottomWallBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/front_decor.png", UriKind.RelativeOrAbsolute)));
            }
        }
        
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (mapArea.Width > 0 && mapArea.Height > 0 && model != null)
            {
                drawingContext.DrawGeometry(
                    TopWallBrush, new Pen(Brushes.Black, 1), model.TopWall.Area);
                drawingContext.DrawGeometry(
                    BottomWallBrush, new Pen(Brushes.Black, 1), model.BottomWall.Area);

                drawingContext.DrawRectangle(PlayerBrush, new Pen(Brushes.Black, 1),
                     new Rect(model.Player.Center.X, model.Player.Center.Y, model.Player.Width, model.Player.Height));
            }
        }
    }
}
