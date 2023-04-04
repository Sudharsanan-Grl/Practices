using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static CSVFILE.Packet;
using System.IO;
using System.Drawing;
using CSVFILE;


namespace CSVFILE
{
    public class TestCase4211
    {
        public List<string> TestCasesResults = new List<string>();
        public void Verify4211(List<Packet>PacketList)
        {
            for(int i = 0; i < PacketList.Count; i++)
            {
                if (PacketList[i].CmdValue == CmdType.TestStart )
                {
                      ValHPDTimeDiff(PacketList);
                    using (StreamWriter writer = new StreamWriter("e:\\rawdata\\sample.html"))
                    {
                        writer.WriteLine(TestCasesResults[0]);
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
                    $"ms Start index#{HPDAssertedIndex} " + $"Stop index#{HPDRemovedIndex}");
            }
            else
            {
                TestCasesResults.Add($"Step 1 ::[FAIL]:HPD Asserted and HPD Removed " + $"Time difference  Exp is atleast : 2ms Obt:" +
                    $"{(PacketList[HPDAssertedIndex].TimeStamp - PacketList[HPDRemovedIndex].TimeStamp) * 1e3}" +
                    $"ms Start index#{HPDAssertedIndex} Stop index#{HPDRemovedIndex}");

            }
            string coloredPass = "<b style='color:green;'>PASS</b>";
            string coloredFail = "<b style='color:red;'>FAIL</b>";


            for (int i = 0; i < TestCasesResults.Count; i++)
            {
                TestCasesResults[i] = TestCasesResults[i].Replace("PASS", coloredPass);
                TestCasesResults[i] = TestCasesResults[i].Replace("FAIL", coloredFail);
                Console.WriteLine(TestCasesResults[i]);

            }

        }

        //    using (streamwriter writer = new streamwriter("e:\\rawdata\\sample.html"))
        //    {
        //        writer.writeline(testcasesresults[0]);
        //    }

        //}


    }

}
