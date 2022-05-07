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
        public Chest()
        {
            r = new Random();
            buff = (Buffs)r.Next(0, 4);
        }
        public void Open(ref Player p) 
        {
            switch (buff)
            {
                case Buffs.HealthBuff:
                    p.Health += 50;
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
        }
    }
}
