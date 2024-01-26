namespace HTML_CSV_processing;

public class DataProcessor
{

    /// <summary>
    ///     Filters data from GameOrderStatistics by entered time frame and converts them to GameStatistics
    /// </summary>
    /// <param name="dateFrom">First (odlest) date</param>
    /// <param name="dateTo">Last (newest) date</param>
    /// <param name="rawData">List of data obtained by DataReaderParser</param>
    /// <returns>Array of GameStatistics[] sorted by GameTitle alphabetically</returns>
    public GameStatistics[] FilterData(DateTime dateFrom, DateTime dateTo, List<GameOrderStatistics> rawData)
    {
        //filters raw data with DateTime restrictions
        GameOrderStatistics[] dateRestricted = FilterByDate(dateFrom, dateTo, rawData);

        //makes array of unique GameTitles
        string[] uniqueGames = GetUniqueGames(dateRestricted);

        //preparation of list containing filtered data
        List<GameStatistics> filteredData = new List<GameStatistics>();

        //creates GameStatistics instance for each unique game
        foreach (string game in uniqueGames)
        {
            string mostUsed = GetMostUsedPlatform(game, dateRestricted);

            int numOfOrders = GetNumberOfOrdersPerGame(game, dateRestricted);

            DateTime lastDatePurchased = GetLastDatePurchased(game, dateRestricted);

            filteredData.Add(new GameStatistics(game, numOfOrders, mostUsed, lastDatePurchased));

            filteredData = filteredData.OrderBy(d => d.GameTitle).ToList();

        }

        return filteredData.ToArray();

    }

    /// <summary>
    ///     Filters provided data by specified DateTime parameters
    /// </summary>
    /// <param name="dateFrom">First (odlest) date</param>
    /// <param name="dateTo">Last (newest) date</param>
    /// <param name="rawData">List of data obtained by DataReaderParser</param>
    /// <returns>Array of GameOrderStatistics that are inside entered time-frame</returns>
    private GameOrderStatistics[] FilterByDate(DateTime dateFrom, DateTime dateTo, List<GameOrderStatistics> rawData)
    {
        GameOrderStatistics[] filtered =
            rawData
                .Where(s => s.OrderDate >= dateFrom)
                .Where(s => s.OrderDate <= dateTo)
                .ToArray();
        return filtered;
    }

    /// <summary>
    ///     Looks for unique game titles 
    /// </summary>
    /// <returns>Array of strings - titles of unique games</returns>
    private string[] GetUniqueGames(GameOrderStatistics[] data)
    {
        return data.Select(d => d.GameTitle).Distinct().ToArray();
    }


    /// <summary>
    ///     Returns most used platform for specified game
    /// </summary>
    /// <param name="game">(string) Game title</param>
    /// <param name="statistics">Data to look at</param>
    /// <returns>String of most used platform</returns>
    private string GetMostUsedPlatform(string game, GameOrderStatistics[] statistics)
    {
        return statistics
            .Where(o => o.GameTitle == game)    // filter games by their title
            .GroupBy(o => o.Platform)           // groups them by their platform
            .OrderByDescending(g => g.Count())  // orders them by count in group
            .First().Key;                       // returns most used key (platform) 
    }

    /// <summary>
    ///     Returns numbers of orders per game
    /// </summary>
    /// <param name="game">(string) Game title</param>
    /// <param name="statistics">Data to look at</param>
    /// <returns>Number of orders</returns>
    private int GetNumberOfOrdersPerGame(string game, GameOrderStatistics[] statistics)
    {
        return statistics
            .Where(o => o.GameTitle == game)    // filter games by their title
            .Count();                           // returns count of them
    }

    /// <summary>
    ///     Returns DateTime of the most recent order
    /// </summary>
    /// <param name="game">(string) Game title</param>
    /// <param name="statistics">Data to look at</param>
    /// <returns>(DateTime) of the most recent order</returns>
    private DateTime GetLastDatePurchased(string game, GameOrderStatistics[] statistics)
    {
        return statistics
            .Where(o => o.GameTitle == game)    // filter games by their title
            .OrderByDescending(o => o.OrderDate)// orders them by DatePurchased, descending (newest to oldest)
            .Select(o => o.OrderDate).First();  // returns first DateTime
    }
}