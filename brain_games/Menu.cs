// <copyright file="Menu.cs" company="MISIS">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Основной класс меню.
/// </summary>
public class Menu
{
    /// <summary>
    /// Представляет меню приложения.
    /// </summary>
    /// <param name="args">Аргументы для базового класса Main.</param>
    public static void Main(string[] args)
    {
        Console.WriteLine("Please, choose the game: ");
        Console.WriteLine("1. Game \"НОК\"");
        Console.WriteLine("2. Game \"Геометрическая прогрессия\"");
        Console.Write("Enter the number of the game you want to play: ");

        string? choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                LCMGame.Play();
                break;
            case "2":
                GeometricProgrssionGame.Play();
                break;
            default:
                Console.WriteLine("Wrong choice. Exit the program.");
                break;
        }
    }
}