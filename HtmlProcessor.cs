namespace HTML_CSV_processing;

public class HtmlProcessor
{
    public string ReadTemplate(string path)
    {
        if (!File.Exists(path)) throw new Exception();
        return File.ReadAllText(path);
    }

    public string ReturnHtmlTableRows(GameOrderStatistics[] filteredData)
    {
        string HtmlTableRows = "";
        foreach (GameOrderStatistics filteredStat in filteredData)
        {
            HtmlTableRows +=
                $"<tr>\n" +
                $"  <td>{filteredStat.GameTitle}</td>\n" +
                $"  <td>foo</td>\n" +
                $"  <td>foo</td>\n" +
                $"  <td>bar</td>\n" +
                $"</tr>\n";
        }
        return HtmlTableRows;
    }


}
