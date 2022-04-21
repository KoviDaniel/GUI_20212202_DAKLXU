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

        #region newIdea
        public Enemy(Player player)
        {
            this.player = player;
        }

        private Player player;
        public double Distance
        {
            get
            {
                return Math.Sqrt(Math.Pow((player.Center.X-this.Center.X), 2)+Math.Pow((player.Center.Y - this.Center.Y), 2));
            }
        }
        #endregion
    }
}
