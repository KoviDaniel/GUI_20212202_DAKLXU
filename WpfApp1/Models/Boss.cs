using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShoresOfGold.Models
{
    class Boss : Entity
    {
        Player player;
        Random r = new Random(); //támadás típushoz
        const int attackIntensity = 100;
        int cooldown = 0;
        Size mapArea;
        public Boss(Size mapArea, Player player)
        {
            this.player = player;
            this.mapArea = mapArea;
            Center = new System.Drawing.Point((int)mapArea.Width / 2, (int)mapArea.Height / 2);
            this.Speed = new Vector(0, 0);
            this.Health = 1000;
            this.Width = 250;
            this.Height = 100;
        }
        public Rect BossRect { get; set; }
        private double Distance
        {
            get
            {
                return Math.Sqrt(Math.Pow((player.Center.X - this.Center.X), 2) + Math.Pow((player.Center.Y - this.Center.Y), 2));
            }
        }

        public void AttackHandler() 
        {
            if (this.player != null) {
                var option = r.Next(4);
                if (cooldown >= attackIntensity)
                {
                    switch (option) {
                        case 0:
                            HalfAreaAttack();
                            cooldown = 0;
                            break;
                        case 1:
                            CloseAttack();
                            cooldown = 0;
                            break;
                        case 2:
                            //todo new attacks
                            break;
                        case 3:
                            //todo new Attacks
                            break;
                    }
                }
                ++cooldown;
            }
        }

        #region Attacks
        private void HalfAreaAttack() 
        {
            var opt=r.Next(1);
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
            if (Distance <= 100) this.player.GetDamage(70);
        }
        #endregion
    }
}
