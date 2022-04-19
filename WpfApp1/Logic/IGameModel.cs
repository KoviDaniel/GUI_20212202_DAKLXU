using System;
using WpfApp1.Models;

namespace WpfApp1.Logic
{
    public interface IGameModel
    {
        Player Player { get; set; }

        event EventHandler Changed;
    }
}