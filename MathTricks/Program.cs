namespace MathTricks
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to MathTricks!\nPlease enter the grid size: (rows cols)");
            
            int rows = 0, cols = 0;
            string[] input = Console.ReadLine().Split();

            /*
                Checks if the numbers are in correct format,
                then if they are in the correct boundaries.
                If they are not, we just read the input again.
            */
            while 
                (!int.TryParse(input[0], out rows) 
                || !int.TryParse(input[1], out cols) 
                || rows <= 2 || rows > 20 
                || cols <= 2 || cols > 20) 
            {
                input = Console.ReadLine().Split();
            }

            /*
                Generates the grid with random cell values inside.
            */
            Grid grid = new Grid(rows, cols);
            grid.Visualize();
        }
    }
}