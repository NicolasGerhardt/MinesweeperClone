using Minesweeper.Data;
using System;

namespace Minesweeper.Textapp
{
    class Program
    {
        private static int width = 30;
        private static int height = 30;
        private static int mines = 10;
        private static Minefield minefield;
        static void Main(string[] args)
        {
            Setup();
            while (true)
            {
                Loop();
            }
        }

        private static void Loop()
        {
            DrawMineField();
            Console.WriteLine($"Press Any Key to Continue");
            var keyPressed = Console.ReadKey().Key;
            var random = new Random();
            int x = random.Next(0, minefield.Cols);
            int y = random.Next(0, minefield.Rows);
            if (keyPressed == ConsoleKey.R)
            {
                minefield.RevealPlot(x, y);
            }
            else if (keyPressed == ConsoleKey.F)
            {
                minefield.TogglePlotFlag(x, y);
            }
        }

        private static void DrawMineField()
        {
            Console.Clear();
            for (int x = 0; x < minefield.Cols; x++)
            {
                for (int y = 0; y < minefield.Rows; y++)
                {
                    Console.Write(' ');
                    if (minefield.Plots[x, y].IsCovered)
                    {
                        if (minefield.Plots[x, y].IsFlagged)
                        {
                            Console.Write('F');
                        } 
                        else
                        {
                            Console.Write('.');
                        }
                    }
                    else if (minefield.Plots[x, y].IsMine)
                    {
                        Console.Write('M');
                    }
                    else
                    {
                        int count = minefield.CountNeighboringMines(x, y);

                        if (count == 0)
                        {
                            Console.Write('_');
                        }
                        else
                        {
                            Console.Write(count);
                        }
                    }
                }
                Console.Write('\n');
            }
        }

        private static void Setup()
        {
            
            Console.Title = "Minesweeper Clone (console viewer)";
            Console.WindowWidth = width * 3;
            Console.BufferWidth = Console.WindowWidth;
            Console.WindowHeight = height + 5;
            Console.BufferHeight = Console.WindowHeight;
            
            Console.CursorVisible = false;
            minefield = new Minefield(width, height, mines);
        }
    }
    
}
