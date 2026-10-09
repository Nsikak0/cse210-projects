using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name? ");
        string first = Console.ReadLine();

        // Display user input in Capitalized format.
        string result_1 = char.ToUpper(first[0])+ first.Substring(1);

        Console.Write("What is your last name? ");
        string last = Console.ReadLine();

        // Display user input in Capitalized format.
        string result_2 = char.ToUpper(last[0])+ last.Substring(1);

        Console.WriteLine();

        Console.WriteLine ($"Your name is {result_2}, {result_1} {result_2}.");


    }
}
 