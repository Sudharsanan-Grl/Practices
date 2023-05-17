using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CsvFile.Packet;

namespace CsvFile
{
    public class TestCase4215
    {
        HelperClass helperObj = new HelperClass();

        public List<string> TestCasesResults4215 = new List<string>();

        public List<string> TestPrintFile4215 = new List<string>();

        // for validating the 4.2.1.5 testcase

        public void Verify4215(List<Packet> PacketList)
        {
            for (int i = 0; i < PacketList.Count; i++)
            {
                // checks for teststart is present or not

                if (PacketList[i].CmdValue == CmdType.TestStart)
                {
                    // for time and testcase name storing in text file

                    DateTime startTime = DateTime.Now;

                    TestPrintFile4215.Add("TestCase ID : TD_4_2_1_5");

                    TestPrintFile4215.Add("TestCase Name : TD_4_2_1_5 Source Device Inactive HPD / Inactive AUX Test");

                    TestPrintFile4215.Add("The TestCase Started time is : " + startTime);

                    //for validating step 1

                    helperObj.ValHPDTimeDiff(PacketList, TestCasesResults4215);

                    //for validating step 2
                    helperObj.SinkAsserts(PacketList, TestCasesResults4215);

                    //for validating step 3
                    helperObj.LinkFinishedin5Sec(PacketList, TestCasesResults4215);

                    //for validating step 4
                    helperObj.SecondHPDLowWaitForNextAUX(PacketList, TestCasesResults4215);

                    //for validating step 5
                    helperObj.NoAUXTransaction(PacketList, TestCasesResults4215);

                    //changing pass and fail color
                    helperObj.ColorChange(TestCasesResults4215);

                    DateTime endTime = DateTime.Now;

                    TestPrintFile4215.Add("The TestCase EndTime time is : " + endTime);

                    //writing into html file

                    using (StreamWriter writer = new StreamWriter("E:\\Outputs\\4215.html"))
                    {
                        foreach (var line in TestCasesResults4215)
                        {
                            writer.WriteLine(line);
                        }
                    }

                    // for writing on the text file

                    using (StreamWriter writer = new StreamWriter("E:\\Outputs\\4215.txt"))
                    {
                        foreach (var line in TestPrintFile4215)
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

