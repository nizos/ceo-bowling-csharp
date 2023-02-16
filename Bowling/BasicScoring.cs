namespace Bowling;

public class BasicScoring: IScoringStrategy
{
    public int GetScore(Frame frame)
    {
        return frame.Rounds.Sum();
    }
}