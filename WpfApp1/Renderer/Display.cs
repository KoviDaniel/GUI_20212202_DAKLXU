using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ShoresOfGold.Logic;
using ShoresOfGold.Models;

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
                if (model.Player.HeadLeft)
                {
                    if (model.Player.IsShooting)
                    {
                        return new ImageBrush(new BitmapImage(new Uri("Images/Player/pirate_with_gun.png", UriKind.RelativeOrAbsolute)));

                    }
                    else if (model.Player.IsAttacking)
                    {
                        return new ImageBrush(new BitmapImage(new Uri("Images/Player/pirate_with_sword.png", UriKind.RelativeOrAbsolute)));
                    }
                    else if (model.Player.IsDamaged)
                    {
                        return new ImageBrush(new BitmapImage(new Uri("Images/Player/pirate_damaged.png", UriKind.RelativeOrAbsolute)));
                    }
                    else
                    {
                        return new ImageBrush(new BitmapImage(new Uri("Images/player/pirate_idle.png", UriKind.RelativeOrAbsolute)));
                    }
                }
                else
                {
                    if (model.Player.IsShooting)
                    {
                        return TransformImage("Images/Player/pirate_with_gun.png");
                    }
                    else if (model.Player.IsAttacking)
                    {
                        return TransformImage("Images/Player/pirate_with_sword.png");
                    }
                    else if (model.Player.IsDamaged)
                    {
                        return TransformImage("Images/Player/pirate_damaged.png"); 
                    }
                    else
                    {
                        return TransformImage("Images/Player/pirate_idle.png");
                    }
                }               
            }
        } // DONE

        public Brush ArrowBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/Others/arrow.png", UriKind.RelativeOrAbsolute)));
            }
        } //DONE

        public Brush BulletBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/Others/cannonball.png", UriKind.RelativeOrAbsolute)));
            }
        } //DONE

        #region EndBrushes
        public Brush WinnerBrush 
        {
            get 
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/End/win.png", UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush LoseBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/End/lost.png", UriKind.RelativeOrAbsolute)));
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
                    return new ImageBrush(new BitmapImage(new Uri("Images/Boss/bob_the_boat.png", UriKind.RelativeOrAbsolute)));
                }
                else 
                {
                    if (model.Boss.AttackType == 0) 
                    {
                        return new ImageBrush(new BitmapImage(new Uri("Images/Boss/bobtheboat_half.png", UriKind.RelativeOrAbsolute)));
                    }
                    return new ImageBrush(new BitmapImage(new Uri("Images/Boss/bobtheboat_close.png", UriKind.RelativeOrAbsolute)));
                }
            }
        }
        public Brush BobTheBoatHalfBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/Boss/bobtheboat_half.png", UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush BobTheBoatCloseBrush
        {
            get
            {
                
                return new ImageBrush(new BitmapImage(new Uri("Images/Boss/bobtheboat_close.png", UriKind.RelativeOrAbsolute)));
                
            }
        }
        #endregion

        #region ZombieBrushes
        public Brush ZombieLeftIdleBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/Zombie/zombie_idle.png", UriKind.RelativeOrAbsolute)));                         
            }
        }
        public Brush ZombieLeftAttackBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/Zombie/zombie_attack.png", UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush ZombieLeftDamagedBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/Zombie/zombie_damaged.png", UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush ZombieRightIdleBrush
        {
            get
            {
                return TransformImage("Images/Zombie/zombie_idle.png");
            }
        }
        public Brush ZombieRightAttackBrush
        {
            get
            {
                return TransformImage("Images/Zombie/zombie_attack.png");
            }
        }
        public Brush ZombieRightDamagedBrush
        {
            get
            {
                return TransformImage("Images/Zombie/zombie_damaged.png");
            }
        }
        #endregion

        #region BruteBrushes
        public Brush BruteLeftIdleBrush 
        { 
            get 
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/Brute/brute_idle.png", UriKind.RelativeOrAbsolute)));  
            }
        }
        public Brush BruteLeftAttackBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/Brute/brute_attack.png", UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush BruteLeftDamagedBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/Brute/brute_damaged.png", UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush BruteRightIdleBrush
        {
            get
            {
                return TransformImage("Images/Brute/brute_idle.png");
            }
        }
        public Brush BruteRightAttackBrush
        {
            get
            {
                return TransformImage("Images/Brute/brute_attack.png");
            }
        }
        public Brush BruteRightDamagedBrush
        {
            get
            {
                return TransformImage("Images/Brute/brute_damaged.png");
            }
        }
        #endregion

        #region SniperBrushes
        public Brush SniperLeftIdleBrush 
        { 
            get 
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/Sniper/sniper_idle.png", UriKind.RelativeOrAbsolute)));
            } 
        }
        public Brush SniperLeftAttackBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/Sniper/sniper_attack.png", UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush SniperLeftDamagedBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/Sniper/sniper_damaged.png", UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush SniperRightIdleBrush
        {
            get
            {
                return TransformImage("Images/Sniper/sniper_idle.png");
            }
        }
        public Brush SniperRightAttackBrush
        {
            get
            {
                return TransformImage("Images/Sniper/sniper_attack.png");
            }
        }
        public Brush SniperRightDamagedBrush
        {
            get
            {
                return TransformImage("Images/Sniper/sniper_damaged.png");
            }
        }
        #endregion

        #region ChestBrushes
        public Brush OpenChestHealthBrush 
        {
            get 
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/Chests/chestopen_health_3.png", UriKind.RelativeOrAbsolute)));
            } 
        }
        public Brush OpenChestMeleeBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/Chests/chestopen_melee_3.png", UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush OpenChestSpeedBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/Chests/chestopen_speed_3.png", UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush OpenChestRangeBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/Chests/chestopen_range_3.png", UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush OpenChestStaminaBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/Chests/chestopen_stamina_3.png", UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush OpenChestBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/Chests/chestopen.png", UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush ClosedChestBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/Chests/chestclosed.png", UriKind.RelativeOrAbsolute)));
            }
        }
        #endregion

        #region MapBrushes
        public Brush TopWallBrush_1
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/Maps/back_decor_1.png", UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush BottomWallBrush_1
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/Maps/front_decor_1.png", UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush BackgroundBrush_1
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/Maps/battleground_1.png", UriKind.RelativeOrAbsolute)));
            }
        }

        public Brush TopWallBrush_2
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/Maps/back_decor_2.png", UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush BottomWallBrush_2
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/Maps/front_decor_2.png", UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush BackgroundBrush_2
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/Maps/battleground_2.png", UriKind.RelativeOrAbsolute)));
            }
        }

        public Brush TopWallBrush_3
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/Maps/back_decor_3.png", UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush BottomWallBrush_3
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/Maps/front_decor_3.png", UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush BackgroundBrush_3
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/Maps/battleground_3.png", UriKind.RelativeOrAbsolute)));
            }
        }

        public Brush TopWallBrush_4
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/Maps/back_decor_4.png", UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush BottomWallBrush_4
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/Maps/front_decor_4.png", UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush BackgroundBrush_4
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri("Images/Maps/battleground_4.png", UriKind.RelativeOrAbsolute)));
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

                    # region MAP DRAW
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
                    #endregion

                    #region CHEST DRAW
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
                            else if (chest.buff == Models.Buffs.RangeDamageBuff)
                            {
                                drawingContext.DrawRectangle(OpenChestRangeBrush, null, new Rect
                                (
                                    chest.Center.X - chest.Width / 2, chest.Center.Y - chest.Height / 2,
                                    chest.Width, chest.Height
                                ));
                            }
                            else if (chest.buff == Models.Buffs.StaminaBuff)
                            {
                                drawingContext.DrawRectangle(OpenChestStaminaBrush, null, new Rect
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
                    #endregion

                    #region ENEMY DRAW
                    foreach (var e in model.Enemies)
                    {
                        if (e.Health > 0)
                        {
                            if (e.PlayerIsOnLeft)
                            {
                                if (e is Brute)
                                {
                                    if (e.IsAttacking)
                                    {
                                        // ATTACKING BRUSH
                                        drawingContext.DrawRectangle(BruteLeftAttackBrush, null/*new Pen(Brushes.Black, 1)*/, new Rect(
                                            e.Center.X - e.Width / 2, e.Center.Y - e.Height / 2, e.Width, e.Height));
                                    }
                                    else if (e.IsDamaged)
                                    {
                                        // DAMAGED BRUSH
                                        drawingContext.DrawRectangle(BruteLeftDamagedBrush, null/*new Pen(Brushes.Black, 1)*/, new Rect(
                                            e.Center.X - e.Width / 2, e.Center.Y - e.Height / 2, e.Width, e.Height));
                                    }
                                    else
                                    {
                                        // IDLE BRUSH
                                        drawingContext.DrawRectangle(BruteLeftIdleBrush, null/*new Pen(Brushes.Black, 1)*/, new Rect(
                                            e.Center.X - e.Width / 2, e.Center.Y - e.Height / 2, e.Width, e.Height));
                                    }
                                }
                                else if (e is Zombie)
                                {
                                    if (e.IsAttacking)
                                    {
                                        // ATTACKING BRUSH
                                        drawingContext.DrawRectangle(ZombieLeftAttackBrush, null/*new Pen(Brushes.Black, 1)*/, new Rect(
                                            e.Center.X - e.Width / 2, e.Center.Y - e.Height / 2, e.Width, e.Height));
                                    }
                                    else if (e.IsDamaged)
                                    {
                                        // DAMAGED BRUSH
                                        drawingContext.DrawRectangle(ZombieLeftDamagedBrush, null/*new Pen(Brushes.Black, 1)*/, new Rect(
                                            e.Center.X - e.Width / 2, e.Center.Y - e.Height / 2, e.Width, e.Height));
                                    }
                                    else
                                    {
                                        // IDLE BRUSH
                                        drawingContext.DrawRectangle(ZombieLeftIdleBrush, null/*new Pen(Brushes.Black, 1)*/, new Rect(
                                            e.Center.X - e.Width / 2, e.Center.Y - e.Height / 2, e.Width, e.Height));
                                    }
                                }
                                else if (e is Sniper)
                                {
                                    if (e.IsAttacking)
                                    {
                                        // ATTACKING BRUSH
                                        drawingContext.DrawRectangle(SniperLeftAttackBrush, null/*new Pen(Brushes.Black, 1)*/, new Rect(
                                            e.Center.X - e.Width / 2, e.Center.Y - e.Height / 2, e.Width, e.Height));
                                    }
                                    else if (e.IsDamaged)
                                    {
                                        // DAMAGED BRUSH
                                        drawingContext.DrawRectangle(SniperLeftDamagedBrush, null/*new Pen(Brushes.Black, 1)*/, new Rect(
                                            e.Center.X - e.Width / 2, e.Center.Y - e.Height / 2, e.Width, e.Height));
                                    }
                                    else
                                    {
                                        // IDLE BRUSH
                                        drawingContext.DrawRectangle(SniperLeftIdleBrush, null/*new Pen(Brushes.Black, 1)*/, new Rect(
                                            e.Center.X - e.Width / 2, e.Center.Y - e.Height / 2, e.Width, e.Height));
                                    }
                                }
                            }
                            else
                            {
                                if (e is Brute)
                                {
                                    if (e.IsAttacking)
                                    {
                                        // ATTACKING BRUSH
                                        drawingContext.DrawRectangle(BruteRightAttackBrush, null/*new Pen(Brushes.Black, 1)*/, new Rect(
                                            e.Center.X - e.Width / 2, e.Center.Y - e.Height / 2, e.Width, e.Height));
                                    }
                                    else if (e.IsDamaged)
                                    {
                                        // DAMAGED BRUSH
                                        drawingContext.DrawRectangle(BruteRightDamagedBrush, null/*new Pen(Brushes.Black, 1)*/, new Rect(
                                            e.Center.X - e.Width / 2, e.Center.Y - e.Height / 2, e.Width, e.Height));
                                    }
                                    else
                                    {
                                        // IDLE BRUSH
                                        drawingContext.DrawRectangle(BruteRightIdleBrush, null/*new Pen(Brushes.Black, 1)*/, new Rect(
                                            e.Center.X - e.Width / 2, e.Center.Y - e.Height / 2, e.Width, e.Height));
                                    }
                                }
                                else if (e is Zombie)
                                {
                                    if (e.IsAttacking)
                                    {
                                        // ATTACKING BRUSH
                                        drawingContext.DrawRectangle(ZombieRightAttackBrush, null/*new Pen(Brushes.Black, 1)*/, new Rect(
                                            e.Center.X - e.Width / 2, e.Center.Y - e.Height / 2, e.Width, e.Height));
                                    }
                                    else if (e.IsDamaged)
                                    {
                                        // DAMAGED BRUSH
                                        drawingContext.DrawRectangle(ZombieRightDamagedBrush, null/*new Pen(Brushes.Black, 1)*/, new Rect(
                                            e.Center.X - e.Width / 2, e.Center.Y - e.Height / 2, e.Width, e.Height));
                                    }
                                    else
                                    {
                                        // IDLE BRUSH
                                        drawingContext.DrawRectangle(ZombieRightIdleBrush, null/*new Pen(Brushes.Black, 1)*/, new Rect(
                                            e.Center.X - e.Width / 2, e.Center.Y - e.Height / 2, e.Width, e.Height));
                                    }
                                }
                                else if (e is Sniper)
                                {
                                    if (e.IsAttacking)
                                    {
                                        // ATTACKING BRUSH
                                        drawingContext.DrawRectangle(SniperRightAttackBrush, null/*new Pen(Brushes.Black, 1)*/, new Rect(
                                            e.Center.X - e.Width / 2, e.Center.Y - e.Height / 2, e.Width, e.Height));
                                    }
                                    else if (e.IsDamaged)
                                    {
                                        // DAMAGED BRUSH
                                        drawingContext.DrawRectangle(SniperRightDamagedBrush, null/*new Pen(Brushes.Black, 1)*/, new Rect(
                                            e.Center.X - e.Width / 2, e.Center.Y - e.Height / 2, e.Width, e.Height));
                                    }
                                    else
                                    {
                                        // IDLE BRUSH
                                        drawingContext.DrawRectangle(SniperRightIdleBrush, null/*new Pen(Brushes.Black, 1)*/, new Rect(
                                            e.Center.X - e.Width / 2, e.Center.Y - e.Height / 2, e.Width, e.Height));
                                    }
                                }
                            }                       
                        }
                    }
                    #endregion

                    #region BOSS DRAW
                    if (model.Boss.Health > 0 && model.Enemies.Count <= 0 && model.MapNumber == 4)
                    {
                        if (model.Boss.AttackType == -1)
                        {
                            drawingContext.DrawRectangle(BobTheBoatBrush,null, new Rect
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
                    }
                    #endregion

                    #region PLAYER DRAW
                    if (model.Player.Health > 0)
                    {
                        drawingContext.DrawRectangle(PlayerBrush, null, new Rect(
                            model.Player.Center.X - model.Player.Width / 2, model.Player.Center.Y - model.Player.Height / 2,
                            model.Player.Width, model.Player.Height
                            ));
                    }
                    #endregion

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

                    FormattedText bhp = new FormattedText("Boss HP: " + model.Boss.Health + "/" + model.Boss.MAX_HEALTH, System.Globalization.CultureInfo.CurrentCulture,
                       FlowDirection.LeftToRight, new Typeface(new FontFamily("Arial"), FontStyles.Normal,
                       FontWeights.Normal, FontStretches.Normal), 24, Brushes.Red, 10);

                    drawingContext.DrawText(hp, new Point(100, 50));
                    drawingContext.DrawText(stamina, new Point(100, 100));
                    if (model.Boss.Appear) 
                        drawingContext.DrawText(bhp, new Point(mapArea.Width - 250, 50));
                }

                #region GAME END
                else if (model.Player.Health > 0 && model.Boss.Health <= 0)
                {
                    drawingContext.DrawRectangle(WinnerBrush, null, new Rect(0, 0, mapArea.Width, mapArea.Height));
                }
                else 
                {
                    drawingContext.DrawRectangle(LoseBrush, null, new Rect(0, 0, mapArea.Width, mapArea.Height));
                }
                #endregion
            }
        }

        private ImageBrush TransformImage(string path)
        {
            var picture = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));
            var transform = new ScaleTransform(-1, 1, 0, 0);
            var tb = new TransformedBitmap();
            tb.BeginInit();
            tb.Source = picture;
            tb.Transform = transform;
            tb.EndInit();
            return new ImageBrush(tb);
        }
    }
}
