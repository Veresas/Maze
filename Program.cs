using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Maze maze = new Maze(20, 50);
            ConsoleKeyInfo lastPressedKey = new ConsoleKeyInfo();
            maze.DispalyMaze(0);
            while (!maze.ChekIsEnd())
            {
                lastPressedKey = Console.ReadKey(true);
                switch (lastPressedKey.Key)
                {
                    case ConsoleKey.LeftArrow:
                        maze.DispalyMaze(1);
                        break;
                    case ConsoleKey.UpArrow:
                        maze.DispalyMaze(2);
                        break;
                    case ConsoleKey.RightArrow:
                        maze.DispalyMaze(3);
                        break;

                    case ConsoleKey.DownArrow:
                        maze.DispalyMaze(4);
                        break;
                    default:
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
