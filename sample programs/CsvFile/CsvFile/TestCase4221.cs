using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CsvFile.Packet;

namespace CsvFile
{
    public class TestCase4221
    {
        HelperClass helperObj = new HelperClass();

        public List<string> TestCasesResults4221 = new List<string>();

        public List<string> TestPrintFile4221 = new List<string>();

        // for validating the 4.2.2.1 testcase

        public void Verify4221(List<Packet> PacketList)
        {
            for (int i = 0; i < PacketList.Count; i++)
            {
                // checks for teststart is present or not

                if (PacketList[i].CmdValue == CmdType.TestStart)
                {
                    // for time and testcase name storing in text file

                    DateTime startTime = DateTime.Now;

                    TestPrintFile4221.Add("TestCase ID : TD_4_2_2_1");

                    TestPrintFile4221.Add("TestCase Name : TD_4_2_2_1  DPCD Receiver Capability and EDID Read upon HPD Plug Event");

                    TestPrintFile4221.Add("The TestCase Started time is : " + startTime);

                    //for validating step 1

                    helperObj.ValHPDTimeDiff(PacketList, TestCasesResults4221);

                    //for validating step 2
                    helperObj.SinkAsserts(PacketList, TestCasesResults4221);          

                    //changing pass and fail color
                    helperObj.ColorChange(TestCasesResults4221);

                    DateTime endTime = DateTime.Now;

                    TestPrintFile4221.Add("The TestCase EndTime time is : " + endTime);

                    //writing into html file

                    using (StreamWriter writer = new StreamWriter("E:\\Outputs\\4221.html"))
                    {
                        foreach (var line in TestCasesResults4221)
                        {
                            writer.WriteLine(line);
                        }
                    }

                    // for writing on the text file

                    using (StreamWriter writer = new StreamWriter("E:\\Outputs\\4221.txt"))
                    {
                        foreach (var line in TestPrintFile4221)
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
