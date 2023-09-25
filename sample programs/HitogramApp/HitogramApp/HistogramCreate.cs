using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitogramApp
{
    public class HistogramCreate
    {
        public int intervalIndex;
        public int numIntervals = 255;

        public int[] CreateHistogram(List<double> signalData)
        {
            // Find the minimum and maximum voltage levels
            double minVoltage = signalData.Min();
            double maxVoltage = signalData.Max();



            // Calculate the interval width
            double intervalWidth = (maxVoltage - minVoltage) / numIntervals;

            // Initialize an array to store the histogram values

            int[] histogram = new int[numIntervals];
            // Create the histogram
            foreach (double dataPoint in signalData)
            {
                // Calculate the interval index for the data point
                intervalIndex = (int)((dataPoint - minVoltage) / intervalWidth);
                //   Console.WriteLine(intervalIndex);

                // Ensure the index is within bounds
                if (intervalIndex >= 0 && intervalIndex < numIntervals)
                {
                    // Increment the histogram count for the corresponding interval
                    histogram[intervalIndex]++;
                }
            }
            return histogram;
        }
    }
}
