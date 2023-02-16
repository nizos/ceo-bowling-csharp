namespace Bowling;

public class SparesAndStrikesScoring: IScoringStrategy
{
    public int GetScore(Frame frame)
    {
        var score = frame.Rounds.Sum();
        var spares = Utils.GetTotalSpares(frame.Rounds);
        var strikes = Utils.GetTotalStrikes(frame.Rounds);
        return score + (spares * 5) + (strikes * 10);
    }
}
