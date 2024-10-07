/*
CREATED BY Perss00n
Email: Perss00n@gmail.com
Discord: Perss00n
*/

namespace GuessTheNumber2._0;
public class Player
{
    private string userName = string.Empty;

    public string UserName
    {
        get { return char.ToUpper(userName[0]) + userName[1..].ToLower(); }
        private set { userName = value; }
    }
    public int Score { get; private set; }
    public int NumbOfGuesses { get; private set; }
    public static string[] LeaderBoardName { get; set; } = new string[5];
    public static int[] LeaderBoardGuesses { get; set; } = new int[5];
    public bool HasGuessedTheSecretNum { get; set; }

    public void NewUser()
    {
        string input;
        bool showError = false;

        do
        {
            Console.Clear();
            Display.Logo();

            if (showError)
                Console.WriteLine("Name can't be empty and must contain at least 2 letters! Try again...\n");

            Console.Write("Please enter your username: ");
            input = Console.ReadLine()!.Trim();

            showError = String.IsNullOrEmpty(input) || input.Length < 2;

        }
        while (showError);

        UserName = input;
    }


    public void UpdateNumbOfGuesses()
    {
        NumbOfGuesses++;
    }

    public void UpdateScore()
    {
        Score++;
    }

    public void UpdateLeaderBoard(string name, int guesses)
    {
        for (int i = 0; i < LeaderBoardName.Length; i++)
        {
            if (string.IsNullOrEmpty(LeaderBoardName[i]))
            {
                LeaderBoardName[i] = name;
                LeaderBoardGuesses[i] = guesses;
                break;
            }
        }
    }
}