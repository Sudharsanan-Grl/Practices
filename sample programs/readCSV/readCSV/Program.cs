using Bytescout.Spreadsheet;
using CsvHelper;
using Microsoft.VisualBasic;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
namespace ReadCSV
{

    public class Readcsv
    {
      
        
    }
    public class Program
    {
        static void Main(string[] args)
        {
       

            string filePath2 = @"C:\Users\GRL\Downloads\TD_4_2_1_1\TD_4_2_1_1\Test_Pkt.csv";
            string filePath3 = @"C:\Users\GRL\Downloads\TD_4_2_1_1\TD_4_2_1_1\Rows.txt";
            string filePath4 = @"C:\Users\GRL\Downloads\TD_4_2_1_1\TD_4_2_1_1\Seperatedby,.txt";
            
            StreamWriter writer = new StreamWriter(filePath3);
            
            StreamWriter writer2 = new StreamWriter(filePath4);

            string[]csvlines= System.IO.File.ReadAllLines(filePath2);
 
            List<string> rows = new List<string>();

            for(int i=0;i<csvlines.Length;i++)

            {
                string row = csvlines[i];
                rows.Add(row);
            }

            foreach(string row in rows)

            {
                string[]seperated = row.Split(',');

                foreach(string seperate in seperated) 

                {
                   // Console.WriteLine(seperate);
                    writer2.WriteLine(seperate);

                    if(seperate == "HPD_Removed")
                    {
                        Console.WriteLine("yess");
                    }
                }
            }
         
           
            foreach (string line in csvlines)
            {
                writer.WriteLine(line);
            }
          


            writer.Close();
            writer2.Close();



            string csvFilePath = @"C:\\Users\\GRL\\Downloads\\TD_4_2_1_1\\TD_4_2_1_1\\Test_Pkt.csv";
            string searchValue = "HPD_Asserted";
          

            var lines = File.ReadLines(csvFilePath);

            int rowIndex = -1;
          

            if (lines.Any())
            {
              //  string[] header = lines.First().Split(',');
     
                for (int i = 1; i < lines.Count(); i++)
                {
                    string[] rowValues = lines.ElementAt(i).Split(',');

                    if (rowValues.Contains(searchValue))
                    {
                        rowIndex = i;
                        break;
                    }
                }
            }

            Console.WriteLine("Row index: " + rowIndex);
            // Read the CSV file
            using var reader = new StreamReader(@"C:\Users\GRL\Downloads\TD_4_2_1_1\TD_4_2_1_1\Test_Pkt.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            // Read the header row
            csv.Read();
            csv.ReadHeader();

            // Get the value at index 2 (assuming zero-based indexing)
            var value = csv.GetField<string>(5);
            Console.WriteLine(value);
        }
    }
}
