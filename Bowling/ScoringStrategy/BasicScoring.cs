namespace Bowling.ScoringStrategy;

public class BasicScoring: IScoringStrategy
{
    public int GetScore(Frame frame)
    {
        return frame.Rounds.Sum();
    }
}