using CsvHelper.Configuration;
using CsvHelper;
using OxyPlot.Series;
using System.Globalization;
using System.Web.Helpers;
using HitogramApp;

namespace HistogramApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            CsvRead CsvRead = new CsvRead();

            HistogramWrite histogramWrite = new HistogramWrite();

            string csvFilePath = @"E:\Cap0\Sample.csv";

            List<double> signalData = CsvRead.GetList(csvFilePath);


            histogramWrite.signalData = signalData;

            histogramWrite.HistrogramWriteHTML();
            histogramWrite.HistrogramWriteCSV();

        }
    }

}
