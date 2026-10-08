using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private readonly List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are your personal strengths?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };
    private readonly PromptGenerator _promptGenerator;

    public ListingActivity()
        : base(
            "Listing",
            "This activity will help you reflect on the good things in your life by listing as many things as you can in a certain area.")
    {
        _promptGenerator = new PromptGenerator(_prompts);
    }

    public void Run()
    {
        DisplayStartingMessage();

        string prompt = _promptGenerator.GetRandomOption();

        Console.WriteLine("\nList as many responses as you can to the following prompt:");
        Console.WriteLine($"\n--- {prompt} ---");

        Console.Write("\nYou may begin in: ");
        ShowCountDown(5);

        List<string> items = new List<string>();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");

            string response = Console.ReadLine();

            if (response == null)
            {
                break;
            }

            if (!string.IsNullOrWhiteSpace(response))
            {
                items.Add(response);
            }
        }

        Console.WriteLine($"\nYou listed {items.Count} items!");

        DisplayEndingMessage();
    }
}