using System.Globalization;

namespace HTML_CSV_processing;

public static class UserInterviewer
{
    public static DateTime GetDate(string message)
    {
        DateTime date;
        Console.WriteLine(message);
        DateTime.TryParseExact(Console.ReadLine(), format: "yyyy-MM-dd", null, DateTimeStyles.None, out date);
        //DateTime.TryParse(Console.ReadLine(), out date);
        Logger.FileLog($"Entered date: {date.ToString("dd/MM/yyyy")}");
        return date;
    }
}