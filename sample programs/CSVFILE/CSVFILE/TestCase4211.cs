using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static CsvFile.Packet;
using static CsvFile.HelperClass;
using System.IO;
using System.Drawing;
using CsvFile;


namespace CsvFile
{
    /// <summary>
    /// This is the Testcase validation class.
    /// This class used for validation of testcase 4.2.1.1
    /// The results are stored in the html file.
    /// The timings and testcase names are stored in the text file.
    /// </summary>
    public class TestCase4211
    {
        HelperClass helperObj = new HelperClass();

        public List<string> TestCasesResults4211 = new List<string>();

        public List<string> TestPrintFile4211 = new List<string>();

        // for validating the 4.2.1.1 testcase
        public void Verify4211(List<Packet>PacketList)
        {
            for(int i = 0; i < PacketList.Count; i++)
            {
                // checks for teststart is present or not

                if (PacketList[i].CmdValue == CmdType.TestStart )
                {
                    // for time and testcase name storing in text file

                    DateTime startTime = DateTime.Now;

                    TestPrintFile4211.Add("TestCase ID : TD_4_2_1_1");

                    TestPrintFile4211.Add("TestCase Name : TD_4_2_1_1 Source DUT Retry on No Reply");

                    TestPrintFile4211.Add("The TestCase Started time is : " + startTime);

                    //for validating step 1

                    helperObj.ValHPDTimeDiff(PacketList,TestCasesResults4211);

                    //for validating step 2

                    helperObj.ValTwoReqContinuos(PacketList, TestCasesResults4211);

                    //for validating step 3

                    helperObj.ValidateTwoReqTiming(PacketList, TestCasesResults4211);

                    //for validating step 4

                    helperObj.ValFirstAndEndReq(PacketList, TestCasesResults4211);

                    DateTime endTime = DateTime.Now;

                    TestPrintFile4211.Add("The TestCase EndTime time is : " + endTime);

                    // for writing on the html file

                    using (StreamWriter writer = new StreamWriter("E:\\rawdata\\4211.html"))
                    {
                        foreach(var line in TestCasesResults4211)
                        {
                            writer.WriteLine(line);
                        }                       
                    }

                    // for writing on the text file

                    using (StreamWriter writer = new StreamWriter("E:\\rawdata\\4211.txt"))
                    {
                        foreach (var line in  TestPrintFile4211)
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
            }       
        }
     
 
       
    }
}
