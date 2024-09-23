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
            maze.dispalyMaze(0);
            while (!maze.chekIsEnd())
            {
                lastPressedKey = Console.ReadKey(true);
                switch (lastPressedKey.Key)
                {
                    case ConsoleKey.LeftArrow:
                        maze.dispalyMaze(1);
                        break;
                    case ConsoleKey.UpArrow:
                        maze.dispalyMaze(2);
                        break;
                    case ConsoleKey.RightArrow:
                        maze.dispalyMaze(3);
                        break;

                    case ConsoleKey.DownArrow:
                        maze.dispalyMaze(4);
                        break;
                    default:
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
