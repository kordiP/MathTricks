﻿namespace MathTricks
{
    public class Player 
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private double points;

        public double Points
        {
            get { return points; }
            set { points = value; }
        }

        private ConsoleColor color;

        public ConsoleColor Color
        {
            get { return color; }
            set { color = value; }
        }
        private Cell currentCell;

        public Cell CurrentCell
        {
            get { return currentCell; }
            set { currentCell = value; }
        }

        public Player(ConsoleColor color, int startingPoints, string name)
        {
            this.Color = color;
            this.Points = startingPoints;
            this.Name = name;
        }

        private bool MoveToCell(int rowMove, int colMove)
        {
            int nextCellRow = this.CurrentCell.RowNumber + rowMove;
            int nextCellColumn = this.CurrentCell.ColumnNumber + colMove;
            if (IsValidMove(rowMove, colMove))
            {
                this.CurrentCell = Grid.Cells[nextCellRow, nextCellColumn];
                this.CurrentCell.RowNumber = nextCellRow;
                this.CurrentCell.ColumnNumber = nextCellColumn;
                this.CurrentCell.Captured = true;
                this.CurrentCell.Color = Color;
                CalculateNewPoints(this.CurrentCell.Value);
                return true;
            }
            return false;
        }
       
        public bool IsValidMove(int rowMove, int colMove)
        {
            if (this.CurrentCell.RowNumber + rowMove >= Grid.rowCount || this.CurrentCell.RowNumber + rowMove < 0 
                || this.CurrentCell.ColumnNumber + colMove >= Grid.colCount || this.CurrentCell.ColumnNumber + colMove < 0)
            {
                return false;
            }
            else if (Grid.Cells[this.CurrentCell.RowNumber + rowMove, this.CurrentCell.ColumnNumber + colMove].Captured)
            {
                return false;
            }
            return true;
        }
        private void CalculateNewPoints(string value) 
        {
            char operation = value[0];
            value = value.Remove(0, 1);
            int number = int.Parse(value);
            switch (operation)
            {
                case '+':
                    this.Points += number;
                    break;         
                case '-':          
                    this.Points -= number;
                    break;         
                case '*':          
                    this.Points *= number;
                    break;
                case '/':
                    this.Points /= number;
                    break;
                default:
                    break;
            }
        }
        public bool HasAnyLegalMove()
        {
            if (IsValidMove(0, 1) || IsValidMove(0, -1) || 
                IsValidMove(-1, 0) || IsValidMove(-1, -1) || IsValidMove(-1, 1) || 
                IsValidMove(1, 0) || IsValidMove(1, -1) || IsValidMove(1, 1))
                return true;
            return false;
        }

        public void MovePlayer()
        {
            bool legalMove = false;
            while (!legalMove && this.HasAnyLegalMove())
            {
                ConsoleKey move = Console.ReadKey().Key;
                switch (move)
                {
                    case ConsoleKey.NumPad1:
                        legalMove = this.MoveToCell(1, -1);
                        break;
                    case ConsoleKey.NumPad2:
                        legalMove = this.MoveToCell(1, 0);
                        break;
                    case ConsoleKey.NumPad3:
                        legalMove = this.MoveToCell(1, 1);
                        break;
                    case ConsoleKey.NumPad4:
                        legalMove = this.MoveToCell(0, -1);
                        break;
                    case ConsoleKey.NumPad6:
                        legalMove = this.MoveToCell(0, 1);
                        break;
                    case ConsoleKey.NumPad7:
                        legalMove = this.MoveToCell(-1, -1);
                        break;
                    case ConsoleKey.NumPad8:
                        legalMove = this.MoveToCell(-1, 0);
                        break;
                    case ConsoleKey.NumPad9:
                        legalMove = this.MoveToCell(-1, 1);
                        break;
                }
            }
        }
        public override string ToString()
        {
            return $"{Name}: {Points:f2}";
        }

    }
}
