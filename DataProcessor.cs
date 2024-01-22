namespace HTML_CSV_processing;

public class DataProcessor
{
    public List<GameOrderStatistics> Data { get; set; }
    public string Path { get; set; }
    public DateHandler DateHandler { get; set; }



    public DataProcessor(string path = "./", string datePattern = "yyyy-MM-dd")
    {
        Path = path;
        Data = ReadCSV(Path);
        DateHandler = new DateHandler(datePattern);

    }



    public GameOrderStatistics[] FilterByDate(DateTime dateFrom, DateTime dateTo)
    {
        GameOrderStatistics[] ordered =
            Data.Where(s => s.OrderDate >= dateFrom)
                .Where(s => s.OrderDate <= dateTo)
                .ToArray();
        return ordered;
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
                    stats.Add(ParseLine(rdr.ReadLine()));
                }
            }
        }
        return stats;
    }

    public GameOrderStatistics ParseLine(string line)
    {
        string[] data = line.Split(',');

        string email = data[0];
        string game = data[1];
        string platform = data[2];
        DateTime orderDate = DateHandler.Parse(data[3]);
        string location = data[4];

        return new GameOrderStatistics(email, game, platform, orderDate, location);
    }

}
