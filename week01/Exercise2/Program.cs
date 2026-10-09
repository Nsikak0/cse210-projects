using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string answer = Console.ReadLine();
        int grade = int.Parse(answer);

        string letterGrade = "";

        if (grade >= 90)
        {
            letterGrade = "A";
        }
        else if (grade >= 80)
        {
            letterGrade = "B";
        }
        else if (grade >=70)
        {
            letterGrade = "C";
        }
        else if (grade >=60 )
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }
        string letterGradeWithSign = "";
        int lastDigit = grade % 10;

        if (lastDigit >=7 )
        {
            letterGradeWithSign = "+";
        }
        else if (lastDigit<3)
        {
            letterGradeWithSign = "-";
        }
        else
        {
            letterGradeWithSign = "";
        }

        if (grade >=93)
        {
            letterGradeWithSign = "";
        }
        if (letterGrade == "F")
        {
            letterGradeWithSign = "";
        }

        Console.WriteLine($"Your grade is: {letterGrade}{letterGradeWithSign}");

        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course. ");
        }
        else
        {
            Console.WriteLine("Don't Give up, Better luck next time!");
        }
    }
}