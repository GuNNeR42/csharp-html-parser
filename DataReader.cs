namespace HTML_CSV_processing;

public class DataReader
{
    public LineParser Parser { get; set; }

    public DataReader()
    {
        Parser = new LineParser(datePattern: "yyyy-MM-dd");
    }

    public List<GameOrderStatistics> ReadCSV(string path, bool firstLineHeader = true)
    {
        List<GameOrderStatistics> stats = new List<GameOrderStatistics>();

        using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            using (StreamReader rdr = new StreamReader(stream))
            {
                if (firstLineHeader) rdr.ReadLine(); //skips header

                while (!rdr.EndOfStream)
                {
                    stats.Add(Parser.ParseLine(rdr.ReadLine()));
                }
            }
        }
        return stats;
    }
}
