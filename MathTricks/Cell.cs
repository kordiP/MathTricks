namespace MathTricks
{
    public class Cell
    {
        private char[] mathOperations = new char[] { '+', '-', '*', '/' };
        private ConsoleColor color;
        public ConsoleColor Color
        {
            get { return color; }
            set { color = value; }
        }
        private string value; // will be in a format "+1"
        public string Value
        {
            get { return value; }
            set { this.value = value; }
        }
        private bool captured;
        public bool Captured
        {
            get { return captured; }
            set { captured = value; }
        }

        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }
        public Cell()
        {
            Random randomOperation = new Random();
            Random randomNumber = new Random();

            this.Color = ConsoleColor.DarkGray;
            this.Value = $"{mathOperations[randomOperation.Next(0, 4)]}{randomNumber.Next(1, 6)}";
            this.Captured = false;
        }

        public override string ToString()
        {
            return $"{Value}";
        }
    }
}
