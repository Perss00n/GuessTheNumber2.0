/*
CREATED BY Perss00n
Email: Perss00n@gmail.com
Discord: Perss00n
*/

namespace GuessTheNumber2._0;
public class Display
{
    public void Menu()
    {
        int input;
        bool isValidInput;

        do
        {
            Console.WriteLine("1. Play Game (Easy)");
            Console.WriteLine("2. Play Game (Medium)");
            Console.WriteLine("3. Play Game (Hard)");
            Console.WriteLine("4. Look at the leaderboard");
            Console.WriteLine("5. Quit");

            Console.Write("Please select an option from the list above: ");

            isValidInput = Int32.TryParse(Console.ReadLine(), out input);

            if (!isValidInput || input < 1 || input > 5)
            {
                Logo();
                Console.WriteLine("Error! Please enter a valid integer! Try again...");
                continue;
            }

            switch (input)
            {
                case 1: StartGame(1); break;
                case 2: StartGame(2); break;
                case 3: StartGame(3); break;
                case 4: LeaderBoard(); break;
                case 5: Console.WriteLine("Thank you for playing! See ya around!"); return;
            }

        } while (Game.TotalRoundsPlayed < 5);

        Console.WriteLine("The game has ended. The maximum of 5 rounds has been played.");
        Console.WriteLine("The final score will be shown above. Thank you for playing! See ya around!");
    }

    public void StartGame(int level)
    {
        Display.Logo();
        Player player = new Player();
        player.NewUser();
        Game game = new Game();
        game.Play(player, level);
    }

    public static void Logo()
    {
        Console.Clear();
        Console.WriteLine("##########################");
        Console.WriteLine("#                        #");
        Console.WriteLine("#  Guess The Number 2.0  #");
        Console.WriteLine("#                        #");
        Console.WriteLine("#                        #");
        Console.WriteLine("#  Coded By Marcus Lehm  #");
        Console.WriteLine("#                        #");
        Console.WriteLine("#                        #");
        Console.WriteLine("##########################");
    }

    public static void LeaderBoard()
    {
        Console.Clear();
        Console.WriteLine("### LEADERBOARD ###");

        for (int i = 0; i < Player.LeaderBoardGuesses.Length; i++)
        {
            if (!string.IsNullOrEmpty(Player.LeaderBoardName[i]))
                Console.WriteLine($"{i + 1}. {Player.LeaderBoardName[i],-10} - {Player.LeaderBoardGuesses[i]} tries.");
            else
                Console.WriteLine($"{i + 1}. {"Name: N/A",-10} - {"Guesses: N/A",-5}");
        }
        Console.WriteLine();
    }
}
