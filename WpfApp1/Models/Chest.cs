using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShoresOfGold.Models
{
    enum Buffs 
    {
        HealthBuff, MeleeDamageBuff, RangeDamageBuff, SpeedBuff
    }
    public class Chest
    {
        Random r;
        Buffs buff;
        public int Width { get; set; }
        public int Height { get; set; }
        //Player p;
        public bool Opened { get; set; }
        public System.Drawing.Point Center { get; set; }
        public Chest(Size mapArea, double upperBound, double lowerBound)
        {
            r = new Random();
            buff = (Buffs)r.Next(0, 4);
            Width = 40;
            Height = 40;
            //Center = new System.Drawing.Point(r.Next(30, (int)mapArea.Width-40), r.Next(15, (int)mapArea.Height - 25));
            Center = new System.Drawing.Point(r.Next(Width / 2, (int)mapArea.Width-Width/2), r.Next((int)upperBound + Height, (int)lowerBound - Height/2));
            Opened = false;
        }
        public void Open(Player p) 
        {
            if (Opened == false)
            {
                switch (buff)
                {
                    case Buffs.HealthBuff:
                        p.MAX_HEALTH += 50;
                        break;
                    case Buffs.MeleeDamageBuff:
                        p.MeleeDamage += 10;
                        break;
                    case Buffs.RangeDamageBuff:
                        p.RangeDamage += 5;
                        break;
                    case Buffs.SpeedBuff:
                        Vector v = new Vector();
                        v.X = p.Speed.X + 0.15;
                        v.Y = p.Speed.Y + 0.15;
                        p.Speed = v;
                        break;
                    default:
                        break;
                }
                Opened = true;
            }
        }
    }
}
