using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTricks
{
    public static class Engine
    {
        public static void Run()
        {
            Console.WriteLine("Welcome to MathTricks!\nPlease enter the grid size: (rows cols)");
            int rows = 0, cols = 0;
            string[] inputGame = Console.ReadLine().Split();
            /*
                Checks if the numbers are in correct format,
                then if they are in the correct boundaries.
            */
            while
                (!int.TryParse(inputGame[0], out rows)
                || !int.TryParse(inputGame[1], out cols)
                || rows <= 2 || rows > 20
                || cols <= 2 || cols > 20)
            {
                inputGame = Console.ReadLine().Split();
            }
            /*
                Generates the grid with random cell values inside.
            */
            Grid.rowNumber = rows;
            Grid.colNumber = cols;
            Grid.GenerateCells();


            // Code below is a demo for 1 player

            Console.WriteLine("Please enter player 1's name and points to start:");
            string[] inputPlayer1 = Console.ReadLine().Split();
          
            Player bluePLayer = new Player(ConsoleColor.DarkCyan, int.Parse(inputPlayer1[1]), inputPlayer1[0]);
            bluePLayer.CurrentCell = Grid.Cells[0, 0];

            Grid.Visualize();

            
            ConsoleKey inputMove = Console.ReadKey().Key;
            Console.WriteLine(bluePLayer.CurrentCell.RowNumber + " " + bluePLayer.CurrentCell.ColumnNumber);
            while (inputMove != ConsoleKey.NumPad0)
            {
                switch (inputMove)
                {
                    case ConsoleKey.NumPad1:
                        bluePLayer.MoveToCell(1, -1);
                        break;
                    case ConsoleKey.NumPad2:
                        bluePLayer.MoveToCell(1, 0);
                        break;
                    case ConsoleKey.NumPad3:
                        bluePLayer.MoveToCell(1,1);
                        break;
                    case ConsoleKey.NumPad4:
                        bluePLayer.MoveToCell(0, -1);
                        break;
                    case ConsoleKey.NumPad6:
                        bluePLayer.MoveToCell(0, 1);
                        break;
                    case ConsoleKey.NumPad7:
                        bluePLayer.MoveToCell(-1, -1);
                        break;
                    case ConsoleKey.NumPad8:
                        bluePLayer.MoveToCell(-1, 0);
                        break;
                    case ConsoleKey.NumPad9:
                        bluePLayer.MoveToCell(-1, 1);
                        break;
                    default:
                        inputMove = Console.ReadKey().Key;
                        break;
                }
                Grid.Visualize();
                Console.WriteLine($"{bluePLayer.Name}'s Points: {bluePLayer.Points}. Current cell index: {bluePLayer.CurrentCell.RowNumber} {bluePLayer.CurrentCell.ColumnNumber}");
                if (!bluePLayer.HasAnyLegalMove()) break;
                inputMove = Console.ReadKey().Key;
            }
        }
    }
}
