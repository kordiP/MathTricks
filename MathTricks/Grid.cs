using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTricks
{
    public class Grid
    {
        public Cell[,] cells;

        public Grid(int rows, int cols)
        {
            cells = new Cell[rows, cols];
            GenerateCells();
        }
        private void GenerateCells()
        {
            for (int i = 0; i < cells.GetLength(0); i++)
                for (int j = 0; j < cells.GetLength(1); j++)
                    cells[i, j] = new Cell();
            // GetLength -->  0 - rows / 1 - cols  
        }
        public void Visualize()
        {
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                Console.Write("+");
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    Console.Write("----+");
                }
                Console.WriteLine();
                Console.Write("|");
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    Console.BackgroundColor = cells[i, j].Color;
                    Console.Write($" {cells[i, j]} ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("|");
                }
                Console.WriteLine();
            }
            Console.Write("+");
            for (int j = 0; j < cells.GetLength(1); j++)
            {
                Console.Write("----+");
            }
            Console.WriteLine();
        }
    }
}
