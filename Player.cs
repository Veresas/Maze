using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_game
{
    /// <summary>
    /// class representing a player
    /// </summary>
    /// <remarks> Класс представляющий собой игрока</remarks>
    internal class Player
    {
        public int PosX { get; private set; }
        public int PosY { get; private set; }
        public char Body { get; private set; }

        public Player(int x, int y)
        {
            PosY = y;
            PosX = x;
            Body = '&';
        }

        public void GoUp()
        {
            PosX--;
        }

        public void GoDown()
        {
            PosX++;
        }
        public void GoLeft()
        {
            PosY--;
        }
        public void GoRight()
        {
            PosY++;
        }
    }
}
