namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // We begin our entire program with tryAgain while loop, which can make us restart it later.
            // Here is the main code, where we first ask the difficulty choice of the number guessing game and then the program gets a secret number within that difficulty range.

            bool tryAgain = true;
            while (tryAgain)
            {
                
                Console.WriteLine("Välkommen! Jag tänker på ett nummer. Kan du gissa vilket? Du får fem försök.");
                Console.WriteLine("Vänligen välj en svårighetsgrad först: Välj en siffra mellan \"1\" till \"4\".");

                // Here is a new while loop that checks user input to use as a difficulty choice. User is only allowed to write a number between 1-4. 

                int difficultyNumber = 0;
                bool validDifficultyInput = false;

                while (!validDifficultyInput)
                {
                    if (int.TryParse(Console.ReadLine(), out difficultyNumber))
                    {
                        if (difficultyNumber >= 1 && difficultyNumber <= 4)
                        {
                            validDifficultyInput = true;
                        }
                        else
                        {
                            Console.WriteLine("Ogiltig inmatning, välj mellan \"1\" till \"4\".");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ogiltig inmatning, det måste vara en siffra mellan \"1\" till \"4\".");
                    }
                }

                Console.WriteLine($"Jag tänker på ett tal mellan 1 och {DifficultyChoice(difficultyNumber)}, gissa vilket:");

                // Here is a random number, then we add the difficulty depending what the user picked in difficultyNumber.

                int secretNumber = 0;
                Random random = new Random();
                secretNumber = random.Next(1, DifficultyChoice(difficultyNumber) + 1);

                CheckGuess(secretNumber);

                // Here we have restartAgain where we ask user if they want to restart the entire program.

                string restartAgain;
                while (true)
                {
                    Console.WriteLine("Vill du starta om programmet? Skriv \"ja\" eller \"nej\".");
                    restartAgain = Console.ReadLine() ?? "";
                    if (restartAgain.ToLower() == "ja")
                    {
                        Console.WriteLine("Startar om programmet efter 1 sekund...");
                        Thread.Sleep(1000);
                        Console.Clear();
                        tryAgain = true;
                        break;
                    }
                    else if (restartAgain.ToLower() == "nej")
                    {
                        Console.WriteLine("Programmet avslutas om 1 sekund... Hej då!");
                        Thread.Sleep(1000);
                        tryAgain = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Du måste ange \"ja\" eller \"nej\"");
                    }
                }
            }
        }

        // Difficulty choice depending on users input of number 1-4. A default case is always needed so it returns something, but it will never happen!

        public static int DifficultyChoice(int difficultyNumber)
        {
            switch (difficultyNumber)
            {
                case 1:
                    return 10;
                case 2:
                    return 25;
                case 3:
                    return 50;
                case 4:
                    return 100;
                default:
                    return 0;
            }
        }

        // CheckGuess method which handles the guessing logic itself.

        public static void CheckGuess(int secretNumber)
        {
            int guessNumber = 0;
            int guessAmounts = 0;
            while ((guessNumber != secretNumber) && guessAmounts < 5)
            {
                if (!int.TryParse(Console.ReadLine(), out guessNumber))
                {
                    Console.WriteLine("Det var ingen giltig siffra, försök igen.");
                    continue;
                }
                if (guessNumber < secretNumber)
                {
                    guessAmounts++;
                    Console.WriteLine($"Du har gissat för lågt tal! Du har gissat {guessAmounts} gånger.");
                }
                else if (guessNumber > secretNumber)
                {
                    guessAmounts++;
                    Console.WriteLine($"Du har gissat för högt tal! Du har gissat {guessAmounts} gånger.");
                }
            }
            if (guessNumber == secretNumber)
            {
                guessAmounts++;
                Console.WriteLine($"Wohoo! Du klarade det! Talet var {secretNumber}, efter {guessAmounts} försök.");
            }
            else
            {
                Console.WriteLine($"Tyvärr, du lyckades inte gissa talet på fem försök! Rätt tal var {secretNumber}.");
            }
        }
    }
}