namespace Bowling;

public interface IScoringStrategy
{
    public int GetScore(Frame frame);
}