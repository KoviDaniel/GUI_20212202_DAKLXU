﻿using ShoresOfGold.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ShoresOfGold.Logic;

namespace ShoresOfGold.Models
{
    public class Player : Entity
    {
        private Size mapArea;
        public int Gold { get; set; }

        public double UpperBound { get; set; }
        public double LowerBound { get; set; }
        public double LeftBound { get; set; }
        public double RightBound { get; set; }

        public int MeleeDamage { get; set; }
        public int RangeDamage { get; set; }
        public List<Bullet> Bullets;
        public int MAX_HEALTH { get; set; }
        public int MAX_STAMINA { get; set; }
        public Player(Size mapArea, double upperBound, double lowerBound)
        {
            this.mapArea = mapArea;
            MAX_HEALTH = 100;
            Health = 100;
            MAX_STAMINA = 100;
            Stamina = 100;
            Gold = 0;
            Width = 70;
            Height = 86;
            Center = new System.Drawing.Point(10+Width/2, (int)mapArea.Height / 2);
            Speed = new Vector(3, 3);
            Width = 70;
            Height = 86;

            UpperBound = upperBound;
            LowerBound = lowerBound;
            LeftBound = 0;
            RightBound = mapArea.Width;
            MeleeDamage = 40;
            RangeDamage = 30;
            Bullets = new List<Bullet>();
            //PlayerRect = new Rect(this.Center.X, this.Center.Y, this.Width, this.Height);
        }
        public Rect PlayerRect { get { return new Rect(this.Center.X-this.Width/2, this.Center.Y-this.Height/2, this.Width, this.Height); } }

        public void Move(Controls control)
        {
            if (control == Controls.Up && Center.Y + Height > UpperBound)
            {
                Center = new System.Drawing.Point(Center.X, Center.Y - (int)Speed.Y);
            }
            else if (control == Controls.Down && Center.Y + Height < LowerBound)
            {
                Center = new System.Drawing.Point(Center.X, Center.Y + (int)Speed.Y);
            }
            else if (control == Controls.Left && Center.X > LeftBound)
            {
                Center = new System.Drawing.Point(Center.X - (int)Speed.X, Center.Y);
            }
            else if (control == Controls.Right && Center.X + Width < RightBound)
            {
                Center = new System.Drawing.Point(Center.X + (int)Speed.X, Center.Y);
            }
            
        }
        public void Interact(Controls control ,List<Chest> chests) 
        {
            foreach (var c in chests)
            {
                if (DistanceCalculator(c.Center) <= 80) 
                {
                    c.Open(this);
                }
            }
        }
        public void MeleeAttack(List<Enemy> enemies, Boss boss) 
        {
            if (this.Health > 0 && this.Stamina-20 >= 0)
            {
                this.Stamina -= 20;
                foreach (var e in enemies)
                {
                    if (DistanceCalculator(e.Center) <= 130 && Health > 0)
                    {
                        e.GetDamage(this.MeleeDamage);
                    }
                }
                if (DistanceCalculator(boss.Center) <= 350) 
                {
                    boss.GetDamage(this.MeleeDamage);
                }
            }
        }
        public void RangeAttack(List<Enemy> enemies, Point target)
        {
            if (this.Health>0 && this.Stamina-30>=0) 
            {
                this.Stamina -= 30;
                Shoot(target);
            }
           // BulletLife(enemies);
        }
        private void Shoot(Point target) 
        {
            //System.Drawing.Point dTarget = new System.Drawing.Point();
            //dTarget.X = (int)target.X;
            //dTarget.Y = (int)target.Y;
            Bullets.Add(new Bullet(this.Center, target));
        }
        public void BulletLife(List<Enemy> enemies) 
        {
            List<Bullet> removing = new List<Bullet>();
            foreach (var e in enemies)
            {
                foreach (var b in Bullets)
                {
                    if (b.Alive = false || b.Center.X <= 0 || b.Center.X >= mapArea.Width
                    || b.Center.Y <= 0 || b.Center.Y >= mapArea.Height)
                    {
                        removing.Add(b);
                    }
                    else
                    {
                        b.Moving(); // moving
                                    //HitDetection
                        if (b.BulletRect.IntersectsWith(e.EnemyRect))
                        {
                            e.GetDamage(this.RangeDamage);
                            //this.bullets.Remove(b);
                            b.Alive = false;
                            removing.Add(b);
                        }
                    }
                }
                foreach (var r in removing)
                {
                    Bullets.Remove(r);
                }
            }
        }

        private double DistanceCalculator(System.Drawing.Point center) 
        {
            return Math.Sqrt(Math.Pow((center.X-this.Center.X),2)+Math.Pow((center.Y-this.Center.Y),2));
        }


        private int restoreRate = 0;
        public void Restoration() 
        {
            if (restoreRate >= 50)
            {
                if (this.Health > 0 && this.Health + 5 <= MAX_HEALTH) this.Health += 5;
                if (this.Stamina +20 <= this.MAX_STAMINA) this.Stamina += 20;
                restoreRate = 0;
            }
            restoreRate++;
        }

        public void GetDamage(double damage) 
        {
            this.Health -= damage;
            if (this.Health <= 0) { /*the player dies*/}
        }
    }
}
