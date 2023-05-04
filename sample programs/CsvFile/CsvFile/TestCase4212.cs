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


                }
            }
        }
    }
}
