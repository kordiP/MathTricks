using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTricks
{
    public static class Grid
    {
        public static int rowCount;
        public static int colCount;
        public static Cell[,] Cells;
        public static void GenerateCells()
        {
            Cells = new Cell[rowCount, colCount];
            for (int i = 0; i < rowCount; i++)
                for (int j = 0; j < colCount; j++)
                {
                    Cells[i, j] = new Cell();
                }
            /*
                Code below sets the two cells in the corners to have values of 0 (where the players initially spawn) 
             */
            Cells[0, 0].Color = ConsoleColor.DarkCyan;
            Cells[0, 0].Captured = true;
            Cells[0, 0].Value = "+0";

            Cells[rowCount - 1, colCount - 1].Color = ConsoleColor.DarkRed;
            Cells[rowCount - 1, colCount - 1].Captured = true;
            Cells[rowCount - 1, colCount - 1].Value = "+0";
        }
        public static void Visualize()
        {
            Console.WriteLine();

            for (int i = 0; i < rowCount; i++)
            {
                Console.Write("+");
                for (int j = 0; j < colCount; j++)
                {
                    Console.Write("----+");
                }
                Console.WriteLine();
                Console.Write("|");
                for (int j = 0; j < colCount; j++)
                {
                    Console.BackgroundColor = Cells[i, j].Color;
                    Console.Write($" {Cells[i, j]} ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("|");
                }
                Console.WriteLine();
            }
            Console.Write("+");
            for (int j = 0; j < colCount; j++)
            {
                Console.Write("----+");
            }
            Console.WriteLine();

        }
        public static void ReadGridSize()
        {
            /*
            Gets grid size
            */
            Console.WriteLine("Welcome to MathTricks!\nPlease enter the grid size: ");
            string[] inputGame = Console.ReadLine().Split();

            /*
                Checks if the numbers are in correct format,
                then if they are in the correct boundaries.
            */
            while
                (!int.TryParse(inputGame[0], out rowCount)
                || !int.TryParse(inputGame[1], out colCount)
                || rowCount <= 3 || rowCount > 12
                || colCount <= 3 || colCount > 12)
            {
                inputGame = Console.ReadLine().Split();
            }
            Grid.GenerateCells();
        }
    }
}
