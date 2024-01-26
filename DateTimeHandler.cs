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
    /// If failed to parse: returns DateTime.MinValue
    /// </summary>
    /// <param name="dateValue">String date value</param>
    /// <returns>Parsed DateTime</returns>
    public DateTime Parse(string dateValue)
    {
        DateTime parsedDate = DateTime.MinValue;
        try
        {
            DateTime.TryParseExact(dateValue, Pattern, null, DateTimeStyles.None, out parsedDate);
        }
        catch (Exception e)
        {
            Logger.Log(e.Message);
        }

        return parsedDate;
    }
}