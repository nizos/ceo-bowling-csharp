using Bowling;

namespace Tests;

[TestFixture]
public class UtilsTests
{
    [Test]
    public void GetPlayerName()
    {
        const string frame = "Asa Datafraz 10 1 9 0 0 1 0 0 2 0 0 1 9 0 4 1 0 5 0 10";
        var name = Utils.GetPlayerName(frame);
        Assert.That(name, Is.EqualTo("Asa Datafraz"));
    }
    
    [Test]
    public void GetPlayerRounds()
    {
        const string frame = "Asa Datafraz 10 1 9 0 0 1 0 0 2 0 0 1 9 0 4 1 0 5 0 10";
        var expected = new List<int> {10, 1, 9, 0, 0, 1, 0, 0, 2, 0, 0, 1, 9, 0, 4, 1, 0, 5, 0, 10};
        var rounds = Utils.GetPlayerRounds(frame);
        Assert.That(rounds, Is.EqualTo(expected));
    }
}