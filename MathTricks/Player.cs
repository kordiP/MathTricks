namespace MathTricks
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

        public bool MoveToCell(int rowMove, int colMove)
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
            if (this.CurrentCell.RowNumber + rowMove >= Grid.rowNumber || this.CurrentCell.RowNumber + rowMove < 0 
                || this.CurrentCell.ColumnNumber + colMove >= Grid.colNumber || this.CurrentCell.ColumnNumber + colMove < 0)
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
        public override string ToString()
        {
            return $"{Name}: {Points:f2}";
        }
    }
}
