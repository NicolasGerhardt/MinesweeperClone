using Minesweeper.Data;
using System;

namespace Minesweeper.Textapp
{
    class Program
    {
        private static int width = 30;
        private static int height = 30;
        private static int mines = 30;
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
            Console.WriteLine("[F] Flag Random");
            Console.WriteLine("[R] Reveal Random");
            Console.WriteLine("[M] Make Random Minefield");
            Console.WriteLine("[A] Reveal All");
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
            else if (keyPressed == ConsoleKey.M)
            {
                minefield = new Minefield(width, height, mines);
            }
            else if (keyPressed == ConsoleKey.A)
            {
                foreach (Plot plot in minefield.Plots)
                {
                    plot.Reveal();
                }
            }
        }

        private static void DrawMineField()
        {
            Console.Clear();
            for (int x = 0; x < minefield.Cols; x++)
            {
                for (int y = 0; y < minefield.Rows; y++)
                {
                    Console.Write(' '); // horizontal space between characters

                    string s = minefield.Plots[x, y].ToString();
                    if (string.IsNullOrWhiteSpace(s))
                    {
                        int count = minefield.CountNeighboringMines(x, y);
                        if (count == 0)
                        {
                            s = ".";
                        }
                        else
                        {
                            s = count.ToString();
                        }
                    }
                    
                    Console.Write(s);
                    
                }
                Console.Write('\n');
            }
        }

        private static void Setup()
        {
            
            Console.Title = "Minesweeper Clone (console version)";
            Console.WindowWidth = width * 3;
            Console.BufferWidth = Console.WindowWidth;
            Console.WindowHeight = height + 5;
            Console.BufferHeight = Console.WindowHeight;
            
            Console.CursorVisible = false;
            minefield = new Minefield(width, height, mines);
        }
    }
    
}
