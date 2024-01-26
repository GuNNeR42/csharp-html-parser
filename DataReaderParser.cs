namespace HTML_CSV_processing;

public class DataReaderParser
{

    public DateTimeHandler DTHandler { get; set; }
    public string Path { get; set; }


    public DataReaderParser(string dateTimeFormat, string path)
    {
        DTHandler = new DateTimeHandler(pattern: dateTimeFormat);
        Path = path;
    }

    /// <summary>
    /// Reads CSV file from location specified in instance property "Path"
    /// </summary>
    /// <param name="firstLineHeader">Specify if the file contains header</param>
    /// <returns>List of GameOrderStatistics - one instance for each line</returns>
    public List<GameOrderStatistics> ReadCSV(bool firstLineHeader = true)
    {
        List<GameOrderStatistics> stats = new List<GameOrderStatistics>();

        try
        {
            using (FileStream stream = new FileStream(Path, FileMode.Open, FileAccess.Read))
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
        }
        catch (Exception e)
        {
            Logger.Log(e.Message);
        }

        return stats;
    }

    /// <summary>
    /// Creates instance of GameOrderStatistics and parses given line to it
    /// </summary>
    /// <param name="line">Line from CSV file</param>
    /// <returns>GameOrderStatistics instance with filled information</returns>
    private GameOrderStatistics ParseLine(string line)
    {
        string[] data = line.Split(',');

        string email = data[0];
        string game = data[1];
        string platform = data[2];
        DateTime orderDate = DTHandler.Parse(data[3]);
        string location = data[4];

        return new GameOrderStatistics(email, game, platform, orderDate, location);
    }

}
