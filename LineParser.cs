namespace HTML_CSV_processing;

public class LineParser
{
    public DateHandler DateHandler { get; set; }


    public LineParser(string datePattern)
    {
        DateHandler = new DateHandler(pattern: datePattern);
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