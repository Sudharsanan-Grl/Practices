﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CsvFile.Packet;

namespace CsvFile
{
    public class TestCase4222
    {
        HelperClass helperObj = new HelperClass();

        public List<string> TestCasesResults4222 = new List<string>();

        public List<string> TestPrintFile4222 = new List<string>();

        // for validating the 4.2.2.2 testcase

        public void Verify4222(List<Packet> PacketList)
        {
            for (int i = 0; i < PacketList.Count; i++)
            {
                // checks for teststart is present or not

                if (PacketList[i].CmdValue == CmdType.TestStart)
                {
                    // for time and testcase name storing in text file

                    DateTime startTime = DateTime.Now;

                    TestPrintFile4222.Add("TestCase ID : TD_4_2_2_2");

                    TestPrintFile4222.Add("TestCase Name : TD_4_2_2_2  DPCD Extended Receiver Capability and EDID Read upon HPD Plug Event");

                    TestPrintFile4222.Add("The TestCase Started time is : " + startTime);

                    //for validating step 1

                    helperObj.ValHPDTimeDiff(PacketList, TestCasesResults4222);

                    //for validating step 2
                    helperObj.SinkAsserts(PacketList, TestCasesResults4222);

                    //for validating step 3
                    helperObj.ReadDPCD(PacketList, TestCasesResults4222);

                    //for validating step 4
                    helperObj.ReadEDID(PacketList, TestCasesResults4222);

                    //for validating step 5
                    helperObj.LinkTraingHappens(PacketList, TestCasesResults4222);

                    //changing pass and fail color
                    helperObj.ColorChange(TestCasesResults4222);

                    DateTime endTime = DateTime.Now;

                    TestPrintFile4222.Add("The TestCase EndTime time is : " + endTime);

                    //writing into html file

                    using (StreamWriter writer = new StreamWriter("E:\\Outputs\\4222.html"))
                    {
                        foreach (var line in TestCasesResults4222)
                        {
                            writer.WriteLine(line);
                        }
                    }

                    // for writing on the text file

                    using (StreamWriter writer = new StreamWriter("E:\\Outputs\\4222.txt"))
                    {
                        foreach (var line in TestPrintFile4222)
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
