namespace HTML_CSV_processing;

public static class DataWriter
{
    public static bool WriteTextFile(string contents, string path = "./export.html")
    {
        try
        {
            File.WriteAllText(path, contents);
            return true;
        }
        catch(Exception e)
        {
            Logger.Log(e.Message);
            return false;
        }
    }

}
