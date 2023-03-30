using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static CSVFILE.Packet;
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
        }

        private void ValHPDTimeDiff(List<CmdType> CmdList, List<double> StartTimeList)
        {
            int HPDAssertedIndex = CmdList.IndexOf(CmdType.HPD_Asserted);
            int HPDRemovedIndex = CmdList.IndexOf(CmdType.HPD_Removed);
            if ((StartTimeList[HPDAssertedIndex] - StartTimeList[HPDRemovedIndex]) * 1e3 >= 200)
            {
                TestCasesResults.Add($"Step 1 ::[PASS]:HPD Asserted and HPD Removed Time difference  Exp is atleast : 2ms Obt:{(StartTimeList[HPDAssertedIndex] - StartTimeList[HPDRemovedIndex]) * 1e3}ms Start index#{HPDAssertedIndex} Stop index#{HPDRemovedIndex}");
            }
            else
            {
                TestCasesResults.Add($"Step 1 ::[FAIL]:HPD Asserted and HPD Removed Time difference  Exp is atleast : 2ms Obt:{(StartTimeList[HPDAssertedIndex] - StartTimeList[HPDRemovedIndex]) * 1e3}ms Start index#{HPDAssertedIndex} Stop index#{HPDRemovedIndex}");

            }
            // TestCasesResults[0].Contains("[PASS]");
           

            const string GREEN = "\u001b[32m";
            const string RED = "\u001b[31m";
            const string RESET = "\u001b[0m";

            // Create a string with colored text
            string coloredPass = GREEN + "PASS" + RESET;
            string coloredFail = RED + "FAIL" + RESET;

            for(int i = 0; i < TestCasesResults.Count; i++)
            {
                TestCasesResults[i] = TestCasesResults[i].Replace("PASS", coloredPass);
                TestCasesResults[i] = TestCasesResults[i].Replace("FAIL", coloredFail);

            } 
           
        }
    }
}
