using Bowling;

namespace Tests;

[TestFixture]
public class UtilsTests
{
    private static readonly object[] PlayerNamesTestCaseSource = 
    {
        new object[] {"Yatas Del Lana 3 5 3 5 7 2 3 0 10 4 3", "Yatas Del Lana"},
        new object[] {"Eve Stojbs 3 7 3 3 9 1 6 4 2 3 1 0", "Eve Stojbs"}
    };
    
    [TestCaseSource(nameof(PlayerNamesTestCaseSource))]
    public void GetPlayerName(string input, string name)
    {
        Assert.That(Utils.GetPlayerName(input), Is.EqualTo(name));
    }
    
    private static readonly object[] PlayerRoundsTestCaseSource = 
    {
        new object[] {"Yatas Del Lana 3 5 3 5 7 2 3 0 10 4 3", new List<int> {3, 5, 3, 5, 7, 2, 3, 0, 10, 4, 3}},
        new object[] {"Eve Stojbs 3 7 3 3 9 1 6 4 2 3 1 0", new List<int> {3, 7, 3, 3, 9, 1, 6, 4, 2, 3, 1, 0}}
    };
    
    [TestCaseSource(nameof(PlayerRoundsTestCaseSource))]
    public void GetPlayerRounds(string input, List<int> rounds)
    {
        Assert.That(Utils.GetPlayerRounds(input), Is.EqualTo(rounds));
    }
    
    private static readonly object[] TotalSparesTestCaseSource = 
    {
        new object[] {new List<int> {3, 5, 3, 5, 7, 2, 3, 0, 10, 4, 3}, 0},
        new object[] {new List<int> {3, 7, 3, 3, 9, 1, 6, 4, 2, 3, 1, 0}, 3}
    };

    [TestCaseSource(nameof(TotalSparesTestCaseSource))]
    public void GetTotalSpares(List<int> input, int result)
    {
        Assert.That(Utils.GetNrOfSpares(input), Is.EqualTo(result));
    }
    
    private static readonly object[] TotalStrikesTestCaseSource = 
    {
        new object[] {new List<int> {3, 5, 3, 5, 7, 2, 3, 0, 10, 4, 3}, 1},
        new object[] {new List<int> {3, 7, 3, 3, 9, 1, 6, 4, 2, 3, 1, 0}, 0}
    };
    
    [TestCaseSource(nameof(TotalStrikesTestCaseSource))]
    public void GetTotalStrikes(List<int> input, int result)
    {
        Assert.That(Utils.GetNrOfStrikes(input), Is.EqualTo(result));
    }
    
    private static readonly object[] TotalSpareBonusTestCaseSource = 
    {
        new object[] {new List<int> {3, 5, 3, 5, 7, 2, 3, 0, 10, 4, 3}, 0},
        new object[] {new List<int> {3, 7, 3, 3, 9, 1, 6, 4, 2, 3, 1, 0}, 11}
    };
    
    [TestCaseSource(nameof(TotalSpareBonusTestCaseSource))]
    public void GetTotalSpareBonus(List<int> input, int result)
    {
        Assert.That(Utils.GetTotalSpareBonus(input), Is.EqualTo(result));
    }
    
    private static readonly object[] TotalStrikeBonusTestCaseSource = 
    {
        new object[] {new List<int> {3, 5, 3, 5, 7, 2, 3, 0, 10, 4, 3}, 7},
        new object[] {new List<int> {3, 7, 3, 3, 9, 1, 6, 4, 2, 3, 1, 0}, 0}
    };
    
    [TestCaseSource(nameof(TotalStrikeBonusTestCaseSource))]
    public void GetTotalStrikeBonus(List<int> input, int result)
    {
        Assert.That(Utils.GetTotalStrikeBonus(input), Is.EqualTo(result));
    }
    
    private static readonly object[] TotalSpareStreakBonusTestCaseSource = 
    {
        new object[] {new List<int> {3, 5, 3, 5, 7, 2, 3, 0, 10, 4, 3}, 0},
        new object[] {new List<int> {3, 7, 3, 3, 9, 1, 6, 4, 2, 3, 1, 0}, 18}
    };
    
    [TestCaseSource(nameof(TotalSpareStreakBonusTestCaseSource))]
    public void GetTotalSpareStreakBonus(List<int> input, int result)
    {
        Assert.That(Utils.GetTotalSpareStreakBonus(input), Is.EqualTo(result));
    }
    
    private static readonly object[] TotalStrikeStreakBonusTestCaseSource = 
    {
        new object[] {new List<int> {3, 5, 3, 5, 7, 2, 3, 0, 10, 4, 3}, 10},
        new object[] {new List<int> {3, 7, 3, 3, 9, 1, 6, 4, 2, 3, 1, 0}, 0}
    };
    
    [TestCaseSource(nameof(TotalStrikeStreakBonusTestCaseSource))]
    public void GetTotalStrikeStreakBonus(List<int> input, int result)
    {
        Assert.That(Utils.GetTotalStrikeStreakBonus(input), Is.EqualTo(result));
    }
}