using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
              "Breathing",
              "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            int remainingSeconds = (int)Math.Ceiling((endTime - DateTime.Now).TotalSeconds);
            Console.Write("\nBreathe in...");
            ShowCountDown(Math.Min(4, remainingSeconds));

            if (DateTime.Now < endTime)
            {
                remainingSeconds = (int)Math.Ceiling((endTime - DateTime.Now).TotalSeconds);
                Console.Write("\nBreathe out...");
                ShowCountDown(Math.Min(4, remainingSeconds));
            }

            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}