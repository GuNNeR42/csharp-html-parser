namespace HTML_CSV_processing;

public static class Logger
{
    public static void Log(string message)
    {
        FileLog(message);
        Console.WriteLine(message);
    }

    private static void FileLog(string message)
    {
        string log = $"t:{DateTime.Now.ToString()}; msg: {message}";
        File.AppendAllText(path: "./log.txt", log);
    }
}
