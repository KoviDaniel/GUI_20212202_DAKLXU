using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShoresOfGold.Models
{
    public class Boss : Entity
    {
        Player player;
        Random r = new Random(); //támadás típushoz
        const int attackIntensity = 1000;
        int cooldown = 0;
        Size mapArea;
        public int AttackType { get; set; }
        public int CloseAttackSize { get; set; }
        public Boss(Size mapArea, Player player)
        {
            this.player = player;
            this.mapArea = mapArea;
            this.Speed = new Vector(0, 0);
            this.Health = 1000;
            this.Width = 650;
            this.Height = 600;
            this.CloseAttackSize = 475;
            this.AttackType = -1;
            Center = new System.Drawing.Point((int)mapArea.Width/2, (int)mapArea.Height / 2-360);
        }
        private double Distance
        {
            get
            {
                return Math.Sqrt(Math.Pow((player.Center.X - this.Center.X), 2) + Math.Pow((player.Center.Y - this.Center.Y), 2));
            }
        }
        public Rect BossRect { 
            get 
            {
                return new Rect(this.Center.X - this.Width / 2, this.Center.Y - this.Height / 2, this.Width,this.Height);
            } 
        }
        public void GetDamage(int damage) 
        {
            this.Health -= damage;
        }
        public void AttackHandler() 
        {
            if (this.player != null && this.Health>0 && this.player.Health > 0) {
                if (cooldown == attackIntensity - 40) 
                {
                    this.AttackType = r.Next(0, 2);
                }
                if (cooldown >= attackIntensity)
                {
                    if (this.AttackType == 0)
                    {
                        HalfAreaAttack();
                    }
                    else if (this.AttackType == 1) 
                    {
                        CloseAttack();
                    }
                    cooldown = 0;
                    this.AttackType = -1;
                }
            }
            ++cooldown;
        }

        #region Attacks
        private void HalfAreaAttack() 
        {
            int opt=r.Next(0, 1);
            if (opt == 0) {
                if (this.player.Center.X < this.mapArea.Width / 2) 
                {
                    this.player.GetDamage(50);
                }
            }
            else 
            {
                if (this.player.Center.X >= this.mapArea.Width / 2) {
                    this.player.GetDamage(50);
                }
            }
        }
        private void CloseAttack() 
        {
            if (Distance <= this.CloseAttackSize) this.player.GetDamage(70);
        }
        #endregion
    }
}
