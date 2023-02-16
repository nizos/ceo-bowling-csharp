using Bowling;

namespace Tests;

[TestFixture]
public class GameTests
{
    [Test]
    public void ReadData()
    {
        var game = new Game();
        var lines = System.IO.File.ReadAllLines("../../../../Bowling/Data/Series1.txt");
        Assert.That(game.ReadData(), Is.EqualTo(lines.ToList()));
    }

    [Test]
    public void ReadTestData()
    {
        var game = new Game("TestData.txt");
        var data = game.ReadData();
        var expect = new List<string>
        {
            "Yatas Del Lana 3 5 3 5 7 2 3 0 10 4 3",
            "Eve Stojbs 3 7 3 3 9 1 6 4 2 3 1 0"
        };
        Assert.That(data, Is.EqualTo(expect));
    }
    
    [Test]
    public void GetFrames()
    {
        var game = new Game("TestData.txt");
        var expect = new List<Frame>();
        var frame1 = new Frame
        {
            Name = "Yatas Del Lana",
            Rounds = new List<int>() {3, 5, 3, 5, 7, 2, 3, 0, 10, 4, 3},
            Score = 45
        };
        var frame2 = new Frame
        {
            Name = "Eve Stojbs",
            Rounds = new List<int>() {3, 7, 3, 3, 9, 1, 6, 4, 2, 3, 1, 0},
            Score = 42
        };
        
        expect.Add(frame1);
        expect.Add(frame2);
        var frames = game.GetFrames();

        for (var i = 0; i < 2; i++)
        {
            Assert.Multiple(() =>
            {
                Assert.That(frames[i].Name, Is.EqualTo(expect[i].Name));
                Assert.That(frames[i].Rounds, Is.EqualTo(expect[i].Rounds));
                Assert.That(frames[i].Score, Is.EqualTo(expect[i].Score));
            });
        }
    }
    
    [Test]
    public void GetWinnerByBasicScoring()
    {
        var game = new Game("TestData.txt", new BasicScoring());
        var expected = new Frame
        {
            Name = "Yatas Del Lana",
            Rounds = new List<int>() {3, 5, 3, 5, 7, 2, 3, 0, 10, 4, 3},
            Score = 45
        };

        var winner = game.GetWinner();
        Assert.Multiple(() =>
        {
            Assert.That(winner.Name, Is.EqualTo(expected.Name));
            Assert.That(winner.Rounds, Is.EqualTo(expected.Rounds));
            Assert.That(winner.Score, Is.EqualTo(expected.Score));
        });
    }
    
    [Test]
    public void GetWinnerBySparesAndStrikesScoring()
    {
        var game = new Game("TestData.txt", new SparesAndStrikesScoring());
        var expected = new Frame
        {
            Name = "Eve Stojbs",
            Rounds = new List<int>() {3, 7, 3, 3, 9, 1, 6, 4, 2, 3, 1, 0},
            Score = 57
        };

        var winner = game.GetWinner();
        Assert.Multiple(() =>
        {
            Assert.That(winner.Name, Is.EqualTo(expected.Name));
            Assert.That(winner.Rounds, Is.EqualTo(expected.Rounds));
            Assert.That(winner.Score, Is.EqualTo(expected.Score));
        });
    }
    
    [Test]
    public void GetWinnerByStreaksScoring()
    {
        var game = new Game("TestData.txt", new StreaksScoring());
        var expected = new Frame
        {
            Name = "Eve Stojbs",
            Rounds = new List<int>() {3, 7, 3, 3, 9, 1, 6, 4, 2, 3, 1, 0},
            Score = 60
        };

        var winner = game.GetWinner();
        Assert.Multiple(() =>
        {
            Assert.That(winner.Name, Is.EqualTo(expected.Name));
            Assert.That(winner.Rounds, Is.EqualTo(expected.Rounds));
            Assert.That(winner.Score, Is.EqualTo(expected.Score));
        });
    }
}
