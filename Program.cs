﻿using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data;
using System.Reflection.Metadata;

namespace HTML_CSV_processing;

class Program
{
    static void Main(string[] args)
    {
        Logger.FileLog("Application run");

        DateTime dateFrom = UserInterviewer.GetDate("Enter Start Date in format 'YYYY-MM-DD'");
        DateTime dateTo = UserInterviewer.GetDate("Enter End Date in format 'YYYY-MM-DD'");


        DataReaderParser drp = new DataReaderParser(DefaultSettings.UserInputDateTimeFormat, DefaultSettings.DataPath);
        DataProcessor dataProc = new DataProcessor();


        List<GameOrderStatistics> rawData = drp.ReadCSV();

        GameStatistics[] filtered = dataProc.FilterData(dateFrom, dateTo, rawData);

        string page = HtmlProcessor.GetHtmlPage(dateFrom, dateTo, filtered, DefaultSettings.TemplatePath);

        DataWriter.WriteTextFile(contents:page, DefaultSettings.ExportPath);

        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
    }
}