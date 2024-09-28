using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GeometricProgrssionGame
{
    public static Random random = new Random();
    public static void Play()
    {
        string gameName = "brain-scm";
        string gameInfo = "Find the smallest common multiple of given numbers.";
        Engine.RunGame(gameName, gameInfo, GenerateRound);
    }

    public static (string question, string correctAnswer) GenerateRound()
    {
        int length = random.Next(5, 11);
        int start = random.Next(1, 10);
        int ratio = random.Next(2, 6);

        int[] progression = new int[length];

        progression[0] = start;
        for (int i = 1; i < length; i++)
        {
            progression[i] = progression[i - 1] * ratio;
        }

        int hiddenIndex = random.Next(0, length);
        int correctAnswer = progression[hiddenIndex];

        string[] progressionDisplay = new string[length];
        for (int i = 0; i < length; i++)
        {
            if (i == hiddenIndex)
            {
                progressionDisplay[i] = "..";
            }
            else
            {
                progressionDisplay[i] = progression[i].ToString();
            }
        }

        string question = string.Join(" ", progressionDisplay);

        return (question, correctAnswer.ToString());
    }
}
