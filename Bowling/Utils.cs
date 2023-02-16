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

    public static int GetNrOfSpares(List<int> rounds)
    {
        var spares = 0;
        var previous = 0;
        var firstAttempt = true;
        foreach (var current in rounds)
        {
            if (!firstAttempt)
            {
                if (previous + current == 10)
                {
                    spares++;
                }
                firstAttempt = true;
            }
            else
            {
                if (current != 10)
                {
                    firstAttempt = false;
                }
            }
            previous = current;
        }
        return spares;
    }
    
    public static int GetNrOfStrikes(List<int> rounds)
    {
        var streaks = 0;
        var firstAttempt = true;
        foreach (var current in rounds)
        {
            if (firstAttempt)
            {
                if (current == 10)
                {
                    streaks++;
                }
                else
                {
                    firstAttempt = false;
                }
            }
            else
            {
                firstAttempt = true;
            }
        }
        return streaks;
    }

    public static int GetTotalSpareBonus(List<int> rounds)
    {
        var bonus = 0;
        var previous = 0;
        var firstAttempt = true;
        for (var i = 0; i < rounds.Count; i++)
        {
            if (!firstAttempt)
            {
                if (previous + rounds[i] == 10)
                {
                    if (i + 1 < rounds.Count)
                    {
                        bonus += rounds[i + 1];
                    }
                }

                firstAttempt = true;
            }
            else
            {
                if (rounds[i] != 10)
                {
                    firstAttempt = false;
                }
            }

            previous = rounds[i];
        }

        return bonus;
    }
    
    public static int GetTotalStrikeBonus(List<int> rounds)
    {
        var bonus = 0;
        var firstAttempt = true;
        for (var i = 0; i < rounds.Count; i++)
        {
            if (firstAttempt)
            {
                if (rounds[i] == 10)
                {
                    if (i + 2 < rounds.Count)
                    {
                        bonus += rounds[i + 1] + rounds[i + 2];;
                    }
                    else if (i + 1 < rounds.Count)
                    {
                        bonus += rounds[i + 1];
                    }
                }
                else
                {
                    firstAttempt = false;
                }
            }
            else
            {
                firstAttempt = true;
            }
        }

        return bonus;
    }

    public static int GetTotalSpareStreakBonus(List<int> rounds)
    {
        var spareStreakBonus = 0;
        var spares = GetNrOfSpares(rounds);
        for (var i = 0; i < spares; i++)
        {
            spareStreakBonus += (i * 1) + 5;
        }

        return spareStreakBonus;
    }
    
    public static int GetTotalStrikeStreakBonus(List<int> rounds)
    {
        var strikeStreakBonus = 0;
        var strikes = GetNrOfStrikes(rounds);
        for (var i = 0; i < strikes; i++)
        {
            strikeStreakBonus += (i * 2) + 10;
        }

        return strikeStreakBonus;
    }
}