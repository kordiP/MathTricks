namespace MathTricks
{
    public static class Engine
    {
        public static void Run()
        {
            /*
                Gets grid size
             */
            Console.WriteLine("Welcome to MathTricks!\nPlease enter the grid size: ");
            int rows = 0, cols = 0;
            string[] inputGame = Console.ReadLine().Split();


            /*
                Checks if the numbers are in correct format,
                then if they are in the correct boundaries.
            */
            while
                (!int.TryParse(inputGame[0], out rows)
                || !int.TryParse(inputGame[1], out cols)
                || rows <= 3 || rows > 12
                || cols <= 3 || cols > 12)
            {
                inputGame = Console.ReadLine().Split();
            }


            /*
                Generates the grid with random cell values inside.
            */
            Grid.rowNumber = rows;
            Grid.colNumber = cols;
            Grid.GenerateCells();


            /*
                Sets players parameters and shows grid
            */
            Console.WriteLine("Please enter red player's name and starting points:");
            string[] inputBluePLayer = Console.ReadLine().Split();
            Player bluePLayer = new Player(ConsoleColor.DarkCyan, int.Parse(inputBluePLayer[1]), inputBluePLayer[0]);
            bluePLayer.CurrentCell = Grid.Cells[0, 0];
            bluePLayer.CurrentCell.RowNumber = 0;
            bluePLayer.CurrentCell.ColumnNumber = 0;

            Console.WriteLine("Please enter blue player's name and starting points:");
            string[] inputRedPLayer = Console.ReadLine().Split();
            Player redPLayer = new Player(ConsoleColor.DarkRed, int.Parse(inputRedPLayer[1]), inputRedPLayer[0]);
            redPLayer.CurrentCell = Grid.Cells[rows - 1, cols - 1];
            redPLayer.CurrentCell.RowNumber = rows - 1;
            redPLayer.CurrentCell.ColumnNumber = cols - 1;

            Grid.Visualize();


            /*
                Reads moves from players and moves them to cells
             */
            do
            {

                /*
                 Blue player moves
                */
                Console.WriteLine();
                bool blueLegalMove = false;
                while (!blueLegalMove)
                {
                    ConsoleKey blueMove = Console.ReadKey().Key;
                    switch (blueMove) 
                    {
                        case ConsoleKey.NumPad1:
                            blueLegalMove = bluePLayer.MoveToCell(1, -1);
                            break;
                        case ConsoleKey.NumPad2:
                            blueLegalMove = bluePLayer.MoveToCell(1, 0);
                            break;
                        case ConsoleKey.NumPad3:
                            blueLegalMove = bluePLayer.MoveToCell(1, 1);
                            break;
                        case ConsoleKey.NumPad4:
                            blueLegalMove = bluePLayer.MoveToCell(0, -1);
                            break;
                        case ConsoleKey.NumPad6:
                            blueLegalMove = bluePLayer.MoveToCell(0, 1);
                            break;
                        case ConsoleKey.NumPad7:
                            blueLegalMove = bluePLayer.MoveToCell(-1, -1);
                            break;
                        case ConsoleKey.NumPad8:
                            blueLegalMove = bluePLayer.MoveToCell(-1, 0);
                            break;
                        case ConsoleKey.NumPad9:
                            blueLegalMove = bluePLayer.MoveToCell(-1, 1);
                            break;
                    }
                    Grid.Visualize();
                    Console.WriteLine($"{bluePLayer} | {redPLayer}");

                }
                Console.WriteLine();

                bool redLegalMove = false;
                while (!redLegalMove)
                {
                    ConsoleKey redMove = Console.ReadKey().Key;
                    switch (redMove)
                    {
                        case ConsoleKey.NumPad1:
                            redLegalMove = redPLayer.MoveToCell(1, -1);
                            break;
                        case ConsoleKey.NumPad2:
                            redLegalMove = redPLayer.MoveToCell(1, 0);
                            break;
                        case ConsoleKey.NumPad3:
                            redLegalMove = redPLayer.MoveToCell(1, 1);
                            break;
                        case ConsoleKey.NumPad4:
                            redLegalMove = redPLayer.MoveToCell(0, -1);
                            break;
                        case ConsoleKey.NumPad6:
                            redLegalMove = redPLayer.MoveToCell(0, 1);
                            break;
                        case ConsoleKey.NumPad7:
                            redLegalMove = redPLayer.MoveToCell(-1, -1);
                            break;
                        case ConsoleKey.NumPad8:
                            redLegalMove = redPLayer.MoveToCell(-1, 0);
                            break;
                        case ConsoleKey.NumPad9:
                            redLegalMove = redPLayer.MoveToCell(-1, 1);
                            break;
                    }
                    Grid.Visualize();
                    Console.WriteLine($"{bluePLayer} | {redPLayer}");

                }
            } while (redPLayer.HasAnyLegalMove() && bluePLayer.HasAnyLegalMove());

            if (bluePLayer.Points > redPLayer.Points)
                Console.WriteLine($"{bluePLayer.Name} wins with {bluePLayer.Points:f2} points! {redPLayer.Name} lost with {redPLayer.Points:f2} points!");

            else 
                Console.WriteLine($"{redPLayer.Name} wins with {redPLayer.Points:f2} points! {bluePLayer.Name} lost with {bluePLayer.Points:f2} points!");
        }
    }
}
