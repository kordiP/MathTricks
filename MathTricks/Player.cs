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

        private int points;

        public int Points
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

       

        public void MoveToCell(int rowMove, int colMove)
        {
            int nextCellRow = this.CurrentCell.RowNumber + rowMove;
            int nextCellColumn = this.CurrentCell.ColumnNumber + colMove;
            if (IsValidMove(nextCellRow, nextCellColumn))
            {
                this.CurrentCell.Captured = true;
                this.CurrentCell.Color = Color;
                this.CurrentCell.RowNumber = nextCellRow;
                this.CurrentCell.ColumnNumber = nextCellColumn;
                Console.WriteLine("Moved at: " + CurrentCell.RowNumber + "-" + CurrentCell.ColumnNumber);
            }
            else
            {
                Console.WriteLine(" it be dont legal");
            }
        }

        /* check if it IS outside of the boundaries,                                    
        * then if it HAS been already taken and if it goes through all cases,           
        * the game ends and points need to be calculated 
        * **you can have a move counter that is the number of possible moves and 
        * if a move is successful you subtract 1. 
        * If at anytime this counter is more than 1 (because of last move) and 
        * there is no legal move for the current player, 
        * game ends and current player automatically loses
        */
        public bool IsValidMove(int nextCellRow, int nextCellColumn)
        {
            if (nextCellRow >= Grid.rowNumber || nextCellRow < 0 || nextCellColumn >= Grid.colNumber || nextCellColumn < 0)
            {
                return false;
            }
            else if (Grid.Cells[nextCellRow, nextCellColumn].Captured)
            {
                return false;
            }
            return true;
        }
    }
}
