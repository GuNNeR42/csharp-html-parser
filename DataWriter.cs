namespace HTML_CSV_processing;

public static class DataWriter
{
    public static bool WriteTextFile(string contents, string path)
    {
        try
        {
            File.WriteAllText(path, contents);
            Logger.Log("File successfully exported");
            return true;
        }
        catch(Exception e)
        {
            Logger.Log(e.Message);
            return false;
        }
    }
}