namespace HTML_CSV_processing;

public static class Logger
{
    public static void Log(string message)
    {
        FileLog(message);
        Console.WriteLine(message);
    }

    public static void FileLog(string message)
    {
        string log = $"t:{DateTime.Now.ToString()}; msg: {message}\n";
        File.AppendAllText(path: DefaultSettings.LogPath, log);
    }
}
