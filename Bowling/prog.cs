using Bowling.ScoringStrategy;

namespace Bowling;

using System;

internal class Gfg {
  
    // Main Method
    public static void Main()
    {
        // Series 1: Basic Scoring
        // Eve Stermball (790 points).
        var series1 = new Game("Series1.txt");
        var series1Winner = series1.GetWinner();
        Console.WriteLine("Series 1 winner is:");
        Console.WriteLine("{0} ({1} points).", series1Winner.Name, series1Winner.Score);

        // Series 2: Spares and Strikes Rewarded
        // Zerkk MacBurger (1053 points).
        var series2 = new Game("Series2.txt", new SparesAndStrikesScoring());
        var series2Winner = series2.GetWinner();
        Console.WriteLine("Series 2 winner is:");
        Console.WriteLine("{0} ({1} points).", series2Winner.Name, series2Winner.Score);
        
        // Series 3: Spares and Streaks Rewarded with streak-based bonuses
        // Zoe Bjeffs (1046 points).
        var series3 = new Game("Series3.txt", new StreaksScoring());
        var series3Winner = series3.GetWinner();
        Console.WriteLine("Series 3 winner is:");
        Console.WriteLine("{0} ({1} points).", series3Winner.Name, series3Winner.Score);
        
        // Series 4: Just get weird with it
        // Kim Octo (893 points).
        var series4 = new Game("Series4.txt", new ElectricBoogalooScoring());
        var series4Winner = series4.GetWinner();
        Console.WriteLine("Series 4 winner is:");
        Console.WriteLine("{0} ({1} points).", series4Winner.Name, series4Winner.Score);
    }
}