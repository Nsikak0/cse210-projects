using System;

class Program
{
    // Creative extras: prompts and reflection questions are randomized without repeats until each set
    // has been used, and the program also validates durations and safely handles redirected input.
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            // Extra robustness: avoid clearing terminals that do not support screen control.
            if (!Console.IsOutputRedirected)
            {
                Console.Clear();
            }

            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start Breathing Activity");
            Console.WriteLine("  2. Start Reflecting Activity");
            Console.WriteLine("  3. Start Listing Activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();
            if (choice == null)
            {
                // Treat end-of-input like Quit so redirected input cannot leave the menu looping.
                running = false;
                continue;
            }

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    break;

                case "2":
                    ReflectingActivity reflecting = new ReflectingActivity();
                    reflecting.Run();
                    break;

                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    break;

                case "4":
                    running = false;
                    break;

                default:
                    Console.WriteLine("\nInvalid choice. Press Enter to try again.");
                    Console.ReadLine();
                    break;
            }

            if (running && choice != "4")
            {
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }
    }
}