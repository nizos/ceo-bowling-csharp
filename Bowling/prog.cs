using Bowling.ScoringStrategy;

namespace Bowling;

using System;

internal class Gfg {

    // Main Method
    public static void Main()
    {
        // Series 1: Basic Scoring
        // Eve Stermball (790 points).
        var series1 = new Game(new BasicScoring());
        series1.LoadData("Series1.txt");
        var series1Winner = series1.GetWinner();
        Console.WriteLine("Series 1 winner is:");
        Console.WriteLine("{0} ({1} points).", series1Winner.Name, series1Winner.Score);

        // Series 2: Spares and Strikes Rewarded
        // Zerkk MacBurger (1053 points).
        var series2 = new Game(new SparesAndStrikesScoring());
        series2.LoadData("Series2.txt");
        var series2Winner = series2.GetWinner();
        Console.WriteLine("Series 2 winner is:");
        Console.WriteLine("{0} ({1} points).", series2Winner.Name, series2Winner.Score);
        
        // Series 3: Spares and Streaks Rewarded with streak-based bonuses
        // Zoe Bjeffs (1046 points).
        var series3 = new Game(new StreaksScoring());
        series3.LoadData("Series3.txt");
        var series3Winner = series3.GetWinner();
        Console.WriteLine("Series 3 winner is:");
        Console.WriteLine("{0} ({1} points).", series3Winner.Name, series3Winner.Score);
        
        // Series 4: Just get weird with it
        // Kim Octo (893 points).
        var series4 = new Game(new ElectricBoogalooScoring());
        series4.LoadData("Series4.txt");
        var series4Winner = series4.GetWinner();
        Console.WriteLine("Series 4 winner is:");
        Console.WriteLine("{0} ({1} points).", series4Winner.Name, series4Winner.Score);
        
        // Series 5: Combined scoring of all played series
        //  ( points).
        var overall = new Game(new CombinedScoring());
        overall.LoadData("Series1.txt");
        overall.LoadData("Series2.txt");
        overall.LoadData("Series3.txt");
        overall.LoadData("Series4.txt");
        var overallWinner = overall.GetWinner();
        Console.WriteLine("Overall winner is:");
        Console.WriteLine("{0} ({1} points).", overallWinner.Name, overallWinner.Score);
    }
}