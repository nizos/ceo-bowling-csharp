namespace Bowling.ScoringStrategy;

public interface IScoringStrategy
{
    public int GetScore(Frame frame);
}