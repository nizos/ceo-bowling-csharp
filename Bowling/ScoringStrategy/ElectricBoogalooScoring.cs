namespace Bowling.ScoringStrategy;

public class ElectricBoogalooScoring: IScoringStrategy
{
    public int GetScore(Frame frame)
    {
        var score = frame.Rounds.Sum();
        var spareBonus = Utils.GetTotalSpareBonus(frame.Rounds);
        var streakBonus = Utils.GetTotalStrikeBonus(frame.Rounds);
        return score + spareBonus + streakBonus;
    }
}