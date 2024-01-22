using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data;

namespace HTML_CSV_processing;

class Program
{
    static void Main(string[] args)
    {
        DataProcessor dataProc = new DataProcessor(path: "./game_orders.csv");
        HtmlProcessor htmlProc = new HtmlProcessor();


        DateTime dateFrom = UserInterviewer.GetDate("Enter Start Date in format 'YYYY-MM-DD'");
        Console.WriteLine(dateFrom.ToString());

        DateTime dateTo = UserInterviewer.GetDate("Enter End Date in format 'YYYY-MM-DD'");
        Console.WriteLine(dateTo.ToString());

        string tableDataHtmlFormat = "";


        string page = htmlProc.ReadTemplate(path: "./template.html");


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
