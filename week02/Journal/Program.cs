using System;

class Program
{
    static void Main(string[] args)
    {
        // Beyond the core requirements, entries include a mood and the menu reports journal statistics.
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        while (true)
        {
            Console.WriteLine("\n=== Journal Menu ===");
            Console.WriteLine("1. Write a New Entry");
            Console.WriteLine("2. Display Journal");
            Console.WriteLine("3. Save Journal");
            Console.WriteLine("4. Load Journal");
            Console.WriteLine("5. Show Statistics");
            Console.WriteLine("6. Quit");

            Console.Write("Choose an option: ");
            string input = Console.ReadLine();

            if (input == null)
            {
                break;
            }

            if (int.TryParse(input, out int choice))
            {
                switch (choice)
                {
                    case 1:
                        WriteEntry(journal, promptGenerator);
                        break;

                    case 2:
                        journal.DisplayAll();
                        break;

                    case 3:
                        SaveJournal(journal);
                        break;

                    case 4:
                        LoadJournal(journal);
                        break;

                    case 5:
                        journal.ShowStatistics();
                        break;

                    case 6:
                        Console.WriteLine("Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }
    }

    static void WriteEntry(Journal journal, PromptGenerator promptGenerator)
    {
        string prompt = promptGenerator.GetRandomPrompt();

        Console.WriteLine($"\nPrompt: {prompt}");
        Console.Write("> ");
        string response = Console.ReadLine();

        if (response == null)
        {
            return;
        }

        Console.Write("What is your mood today? ");
        string mood = Console.ReadLine();

        if (mood == null)
        {
            return;
        }

        Entry entry = new Entry();

        entry.Date = DateTime.Now.ToShortDateString();
        entry.PromptText = prompt;
        entry.EntryText = response;
        entry.Mood = mood;

        journal.AddEntry(entry);

        Console.WriteLine("Journal entry added successfully.");
    }

    static void SaveJournal(Journal journal)
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();

        if (filename == null)
        {
            return;
        }

        journal.SaveToFile(filename);
    }

    static void LoadJournal(Journal journal)
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();

        if (filename == null)
        {
            return;
        }

        journal.LoadFromFile(filename);
    }
}