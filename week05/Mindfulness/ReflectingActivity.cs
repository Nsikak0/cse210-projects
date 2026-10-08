using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private readonly List<string> _prompts = new List<string>()
    {
        "Think of a time when you helped someone.",
        "Think of a time when you overcame a challenge.",
        "Think of a time when you did something difficult.",
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something you were afraid to try."
    };

    private readonly List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private readonly PromptGenerator _promptGenerator;
    private readonly PromptGenerator _questionGenerator;

    public ReflectingActivity()
        : base(
              "Reflecting",
              "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _promptGenerator = new PromptGenerator(_prompts);
        _questionGenerator = new PromptGenerator(_questions);
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine(
            "\nConsider the following prompt:\n");

        Console.WriteLine(
            $"--- {_promptGenerator.GetRandomOption()} ---");

        DateTime endTime =
            DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.WriteLine(
                $"\n{_questionGenerator.GetRandomOption()}");

            int remainingSeconds = (int)Math.Ceiling((endTime - DateTime.Now).TotalSeconds);
            ShowSpinner(Math.Min(5, remainingSeconds));
        }

        DisplayEndingMessage();
    }
}