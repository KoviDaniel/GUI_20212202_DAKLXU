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
        public double Power { get; set; }

        public Enemy()
        {
            
        }

        public void Move() 
        {
            //Center = new System.Drawing.Point(Center.X, Center.Y - (int)Speed.Y);
        }

        public void FollowPlayer(Player player, Size mapArea) // TODO
        {
            while (true) // TODO: addig koveti amig utesi rangen belul nincs a player
            {
                //var enemyCurrPos = this.Center;
                var playerCurrPos = player.Center;

                var upperLimit = player.Center.Y + (player.Height / 2);
                var lowerLimit = player.Center.Y + mapArea.Height - (player.Height / 2);

                var leftlimit = player.Center.X + (player.Width / 2);
                var rightlimit = player.Center.X + mapArea.Width - (player.Width / 2);

                if ((playerCurrPos.X > leftlimit && playerCurrPos.X < rightlimit) && (playerCurrPos.Y > upperLimit && playerCurrPos.Y < lowerLimit))
                {
                    Center = new (playerCurrPos.X - (player.Width / 2), playerCurrPos.Y - (player.Height / 2));
                    //Canvas.SetLeft(player, playerCurrPos.X - (player.Width / 2));
                    //Canvas.SetTop(player, playerCurrPos.Y - (player.Height / 2));
                }
            }
        }

    }
}
