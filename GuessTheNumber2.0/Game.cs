/*
CREATED BY Perss00n
Email: Perss00n@gmail.com
Discord: Perss00n
*/

namespace GuessTheNumber2._0;
public class Game
{
    public static int TotalRoundsPlayed { get; private set; } = 0;

    public void Play(Player player, int level)
    {
        Console.Clear();

        int secretNum = 0;

        if (level == 1)
            secretNum = Random.Shared.Next(1, 31);
        else if (level == 2)
            secretNum = Random.Shared.Next(1, 61);
        else if (level == 3)
            secretNum = Random.Shared.Next(1, 121);

        int userGuess = 0;
        int guessTimer = 30;
        int maxAllowedGuesses = 10;
        bool isValidGuess = false;

        Console.WriteLine($"###RULES!###\nYou have {guessTimer} seconds to guess the secret number ranging from {(level == 1 ? "1 - 30" : level == 2 ? "1 - 60" : "1 - 120")} and a maximum of {maxAllowedGuesses} guesses! goGoGO!!!");
        do
        {
            Task inputTask = Task.Run(() =>
            {
                Console.Write("Guess the number: ");
                isValidGuess = Int32.TryParse(Console.ReadLine(), out userGuess);
            });

            bool inputReceivedInTime = Task.WaitAny(new[] { inputTask }, TimeSpan.FromSeconds(guessTimer)) == 0;

            if (!inputReceivedInTime)
            {
                player.UpdateLeaderBoard(player.UserName, maxAllowedGuesses);
                Console.WriteLine("Time is up! You didn't guess in time. Game Over!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                break;
            }

            if (!isValidGuess)
            {
                Console.Clear();
                Console.WriteLine("Please enter a valid integer! Try again...");
                continue;
            }

            if (userGuess != secretNum)
            {
                player.UpdateNumbOfGuesses();
                string lowerOrHigherMsg = "";

                switch (level)
                {
                    case 1:
                    case 2:
                        lowerOrHigherMsg = userGuess > secretNum ? $"{userGuess} was too high!" : $"{userGuess} was too low!";
                        break;
                    case 3:
                        lowerOrHigherMsg = Math.Abs(userGuess - secretNum) <= 10 ? (userGuess > secretNum ? $"{userGuess} was too high!" : $"{userGuess} was too low!") : $"{userGuess} was wrong!";
                        break;
                }

                if (player.NumbOfGuesses == maxAllowedGuesses)
                {
                    Console.Clear();
                    Console.WriteLine($"{lowerOrHigherMsg.TrimEnd('!')} and you are out of guesses!\nGame Over! Press any key to continue...");
                    Console.ReadKey(true);
                    player.UpdateLeaderBoard(player.UserName, player.NumbOfGuesses);
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"{lowerOrHigherMsg} Try Again! You have guessed {player.NumbOfGuesses} times!");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Congratulations! You guessed the right number -> '{secretNum}'");
                Console.WriteLine($"Your score of {player.NumbOfGuesses} guesses has been added to the leaderboard. Good Job!");
                Console.WriteLine("Press any key to continue...");
                player.UpdateLeaderBoard(player.UserName, player.NumbOfGuesses);
                player.HasGuessedTheSecretNum = true;
                Console.ReadKey();
            }

        } while (!player.HasGuessedTheSecretNum && player.NumbOfGuesses < maxAllowedGuesses);

        TotalRoundsPlayed++;
        Console.WriteLine($"Total rounds played: {TotalRoundsPlayed}/5");

        Display.LeaderBoard();
    }
}
