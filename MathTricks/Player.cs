using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTricks
{
    public class Player
    {
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
        public Player(ConsoleColor color) 
        {
            Color = color;
            Points = 0;
        }
	}
}
