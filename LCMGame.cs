using System;

public class LCMGame
{
    private static Random random = new Random();

    public static void Play()
    {
        string gameName = "brain-scm";
        string gameInfo = "Find the smallest common multiple of given numbers.";
        Engine.RunGame(gameName, gameInfo, GenerateRound);
    }

    private static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    private static int LCM(int a, int b)
    {
        return a * b / GCD(a, b);
    }

    private static (string question, string correctAnswer) GenerateRound()
    {
        int arrayLength = 3;
        int[] numbers = new int[arrayLength];

        // Генерируем числа и сохраняем их в массиве
        for (int i = 0; i < arrayLength; i++)
        {
            numbers[i] = random.Next(1, 30);
        }

        // Вычисляем НОК всех чисел в массиве
        int correctAnswer = numbers[0];
        for (int i = 1; i < arrayLength; i++)
        {
            correctAnswer = LCM(correctAnswer, numbers[i]);
        }

        string question = string.Join(" ", numbers);

        return (question, correctAnswer.ToString());
    }
}