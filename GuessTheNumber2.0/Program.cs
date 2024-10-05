namespace GuessTheNumber2._0;

internal class Program
{
    static void Main(string[] args)
    {
        Display display = new Display();
        Display.Logo();
        display.Menu();

        Console.ReadLine();
    }
}