using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

public class Engine
{
    public static string GetNameUser()
    {
        string userName;
        do
        {
            Console.WriteLine("May I have your name?");
            userName = Console.ReadLine();
            if (string.IsNullOrEmpty(userName))
            {
                Console.WriteLine("Incorrect name");
            }
        } while (string.IsNullOrEmpty(userName));

        Console.WriteLine($"Hello, {userName}!");
        return userName;
    }

    public static void ShowCongratulations(string name)
    {
        Console.WriteLine($"Congratulations, {name}");
    }

    public static void ShowTryAgain(string name)
    {
        Console.WriteLine($"Let's try again, {name}");
    }

    public static void RunGame(string gameName, string gameInstruction, Func<(string question, string correctAnswer)> generateRound)
    {
        Console.WriteLine(gameName);
        string userName = GetNameUser();
        Console.WriteLine(gameInstruction);
        Console.WriteLine("Введите желаемое количество раундов: ");
        int rounds = Convert.ToInt32(Console.ReadLine());
        int numCorrectAnsers = 0;
        for (int i = 0; i < rounds; i++)
        {
            var (question, correctAnswer) = generateRound();
            Console.WriteLine($"Question: {question}");
            Console.WriteLine("Your answer: ");
            string userImput = Console.ReadLine();
            if (userImput == correctAnswer)
            {
                Console.WriteLine("Correct");
                numCorrectAnsers += 1;
            }
            else
            {
                Console.WriteLine($"'{userImput}' is wrong answer ;(. Correct answer was '{correctAnswer}'.");
                ShowTryAgain(userName);
                break;
            }
        }
        if (numCorrectAnsers == rounds)
        {
            ShowCongratulations(userName);
        }
    }
}