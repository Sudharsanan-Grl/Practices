using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static CSVFILE.Packet;
using static CSVFILE.HelperClass;
using System.IO;
using System.Drawing;
using CSVFILE;


namespace CSVFILE
{
    
    public class TestCase4211
    {
        HelperClass HelperObj = new HelperClass();

        public List<string> TestCasesResults = new List<string>();

        public List<string> TestPrintFile = new List<string>();

     
        public void Verify4211(List<Packet>PacketList)
        {
            for(int i = 0; i < PacketList.Count; i++)
            {
                if (PacketList[i].CmdValue == CmdType.TestStart )
                {
                    DateTime startTime = DateTime.Now;
                    TestPrintFile.Add("TestCase ID : TD_4_2_1_1");

                    TestPrintFile.Add("TestCase Name : TD_4_2_1_1 Source DUT Retry on No Reply");

                    TestPrintFile.Add("The TestCase Started time is : " + startTime);

                    ValHPDTimeDiff(PacketList);

                    ValTwoReqContinuos(PacketList);

                    DateTime endTime = DateTime.Now;

                    TestPrintFile.Add("The TestCase EndTime time is : " + endTime);

                    using (StreamWriter writer = new StreamWriter("E:\\rawdata\\4211.html"))
                    {
                        foreach(var line in TestCasesResults)
                        {
                            writer.WriteLine(line);
                        }                       
                    }
                    using (StreamWriter writer = new StreamWriter("E:\\rawdata\\4211.txt"))
                    {
                        foreach (var line in TestPrintFile)
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
            }       
        }
        public int CmdIndexReturn(CmdType CmdValue,List<Packet>PacketList)
        {
            int index = 0;

            for(int i = 0;i<PacketList.Count;i++)
            {
                if (PacketList[i].CmdValue == CmdValue)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        public void ValHPDTimeDiff(List<Packet> PacketList)
        {
            int HPDAssertedIndex = CmdIndexReturn(CmdType.HPD_Asserted, PacketList);

            int HPDRemovedIndex = CmdIndexReturn(CmdType.HPD_Removed, PacketList);

            if ((PacketList[HPDAssertedIndex].TimeStamp - PacketList[HPDRemovedIndex].TimeStamp) * 1e3 >= 2)
            {
                    TestCasesResults.Add($"Step 1 ::[PASS]:HPD Asserted and HPD Removed Time difference  Exp is atleast : 2ms Obt:" +
                    $"{(PacketList[HPDAssertedIndex].TimeStamp - PacketList[HPDRemovedIndex].TimeStamp) * 1e3}" +
                    $"ms Start index#{HPDAssertedIndex} " + $"Stop index#{HPDRemovedIndex}<br>");
            }
            else
            {
                    TestCasesResults.Add($"Step 1 ::[FAIL]:HPD Asserted and HPD Removed " + $"Time difference  Exp is atleast : 2ms Obt:" +
                    $"{(PacketList[HPDAssertedIndex].TimeStamp - PacketList[HPDRemovedIndex].TimeStamp) * 1e3}" +
                    $"ms Start index#{HPDAssertedIndex} Stop index#{HPDRemovedIndex}<br>");
            }
            ColorChange();
            
        }
        //Wait until the Source DUT issues an AUX request. Reference Sink does not send any reply to AUX
        public void ValTwoReqContinuos(List<Packet> PacketList)
        {
            int FirstReqIndex = FirstReq(PacketList);

            int NextToFirstReq= FirstReqIndex + 1;

            if (PacketList[NextToFirstReq].MsgValue == MsgType.Req)
            {
                TestCasesResults.Add($"Step 2 ::[PASS]:Wait until the Source DUT issues an AUX request. Reference Sink does not send any reply to AUX <br>");
            }
            else
            {
                TestCasesResults.Add($"Step 2 ::[FAIL]:Wait until the Source DUT issues an AUX request.But Sink Sends the reply <br> ");
            }
            ColorChange();
        }
        public int FirstReq(List<Packet> PacketList)
        {
            int index = 0;

            for(int i = 0;i < PacketList.Count;i++)
            {
                if (PacketList[i].MsgValue == MsgType.Req)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public void ColorChange()
        {
            string coloredPass = "<b style='color:green;'>PASS</b>";

            string coloredFail = "<b style='color:red;'>FAIL</b>";


            for (int i = 0; i < TestCasesResults.Count; i++)
            {
                TestCasesResults[i] = TestCasesResults[i].Replace("PASS", coloredPass);

                TestCasesResults[i] = TestCasesResults[i].Replace("FAIL", coloredFail);
            }

        }
    }
}
