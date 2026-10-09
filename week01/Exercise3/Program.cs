using System;

class Program
{
    static void Main(string[] args)
    {
        bool playAgain;

        do
        {
            int magicNumber;
            while (true)
            {
                Console.Write("Choose the magic number: ");
                string magicNumberInput = Console.ReadLine();

                if (magicNumberInput == null)
                {
                    return;
                }

                if (int.TryParse(magicNumberInput, out magicNumber))
                {
                    break;
                }

                Console.WriteLine("Please enter a whole number.");
            }

            int guess = -1;
            int guessNo = 0;

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string input = Console.ReadLine();

                if (input == null)
                {
                    return;
                }

                if (!int.TryParse(input, out guess))
                {
                    Console.WriteLine("Please enter a whole number.");
                    continue;
                }

                guessNo++;

                if (magicNumber > guess)
                {
                    Console.WriteLine("Guess higher.");
                }
                else if (magicNumber < guess)
                {
                    Console.WriteLine("Guess lower.");
                }
                else
                {
                    Console.WriteLine("You guessed right!");
                }
            }

            Console.WriteLine($"You made {guessNo} guesses.");
            Console.Write("Would you like to play again? (yes/no): ");
            string response = Console.ReadLine();
            playAgain = string.Equals(
                response?.Trim(),
                "yes",
                StringComparison.OrdinalIgnoreCase);
        } while (playAgain);
    }
}