namespace Bowling;

using System;
  
class GFG {
  
    // Main Method
    public static void Main()
    {
        // Series 1
        var series1 = new Game("Series1.txt");
        var series1Winner = series1.GetWinner();
        Console.WriteLine("Series 1 winner is:");
        Console.WriteLine("{0} ({1} points).", series1Winner.Name, series1Winner.Score);
        
        // Series 2
        var series2 = new Game("Series2.txt", new SparesAndStrikesScoring());
        var series2Winner = series2.GetWinner();
        Console.WriteLine("Series 2 winner is:");
        Console.WriteLine("{0} ({1} points).", series2Winner.Name, series2Winner.Score);
        
        // Series 3
        var series3 = new Game("Series3.txt", new StreaksScoring());
        var series3Winner = series3.GetWinner();
        Console.WriteLine("Series 3 winner is:");
        Console.WriteLine("{0} ({1} points).", series3Winner.Name, series3Winner.Score);
    }
}