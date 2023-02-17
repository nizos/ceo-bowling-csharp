using System.Runtime.CompilerServices;
using Bowling.ScoringStrategy;

namespace Bowling;

public class Game
{
    private const string DataPath = "../../../../Bowling/Data/";
    private readonly List<Frame> _frames = new();
    private readonly IScoringStrategy _scoringStrategy;

    public Game()
    {
        _scoringStrategy = new BasicScoring();
    }
    
    public Game(IScoringStrategy scoringStrategy)
    {
        _scoringStrategy = scoringStrategy;
    }

    public static List<string> ReadData(string fileName)
    {
        return File.ReadAllLines(DataPath + fileName).ToList();
    }
    
    public void AddFrame(string frameString)
    {
        if (_frames.Any(frame => frame.Name == Utils.GetPlayerName(frameString))) return;
        var frame = new Frame
        {
            Name = Utils.GetPlayerName(frameString),
            Rounds = Utils.GetPlayerRounds(frameString)
        };
        frame.Score = _scoringStrategy.GetScore(frame);
        _frames.Add(frame);
    }
    
    public void AddRounds(string frameString)
    {
        var index = _frames.FindIndex(frame => frame.Name == Utils.GetPlayerName(frameString));
        if (index < 0) return;
        {
            var frame = _frames[index];
            frame.Rounds.AddRange(Utils.GetPlayerRounds(frameString));
            frame.Score = _scoringStrategy.GetScore(frame);
            _frames[index] = frame;
        }
    }

    public void LoadData(string fileName)
    {
        foreach (var line in ReadData(fileName))
        {
            if (_frames.Any(frame => frame.Name == Utils.GetPlayerName(line)))
            {
                AddRounds(line);
            }
            else
            {
                AddFrame(line);
            }
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