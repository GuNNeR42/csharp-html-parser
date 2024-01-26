using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HTML_CSV_processing;

public static class UserInterviewer
{
    public static DateTimeHandler Dth = new DateTimeHandler(DefaultSettings.UserInputDateTimeFormat);

    public static DateTime GetDate(string message)
    {
        DateTime date;
        Console.WriteLine(message);
        date = ConfirmDate(Console.ReadLine());
        return date;
    }

    private static DateTime ConfirmDate(string userInput)
    {
        DateTime date = Dth.Parse(userInput);

        Logger.FileLog($"Entered: {userInput}\nParsed{date.ToString(DefaultSettings.UserInputDateTimeFormat)}");
        Console.WriteLine(  $"Entered {userInput}\n" +
                            $"Parsed value : {date.ToString(DefaultSettings.UserInputDateTimeFormat)}\n" +
                            $"Press enter to confirm or rewrite the value");
        userInput = Console.ReadLine();

        if (!string.IsNullOrEmpty(userInput)) return ConfirmDate(userInput);

        return date;
    }
}