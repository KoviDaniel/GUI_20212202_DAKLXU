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

        #region mapBrushes
        public Brush TopWallBrush_1
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/back_decor_1.png", UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush BottomWallBrush_1
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/front_decor_1.png", UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush BackgroundBrush_1
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/battleground_1.png", UriKind.RelativeOrAbsolute)));
            }
        }

        public Brush TopWallBrush_2
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/back_decor_2.png", UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush BottomWallBrush_2
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/front_decor_2.png", UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush BackgroundBrush_2
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/battleground_2.png", UriKind.RelativeOrAbsolute)));
            }
        }

        public Brush TopWallBrush_3
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/back_decor_3.png", UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush BottomWallBrush_3
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/front_decor_3.png", UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush BackgroundBrush_3
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/battleground_3.png", UriKind.RelativeOrAbsolute)));
            }
        }

        public Brush TopWallBrush_4
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/back_decor_4.png", UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush BottomWallBrush_4
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/front_decor_4.png", UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush BackgroundBrush_4
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/battleground_4.png", UriKind.RelativeOrAbsolute)));
            }
        }
        #endregion

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (mapArea.Width > 0 && mapArea.Height > 0 && model != null)
            {
                if (model.MapNumber == 1)
                {
                    drawingContext.DrawRectangle(BackgroundBrush_1, null, new Rect(mapArea));
                    drawingContext.DrawGeometry(TopWallBrush_1, null, model.TopWall.Area);
                    drawingContext.DrawGeometry(BottomWallBrush_1, null, model.BottomWall.Area);
                }
                else if (model.MapNumber == 2)
                {
                    drawingContext.DrawGeometry(TopWallBrush_2, null, model.TopWall.Area);
                    drawingContext.DrawRectangle(BackgroundBrush_2, null, new Rect(mapArea));
                    drawingContext.DrawGeometry(BottomWallBrush_2, null, model.BottomWall.Area);
                }
                else if (model.MapNumber == 3)
                {
                    drawingContext.DrawRectangle(BackgroundBrush_3, null, new Rect(mapArea));
                    drawingContext.DrawGeometry(TopWallBrush_3, null, model.TopWall.Area);
                    drawingContext.DrawGeometry(BottomWallBrush_3, null, model.BottomWall.Area);
                }
                else if (model.MapNumber == 4)
                {
                    drawingContext.DrawRectangle(BackgroundBrush_4, null, new Rect(mapArea));
                    drawingContext.DrawGeometry(TopWallBrush_4, null, model.TopWall.Area);
                    drawingContext.DrawGeometry(BottomWallBrush_4, null, model.BottomWall.Area);
                }

                drawingContext.DrawRectangle(PlayerBrush, null,
                     new Rect(model.Player.Center.X, model.Player.Center.Y, model.Player.Width, model.Player.Height));
            }
        }
    }
}
