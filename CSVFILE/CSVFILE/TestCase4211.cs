using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static CSVFILE.Packet;
using System.IO;
using System.Drawing;

namespace CSVFILE
{
    internal class TestCase4211
    {
        public List<string> TestCasesResults = new List<string>();
        public void verify(List<CmdType> CmdList,List<double>StartTimeList)
        {
           if( CmdList.Contains(CmdType.TestStart))
            {
                ValHPDTimeDiff(CmdList, StartTimeList);

                foreach (var line in TestCasesResults)
                {
                    Console.WriteLine(line);

                }
                

            }
            using (StreamWriter writer = new StreamWriter("E:\\RawData\\sample.html"))
            {
                writer.WriteLine(TestCasesResults[0]);
            }

        }

        private void ValHPDTimeDiff(List<CmdType> CmdList, List<double> StartTimeList)
        {
            int HPDAssertedIndex = CmdList.IndexOf(CmdType.HPD_Asserted);
            int HPDRemovedIndex = CmdList.IndexOf(CmdType.HPD_Removed);
            if ((StartTimeList[HPDAssertedIndex] - StartTimeList[HPDRemovedIndex]) * 1e3 >= 2)
            {
                TestCasesResults.Add($"Step 1 ::[PASS]:HPD Asserted and HPD Removed Time difference  Exp is atleast : 2ms Obt:{(StartTimeList[HPDAssertedIndex] - StartTimeList[HPDRemovedIndex]) * 1e3}ms Start index#{HPDAssertedIndex} Stop index#{HPDRemovedIndex}");
            }
            else
            {
                TestCasesResults.Add($"Step 1 ::[FAIL]:HPD Asserted and HPD Removed Time difference  Exp is atleast : 2ms Obt:{(StartTimeList[HPDAssertedIndex] - StartTimeList[HPDRemovedIndex]) * 1e3}ms Start index#{HPDAssertedIndex} Stop index#{HPDRemovedIndex}");

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
    }
}
