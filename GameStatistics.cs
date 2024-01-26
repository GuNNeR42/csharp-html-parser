namespace HTML_CSV_processing;

public class GameStatistics
{
    public string GameTitle { get; set; }
    public int NumberOfOrders { get; set; }
    public string MostUsedPlatform { get; set; }
    public DateTime LastOrder { get; set; }

    public GameStatistics(string gameTitle, int numberOfOrders, string mostUsedPlatform, DateTime lastOrder)
    {
        GameTitle = gameTitle;
        NumberOfOrders = numberOfOrders;
        MostUsedPlatform = mostUsedPlatform;
        LastOrder = lastOrder;
    }
}