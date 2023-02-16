namespace Bowling.ScoringStrategy;

public class SparesAndStrikesScoring: IScoringStrategy
{
    public int GetScore(Frame frame)
    {
        var score = frame.Rounds.Sum();
        var spares = Utils.GetNrOfSpares(frame.Rounds);
        var strikes = Utils.GetNrOfStrikes(frame.Rounds);
        return score + (spares * 5) + (strikes * 10);
    }
}
