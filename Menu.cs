using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Menu
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please, choose the game: ");
        Console.WriteLine("1. Игра \"НОК\"");
        Console.WriteLine("2. Игра \"Геометрическая прогрессия\"");
        Console.Write("Введите номер игры, в которую хотите сыграть: ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                LCMGame.Play();
                break;
            case "2":
                GeometricProgrssionGame.Play();
                break;
            default:
                Console.WriteLine("Неверный выбор. Выход из программы.");
                break;
        }
    }
}