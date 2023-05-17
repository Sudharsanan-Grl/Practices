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
    /// This class used for validation of testcase 4.2.1.3
    /// The results are stored in the html file.
    /// The timings and testcase names are stored in the text file.
    /// </summary>
    public class TestCase4213
    {

        HelperClass helperObj = new HelperClass();

        public List<string> TestCasesResults4213 = new List<string>();

        public List<string> TestPrintFile4213 = new List<string>();

        // for validating the 4.2.1.3 testcase

        public void Verify4213(List<Packet> PacketList)
        {
            for (int i = 0; i < PacketList.Count; i++)
            {
                // checks for teststart is present or not

                if (PacketList[i].CmdValue == CmdType.TestStart)
                {
                    // for time and testcase name storing in text file

                    DateTime startTime = DateTime.Now;

                    TestPrintFile4213.Add("TestCase ID : TD_4_2_1_3");

                    TestPrintFile4213.Add("TestCase Name : TD_4_2_1_3 Source Device HPD Event Pulse Length Test");

                    TestPrintFile4213.Add("The TestCase Started time is : " + startTime);

                    //for validating step 1

                    helperObj.ValHPDTimeDiffExtraPulse(PacketList, TestCasesResults4213);

                    //for validating step 2
                    helperObj.SinkAsserts(PacketList, TestCasesResults4213);

                    //for validating step 3
                    helperObj.LinkStartWithin5Sec(PacketList, TestCasesResults4213);

                    //for validating step 4
                    helperObj.LinkFinishedin5Sec(PacketList, TestCasesResults4213);

                    //changing pass and fail color
                    helperObj.ColorChange(TestCasesResults4213);

                    DateTime endTime = DateTime.Now;

                    TestPrintFile4213.Add("The TestCase EndTime time is : " + endTime);

                    //writing into html file

                    using (StreamWriter writer = new StreamWriter("E:\\Outputs\\4213.html"))
                    {
                        foreach (var line in TestCasesResults4213)
                        {
                            writer.WriteLine(line);
                        }
                    }

                    // for writing on the text file

                    using (StreamWriter writer = new StreamWriter("E:\\Outputs\\4213.txt"))
                    {
                        foreach (var line in TestPrintFile4213)
                        {
                            writer.WriteLine(line);
                        }
                    }
                    break;
                }
            }
        }
    }
}
