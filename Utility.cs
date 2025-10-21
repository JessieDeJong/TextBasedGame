namespace TextBasedAdventure;

public class Utility
{
    public static void UserIndent() => WriteColor(ConsoleColor.Cyan,"  > ");

    public static void WriteColor(ConsoleColor color, string text)
    {
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ResetColor();
    }

    public static void WriteLineColor(ConsoleColor color, string text)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor();
    }

    public static void GameOver() //prompts user to press any key to continue > C.Clear
    {
        WriteLineColor(ConsoleColor.Red,@"
 _______  _______  __   __  _______    _______  __   __  _______  ______   
|       ||   _   ||  |_|  ||       |  |       ||  | |  ||       ||    _ |  
|    ___||  |_|  ||       ||    ___|  |   _   ||  |_|  ||    ___||   | ||  
|   | __ |       ||       ||   |___   |  | |  ||       ||   |___ |   |_||_ 
|   ||  ||       ||       ||    ___|  |  |_|  ||       ||    ___||    __  |
|   |_| ||   _   || ||_|| ||   |___   |       | |     | |   |___ |   |  | |
|_______||__| |__||_|   |_||_______|  |_______|  |___|  |_______||___|  |_|");
        Console.ReadLine();
    }

}