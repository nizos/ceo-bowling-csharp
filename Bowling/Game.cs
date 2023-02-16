using System.Runtime.CompilerServices;

namespace Bowling;

public class Game
{
    private readonly string _fileName;
    private const string DataPath = "../../../../Bowling/Data/";
    private readonly List<Frame> _frames = new();

    public Game()
    {
        _fileName = "Series1.txt";
        LoadGame();
    }

    public Game(string fileName)
    {
        _fileName = fileName;
        LoadGame();
    }

    public List<string> ReadData()
    {
        return File.ReadAllLines(DataPath + _fileName).ToList();
    }

    private void LoadGame()
    {
        var lines = File.ReadAllLines(DataPath + _fileName);
        foreach (var line in lines)
        {
            var frame = new Frame();
            frame.Name = Utils.GetPlayerName(line);
            frame.Rounds = Utils.GetPlayerRounds(line);
            frame.Score = frame.Rounds.Sum();
            frame.Spares = Utils.GetTotalSpares(frame.Rounds);
            frame.Strikes = Utils.GetTotalStrikes(frame.Rounds);
            frame.Total = frame.Score + (frame.Spares * 5) + (frame.Strikes * 10);
            _frames.Add(frame);
        }
    }

    public List<Frame> GetFrames()
    {
        return _frames;
    }

    public Frame GetWinnerByScore()
    {
        var winner = new Frame();
        foreach (var frame in _frames.Where(frame => frame.Score > winner.Score))
        {
            winner = frame;
        }
        return winner;
    }
    
    public Frame GetWinnerByTotal()
    {
        var winner = new Frame();
        foreach (var frame in _frames.Where(frame => frame.Total > winner.Total))
        {
            winner = frame;
        }
        return winner;
    }
}