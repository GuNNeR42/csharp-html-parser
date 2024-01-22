namespace HTML_CSV_processing;

public class DataProcessor
{
    public DataReader Rdr { get; set; }
    public List<GameOrderStatistics> Data { get; set; }
    public string Path { get; set; }

    public DataProcessor(DataReader rdr, string path = "./")
    {
        Rdr = rdr;
        Path = path;
        Data = Rdr.ReadCSV(Path);
    }

    public GameOrderStatistics[] FilterByDate(DateTime dateFrom, DateTime dateTo)
    {
        GameOrderStatistics[] ordered =
            Data.Where(s => s.OrderDate >= dateFrom)
                .Where(s => s.OrderDate <= dateTo)
                .ToArray();
        return ordered;
    }
}
