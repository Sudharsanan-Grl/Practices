using CsvHelper.Configuration;
using CsvHelper;
using OxyPlot.Series;
using System.Globalization;
using System.Web.Helpers;

namespace HistogramApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            string csvFilePath = @"E:\Cap0\Sample.csv";
            string[] csvLines = File.ReadAllLines(csvFilePath);
            List<double> signalData = new List<double>();
            
            if (csvLines.Length > 0)
            {

                for (int i = 1; i < csvLines.Length; i++)
                {
                  
                    string[] row = csvLines[i].Split(',');

                    signalData.Add(double.Parse(row[2]));                 
                  
                }
            }

            // Find the minimum and maximum voltage levels
            double minVoltage = signalData.Min();
            double maxVoltage = signalData.Max();
           
            // Define the number of intervals (255 in this case)
            int numIntervals = 255;

            // Calculate the interval width
            double intervalWidth = (maxVoltage - minVoltage) / numIntervals;

            // Initialize an array to store the histogram values
            int[] histogram = new int[numIntervals];

            // Create the histogram
            foreach (double dataPoint in signalData)
            {
                // Calculate the interval index for the data point
                int intervalIndex = (int)((dataPoint - minVoltage) / intervalWidth);

                // Ensure the index is within bounds
                if (intervalIndex >= 0 && intervalIndex < numIntervals)
                {
                    // Increment the histogram count for the corresponding interval
                    histogram[intervalIndex]++;
                }
            }

            string histogramCsvFilePath = @"E:\Cap0\HistogramData.csv";

            using (var writer = new StreamWriter(histogramCsvFilePath))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                // Write the histogram data to the CSV file
                for (int i = 0; i < numIntervals; i++)
                {
                    csv.WriteRecord(new { Interval = i, Count = histogram[i] });
                    Console.WriteLine( i +" "+ histogram[i] );
                }
            }

            // Display a message indicating where the CSV is saved
            Console.WriteLine($"Histogram data saved to: {histogramCsvFilePath}");



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
