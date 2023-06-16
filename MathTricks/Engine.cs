namespace MathTricks
{
    public static class Engine
    {
        public static void Run()
        {
            /*
                Generates the grid with random cell values inside.
            */
            Grid.ReadGridSize();

            /*
                Sets players parameters and shows grid
            */
            Console.WriteLine("Please enter blue player's name and starting points:");
            string[] inputBluePlayer = Console.ReadLine().Split();
            Player bluePlayer = new Player(ConsoleColor.DarkCyan, int.Parse(inputBluePlayer[1]), inputBluePlayer[0]);
            bluePlayer.CurrentCell = Grid.Cells[0, 0];
            bluePlayer.CurrentCell.RowNumber = 0;
            bluePlayer.CurrentCell.ColumnNumber = 0;

            Console.WriteLine("Please enter red player's name and starting points:");
            string[] inputRedPlayer = Console.ReadLine().Split();
            Player redPlayer = new Player(ConsoleColor.DarkRed, int.Parse(inputRedPlayer[1]), inputRedPlayer[0]);
            redPlayer.CurrentCell = Grid.Cells[Grid.rowCount - 1, Grid.colCount - 1];
            redPlayer.CurrentCell.RowNumber = Grid.rowCount - 1;
            redPlayer.CurrentCell.ColumnNumber = Grid.colCount - 1;

            Grid.Visualize();

            /*
                Reads moves from players and moves them to cells
             */
            do
            {

                /*
                 Blue player moves
                */
                bluePlayer.MovePlayer();
                Grid.Visualize();
                Console.WriteLine($"{bluePlayer} | {redPlayer}");

                /*
                 Red player moves
                */
                redPlayer.MovePlayer();
                Grid.Visualize();
                Console.WriteLine($"{bluePlayer} | {redPlayer}");
            } while (redPlayer.HasAnyLegalMove() && bluePlayer.HasAnyLegalMove());


            if (bluePlayer.Points == redPlayer.Points)
                Console.WriteLine($"A draw! Both players have {bluePlayer.Points} points!");

            else
            {
                Player winner = (bluePlayer.Points > redPlayer.Points) ? bluePlayer : redPlayer;
                Console.WriteLine("The winner is: " + winner);
            }
        }
    }
}
