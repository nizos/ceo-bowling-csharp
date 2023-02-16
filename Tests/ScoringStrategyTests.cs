using Bowling;

namespace Tests;

[TestFixture]
public class ScoringStrategyTests
{
    
    private static readonly object[] BasicScoringTestCaseSource = 
    {
        new object[] {new Frame()
        {
            Name = "Yatas Del Lana",
            Rounds = new List<int>() {3, 5, 3, 5, 7, 2, 3, 0, 10, 4, 3},
        }, 45},
        new object[] {new Frame()
        {
            Name = "Eve Stojbs",
            Rounds = new List<int>() {3, 7, 3, 3, 9, 1, 6, 4, 2, 3, 1, 0},
        }, 42}
    };
    
    [TestCaseSource(nameof(BasicScoringTestCaseSource))]
    public void BasicScoring(Frame frame, int score)
    {
        var scoring = new BasicScoring();
        Assert.That(scoring.GetScore(frame), Is.EqualTo(score));
    }
    
    private static readonly object[] SparesAndStrikesScoringTestCaseSource = 
    {
        new object[] {new Frame()
        {
            Name = "Yatas Del Lana",
            Rounds = new List<int>() {3, 5, 3, 5, 7, 2, 3, 0, 10, 4, 3},
        }, 55},
        new object[] {new Frame()
        {
            Name = "Eve Stojbs",
            Rounds = new List<int>() {3, 7, 3, 3, 9, 1, 6, 4, 2, 3, 1, 0},
        }, 57}
    };
    
    [TestCaseSource(nameof(SparesAndStrikesScoringTestCaseSource))]
    public void SparesAndStrikesScoring(Frame frame, int score)
    {
        var scoring = new SparesAndStrikesScoring();
        Assert.That(scoring.GetScore(frame), Is.EqualTo(score));
    }
    
    private static readonly object[] StreaksScoringTestCaseSource = 
    {
        new object[] {new Frame()
        {
            Name = "Yatas Del Lana",
            Rounds = new List<int>() {3, 5, 3, 5, 7, 2, 3, 0, 10, 4, 3},
        }, 55},
        new object[] {new Frame()
        {
            Name = "Eve Stojbs",
            Rounds = new List<int>() {3, 7, 3, 3, 9, 1, 6, 4, 2, 3, 1, 0},
        }, 60}
    };
    
    [TestCaseSource(nameof(StreaksScoringTestCaseSource))]
    public void StreaksScoring(Frame frame, int score)
    {
        var scoring = new StreaksScoring();
        Assert.That(scoring.GetScore(frame), Is.EqualTo(score));
    }
    
    private static readonly object[] ElectricBoogalooScoringTestCaseSource = 
    {
        new object[] {new Frame()
        {
            Name = "Yatas Del Lana",
            Rounds = new List<int>() {3, 5, 3, 5, 7, 2, 3, 0, 10, 4, 3},
        }, 52},
        new object[] {new Frame()
        {
            Name = "Eve Stojbs",
            Rounds = new List<int>() {3, 7, 3, 3, 9, 1, 6, 4, 2, 3, 1, 0},
        }, 53}
    };
    
    [TestCaseSource(nameof(ElectricBoogalooScoringTestCaseSource))]
    public void ElectricBoogalooScoring(Frame frame, int score)
    {
        var scoring = new ElectricBoogalooScoring();
        Assert.That(scoring.GetScore(frame), Is.EqualTo(score));
    }
}