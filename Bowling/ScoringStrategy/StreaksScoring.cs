namespace Bowling.ScoringStrategy;

public class StreaksScoring: IScoringStrategy
{
    public int GetScore(Frame frame)
    {
        var score = frame.Rounds.Sum();
        var spareBonus = Utils.GetTotalSpareStreakBonus(frame.Rounds);
        var strikeBonus = Utils.GetTotalStrikeStreakBonus(frame.Rounds);
        return score + spareBonus + strikeBonus;
    }
}