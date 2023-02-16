namespace Bowling;

public class StreaksScoring: IScoringStrategy
{
    public int GetScore(Frame frame)
    {
        var score = frame.Rounds.Sum();
        var spares = Utils.GetTotalSpares(frame.Rounds);
        var strikes = Utils.GetTotalStrikes(frame.Rounds);
        var sparesScore = 0;
        for (var i = 0; i < spares; i++)
        {
            sparesScore += (i * 1) + 5;
        }
        var strikesScore = 0;
        for (var i = 0; i < strikes; i++)
        {
            strikesScore += (i * 2) + 10;
        }
        return score + sparesScore + strikesScore;
    }
}