using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static CsvFile.Packet;
using static CsvFile.HelperInput;
using static CsvFile.TestCase4211;
namespace CsvFile
{

    /// <summary>
    /// This helper class is used for converting string value into enum value.
    /// This helper class is also used for converting string value into double and int  value.
    /// This class is also used for getting the index of first/last nat/i2c req/res rd/wr.
    /// </summary>
    public class HelperClass
    {
        // converting string to double
        public double TimeStampMethod(string timeStampstring, double timeStamp)
        {
            if (Double.TryParse(timeStampstring, out timeStamp)) { }
            else
            {
                Console.WriteLine("The string {0} could not be converted to a double.", timeStampstring);
            }
            return timeStamp;
        }
        // converting string to enum

        public Enum EnumConverterMethod(string enumString, Enum enumValue)
        {
            try
            {
                // cheks the types of the enum

                if (enumValue.GetType() == typeof(MsgType))
                {
                    // converting string into enum

                    enumValue = (MsgType)Enum.Parse(typeof(MsgType), enumString);

                    return enumValue;
                }
                else if (enumValue.GetType() == typeof(CmdType))
                {
                    // converting string into enum

                    enumValue = (CmdType)Enum.Parse(typeof(CmdType), enumString);

                    return enumValue;
                }
                else if (enumValue.GetType() == typeof(TransactType))
                {
                    // converting string into enum

                    enumValue = (TransactType)Enum.Parse(typeof(TransactType), enumString);

                    return enumValue;
                }
                else
                {
                    Console.WriteLine("The enum is not in the correct format");

                    return enumValue;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                return enumValue;
            }
        }
        // converting string to int

        public int AddressMethod(string stringAddress, int address)
        {
            address = Convert.ToInt32(stringAddress, 16);

            return address;
        }
        public int DataLengthMethod(string dataLengthString, int dataLength)
        {
            if (dataLengthString == "")
            {
                return dataLength = 0;
            }
            else
            {
                return dataLength = int.Parse(dataLengthString);
            }
        }
        // using helper obj to get the desired packet index
        public int GetDesiredPacketIndex(List<Packet> PacketList, HelperInput obj)
        {
            int index = 0;
            int times = 0;

            if (obj.firstOrLastValueSearch == FirstOrLast.first)
            {
                for (int i = 0; i < PacketList.Count; i++)
                {
                    // checks all the required condition( first/last Nat/I2C Req/Res rd/wr Occ)

                    if (PacketList[i].CmdValue == obj.CmdValueSearch &&
                        PacketList[i].TransactValue == obj.TransactValueSearch &&
                        PacketList[i].MsgValue == obj.MsgvalueSearch)
                    {
                        times++;
                        if (times == obj.Occurance)
                        {
                            index = i;
                            break;
                        }
                    }
                }
                return index;
            }
            else if ((obj.firstOrLastValueSearch == FirstOrLast.last))
            {
                for (int i = PacketList.Count - 1; i > 0; i--)
                {
                    if (PacketList[i].CmdValue == obj.CmdValueSearch &&
                        PacketList[i].TransactValue == obj.TransactValueSearch &&
                        PacketList[i].MsgValue == obj.MsgvalueSearch)
                    {
                        times++;
                        if (times == obj.Occurance)
                        {
                            index = i;
                            break;
                        }
                    }
                }
                return index;
            }
            else
            {
                Console.WriteLine("please update first or last ");
                return -1;
            }

        }
        // getting first nat index
        public int FirstNatIndex(List<Packet> PacketList)
        {
            int index = 0;

            for (int i = 0; i < PacketList.Count; i++)
            {
                if (PacketList[i].TransactValue == TransactType.Nat)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        // getting last nat index
        public int LastNatIndex(List<Packet> PacketList)
        {
            int index = 0;

            for (int i = PacketList.Count - 1; i > 0; i--)
            {
                if (PacketList[i].TransactValue == TransactType.Nat)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        // getting first i2c index
        public int FirstI2CIndex(List<Packet> PacketList)
        {
            int index = 0;

            for (int i = 0; i < PacketList.Count; i++)
            {
                if (PacketList[i].TransactValue == TransactType.I2C)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        // getting last i2c index
        public int LastI2CIndex(List<Packet> PacketList)
        {
            int index = 0;

            for (int i = PacketList.Count - 1; i > 0; i--)
            {
                if (PacketList[i].TransactValue == TransactType.I2C)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        // getting first nat wr index
        public int FirstNatWrIndex(List<Packet> PacketList)
        {
            int index = 0;

            for (int i = 0; i < PacketList.Count; i++)
            {
                if (PacketList[i].TransactValue == TransactType.Nat && PacketList[i].CmdValue == CmdType.Wr)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        // getting last nat wr index
        public int LastNatWrIndex(List<Packet> PacketList)
        {
            int index = 0;

            for (int i = PacketList.Count - 1; i > 0; i--)
            {
                if (PacketList[i].TransactValue == TransactType.Nat &&
                    PacketList[i].CmdValue == CmdType.Wr)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        // getting first i2c wr index
        public int FirstI2CWrIndex(List<Packet> PacketList)
        {
            int index = 0;

            for (int i = 0; i < PacketList.Count; i++)
            {
                if (PacketList[i].TransactValue == TransactType.I2C && PacketList[i].CmdValue == CmdType.Wr)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        // getting last i2c wr index
        public int LastI2CWrIndex(List<Packet> PacketList)
        {
            int index = 0;

            for (int i = PacketList.Count - 1; i > 0; i--)
            {
                if (PacketList[i].TransactValue == TransactType.I2C &&
                    PacketList[i].CmdValue == CmdType.Wr)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        // getting req and res occurance index
        public int ReqResOccuranceIndex(List<Packet> PacketList, int numOfOcc, MsgType reqOrRes)
        {
            int index = 0;
            int times = 0;

            for (int i = 0; i < PacketList.Count; i++)
            {
                if (PacketList[i].MsgValue == reqOrRes)
                {
                    times++;
                    if (times == numOfOcc)
                    {
                        index = i;
                        break;
                    }
                }
            }
            return index;
        }
        // step 1 Validation 
        public void ValHPDTimeDiff(List<Packet> PacketList, List<string> TestCasesResults)
        {
            // Hot plug detect  insert and removed index

            int HPDAssertedIndex = CmdIndexReturn(CmdType.HPD_Asserted, PacketList);

            int HPDRemovedIndex = CmdIndexReturn(CmdType.HPD_Removed, PacketList);

            // using HPD index checking the time diff

            if ((PacketList[HPDAssertedIndex].TimeStamp - PacketList[HPDRemovedIndex].TimeStamp) * 1e3 >= 2) // multiplyed by 1000 for converting milli seconds to seconds.
            {
                TestCasesResults.Add($"Step 1 ::[PASS]: HPD Asserted and HPD Removed Time difference  Exp is atleast : 2ms Obt:" +
                $"{(PacketList[HPDAssertedIndex].TimeStamp - PacketList[HPDRemovedIndex].TimeStamp) * 1e3}" +
                $"ms Start index # {HPDAssertedIndex} " + $"Stop index # {HPDRemovedIndex}<br>");
            }
            else
            {
                TestCasesResults.Add($"Step 1 ::[FAIL]: HPD Asserted and HPD Removed " + $"Time difference  Exp is atleast : 2ms Obt:" +
                $"{(PacketList[HPDAssertedIndex].TimeStamp - PacketList[HPDRemovedIndex].TimeStamp) * 1e3}" +
                $"ms Start index # {HPDAssertedIndex} Stop index # {HPDRemovedIndex}<br>");
            }

        }


        //step 2 validation 

        public void SinkAsserts(List<Packet> PacketList, List<string> TestCasesResults)
        {
            for (int i = 1; i < PacketList.Count; i++)
            {
                //checking HPD is asserted or not
                if (PacketList[i].CmdValue == CmdType.HPD_Asserted)
                {
                    TestCasesResults.Add("Step 2 ::[PASS]: Reference Sink asserts HPD.<br>");
                }

            }
        }

        //step 3 validation 4211

        public void ValTwoReqContinuos(List<Packet> PacketList, List<string> TestCasesResults)
        {

            //finding the first req index

            int firstReqIndex = FirstReq(PacketList);

            //finding the next index by adding 1

            int nextToFirstReq = firstReqIndex + 1;

            //checking next one also req

            if (PacketList[nextToFirstReq].MsgValue == MsgType.Req)
            {
                TestCasesResults.Add($"Step 3 ::[PASS]: Wait until the Source DUT issues an AUX request. Reference Sink does not send any reply to AUX <br>");
            }
            else
            {
                TestCasesResults.Add($"Step 3 ::[FAIL]: Wait until the Source DUT issues an AUX request.But Sink Sends the reply <br> ");
            }

        }

        // step 4 validation 4211
        public void ValidateTwoReqTiming(List<Packet> PacketList, List<string> TestCasesResults)
        {
            int firstReqIndex = FirstReq(PacketList);

            int secondReqIndex = ReqOccurance(PacketList, 2);

            //checking the time diff between is more than 400 us
            if ((PacketList[secondReqIndex].TimeStamp - PacketList[firstReqIndex].TimeStamp) * 1e6 >= 400) // multiplyed by 100000 for converting mirco seconds to seconds.
            {
                TestCasesResults.Add($"Step 4 ::[PASS]: Source DUT waits at least 400us after completion of previous request before sending a new request.Expt TimeDiffe is 400us Obt time diff is " +
                    $"  {(PacketList[secondReqIndex].TimeStamp - PacketList[firstReqIndex].TimeStamp) * 1e6}us  " +
                    $"    Start Index #  {firstReqIndex} End Index # {secondReqIndex} <br> ");
            }
            else
            {
                TestCasesResults.Add($"Step 4 ::[Fail]: Source DUT doesn't waits at least 400us after completion of previous request before sending a new request.Expt TimeDiffe is 400us Obt time diff is " +
                                   $"  {(PacketList[secondReqIndex].TimeStamp - PacketList[firstReqIndex].TimeStamp) * 1e6}us  " +
                                   $"    Start Index #  {firstReqIndex} End Index # {secondReqIndex} <br> ");
            }

        }
        // step 5 validation 4211
        public void ValFirstAndEndReq(List<Packet> PacketList, List<string> TestCasesResults)
        {

            int firstReqIndex = FirstReq(PacketList);

            int lastReqBeforeRes = LastReqIndexBeforeRes(PacketList);

            //checking the first req and req before res time diff between is more than 400 us

            if ((PacketList[lastReqBeforeRes].TimeStamp - PacketList[firstReqIndex].TimeStamp) * 1e6 >= 400) // multiplyed by 100000 for converting mirco seconds to seconds.
            {
                TestCasesResults.Add($"Step 5 ::[PASS]:  the Source DUT  issues another AUX request Reference Sink shall only respond to requests. " +
                 $"Reference Sink replies normally to this AUX request. Verify that Source DUT waits at least 400us after completion of previous request before sending the new request." +
                                   $"  {(PacketList[lastReqBeforeRes].TimeStamp - PacketList[firstReqIndex].TimeStamp) * 1e6}us  " +
                                   $"    Start Index #  {firstReqIndex} End Index # {lastReqBeforeRes} <br> ");
            }
            else
            {
                TestCasesResults.Add($"Step 5 ::[FAIL]:  the Source DUT doesn't issues another AUX request or Reference Sink shall only respond to requests. " +
              $"Reference Sink replies normally to this AUX request. Verify that Source DUT doesn't waits at least 400us after completion of previous request before sending the new request." +
                                $"  {(PacketList[lastReqBeforeRes].TimeStamp - PacketList[firstReqIndex].TimeStamp) * 1e6}us  " +
                                $"    Start Index #  {firstReqIndex} End Index # {lastReqBeforeRes} <br> ");
            }
        }

        // step 3 validation 4212
        public void ValFirstReqRes(List<Packet> PacketList, List<string> TestCasesResults)
        {
            int firstReqIndex = FirstReq(PacketList);
            int nextToFirstReq = firstReqIndex + 1;

            //checking next to the first is a res
            if (PacketList[nextToFirstReq].MsgValue == MsgType.Res)
            {
                TestCasesResults.Add($"Step 3 ::[PASS]:  the Source DUT  issues a AUX request Reference Sink replies normally to this AUX request.<br>");
            }
            else
            {
                TestCasesResults.Add($"Step 3 ::[FAIL]:  the Source DUT  issues a AUX request Reference doesn't replies normally to this AUX request.<br>");
            }

        }

        // step 4 validation 4212
        public void ValSecondReqRes(List<Packet> PacketList, List<string> TestCasesResults)
        {
            int firstReqIndex = FirstReq(PacketList);
            int nextToFirstReq = firstReqIndex + 1;
            int secondReqIndex = ReqOccurance(PacketList, 2);

            //checking next to the first is a res
            if (PacketList[nextToFirstReq].MsgValue == MsgType.Res)
            {
                //checking the time diff btw first and next req is 400 us
                if ((PacketList[secondReqIndex].TimeStamp - PacketList[firstReqIndex].TimeStamp) * 1e6 >= 400) // multiplyed by 100000 for converting mirco seconds to seconds.
                {
                    TestCasesResults.Add($"Step 4 ::[PASS]: Source DUT waits at least 400us after completion of previous request before sending a new request.Expt TimeDiffe is 400us Obt time diff is " +
                        $"  {(PacketList[secondReqIndex].TimeStamp - PacketList[firstReqIndex].TimeStamp) * 1e6}us  " +
                        $"    Start Index #  {firstReqIndex} End Index # {secondReqIndex} <br> ");

                }
                else
                {
                    TestCasesResults.Add($"Step 4 ::[Fail]: Source DUT doesn't waits at least 400us after completion of previous request before sending a new request.Expt TimeDiffe is 400us Obt time diff is " +
                                       $"  {(PacketList[secondReqIndex].TimeStamp - PacketList[firstReqIndex].TimeStamp) * 1e6}us  " +
                                       $"    Start Index #  {firstReqIndex} End Index # {secondReqIndex} <br> ");
                }
            }
            else
            {
                TestCasesResults.Add($"Step 3 ::[FAIL]:  the Source DUT  issues a AUX request Reference doesn't replies normally to this AUX request.");

            }

        }
        //step 3 validation 4213

        public void LinkStartWithin5Sec(List<Packet> PacketList, List<string> TestCasesResults)
        {
            int HPDAssertedIndex = CmdIndexReturn(CmdType.HPD_Asserted, PacketList);
            int TPS_StartIndex = TrainingPatternStartIndex(PacketList, 1);
            if (PacketList[TPS_StartIndex].TimeStamp - PacketList[HPDAssertedIndex].TimeStamp <= 5)
            {
                TestCasesResults.Add("step 3 ::[PASS]:Reference Sink wait up to 5 Sec for Source DUT to write 01h or 21h to the TRAINING_PATTERN_SET");
            }
            else
            {
                TestCasesResults.Add("step 3 ::[FAIL]:Reference doesn't waits 5 Sec for Source DUT to write 01h or 21h to the TRAINING_PATTERN_SET");
            }
        }

        public int TrainingPatternStartIndex(List<Packet> PacketList,int occurance)
        {
         
            int index = 0;
            int times = 0;

            for(int i = 0;i<PacketList.Count;i++)
            {
                
                string check = PacketList[i].PayloadData;
                string finalCheck = check.Substring(0,24);
                 
                if(finalCheck == "TRAINING_PATTERN_SET : 21")
                {
                    times++;
                    if (occurance == times)
                    {
                        break;
                    }
                }
            }

            return index;
        }

        // This method returns the cmdType values index for checking time
        public int CmdIndexReturn(CmdType CmdValue, List<Packet> PacketList)
        {
            int index = 0;

            for (int i = 0; i < PacketList.Count; i++)
            {
                if (PacketList[i].CmdValue == CmdValue)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        //finding the first req index method
        public int FirstReq(List<Packet> PacketList)
        {
            int index = 0;

            for (int i = 0; i < PacketList.Count; i++)
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
        public int ReqOccurance(List<Packet> PacketList, int occurance)
        {
            int index = 0;
            int times = 0;

            for (int i = 0; i < PacketList.Count; i++)
            {
                if (PacketList[i].MsgValue == MsgType.Req)
                {
                    times++;
                    if (times == occurance)
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
                    if (PacketList[i + 1].MsgValue == MsgType.Res)
                    {
                        index = i;
                        break;
                    }
                }
            }
            return index;
        }

        // colour change method
        public void ColorChange(List<string> TestCasesResults)
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
