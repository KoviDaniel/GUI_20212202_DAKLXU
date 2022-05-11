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
        public bool PlayerIsOnLeft 
        { 
            get 
            {
                if (this.Center.X > player.Center.X)
                {
                    PlayerIsOnRight = false;
                    return true;
                }
                else 
                    return false;
            }
            set 
            {
                value = PlayerIsOnLeft;              
            }
        }

        public bool PlayerIsOnRight
        {
            get
            {
                if (this.Center.X < player.Center.X)
                {
                    PlayerIsOnLeft = false;
                    return true;
                }
                else
                    return false;
            }
            set 
            {
                value = PlayerIsOnRight;
            }
        }

        public bool IsAttacking { get; set; }
        public bool IsMoving { get; set; }

        public double Power { get; set; }
        
        public Enemy()
        {
            
        }

        #region newMovementIdea
        public static Random r = new Random();
        public Enemy(Size mapArea,Player player)
        {
            this.player = player;
        }

        public Rect EnemyRect { get { return new Rect(this.Center.X - this.Width / 2, this.Center.Y - this.Height / 2, this.Width, this.Height); } }

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
                this.IsAttacking = false;
                this.IsMoving = true;
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
