using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data;
using System.Reflection.Metadata;

namespace HTML_CSV_processing;

class Program
{
    static void Main(string[] args)
    {
        DateTime dateFrom = UserInterviewer.GetDate("Enter Start Date in format 'YYYY-MM-DD'");
        Console.WriteLine(dateFrom.ToString("dd/MM/yyyy"));

        DateTime dateTo = UserInterviewer.GetDate("Enter End Date in format 'YYYY-MM-DD'");
        Console.WriteLine(dateTo.ToString("dd/MM/yyyy"));


        DataReaderParser drp = new DataReaderParser(dateTimeFormat: "yyyy-MM-dd", path: "./game_orders.csv");
        DataProcessor dataProc = new DataProcessor();

        List<GameOrderStatistics> rawData = drp.ReadCSV();

        GameStatistics[] filtered = dataProc.FilterData(dateFrom, dateTo, rawData);

        string page = HtmlProcessor.GetHtmlPage(dateFrom, dateTo, filtered);

        DataWriter.WriteTextFile(contents:page);
        

        Console.ReadKey();
    }
}
