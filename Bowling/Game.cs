using System.Runtime.CompilerServices;
using Bowling.ScoringStrategy;

namespace Bowling;

public class Game
{
    private readonly string _fileName;
    private const string DataPath = "../../../../Bowling/Data/";
    private readonly List<Frame> _frames = new();
    private readonly IScoringStrategy _scoringStrategy;

    public Game()
    {
        _fileName = "Series1.txt";
        _scoringStrategy = new BasicScoring();
        LoadGame();
    }

    public Game(string fileName)
    {
        _fileName = fileName;
        _scoringStrategy = new BasicScoring();
        LoadGame();
    }
    
    public Game(IScoringStrategy scoringStrategy)
    {
        _fileName = "Series1.txt";
        _scoringStrategy = scoringStrategy;
        LoadGame();
    }
    
    public Game(string fileName, IScoringStrategy scoringStrategy)
    {
        _fileName = fileName;
        _scoringStrategy = scoringStrategy;
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
            var frame = new Frame
            {
                Name = Utils.GetPlayerName(line),
                Rounds = Utils.GetPlayerRounds(line)
            };
            frame.Score = _scoringStrategy.GetScore(frame);
            _frames.Add(frame);
        }
    }

    public List<Frame> GetFrames()
    {
        return _frames;
    }

    public Frame GetWinner()
    {
        var winner = new Frame();
        foreach (var frame in _frames.Where(frame => frame.Score > winner.Score))
        {
            winner = frame;
        }
        return winner;
    }
}