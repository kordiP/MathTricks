using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTricks
{
    public static class Grid
    {
        public static int rowNumber;
        public static int colNumber;
        public static Cell[,] Cells;
        public static void GenerateCells()
        {
            Cells = new Cell[rowNumber, colNumber];
            for (int i = 0; i < rowNumber; i++)
                for (int j = 0; j < colNumber; j++)
                {
                    Cells[i, j] = new Cell();
                }
            /*
                Code below sets the two cells in the corners to have values of 0 (where the players initially spawn) 
             */
            Cells[0, 0].Color = ConsoleColor.DarkCyan;
            Cells[0, 0].Captured = true;
            Cells[0, 0].Value = "+0";

            Cells[rowNumber - 1, colNumber - 1].Color = ConsoleColor.DarkRed;
            Cells[rowNumber - 1, colNumber - 1].Captured = true;
            Cells[rowNumber - 1, colNumber - 1].Value = "+0";
        }
        public static void Visualize()
        {
            for (int i = 0; i < rowNumber; i++)
            {
                Console.Write("+");
                for (int j = 0; j < colNumber; j++)
                {
                    Console.Write("----+");
                }
                Console.WriteLine();
                Console.Write("|");
                for (int j = 0; j < colNumber; j++)
                {
                    Console.BackgroundColor = Cells[i, j].Color;
                    Console.Write($" {Cells[i, j]} ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("|");
                }
                Console.WriteLine();
            }
            Console.Write("+");
            for (int j = 0; j < colNumber; j++)
            {
                Console.Write("----+");
            }
            Console.WriteLine();

        }
    }
}
