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
        private int posX;
        private int posY;
        private char body = '$';

        public Player(int x, int y)
        {
            posY = y;
            posX = x;
        }

        public void goUp()
        {
            posX--;
        }

        public void goDown()
        {
            posX++;
        }
        public void goLeft()
        {
            posY--;
        }
        public void goRight()
        {
            posY++;
        }

        public int GetX()
        {
            return posX;
        }

        public int GetY()
        {
            return posY;
        }

        public char GetBody()
        {
            return body;
        }
    }
}
