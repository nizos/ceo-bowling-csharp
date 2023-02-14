namespace Bowling;

public static class Utils
{
    public static string GetPlayerName(string input)
    {
        var name = "";
        var words = input.Split(' ');
        foreach (var word in words)
        {
            if (!int.TryParse(word, out _))
            {
                name += word + " ";
            }
        }
        return name.TrimEnd();
    }
    
    public static List<int> GetPlayerRounds(string input)
    {
        var rounds = new List<int>();
        var words = input.Split(' ');
        foreach (var word in words)
        {
            if (int.TryParse(word, out var round))
            {
                rounds.Add(round);
            }
        }
        return rounds;
    }
}