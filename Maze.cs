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
        private int width;
        private int height;
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

            height = heightMaze;
            width = widthMaze;
            maze = new char[heightMaze, widthMaze];
            GenerateMaze(heightMaze, widthMaze);
        }

        /// <summary>
        /// Generate random maze
        /// </summary>
        /// <remarks> Создает глвные стены и визуальный шум</remarks>
        /// <param name="widthMaze"></param>
        /// <param name="heightMaze"></param>
        private void GenerateMaze(int widthMaze, int heightMaze)
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

            AddRooms();
        }

        /// <summary>
        /// Generat main road to end
        /// </summary>
        /// <remarks>Создает основную дорогу к победе, путем присоеденения к концу одного коридора следующий коридор</remarks>
        private void AddRooms()
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
                        IsContinue = AddHallveyRightSide(ref startX, ref startY);
                        continue;

                    case 2:
                        IsContinue = AddhallveyDown(ref startX, ref startY);
                        continue;

                    case 3:
                        IsContinue = AddHallveyLeftSide(ref startX, ref startY);
                        continue;
                    case 4:
                        IsContinue = AddhallveyUp(ref startX, ref startY);
                        continue;
                }
            }


        }

        private bool AddHallveyRightSide(ref int startX, ref int startY)
        {
            int storei = 0;
            for (int i = startX; i < startX + 5; i++)
            {
                if (i < width - 1)
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

        private bool AddHallveyLeftSide(ref int startX, ref int startY)
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

        private bool AddhallveyDown(ref int startX, ref int startY)
        {
            int storei = 0;
            for (int i = startY; i < startY + 3; i++)
            {
                if (i < height - 1)
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

        private bool AddhallveyUp(ref int startX, ref int startY)
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
        public bool ChekCollision(int code)
        {
            int x = player.PosX;
            int y = player.PosY;

            maze[x, y] = ' ';
            switch (code)
            {
                case 1:

                    if (maze[x, y - 1] == 'f')
                    {
                        Win();
                    }
                    else if (maze[x, y - 1] == ' ')
                    {
                        player.GoLeft();
                    }

                    break;

                case 2:

                    if (maze[x - 1, y] == 'f')
                    {
                        Win();
                    }
                    else if (maze[x - 1, y] == ' ')
                    {
                        player.GoUp();
                    }

                    break;

                case 3:
                    if (maze[x, y + 1] == 'f')
                    {
                        Win();
                    }
                    else if (maze[x, y + 1] == ' ')
                    {
                        player.GoRight();
                    }

                    break;

                case 4:
                    if (maze[x + 1, y] == 'f')
                    {
                        Win();
                    }
                    else if (maze[x + 1, y] == ' ')
                    {
                        player.GoDown();
                    }

                    break;

                default:
                    break;
            }
            return true;
        }

        private void Win()
        {
            Console.WriteLine("Победа");
            isEnd = true;
        }
        public bool ChekIsEnd()
        {
            return isEnd;
        }


        public void DispalyMaze(int codeMove)
        {
            Console.Clear();

            ChekCollision(codeMove);
            maze[player.PosX, player.PosY] = player.Body;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(maze[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
