namespace Bowling;

using System;
  
class GFG {
  
    // Main Method
    public static void Main()
    {
        Game game = new Game();
        Frame winner = game.GetWinner();
        Console.WriteLine("Series 1 winner is:");
        Console.WriteLine("{0} ({1} points).", winner.Name, winner.Score);
    }
}