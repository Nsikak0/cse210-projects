using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();

        // Creativity:
        // Added a level system.
        // Every 1000 points increases the player's level.

        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine($"Score: {manager.GetScore()}");
            Console.WriteLine($"Level: {manager.GetLevel()}");
            Console.WriteLine();

            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. Display all goals");
            Console.WriteLine("3. Record progress for a goal");
            Console.WriteLine("4. Save your goals to a file");
            Console.WriteLine("5. Load your goals from a file");
            Console.WriteLine("6. Quit the program");

            WritePrompt("Please pick a choice by entering a number from 1 to 6:");
            string choice = Console.ReadLine();

            if (choice == null)
            {
                break;
            }

            switch (choice)
            {
                case "1":
                    Console.WriteLine("What kind of goal would you like to create?");
                    Console.WriteLine("1. Simple goal (complete once)");
                    Console.WriteLine("2. Eternal goal (earn points each time)");
                    Console.WriteLine("3. Checklist goal (complete a target number of times)");

                    WritePrompt("Enter 1, 2, or 3 to choose a goal type:");
                    string type = Console.ReadLine();
                    if (type != "1" && type != "2" && type != "3")
                    {
                        Console.WriteLine("That goal type is not valid. Please choose 1, 2, or 3.");
                        break;
                    }

                    WritePrompt("Enter a short name for your goal:");
                    string name = Console.ReadLine();
                    if (name == null)
                    {
                        return;
                    }

                    WritePrompt("Describe what you will do to complete or work toward this goal:");
                    string description = Console.ReadLine();
                    if (description == null)
                    {
                        return;
                    }

                    WritePrompt("Enter the whole-number points earned each time you record this goal:");
                    string pointsInput = Console.ReadLine();
                    if (!int.TryParse(pointsInput, out int points) || points < 0)
                    {
                        Console.WriteLine("Points must be a non-negative whole number.");
                        break;
                    }

                    if (type == "1")
                    {
                        manager.AddGoal(
                            new SimpleGoal(
                                name,
                                description,
                                points));
                    }
                    else if (type == "2")
                    {
                        manager.AddGoal(
                            new EternalGoal(
                                name,
                                description,
                                points));
                    }
                    else if (type == "3")
                    {
                        WritePrompt("How many completions are needed to finish this checklist goal? Enter a positive whole number:");
                        string targetInput = Console.ReadLine();
                        if (!int.TryParse(targetInput, out int target) || target < 1)
                        {
                            Console.WriteLine("Target must be a positive whole number.");
                            break;
                        }

                        WritePrompt("How many bonus points should be awarded when you reach the target? Enter a whole number:");
                        string bonusInput = Console.ReadLine();
                        if (!int.TryParse(bonusInput, out int bonus) || bonus < 0)
                        {
                            Console.WriteLine("Bonus must be a non-negative whole number.");
                            break;
                        }

                        manager.AddGoal(
                            new ChecklistGoal(
                                name,
                                description,
                                points,
                                target,
                                bonus));
                    }

                    Console.WriteLine("Your goal has been created.");
                    break;

                case "2":
                    manager.ListGoals();
                    break;

                case "3":
                    manager.ListGoals();

                    WritePrompt("Enter the number beside the goal you completed:");
                    string indexInput = Console.ReadLine();
                    if (!int.TryParse(indexInput, out int index))
                    {
                        Console.WriteLine("Please enter a whole-number goal number from the list.");
                        break;
                    }

                    manager.RecordEvent(index - 1);

                    break;

                case "4":
                    WritePrompt("Enter the file path where you want to save your goals:");
                    string saveFile =
                        Console.ReadLine();

                    manager.SaveGoals(saveFile);

                    break;

                case "5":
                    WritePrompt("Enter the file path of the saved goals you want to load:");
                    string loadFile =
                        Console.ReadLine();

                    manager.LoadGoals(loadFile);

                    break;

                case "6":
                    Console.WriteLine("Goodbye! Your Eternal Quest session has ended.");
                    running = false;
                    break;

                default:
                    Console.WriteLine("That choice is not valid. Please enter a number from 1 to 6.");
                    break;
            }
        }
    }

    private static void WritePrompt(string prompt)
    {
        Console.Write($"{prompt.TrimEnd()} ");
    }
}