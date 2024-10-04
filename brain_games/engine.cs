// <copyright file="engine.cs" company="MISIS">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Основной класс Engine.
/// </summary>
public class Engine
{
    /// <summary>
    /// Функция, узнающая имя игрока.
    /// </summary>
    /// <returns>Возвращает введенное имя пользователя.</returns>
    public static string GetNameUser()
    {
        string? userName;
        do
        {
            Console.WriteLine("May I have your name?");
            userName = Console.ReadLine();
            if (string.IsNullOrEmpty(userName))
            {
                Console.WriteLine("Incorrect name");
            }
        }
        while (string.IsNullOrEmpty(userName));

        Console.WriteLine($"Hello, {userName}!");
        return userName;
    }

    /// <summary>
    /// Функция, которая показывает надпись в случае победы.
    /// </summary>
    /// <param name="name">Имя игрока.</param>
    public static void ShowCongratulations(string name)
    {
        Console.WriteLine($"Congratulations, {name}");
    }

    /// <summary>
    /// Функция, которая показывает надпись в случае провала.
    /// </summary>
    /// <param name="name">Имя игрока.</param>
    public static void ShowTryAgain(string name)
    {
        Console.WriteLine($"Let's try again, {name}");
    }

    /// <summary>
    /// Функция, запускающая игру.
    /// </summary>
    /// <param name="gameName">Название игры.</param>
    /// <param name="gameInstruction">Инструкция игры.</param>
    /// <param name="generateRound">Функция, создающая игру в зависимости от выбранной игры.</param>
    public static void RunGame(string gameName, string gameInstruction, Func<(string question, string correctAnswer)> generateRound)
    {
        Console.WriteLine(gameName);
        string userName = GetNameUser();
        Console.WriteLine(gameInstruction);
        Console.WriteLine("Enter the desired number of rounds: ");
        int rounds = Convert.ToInt32(Console.ReadLine());
        int numCorrectAnsers = 0;
        for (int i = 0; i < rounds; i++)
        {
            var (question, correctAnswer) = generateRound();
            Console.WriteLine($"Question: {question}");
            Console.WriteLine("Your answer: ");
            string? userImput = Console.ReadLine();
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
