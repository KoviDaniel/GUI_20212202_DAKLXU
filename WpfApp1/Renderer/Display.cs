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
        AnimationManager zombieAnimationManager;

        public void SetupSizes(Size mapArea)
        {
            this.mapArea = mapArea;
            this.InvalidateVisual();
        }
        public void SetupModel(IGameModel model)
        {
            this.model = model;
            this.model.Changed += (sender, eventargs) => this.InvalidateVisual();
            zombieAnimationManager= new AnimationManager();
            zombieAnimationManager.Append("Images/zombie/right_idle/"); //0
            zombieAnimationManager.Append("Images/zombie/right_move/"); //1
            zombieAnimationManager.Append("Images/zombie/right_attack/"); //2
            zombieAnimationManager.Append("Images/zombie/right_die/"); //3
        }

        public Brush PlayerBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/pirate.png", UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush ArrowBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/arrow.png", UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush BulletBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/cannonball.png", UriKind.RelativeOrAbsolute)));
            }
        }

        #region EndBrushes
        public Brush WinnerBrush 
        {
            get 
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/end/win.png", UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush LoseBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/end/lost.png", UriKind.RelativeOrAbsolute)));
            }
        }
        #endregion

        #region BobBrushes
        public Brush BobTheBoatBrush
        {
            get
            {
                if (model.Boss.AttackType == -1)
                {
                    return new ImageBrush(new BitmapImage(new Uri("Images/bob_the_boat.png", UriKind.RelativeOrAbsolute)));
                }
                else 
                {
                    if (model.Boss.AttackType == 0) 
                    {
                        return new ImageBrush(new BitmapImage(new Uri("Images/bobtheboat_half.png", UriKind.RelativeOrAbsolute)));
                    }
                    return new ImageBrush(new BitmapImage(new Uri("Images/bobtheboat_close.png", UriKind.RelativeOrAbsolute)));
                }
            }
        }
        public Brush BobTheBoatHalfBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/bobtheboat_half.png", UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush BobTheBoatCloseBrush
        {
            get
            {
                
                return new ImageBrush(new BitmapImage(new Uri("Images/bobtheboat_close.png", UriKind.RelativeOrAbsolute)));
                
            }
        }
        #endregion


        public Brush ZombieBrush
        {
            get
            {
                //if (model.Zombie.PlayerIsOnRight)
                //{
                //    if (model.Zombie.IsMoving && !model.Zombie.IsAttacking)
                //    {
                //        return new ImageBrush(zombieAnimationManager.GetNextofThis(1));
                //    }
                //    else if (!model.Zombie.IsMoving && model.Zombie.IsAttacking)
                //    {
                //         return new ImageBrush(zombieAnimationManager.GetNextofThis(3));            
                //    }
                //    else
                //    {
                //        return new ImageBrush(zombieAnimationManager.GetNextofThis(0));
                //    }
                //}
                //else if (model.Zombie.PlayerIsOnLeft)
                //{
                //    if (model.Zombie.IsMoving && !model.Zombie.IsAttacking)
                //    {
                //        var picture = zombieAnimationManager.GetNextofThis(1);
                //        var transform = new ScaleTransform(-1, 1, 0, 0);
                //        var tb = new TransformedBitmap();
                //        tb.BeginInit();
                //        tb.Source = picture;
                //        tb.Transform = transform;
                //        tb.EndInit();
                //        return new ImageBrush(tb);
                //    }
                //    else if (!model.Zombie.IsMoving && model.Zombie.IsAttacking)
                //    {
                //        var picture = zombieAnimationManager.GetNextofThis(3);
                //        var transform = new ScaleTransform(-1, 1, 0, 0);
                //        var tb = new TransformedBitmap();
                //        tb.BeginInit();
                //        tb.Source = picture;
                //        tb.Transform = transform;
                //        tb.EndInit();
                //        return new ImageBrush(tb);
                //    }
                //    else
                //    {
                //        var picture = zombieAnimationManager.GetNextofThis(0);
                //        var transform = new ScaleTransform(-1, 1, 0, 0);
                //        var tb = new TransformedBitmap();
                //        tb.BeginInit();
                //        tb.Source = picture;
                //        tb.Transform = transform;
                //        tb.EndInit();
                //        return new ImageBrush(tb);
                //    }                
                //}
                if (model.Zombie.PlayerIsOnRight)
                {
                    return new ImageBrush(zombieAnimationManager.GetNextofThis(0));                   
                }
                else if (model.Zombie.PlayerIsOnLeft)
                {
                    var picture = zombieAnimationManager.GetNextofThis(0);
                    var transform = new ScaleTransform(-1, 1, 0, 0);
                    var tb = new TransformedBitmap();
                    tb.BeginInit();
                    tb.Source = picture;
                    tb.Transform = transform;
                    tb.EndInit();
                    return new ImageBrush(tb);
                }
                return new ImageBrush(zombieAnimationManager.GetNextofThis(0));             
            }
        }
        
        #region ChestBrushes
        public Brush OpenChestHealthBrush { get 
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/chests/chestopen_health_3.png", UriKind.RelativeOrAbsolute)));
            } 
        }
        public Brush OpenChestMeleeBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/chests/chestopen_melee_3.png", UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush OpenChestSpeedBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/chests/chestopen_speed_3.png", UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush OpenChestBrush
        {
            get
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
        #endregion

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
            model.LoadNexMap();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (mapArea.Width > 0 && mapArea.Height > 0 && model != null)
            {
                if (model.Player.Health > 0 && model.Boss.Health > 0)
                {
                    if (model.Player.Center.X + model.Player.Width == mapArea.Width + 1 && model.MapNumber < 4 && model.Enemies.Count <= 0)
                    {
                        LoadNextMap();
                    }

                    //MAP DRAW
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

                    //CHEST DRAW
                    foreach (var chest in model.Chests)
                    {
                        if (chest.Opened == false)
                        {
                            drawingContext.DrawRectangle(ClosedChestBrush, null, new Rect
                                (
                                    chest.Center.X - chest.Width / 2, chest.Center.Y - chest.Height / 2,
                                    chest.Width, chest.Height
                                ));
                        }
                        else
                        {
                            if (chest.buff == Models.Buffs.HealthBuff)
                            {
                                drawingContext.DrawRectangle(OpenChestHealthBrush, null, new Rect
                                (
                                    chest.Center.X - chest.Width / 2, chest.Center.Y - chest.Height / 2,
                                    chest.Width, chest.Height
                                ));
                            }
                            else if (chest.buff == Models.Buffs.MeleeDamageBuff)
                            {
                                drawingContext.DrawRectangle(OpenChestMeleeBrush, null, new Rect
                                (
                                    chest.Center.X - chest.Width / 2, chest.Center.Y - chest.Height / 2,
                                    chest.Width, chest.Height
                                ));
                            }
                            else if (chest.buff == Models.Buffs.SpeedBuff)
                            {
                                drawingContext.DrawRectangle(OpenChestSpeedBrush, null, new Rect
                                (
                                    chest.Center.X - chest.Width / 2, chest.Center.Y - chest.Height / 2,
                                    chest.Width, chest.Height
                                ));
                            }
                            else
                            {
                                drawingContext.DrawRectangle(OpenChestBrush, null, new Rect
                                    (
                                        chest.Center.X - chest.Width / 2, chest.Center.Y - chest.Height / 2,
                                        chest.Width, chest.Height
                                    ));
                            }
                        }
                    }

                    //ENEMY DRAW
                    foreach (var e in model.Enemies)
                    {
                        if (e.Health > 0)
                        {
                            drawingContext.DrawRectangle(ZombieBrush, null/*new Pen(Brushes.Black, 1)*/, new Rect(
                            e.Center.X - e.Width / 2, e.Center.Y - e.Height / 2,
                            e.Width, e.Height
                            ));
                        }
                    }


                    //BOSS DRAW
                    if (model.Boss.Health > 0 && model.Enemies.Count <= 0 && model.MapNumber == 4)
                    {
                        if (model.Boss.AttackType == -1)
                        {
                            drawingContext.DrawRectangle(BobTheBoatBrush, /*new Pen(Brushes.Black, 1)*/null, new Rect
                                (
                                    model.Boss.Center.X - model.Boss.Width / 2, model.Boss.Center.Y - model.Boss.Height / 2,
                                    model.Boss.Width, model.Boss.Height
                                ));
                        }
                        if (model.Boss.AttackType == 0)
                        {
                            drawingContext.DrawRectangle(BobTheBoatHalfBrush, /*new Pen(Brushes.Black, 1)*/null, new Rect
                                (
                                    model.Boss.Center.X - model.Boss.Width / 2, model.Boss.Center.Y - model.Boss.Height / 2,
                                    model.Boss.Width, model.Boss.Height
                                ));
                        }
                        if (model.Boss.AttackType == 1)
                        {
                            drawingContext.DrawRectangle(BobTheBoatCloseBrush, /*new Pen(Brushes.Black, 1)*/null, new Rect
                                (
                                    model.Boss.Center.X - model.Boss.Width / 2, model.Boss.Center.Y - model.Boss.Height / 2,
                                    model.Boss.Width, model.Boss.Height
                                ));
                        }
                        // drawingContext.DrawEllipse(null, new Pen(Brushes.Red, 2), new Point(model.Boss.Center.X, model.Boss.Center.Y), model.Boss.CloseAttackSize, model.Boss.CloseAttackSize);
                    }

                    //PLAYER DRAW
                    if (model.Player.Health > 0)
                    {
                        drawingContext.DrawRectangle(PlayerBrush, new Pen(Brushes.Black, 1), new Rect(
                            model.Player.Center.X - model.Player.Width / 2, model.Player.Center.Y - model.Player.Height / 2,
                            model.Player.Width, model.Player.Height
                            ));
                    }


                    //BULLET DRAW
                    foreach (var b in model.Bullets)
                    {
                        drawingContext.DrawRectangle(BulletBrush, null, b.BulletRect);
                    }
                    //NEXT MAP ARROW DRAW
                    if (model.Enemies.Count == 0 && model.MapNumber < 4)
                    {
                        drawingContext.DrawRectangle(ArrowBrush, null, new Rect(
                                mapArea.Width - 75, mapArea.Height / 2, 50, 50
                            ));
                    }
                    FormattedText hp = new FormattedText("HP: " + model.Player.Health + "/" + model.Player.MAX_HEALTH, System.Globalization.CultureInfo.CurrentCulture,
                       FlowDirection.LeftToRight, new Typeface(new FontFamily("Arial"), FontStyles.Normal,
                       FontWeights.Normal, FontStretches.Normal), 24, Brushes.Red, 10);
                    FormattedText stamina = new FormattedText("SM: " + model.Player.Stamina + "/" + model.Player.MAX_STAMINA, System.Globalization.CultureInfo.CurrentCulture,
                       FlowDirection.LeftToRight, new Typeface(new FontFamily("Arial"), FontStyles.Normal,
                       FontWeights.Normal, FontStretches.Normal), 24, Brushes.Yellow, 10);
                    drawingContext.DrawText(hp, new Point(100, 50));
                    drawingContext.DrawText(stamina, new Point(100, 100));
                }
                else if (model.Player.Health > 0 && model.Boss.Health <= 0)
                {
                    drawingContext.DrawRectangle(WinnerBrush, null, new Rect(0, 0, mapArea.Width, mapArea.Height));
                }
                else 
                {
                    drawingContext.DrawRectangle(LoseBrush, null, new Rect(0, 0, mapArea.Width, mapArea.Height));
                }
            }
        }
    }
}
