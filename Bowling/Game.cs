using System.Runtime.CompilerServices;

namespace Bowling;

public class Game
{
    private readonly string _fileName;
    private const string DataPath = "../../../../Bowling/Data/";
    private readonly List<Frame> _frames = new();

    public Game()
    {
        _fileName = "Data.txt";
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
            var frame = new Frame
            {
                Name = Utils.GetPlayerName(line),
                Rounds = Utils.GetPlayerRounds(line),
                Score =  Utils.GetPlayerRounds(line).Sum()
            };
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