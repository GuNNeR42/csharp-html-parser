namespace HTML_CSV_processing;

class Program
{
    static void Main(string[] args)
    {
        DataProcessor processor = new DataProcessor(new DataReader(), "./game_orders.csv");
        HtmlReader reader = new HtmlReader();


        DateTime dateFrom = UserInterviewer.GetDate("Enter Start Date in format 'YYYY-MM-DD'");
        Console.WriteLine(dateFrom.ToString());

        DateTime dateTo = UserInterviewer.GetDate("Enter End Date in format 'YYYY-MM-DD'");
        Console.WriteLine(dateTo.ToString());

        string tableDataHtmlFormat = "";

        foreach(GameOrderStatistics filteredStat in processor.FilterByDate(dateFrom, dateTo))
        {
            tableDataHtmlFormat +=
                $"<tr>\n" +
                $"  <td>{filteredStat.GameTitle}</td>\n" +
                $"  <td>foo</td>\n" +
                $"  <td>foo</td>\n" +
                $"  <td>bar</td>\n" +
                $"</tr>\n";
        }

        string page = reader.ReadHtml(path: "./template.html");


        //string formatedPage = string.Format(format:page, arg0:dateFrom.ToString(), arg1:dateTo.ToString(), arg2:tableDataHtmlFormat);

        //Console.WriteLine(formatedPage);

        page = page.Replace("{0}", dateFrom.ToString()).Replace("{1}", dateTo.ToString()).Replace("{2}", tableDataHtmlFormat);

        Console.WriteLine(page);
        

        Console.ReadKey();
    }
}

public static class Logger
{

}
public class HtmlReader
{
    public string ReadHtml(string path)
    {
        if (!File.Exists(path)) throw new Exception();
        return File.ReadAllText(path);
    }
}

public class HtmlWriter
{

}
