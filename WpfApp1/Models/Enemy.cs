using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ShoresOfGold.Models;

namespace ShoresOfGold.Models
{
    public class Enemy : Entity
    {
        
        #region OlderIdea
        public double Power { get; set; }
        

        public Enemy()
        {
            
        }

        public void Move() // idk yet
        {
            
        }

        public void FollowPlayer(Player player, Size mapArea) // TODO
        {
            var enemyPos = this.Center;
            var playerPos = player.Center;

            var upperLimit = player.Center.Y; //- (player.Height / 2);
            var lowerLimit = player.Center.Y; //+ (player.Height / 2);
            var leftLimit = player.Center.X; //- (player.Width / 2);
            var rightlimit = player.Center.X; //+ (player.Width / 2);
            
            if (((playerPos.X >= leftLimit && playerPos.X <= rightlimit) && // Addig koveti amig utesi rangen belul nincs a player
                (playerPos.Y >= upperLimit && playerPos.Y <= lowerLimit))) // TODO: korrigalas
            {
                //if (enemyPos.Y < playerPos.Y) // felette
                //{
                //    Center = new System.Drawing.Point(enemyPos.X, enemyPos.Y + (int)Speed.Y);
                //    //enemyPos.Y = this.Center.Y + (int)Speed.Y;
                //}
                if (enemyPos.X < playerPos.X && enemyPos.Y < playerPos.Y) // bal fent
                {
                    Center = new System.Drawing.Point(enemyPos.X + (int)Speed.X, enemyPos.Y + (int)Speed.Y);
                    //enemyPos.X = this.Center.X + (int)Speed.X;
                    //enemyPos.Y = this.Center.Y + (int)Speed.Y;
                }
                else if(enemyPos.X > playerPos.X && enemyPos.Y < playerPos.Y) // jobb fent
                {
                    Center = new System.Drawing.Point(enemyPos.X - (int)Speed.X, enemyPos.Y + (int)Speed.Y);
                    //enemyPos.X = this.Center.X - (int)Speed.X;
                    //enemyPos.Y = this.Center.Y + (int)Speed.Y;
                }
                //else if(enemyPos.X < playerPos.X) // balra
                //{
                //    Center = new System.Drawing.Point(enemyPos.X + (int)Speed.X, enemyPos.Y);
                //    //enemyPos.X = this.Center.X + (int)Speed.X;
                //}
                //else if(enemyPos.X > playerPos.X) // jobbra
                //{
                //    Center = new System.Drawing.Point(enemyPos.X - (int)Speed.X, enemyPos.Y);
                //    //enemyPos.X = this.Center.X - (int)Speed.X;
                //}
                else if(enemyPos.X < playerPos.X && enemyPos.Y > playerPos.Y) // bal lent
                {
                    Center = new System.Drawing.Point(enemyPos.X + (int)Speed.X, enemyPos.Y - (int)Speed.Y);
                    //enemyPos.X = this.Center.X + (int)Speed.X;
                    //enemyPos.Y = this.Center.Y - (int)Speed.Y;
                }
                else if(enemyPos.X > playerPos.X && enemyPos.Y > playerPos.Y) // jobb lent
                {
                    Center = new System.Drawing.Point(enemyPos.X - (int)Speed.X, enemyPos.Y - (int)Speed.Y);
                    //enemyPos.X = this.Center.X - (int)Speed.X;
                    //enemyPos.Y = this.Center.Y - (int)Speed.Y;
                }
                //else if(enemyPos.Y > playerPos.Y) // alatta
                //{
                //    Center = new System.Drawing.Point(enemyPos.X, enemyPos.Y - (int)Speed.Y);
                //    //enemyPos.Y = this.Center.Y - (int)Speed.Y;
                //}
            }
        }

        #endregion

        #region newMovementIdea
        static Random r = new Random();
        public Enemy(Size mapArea,Player player)
        {
            this.player = player;
            Center = new System.Drawing.Point(r.Next(0, (int)mapArea.Width + 1) - 25, r.Next(0, (int)mapArea.Height + 1) - 25);
        }

        public int AttackRange { get; set; }
        public int DetectionRange { get; set; }
        public int StoppingRange { get; set; } //the enemy won't go any closer, but the player can


        protected Player player;
        protected double Distance
        {
            get
            {
                return Math.Sqrt(Math.Pow((player.Center.X-this.Center.X), 2)+Math.Pow((player.Center.Y - this.Center.Y), 2));
            }
        }
        //gets a direction vector towards the player
        private Vector DirectionVector() 
        {
            Vector v = new Vector();
            v.X = this.player.Center.X - this.Center.X;
            v.Y = this.player.Center.Y - this.Center.Y;
            double l = v.Length;
            v.X /= l;
            v.Y /= l;
            return v;
        }

        public void NewFollowPlayer() 
        {
            if (player != null)
            {
                double distance = this.Distance;
                if (distance <= this.DetectionRange && distance >= this.StoppingRange)
                {
                    Vector v = this.DirectionVector();
                    this.Center = new System.Drawing.Point(Center.X + (int)(v.X * this.Speed.X), Center.Y + (int)(v.Y * this.Speed.Y));
                }
            }
        }
        #endregion

        #region Attack
        //1 sec = 1000 msec, it will be set by ctor
        //it will increase in every tick and when it reach the proper value, the enemy can attack
        public int cooldown = 0;
        public int AttackIntensity { get; set; }

        public virtual void Attack() 
        {
        }

        public void GetDamage(double damage) { this.Health -= damage; }
        #endregion
    }
}
