using Bowling;

namespace Tests;

[TestFixture]
public class UtilsTests
{
    private static readonly object[] PlayerNamesTestCaseSource = 
    {
        new object[] {"Yatas Del Lana 3 5 3 5 7 2 3 0 10 4 3", "Yatas Del Lana"},   // case 1
        new object[] {"Eve Stojbs 3 7 3 3 9 1 6 4 2 3 1 0", "Eve Stojbs"}           // case 2
    };
    
    [TestCaseSource(nameof(PlayerNamesTestCaseSource))]
    public void GetPlayerName(string input, string name)
    {
        Assert.That(Utils.GetPlayerName(input), Is.EqualTo(name));
    }
    
    private static readonly object[] PlayerRoundsTestCaseSource = 
    {
        new object[] {"Yatas Del Lana 3 5 3 5 7 2 3 0 10 4 3", new List<int> {3, 5, 3, 5, 7, 2, 3, 0, 10, 4, 3}},     // case 1
        new object[] {"Eve Stojbs 3 7 3 3 9 1 6 4 2 3 1 0", new List<int> {3, 7, 3, 3, 9, 1, 6, 4, 2, 3, 1, 0}}    // case 2
    };
    
    [TestCaseSource(nameof(PlayerRoundsTestCaseSource))]
    public void GetPlayerRounds(string input, List<int> rounds)
    {
        Assert.That(Utils.GetPlayerRounds(input), Is.EqualTo(rounds));
    }
    
    private static readonly object[] TotalSparesTestCaseSource = 
    {
        new object[] {new List<int> {3, 5, 3, 5, 7, 2, 3, 0, 10, 4, 3}, 0},     // case 1
        new object[] {new List<int> {3, 7, 3, 3, 9, 1, 6, 4, 2, 3, 1, 0}, 3}    // case 2
    };

    [TestCaseSource(nameof(TotalSparesTestCaseSource))]
    public void GetTotalSpares(List<int> input, int result)
    {
        Assert.That(Utils.GetTotalSpares(input), Is.EqualTo(result));
    }
    
    private static readonly object[] TotalStrikesTestCaseSource = 
    {
        new object[] {new List<int> {3, 5, 3, 5, 7, 2, 3, 0, 10, 4, 3}, 1},     // case 1
        new object[] {new List<int> {3, 7, 3, 3, 9, 1, 6, 4, 2, 3, 1, 0}, 0}    // case 2
    };
    
    [TestCaseSource(nameof(TotalStrikesTestCaseSource))]
    public void GetTotalStrikes(List<int> input, int result)
    {
        Assert.That(Utils.GetTotalStrikes(input), Is.EqualTo(result));
    }
}