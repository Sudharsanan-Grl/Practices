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

                    TestPrintFile4212.Add("TestCase ID : TD_4_2_1_1");

                    TestPrintFile4212.Add("TestCase Name : TD_4_2_1_1 Source DUT Retry on No Reply");

                    TestPrintFile4212.Add("The TestCase Started time is : " + startTime);

                    //for validating step 1

                    helperObj.ValHPDTimeDiff(PacketList, TestCasesResults4212);

                    helperObj.ValFirstReqRes(PacketList, TestCasesResults4212);

                    helperObj.ValSecondReqAndRes(PacketList, TestCasesResults4212);

                }
            }
        }
    }
}
