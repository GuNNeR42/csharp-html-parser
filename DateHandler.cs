using System.Globalization;

namespace HTML_CSV_processing;

public class DateHandler
{
    public string Pattern { get; set; }

    public DateHandler(string pattern)
    {
        Pattern = pattern;
    }



    public DateTime Parse(string dateValue)
    {
        DateTime parsedDate;
        DateTime.TryParseExact(dateValue, Pattern, null, DateTimeStyles.None, out parsedDate);
        return parsedDate;
    }
}