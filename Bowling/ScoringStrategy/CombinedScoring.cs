namespace Bowling.ScoringStrategy;

public class CombinedScoring: IScoringStrategy
{
    public int GetScore(Frame frame)
    {
        var basicScoring = new BasicScoring().GetScore(frame);
        var sparesAndStrikesScoring = new SparesAndStrikesScoring().GetScore(frame);
        var streaksScoring = new StreaksScoring().GetScore(frame);
        var electricBoogalooScoring = new ElectricBoogalooScoring().GetScore(frame);
        var score = basicScoring + sparesAndStrikesScoring + streaksScoring + electricBoogalooScoring;
        return score;
    }
}