using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        DisplayMessage();

        string userName = PromptUserName();

        int favoriteNumber = PromptUserNumber();

        int squaredNumber = UserSquareNumber(favoriteNumber);

        DisplayResult(userName, squaredNumber);
    }
    static void DisplayMessage()
    {
        Console.WriteLine("Welcome to the program!");

    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
  

        return char.ToUpper(name[0]) + name.Substring(1).ToLower();
    }

    static int PromptUserNumber()
    {
        Console.Write("What is your favorite Number? ");
        int number = int.Parse(Console.ReadLine());

        return number;
    }
    static int UserSquareNumber(int number)
    {
        int square = number * number;

        return square;
    }

    static void DisplayResult (string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
}