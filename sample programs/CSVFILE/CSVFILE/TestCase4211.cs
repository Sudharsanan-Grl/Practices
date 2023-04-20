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
    /// <summary>
    /// This is the Testcase validation class.
    /// This class used for validation of testcase 4.2.1.1
    /// The results are stored in the html file.
    /// The timings and testcase names are stored in the text file.
    /// </summary>
    public class TestCase4211
    {
        HelperClass helperObj = new HelperClass();

        public List<string> TestCasesResults = new List<string>();

        public List<string> TestPrintFile = new List<string>();

        // for validating the 4.2.2.1 testcase
        public void Verify4211(List<Packet>PacketList)
        {
            for(int i = 0; i < PacketList.Count; i++)
            {
                // checks for teststart is present or not

                if (PacketList[i].CmdValue == CmdType.TestStart )
                {
                    // for time and testcase name storing in text file

                    DateTime startTime = DateTime.Now;

                    TestPrintFile.Add("TestCase ID : TD_4_2_1_1");

                    TestPrintFile.Add("TestCase Name : TD_4_2_1_1 Source DUT Retry on No Reply");

                    TestPrintFile.Add("The TestCase Started time is : " + startTime);

                    //for validating step 1

                    ValHPDTimeDiff(PacketList);

                    //for validating step 2

                    ValTwoReqContinuos(PacketList);

                    ValidateTwoReqTiming(PacketList);

                    ValFirstAndEndReq(PacketList);

                    DateTime endTime = DateTime.Now;


                    TestPrintFile.Add("The TestCase EndTime time is : " + endTime);

                    // for writing on the html file

                    using (StreamWriter writer = new StreamWriter("E:\\rawdata\\4211.html"))
                    {
                        foreach(var line in TestCasesResults)
                        {
                            writer.WriteLine(line);
                        }                       
                    }

                    // for writing on the text file

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
        // This method returns the cmdType values index for checking time
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
        // step 1 validation
        public void ValHPDTimeDiff(List<Packet> PacketList)
        {
            // Hot plug detect  insert and removed index

            int HPDAssertedIndex = CmdIndexReturn(CmdType.HPD_Asserted, PacketList);

            int HPDRemovedIndex = CmdIndexReturn(CmdType.HPD_Removed, PacketList);

            // using HPD index checking the time diff

            if ((PacketList[HPDAssertedIndex].TimeStamp - PacketList[HPDRemovedIndex].TimeStamp) * 1e3 >= 2)
            {
                    TestCasesResults.Add($"Step 1 ::[PASS]: HPD Asserted and HPD Removed Time difference  Exp is atleast : 2ms Obt:" +
                    $"{(PacketList[HPDAssertedIndex].TimeStamp - PacketList[HPDRemovedIndex].TimeStamp) * 1e3}" +
                    $"ms Start index # {HPDAssertedIndex} " + $"Stop index # {HPDRemovedIndex}<br>");
            }
            else
            {
                    TestCasesResults.Add($"Step 1 ::[FAIL]: HPD Asserted and HPD Removed " + $"Time difference  Exp is atleast : 2ms Obt:" +
                    $"{(PacketList[HPDAssertedIndex].TimeStamp - PacketList[HPDRemovedIndex].TimeStamp) * 1e3}" +
                    $"ms Start index # { HPDAssertedIndex} Stop index # { HPDRemovedIndex}<br>");
            }

            // changing the pass fail colour

            ColorChange();
            
        }
        //step 2 validation
        public void ValTwoReqContinuos(List<Packet> PacketList)
        {

            //finding the first req index

            int firstReqIndex = FirstReq(PacketList);

            //finding the next index by adding 1

            int nextToFirstReq = firstReqIndex + 1;

            //checking next one also req

            if (PacketList[nextToFirstReq].MsgValue == MsgType.Req)
            {
                TestCasesResults.Add($"Step 2 ::[PASS]: Wait until the Source DUT issues an AUX request. Reference Sink does not send any reply to AUX <br>");
            }
            else
            {
                TestCasesResults.Add($"Step 2 ::[FAIL]: Wait until the Source DUT issues an AUX request.But Sink Sends the reply <br> ");
            }
            ColorChange();
        }
        // step 3 validation
        public void ValidateTwoReqTiming(List<Packet> PacketList)
        {
            int firstReqIndex = FirstReq(PacketList);

            int secondReqIndex = ReqOccurance(PacketList, 2);

            //checking the time diff between is more than 400 us
            if ((PacketList[secondReqIndex].TimeStamp - PacketList[firstReqIndex].TimeStamp)*1e6 >= 400)
            {
                TestCasesResults.Add($"Step 3 ::[PASS]: Source DUT waits at least 400us after completion of previous request before sending a new request.Expt TimeDiffe is 400us Obt time diff is " +
                    $"  { (PacketList[secondReqIndex].TimeStamp - PacketList[firstReqIndex].TimeStamp) * 1e6}us  " +
                    $"    Start Index #  { firstReqIndex } End Index # { secondReqIndex} <br> "  );

            }
            else
            {
                TestCasesResults.Add($"Step 3 ::[Fail]: Source DUT doesn't waits at least 400us after completion of previous request before sending a new request.Expt TimeDiffe is 400us Obt time diff is " +
                                   $"  {(PacketList[secondReqIndex].TimeStamp - PacketList[firstReqIndex].TimeStamp) * 1e6}us  " +
                                   $"    Start Index #  { firstReqIndex} End Index # { secondReqIndex} <br> ");
            }
            ColorChange();
        }
        // step 4 validation
        public void ValFirstAndEndReq(List<Packet> PacketList)
        {

            int firstReqIndex = FirstReq(PacketList);

            int lastReqBeforeRes=LastReqIndexBeforeRes(PacketList);

            //checking the first req and req before res time diff between is more than 400 us

            if ((PacketList[lastReqBeforeRes].TimeStamp - PacketList[firstReqIndex].TimeStamp) * 1e6 >= 400)
            {
                TestCasesResults.Add($"Step 4 ::[PASS]:  the Source DUT  issues another AUX request Reference Sink shall only respond to requests. " +
                    $"Reference Sink replies normally to this AUX request. Verify that Source DUT waits at least 400us after completion of previous request before sending the new request." +
                                   $"  {(PacketList[lastReqBeforeRes].TimeStamp - PacketList[firstReqIndex].TimeStamp) * 1e6}us  " +
                                   $"    Start Index #  {firstReqIndex} End Index # {lastReqBeforeRes} <br> ");
            }

        
            else
            {
                TestCasesResults.Add($"Step 4 ::[FAIL]:  the Source DUT doesn't issues another AUX request or Reference Sink shall only respond to requests. " +
                    $"Reference Sink replies normally to this AUX request. Verify that Source DUT doesn't waits at least 400us after completion of previous request before sending the new request." +
                                   $"  {(PacketList[lastReqBeforeRes].TimeStamp - PacketList[firstReqIndex].TimeStamp) * 1e6}us  " +
                                   $"    Start Index #  {firstReqIndex} End Index # {lastReqBeforeRes} <br> ");
            }
            ColorChange();
        }

        //finding the first req index method
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
        //finding the  req Occurance index method
        public int ReqOccurance(List<Packet> PacketList,int occurance)
        {
            int index = 0;
            int times= 0;
            for (int i = 0; i < PacketList.Count; i++)
            {
                if (PacketList[i].MsgValue == MsgType.Req)
                {
                    times++;
                    if(times == occurance)
                    {
                      index = i;
                      break;
                    }
                }
            }
            return index;
        }
        //finding the  req index before the first responce  method
        public int LastReqIndexBeforeRes(List<Packet> PacketList) 
        {
            int index = 0;
            for (int i = 0; i < PacketList.Count; i++)
            {
                if (PacketList[i].MsgValue == MsgType.Req)
                {
                    if (PacketList[i+1].MsgValue == MsgType.Res)
                    {
                        index = i;
                        break;
                    }
                }
            }
            return index;
        }
        // colour change method
        public void ColorChange()
        {
            string coloredPass = "<b style='color:green;'>PASS</b>";

            string coloredFail = "<b style='color:red;'>FAIL</b>";

            // changing the pass and fail colour

            for (int i = 0; i < TestCasesResults.Count; i++)
            {
                TestCasesResults[i] = TestCasesResults[i].Replace("PASS", coloredPass);

                TestCasesResults[i] = TestCasesResults[i].Replace("FAIL", coloredFail);
            }

        }
    }
}
