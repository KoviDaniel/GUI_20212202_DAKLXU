using System;
using ShoresOfGold.Models;

namespace ShoresOfGold.Logic
{
    public interface IGameModel
    {
        Player Player { get; set; }

        event EventHandler Changed;
    }
}