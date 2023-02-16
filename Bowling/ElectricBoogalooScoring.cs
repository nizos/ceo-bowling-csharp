namespace Bowling;

public class ElectricBoogalooScoring: IScoringStrategy
{
    public int GetScore(Frame frame)
    {
        var score = 0;
        var previous = 0;
        var firstAttempt = true;
        for (var i = 0; i < frame.Rounds.Count; i++)
        {
            switch (firstAttempt)
            {
                case true when frame.Rounds[i] == 10:
                {
                    if (i + 2 < frame.Rounds.Count)
                    {
                        score += frame.Rounds[i + 1] + frame.Rounds[i + 2];;
                    }
                    else if (i + 1 < frame.Rounds.Count)
                    {
                        score += frame.Rounds[i + 1];
                    }

                    break;
                }
                case false when previous + frame.Rounds[i] == 10:
                {
                    if (i + 1 < frame.Rounds.Count)
                    {
                        score += frame.Rounds[i + 1];
                    }

                    break;
                }
            }

            if (firstAttempt)
            {
                if (frame.Rounds[i] != 10)
                {
                    firstAttempt = false;
                }
            }
            else
            {
                firstAttempt = true;
            }

            previous = frame.Rounds[i];
            score += frame.Rounds[i];
        }

        return score;
    }
}