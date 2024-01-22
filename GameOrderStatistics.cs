namespace HTML_CSV_processing;

public class GameOrderStatistics
{
    public string UserEmail { get; set; }
    public string GameTitle { get; set; }
    public string Platform { get; set; }
    public DateTime OrderDate { get; set; }
    public string OrderLocation { get; set; }


    public GameOrderStatistics(string userEmail, string gameTitle, string platform, DateTime orderDate, string orderLocation)
    {
        UserEmail = userEmail;
        GameTitle = gameTitle;
        Platform = platform;
        OrderDate = orderDate;
        OrderLocation = orderLocation;
    }

    public override string ToString()
    {
        return $"email: {UserEmail}; title: {GameTitle}; platform: {Platform}; order date: {OrderDate}; order location: {OrderLocation}";
    }
}