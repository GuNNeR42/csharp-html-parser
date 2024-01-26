using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HTML_CSV_processing;

public static class HtmlProcessor
{
    public static string GetHtmlPage(DateTime dateFrom, DateTime dateTo, GameStatistics[] filteredData, string pathToTemplate)
    {
        string page = ReadTemplate(pathToTemplate);
        page = page .Replace("{0}", dateFrom.ToString("dddd, dd/MM/yyyy"))
                    .Replace("{1}", dateTo.ToString("dddd, dd/MM/yyyy"))
                    .Replace("{2}", ReturnHtmlTableRows(filteredData));

        return page;
    }

    public static string ReadTemplate(string path)
    {
        string template = "";
        try
        {
            template = File.ReadAllText(path);
        }
        catch(Exception e)
        {
            Logger.Log(e.Message);
        }
        return template;
    }

    public static string ReturnHtmlTableRows(GameStatistics[] filteredData)
    {
        string HtmlTableRows = "";
        foreach (GameStatistics filteredStat in filteredData)
        {
            HtmlTableRows +=
                $"<tr>\n" +
                $"  <td>{filteredStat.GameTitle}</td>\n" +
                $"  <td>{filteredStat.NumberOfOrders}</td>\n" +
                $"  <td>{filteredStat.MostUsedPlatform}</td>\n" +
                $"  <td>{filteredStat.LastOrder.ToString(DefaultSettings.HtmlParseDateTimeFormat)}</td>\n" +
                $"</tr>\n";
        }
        return HtmlTableRows;
    }
}