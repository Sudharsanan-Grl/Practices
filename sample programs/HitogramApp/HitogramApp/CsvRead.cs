using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitogramApp
{
    public class CsvRead
    {
        public List<double> GetList(string csvFilePath)
        {
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
            return signalData;
        }

    }
}
