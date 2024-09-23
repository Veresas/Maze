using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Maze_game
{
    /// <summary>
    /// class representing a maze
    /// </summary>
    /// <remarks> Класс представляющий собой лабиринт</remarks>
    internal class Maze
    {
        private int widthMaze;
        private int heightMaze;
        private char[,] maze;
        /// <summary>
        /// end game marker
        /// </summary>
        private bool isEnd = false;
        /// <summary>
        /// player like part of maze
        /// </summary>
        private Player player = new Player(1, 1);

        /// <summary>
        /// Basic constructor
        /// </summary>
        /// <param name="heightMaze"></param>
        /// <param name="widhtMaze"></param>
        public Maze(int heightMaze, int widthMaze)
        {

            this.heightMaze = heightMaze;
            this.widthMaze = widthMaze;
            maze = new char[heightMaze, widthMaze];
            generateMaze(heightMaze, widthMaze);
        }

        /// <summary>
        /// Generate random maze
        /// </summary>
        /// <remarks> Создает глвные стены и визуальный шум</remarks>
        /// <param name="widthMaze"></param>
        /// <param name="heightMaze"></param>
        private void generateMaze(int widthMaze, int heightMaze)
        {
            Random rand = new Random();
            int random_number;

            for (int i = 0; i < widthMaze; i++)
            {
                maze[i, 0] = '█';
                maze[i, heightMaze - 1] = '█';
                for (int j = 1; j < heightMaze - 1; j++)
                {
                    random_number = rand.Next(3);
                    if (random_number == 1)
                    {
                        maze[i, j] = '█';
                    }
                    else
                    {
                        maze[i, j] = ' ';
                    }
                }
            }

            for (int j = 0; j < heightMaze; j++)
            {

                maze[0, j] = '█';
                maze[widthMaze - 1, j] = '█';
            }

            addRooms();
        }

        /// <summary>
        /// Generat main road to end
        /// </summary>
        /// <remarks>Создает основную дорогу к победе, путем присоеденения к концу одного коридора следующий коридор</remarks>
        private void addRooms()
        {
            Random rand = new Random();
            int random_number;
            int startX = 1;
            int startY = 1;
            int countRepet = 0;
            bool IsContinue = true;

            maze[1, 1] = ' ';

            while (IsContinue)
            {
                if (countRepet < 3)
                {
                    random_number = rand.Next(1, 3);
                }
                else
                {
                    random_number = rand.Next(1, 5);
                }

                countRepet++;
                switch (random_number)
                {
                    case 1:
                        IsContinue = addHallveyRightSide(ref startX, ref startY);
                        continue;

                    case 2:
                        IsContinue = addhallveyDown(ref startX, ref startY);
                        continue;

                    case 3:
                        IsContinue = addHallveyLeftSide(ref startX, ref startY);
                        continue;
                    case 4:
                        IsContinue = addhallveyUp(ref startX, ref startY);
                        continue;
                }
            }


        }

        private bool addHallveyRightSide(ref int startX, ref int startY)
        {
            int storei = 0;
            for (int i = startX; i < startX + 5; i++)
            {
                if (i < widthMaze - 1)
                {
                    maze[startY, i] = ' ';
                }
                else
                {
                    maze[startY, i - 1] = 'f';
                    return false;
                }
                storei = i;
            }
            startX = storei;
            return true;
        }

        private bool addHallveyLeftSide(ref int startX, ref int startY)
        {
            int storei = 0;
            for (int i = startX; i > startX - 2; i--)
            {
                if (i > 0)
                {
                    maze[startY, i] = ' ';
                }
                else
                {
                    maze[startY, i + 1] = 'f';
                    return false;
                }
                storei = i;
            }
            startX = storei;
            return true;
        }

        private bool addhallveyDown(ref int startX, ref int startY)
        {
            int storei = 0;
            for (int i = startY; i < startY + 3; i++)
            {
                if (i < heightMaze - 1)
                {
                    maze[i, startX] = ' ';
                }
                else
                {
                    maze[i - 1, startX] = 'f';
                    return false;
                }
                storei = i;
            }
            startY = storei;
            return true;
        }

        private bool addhallveyUp(ref int startX, ref int startY)
        {
            int storei = 0;
            for (int i = startY; i > startY - 2; i--)
            {
                if (i > 0)
                {
                    maze[i, startX] = ' ';
                }
                else
                {
                    maze[i + 1, startX] = 'f';
                    return false;
                }
                storei = i;
            }
            startY = storei;
            return true;
        }
        /// <summary>
        /// Checks if the player is touching objects
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool chekCollision(int code)
        {
            int x = player.GetX();
            int y = player.GetY();

            maze[x, y] = ' ';
            switch (code)
            {
                case 1:

                    if (maze[x, y - 1] == 'f')
                    {
                        win();
                    }
                    else if (maze[x, y - 1] == ' ')
                    {
                        player.goLeft();
                    }

                    break;

                case 2:

                    if (maze[x - 1, y] == 'f')
                    {
                        win();
                    }
                    else if (maze[x - 1, y] == ' ')
                    {
                        player.goUp();
                    }

                    break;

                case 3:
                    if (maze[x, y + 1] == 'f')
                    {
                        win();
                    }
                    else if (maze[x, y + 1] == ' ')
                    {
                        player.goRight();
                    }

                    break;

                case 4:
                    if (maze[x + 1, y] == 'f')
                    {
                        win();
                    }
                    else if (maze[x + 1, y] == ' ')
                    {
                        player.goDown();
                    }

                    break;

                default:
                    break;
            }
            return true;
        }

        private void win()
        {
            Console.WriteLine("Победа");
            isEnd = true;
        }
        public bool chekIsEnd()
        {
            return isEnd;
        }


        public void dispalyMaze(int codeMove)
        {
            Console.Clear();

            chekCollision(codeMove);
            maze[player.GetX(), player.GetY()] = player.GetBody();

            for (int i = 0; i < heightMaze; i++)
            {
                for (int j = 0; j < widthMaze; j++)
                {
                    Console.Write(maze[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
