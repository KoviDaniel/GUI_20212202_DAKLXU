using ShoresOfGold.Models;
using System;
using WpfApp1.Models;

namespace WpfApp1.Logic
{
    public interface IGameModel
    {       
        Player Player { get; set; }

        event EventHandler Changed;

        Wall TopWall { get; set; }
        Wall BottomWall { get; set; }

        public int MapNumber { get; set; }
    }
}