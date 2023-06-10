using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTricks
{
    public class Cell
    {
		private char[] mathOperations = new char[] {'+', '-', '*', '/' };
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

        public Cell()
        {
			Random randomOperation = new Random();
			Random randomNumber = new Random();
			Color = ConsoleColor.DarkGray;
			Value = $"{mathOperations[randomOperation.Next(0, 4)]}{randomNumber.Next(1,6)}";
        }

        public override string ToString()
        {
            return $"{Value}";
        }
    }
}
