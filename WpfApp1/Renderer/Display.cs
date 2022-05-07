using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ShoresOfGold.Logic;

namespace ShoresOfGold.Renderer
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
                return new ImageBrush(new BitmapImage(new Uri("Images/Background2.png", UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush ZombieBrush
        {
            get
            {
                //return Brushes.Black;
                return new ImageBrush(new BitmapImage(new Uri("Images/zombie.png", UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush BulletBrush
        {
            get
            {
                return Brushes.Red;
                //return new ImageBrush(new BitmapImage(new Uri("Images/pirate.png", UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush OpenChestBrush { get 
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/chestopen.png", UriKind.RelativeOrAbsolute)));
            } 
        }
        public Brush ClosedChestBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/chestclosed.png", UriKind.RelativeOrAbsolute)));
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (mapArea.Width > 0 && mapArea.Height > 0 && model != null)
            {
                foreach (var chest in model.Chests)
                {
                    if (chest.Opened == false)
                    {
                        drawingContext.DrawRectangle(ClosedChestBrush, null, new Rect
                            (
                                chest.Center.X, chest.Center.Y,
                                40, 40
                            ));
                    }
                    else 
                    {
                        drawingContext.DrawRectangle(OpenChestBrush, null, new Rect
                            (
                                chest.Center.X, chest.Center.Y,
                                40, 40
                            ));
                    }
                }
                foreach (var e in model.Enemies)
                {
                    if (e.Health>0) 
                    {
                        drawingContext.DrawRectangle(ZombieBrush, /*null*/new Pen(Brushes.Black, 1), new Rect(
                        e.Center.X - e.Width/2, e.Center.Y-e.Height/2,
                        e.Width, e.Height
                        ));
                        
                    }
                }
                if (model.Boss.Health > 0 && model.Enemies.Count > 0) 
                {
                    //drawingContext.DrawRectangle()
                }
                if (model.Player.Health > 0)
                {
                    drawingContext.DrawRectangle(PlayerBrush, new Pen(Brushes.Black, 1), new Rect(
                        model.Player.Center.X - model.Player.Width/2, model.Player.Center.Y - model.Player.Height/2,
                        model.Player.Width, model.Player.Height
                        ));
                    
                }
                /*drawingContext.DrawRectangle(ZombieBrush, null, new Rect(
                    model.Zombie.Center.X, model.Zombie.Center.Y,
                    model.Zombie.Width, model.Zombie.Height
                    ));*/
                foreach (var b in model.Bullets)
                {
                    drawingContext.DrawRectangle(BulletBrush, null, b.BulletRect);
                }
            }
        }
    }
}
