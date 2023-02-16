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
            Score =  45,
            Spares = 0,
            Strikes = 1,
            Total = 55
        };
        var frame2 = new Frame
        {
            Name = "Eve Stojbs",
            Rounds = new List<int>() {3, 7, 3, 3, 9, 1, 6, 4, 2, 3, 1, 0},
            Score =  42,
            Spares = 3,
            Strikes = 0,
            Total = 57
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
                Assert.That(frames[i].Spares, Is.EqualTo(expect[i].Spares));
                Assert.That(frames[i].Strikes, Is.EqualTo(expect[i].Strikes));
                Assert.That(frames[i].Total, Is.EqualTo(expect[i].Total));
            });
        }
    }
    
    [Test]
    public void GetWinnerByScore()
    {
        var game = new Game("TestData.txt");
        var expected = new Frame
        {
            Name = "Yatas Del Lana",
            Rounds = new List<int>() {3, 5, 3, 5, 7, 2, 3, 0, 10, 4, 3},
            Score =  45,
            Spares = 0,
            Strikes = 1,
            Total = 55
        };

        var winner = game.GetWinnerByScore();
        Assert.Multiple(() =>
        {
            Assert.That(winner.Name, Is.EqualTo(expected.Name));
            Assert.That(winner.Rounds, Is.EqualTo(expected.Rounds));
            Assert.That(winner.Score, Is.EqualTo(expected.Score));
            Assert.That(winner.Spares, Is.EqualTo(expected.Spares));
            Assert.That(winner.Strikes, Is.EqualTo(expected.Strikes));
            Assert.That(winner.Total, Is.EqualTo(expected.Total));
        });
    }
    
    [Test]
    public void GetWinnerByTotal()
    {
        var game = new Game("TestData.txt");
        var expected = new Frame
        {
            Name = "Eve Stojbs",
            Rounds = new List<int>() {3, 7, 3, 3, 9, 1, 6, 4, 2, 3, 1, 0},
            Score =  42,
            Spares = 3,
            Strikes = 0,
            Total = 57
        };

        var winner = game.GetWinnerByTotal();
        Assert.Multiple(() =>
        {
            Assert.That(winner.Name, Is.EqualTo(expected.Name));
            Assert.That(winner.Rounds, Is.EqualTo(expected.Rounds));
            Assert.That(winner.Score, Is.EqualTo(expected.Score));
            Assert.That(winner.Spares, Is.EqualTo(expected.Spares));
            Assert.That(winner.Strikes, Is.EqualTo(expected.Strikes));
            Assert.That(winner.Total, Is.EqualTo(expected.Total));
        });
    }
}
