using ShoresOfGold.Models;
using System;
using System.Collections.Generic;
using System.Windows;

namespace ShoresOfGold.Logic
{
    public interface IGameModel
    {       
        Player Player { get; set; }
        Boss Boss { get; set; }
        Zombie Zombie { get; set; }
        List<Enemy> Enemies { get; set; }
        List<Bullet> Bullets { get; set; }
        List<Chest> Chests { get; set; }

        event EventHandler Changed;

        Wall TopWall { get; set; }
        Wall BottomWall { get; set; }

        public int MapNumber { get; set; }
        void LoadNexMap();
    }
}