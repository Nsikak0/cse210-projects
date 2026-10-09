using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private readonly List<string> _prompts = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of God in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What made me smile today?",
        "What challenge did I overcome today?",
        "What is one thing I am grateful for today?"
    };

    private readonly Random _random = new Random();

    public string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Count)];
    }
}