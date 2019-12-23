using System;

namespace AIGameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            // Draw the game board
            World drawGrid = new World(20, 20);
            drawGrid.DrawGame();
            Console.WriteLine("Press Enter to move the cells or Escape to close the game");
            //key info object to exit the game or watch the breeding 
            ConsoleKeyInfo keyInfo;

            //keyboard keys click events to exit if the user pressed Esc
            do
            {
                keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    //check if there is any more birds or flies alive to restart the game or close
                    if (drawGrid.ladyBird.Count == 0 || drawGrid.greenFly.Count == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("either is no lady Bird or Green fly alive anymore, Please press Enter to restart the game or Esc to exit");

                        keyInfo = Console.ReadKey();
                        if (keyInfo.Key == ConsoleKey.Enter)
                        {
                            drawGrid = new World(20, 20);
                            drawGrid.DrawGame();
                        }
                        else if (keyInfo.Key == ConsoleKey.Escape)
                        {
                            drawGrid.Statistics();
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        Console.Clear();
                        drawGrid.RedrawGame();
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    drawGrid.Statistics();
                    Environment.Exit(0);
                }
            }
            while (keyInfo.Key == ConsoleKey.Enter);
        }
    }
}