using System.Globalization;

namespace HTML_CSV_processing;

public class DateTimeHandler
{
    public string Pattern { get; set; }

    public DateTimeHandler(string pattern)
    {
        Pattern = pattern;
    }


    /// <summary>
    /// Parses string to DateTime
    /// </summary>
    /// <param name="dateValue">String date value</param>
    /// <returns>Parsed DateTime</returns>
    public DateTime Parse(string dateValue)
    {
        DateTime parsedDate;
        DateTime.TryParseExact(dateValue, Pattern, null, DateTimeStyles.None, out parsedDate);
        return parsedDate;
    }
}