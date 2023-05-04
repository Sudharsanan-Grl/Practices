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
    public class TestCase4212
    {
        HelperClass helperObj = new HelperClass();

        public List<string> TestCasesResults4212 = new List<string>();

        public List<string> TestPrintFile4212 = new List<string>();

        // for validating the 4.2.1.2 testcase
        public void Verify4212(List<Packet> PacketList)
        {
            for (int i = 0; i < PacketList.Count; i++)
            {
                // checks for teststart is present or not

                if (PacketList[i].CmdValue == CmdType.TestStart)
                {
                    // for time and testcase name storing in text file

                    DateTime startTime = DateTime.Now;

                    TestPrintFile4212.Add("TestCase ID : TD_4_2_1_2");

                    TestPrintFile4212.Add("TestCase Name : TD_4_2_1_2 Source Retry on Invalid Reply\r\n");

                    TestPrintFile4212.Add("The TestCase Started time is : " + startTime);

                    //for validating step 1

                    helperObj.ValHPDTimeDiff(PacketList, TestCasesResults4212);

                    //for validating step 2
                    helperObj.SinkAsserts(PacketList, TestCasesResults4212);

                    helperObj.ValFirstReqRes(PacketList, TestCasesResults4212);

                    helperObj.ValSecondReqRes(PacketList, TestCasesResults4212);

                    helperObj.ColorChange(TestCasesResults4212);

                    DateTime endTime = DateTime.Now;

                    TestPrintFile4212.Add("The TestCase EndTime time is : " + endTime);

                    using (StreamWriter writer = new StreamWriter("E:\\Outputs\\4212.html"))
                    {
                        foreach (var line in TestCasesResults4212)
                        {
                            writer.WriteLine(line);
                        }
                    }

                    // for writing on the text file

                    using (StreamWriter writer = new StreamWriter("E:\\Outputs\\4212.txt"))
                    {
                        foreach (var line in TestPrintFile4212)
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
            }
        }
    }
}
