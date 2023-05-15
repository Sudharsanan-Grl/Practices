using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CsvFile.Packet;

namespace CsvFile
{



    /// <summary>
    /// This is the Testcase validation class.
    /// This class used for validation of testcase 4.2.1.4
    /// The results are stored in the html file.
    /// The timings and testcase names are stored in the text file.
    /// </summary>
    public class TestCase4214
    {

        HelperClass helperObj = new HelperClass();

        public List<string> TestCasesResults4214 = new List<string>();

        public List<string> TestPrintFile4214 = new List<string>();

        // for validating the 4.2.1.4 testcase

        public void Verify4214(List<Packet> PacketList)
        {
            for (int i = 0; i < PacketList.Count; i++)
            {
                // checks for teststart is present or not

                if (PacketList[i].CmdValue == CmdType.TestStart)
                {
                    // for time and testcase name storing in text file

                    DateTime startTime = DateTime.Now;

                    TestPrintFile4214.Add("TestCase ID : TD_4_2_1_4");

                    TestPrintFile4214.Add("TestCase Name : TD_4_2_1_4 Source Device IRQ_HPD Pulse Length Test");

                    TestPrintFile4214.Add("The TestCase Started time is : " + startTime);

                    //for validating step 1

                    helperObj.ValHPDTimeDiff(PacketList, TestCasesResults4214);

                    //for validating step 2
                    helperObj.SinkAsserts(PacketList, TestCasesResults4214);

                    //for validating step 3
                    helperObj.LinkFinishedin5Sec(PacketList, TestCasesResults4214);

                    //for validating step 4
                    helperObj.SinkTogglesHPD_IRQ(PacketList, TestCasesResults4214);
                   
                    //for validating step 5
                    helperObj.ReadDPCDAddress(PacketList, TestCasesResults4214);

                    
                    //changing pass and fail color
                    helperObj.ColorChange(TestCasesResults4214);

                    DateTime endTime = DateTime.Now;

                    TestPrintFile4214.Add("The TestCase EndTime time is : " + endTime);

                    //writing into html file

                    using (StreamWriter writer = new StreamWriter("E:\\Outputs\\4214.html"))
                    {
                        foreach (var line in TestCasesResults4214)
                        {
                            writer.WriteLine(line);
                        }
                    }

                    // for writing on the text file

                    using (StreamWriter writer = new StreamWriter("E:\\Outputs\\4214.txt"))
                    {
                        foreach (var line in TestPrintFile4214)
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

