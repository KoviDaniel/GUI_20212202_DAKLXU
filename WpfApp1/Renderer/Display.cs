﻿using System;
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
        public Brush ArrowBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/arrow.png", UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush BobTheBoatBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/bob_the_boat.png", UriKind.RelativeOrAbsolute)));
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
                //return Brushes.Red;
                return new ImageBrush(new BitmapImage(new Uri("Images/cannonball.png", UriKind.RelativeOrAbsolute)));
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

        public void LoadNextMap()
        {
            model.MapNumber += 1;
            model.Player.Center = new System.Drawing.Point(0, (int)mapArea.Height / 2);
            model.SetupSizes(mapArea);
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (mapArea.Width > 0 && mapArea.Height > 0 && model != null)
            {
                if (model.Player.Center.X + model.Player.Width == mapArea.Width + 1 && model.MapNumber < 4 && model.Enemies.Count <= 0)
                {
                    LoadNextMap();
                }

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
                /*if (model.Boss.Health > 0 && model.Enemies.Count <= 0) 
                {
                    drawingContext.DrawRectangle(BobTheBoatBrush, new Pen(Brushes.Black, 1), new Rect
                        (
                            model.Boss.Center.X-model.Boss.Width/2, model.Boss.Center.Y-model.Boss.Height/2,
                            model.Boss.Width, model.Boss.Height
                        ));
                }*/
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

                if (model.Enemies.Count == 0 && model.MapNumber < 4) 
                {
                    drawingContext.DrawRectangle(ArrowBrush, null, new Rect(
                            mapArea.Width-75,mapArea.Height/2, 50, 50
                        ));
                }
            }
        }
    }
}
