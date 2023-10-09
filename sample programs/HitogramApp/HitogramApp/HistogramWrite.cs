using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Bibliography;

namespace HitogramApp
{
    public class HistogramWrite
    {
        public List<double> signalData;

        public void HistrogramWriteCSV()
        {
            HistogramCreate histogramCreate = new HistogramCreate();

            int numIntervals = histogramCreate.numIntervals;

            int[] histogram = histogramCreate.CreateHistogram(signalData);

            string histogramCsvFilePath = @"E:\Cap0\HistogramData.csv";

            using (var writer = new StreamWriter(histogramCsvFilePath))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                // Write the histogram data to the CSV file
                for (int i = 0; i < numIntervals; i++)
                {
                    csv.WriteRecord(new { Interval = i, Count = histogram[i] });

                }
            }
            // Display a message indicating where the CSV is saved
            Console.WriteLine($"Histogram data saved to: {histogramCsvFilePath}");
        }
        public void HistrogramWriteHTML()
        {
            HistogramCreate histogramCreate = new HistogramCreate();
            int numIntervals = histogramCreate.numIntervals;
            int[] histogram = histogramCreate.CreateHistogram(signalData);
            string htmlFilePath = @"E:\Cap0\HistogramChart.html";
            using (var writer = new StreamWriter(htmlFilePath))
            {
                writer.WriteLine("<html>");
                writer.WriteLine("<head>");
                writer.WriteLine("  <script type='text/javascript' src='https://www.gstatic.com/charts/loader.js'></script>");
                writer.WriteLine("  <script type='text/javascript'>");
                writer.WriteLine("    google.charts.load('current', { packages: ['corechart'] });");
                writer.WriteLine("    google.charts.setOnLoadCallback(drawChart);");
                writer.WriteLine("    function drawChart() {");
                writer.WriteLine("      var data = google.visualization.arrayToDataTable([");

                // Write histogram data to the HTML
                writer.WriteLine("        ['Interval', 'Count'],");
                for (int i = 0; i < numIntervals; i++)
                {
                    writer.WriteLine($"        ['{i}', {histogram[i]}],");
                }
                writer.WriteLine("      ]);");
                writer.WriteLine("      var options = {");
                writer.WriteLine("        title: 'Histogram of Voltage Levels',");
                writer.WriteLine("        legend: { position: 'none' },");
                writer.WriteLine("      };");
                writer.WriteLine("      var chart = new google.visualization.Histogram(document.getElementById('chart_div'));");
                writer.WriteLine("      chart.draw(data, options);");
                writer.WriteLine("    }");
                writer.WriteLine("  </script>");
                writer.WriteLine("</head>");
                writer.WriteLine("<body>");
                writer.WriteLine("  <div id='chart_div' style='width: 900px; height: 500px;'></div>");
                writer.WriteLine("</body>");
                writer.WriteLine("</html>");
            }
            // Display a message indicating where the HTML file is saved
            Console.WriteLine($"Histogram chart saved to: {htmlFilePath}");
        }
    }
}
