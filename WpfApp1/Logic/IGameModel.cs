using System;
using ShoresOfGold.Models;

namespace ShoresOfGold.Logic
{
    public interface IGameModel
    {
        Player Player { get; set; }
        Zombie Zombie { get; set; }

        event EventHandler Changed;
    }
}