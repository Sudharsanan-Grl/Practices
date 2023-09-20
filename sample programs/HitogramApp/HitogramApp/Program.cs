using CsvHelper;
using CsvHelper.Configuration;
using HitogramApp;
using System.Globalization;
using System.Net.Sockets;

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
            Console.WriteLine(minVoltage);
            Console.WriteLine(maxVoltage);
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

            // Display the histogram
            Console.WriteLine("Histogram of Voltage Levels:");
            for (int i = 0; i < numIntervals; i++)
            {
                Console.WriteLine($"{i}: {histogram[i]}");
            }
        }
    }
    
}
