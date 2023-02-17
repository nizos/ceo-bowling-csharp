using Bowling;
using Bowling.ScoringStrategy;

namespace Tests;

[TestFixture]
public class GameTests
{
    [Test]
    public void ReadData()
    {
        var lines = System.IO.File.ReadAllLines("../../../../Bowling/Data/Series1.txt");
        Assert.That(Game.ReadData("Series1.txt"), Is.EqualTo(lines.ToList()));
    }

    [Test]
    public void AddFrame()
    {
        const string frameString = "Yatas Del Lana 3 5 3 5 7 2 3 0 10 4 3";
        var game = new Game();
        game.AddFrame(frameString);
        var frames = game.GetFrames();
        Assert.Multiple(() =>
        {
            Assert.That(frames, Has.Count.EqualTo(1));
            Assert.That(frames[0].Name, Is.EqualTo("Yatas Del Lana"));
            Assert.That(frames[0].Rounds, Is.EqualTo(new List<int>{3, 5, 3, 5, 7, 2, 3, 0, 10, 4, 3}));
            Assert.That(frames[0].Score, Is.EqualTo(45));
        });
    }
    
    [Test]
    public void AddRounds()
    {
        const string frameString1 = "Yatas Del Lana 3 5 3 5 7 2 3 0 10 4 3";
        const string frameString2 = "Eve Stojbs 3 7 3 3 9 1 6 4 2 3 1 0";
        const string updateFrameString1 = "Yatas Del Lana 4 4 8 2";
        const string updateFrameString2 = "Steve Mobs 5 2 4 4";
        var game = new Game();
        game.AddFrame(frameString1);
        game.AddFrame(frameString2);
        game.AddRounds(updateFrameString1);
        game.AddRounds(updateFrameString2);
        var frames = game.GetFrames();
        Assert.Multiple(() =>
        {
            Assert.That(frames, Has.Count.EqualTo(2));
            Assert.That(frames[0].Name, Is.EqualTo("Yatas Del Lana"));
            Assert.That(frames[0].Rounds, Is.EqualTo(new List<int>{3, 5, 3, 5, 7, 2, 3, 0, 10, 4, 3, 4, 4, 8, 2}));
            Assert.That(frames[0].Score, Is.EqualTo(63));
            Assert.That(frames[1].Name, Is.EqualTo("Eve Stojbs"));
            Assert.That(frames[1].Rounds, Is.EqualTo(new List<int>{3, 7, 3, 3, 9, 1, 6, 4, 2, 3, 1, 0}));
            Assert.That(frames[1].Score, Is.EqualTo(42));
        });
    }
    
    [Test]
    public void LoadData()
    {
        var game = new Game();
        game.LoadData("TestData.txt");
        
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
    public void GetFrames()
    {
        var game = new Game();
        game.LoadData("TestData.txt");
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
        var game = new Game(new BasicScoring());
        game.LoadData("TestData.txt");
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
        var game = new Game(new SparesAndStrikesScoring());
        game.LoadData("TestData.txt");
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
        var game = new Game(new StreaksScoring());
        game.LoadData("TestData.txt");
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
    
    [Test]
    public void GetWinnerByElectricBoogalooScoring()
    {
        var game = new Game(new ElectricBoogalooScoring());
        game.LoadData("TestData.txt");
        var expected = new Frame
        {
            Name = "Eve Stojbs",
            Rounds = new List<int>() {3, 7, 3, 3, 9, 1, 6, 4, 2, 3, 1, 0},
            Score = 53
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
    public void GetWinnerByFullScoring()
    {
        var game = new Game(new CombinedScoring());
        game.LoadData("TestData.txt");
        var expected = new Frame
        {
            Name = "Eve Stojbs",
            Rounds = new List<int>() {3, 7, 3, 3, 9, 1, 6, 4, 2, 3, 1, 0},
            Score = 212
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
