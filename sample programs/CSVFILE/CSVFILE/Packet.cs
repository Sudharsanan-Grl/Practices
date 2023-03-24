using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSVFILE
{
    //create enum for NAT and I2C
    //create enum for Req and Res
    //create enum for Rd and Wr
    //create int for address
    // crate int for data length
    // create string for payload data
    internal class Packet
    {
        public double TimeStamp;
        public enum TransactType
        {
            None,
            Nat,
            I2C
        }
        public enum MsgType
        {
            FW_Assert,
            Req,
            Res
        }
        public enum CmdType
        {

           
            Wr,
            Rd,
            ACK_A,
            ACK_I,
            DMA_Config,
            TestStart,
            TestStop,
            ClockRecoveryTestPattern_Detected,
            ClockRecoverySuccess,
            EqualizationTestPatternDetected,
            EqualizationSuccess,
            HPD_Removed,
            HPD_Asserted
        }
        public CmdType CmdValue;
        public MsgType MsgValue;
        public TransactType TransactValue;
        public int Address;
        public int DataLength;
        public string PayloadData;

       
        public void ToTimeStamp(string TimeStampstring)
        {
            double value = double.Parse(TimeStampstring);

            TimeStamp = value;
        }
        public void DisplayTimeStamp()
        {
        
                Console.WriteLine(TimeStamp);
            
        }
        public void ToCmdType(string stringValue)
        {
            
            try
            {
                CmdValue = (CmdType)Enum.Parse(typeof(CmdType), stringValue);

            }
            catch (System.ArgumentException ax)
            {
                Console.WriteLine("the argument is missing in the CmdType" );
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    
      public void DisplayCmdValue()
        {
                Console.WriteLine(CmdValue);
            

        }
        public void ToTransactType(string stringValue)
        {
           
            try
            {
                TransactValue = (TransactType)Enum.Parse(typeof(TransactType), stringValue);

            }
            catch (System.ArgumentException ax)
            {
                Console.WriteLine("the argument is missing in the TransactType");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        public void DisplayTransactValue()
        {
            Console.WriteLine(TransactValue);

        }
        public void ToMsgType(string stringValue)
        {
            try
            {
                MsgValue = (MsgType)Enum.Parse(typeof(MsgType), stringValue);
            }
            catch (System.ArgumentException ax)
            {
                Console.WriteLine("the argument is missing in the MsgType ");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
     
        }

        public void DisplayMsg()
        {
            Console.WriteLine(MsgValue);

        }
        public void ToAddressList(string StringAddress)
        {
           Address  = Convert.ToInt32(StringAddress, 16);
            
        }
        public void DisplayAddress()
        {
            Console.WriteLine(Address);
        }
        public void ToDataLength(string DataLengthString)
        {
           
            if (DataLengthString == "")
            {
                DataLength = 0;
            }
            else
            {
                DataLength = int.Parse(DataLengthString);
            }



            
        }
        public void DisplayDataLength()
        {
            Console.WriteLine(DataLength);
        }
        public void ToPayloadData(string PayloadDataString)
        {
            PayloadData = PayloadDataString;
        }
        public void DisplayPayloadData()
        {
            Console.WriteLine(PayloadData);
        }

       /* public void payloadSeparate(List<string> PayloadDataList, int index)
        {

            string[] datas = PayloadDataList[index].Split(':');



            foreach (var item in datas)
            {

                if (item != "")
                {

                    SeperatedPayloadDataList.Add(item.Trim());

                }

            }

            //Console.WriteLine(datas);
            //     datas.First();
            if (datas[0].Contains("MAIN_LINK_CHANNEL_CODING_SET"))
            {
                Console.WriteLine("it contain");
            }

        }
        public void DisplayPayloadSeparate()
        {
            foreach (var item in SeperatedPayloadDataList)
            {
                Console.WriteLine(item);
                //
            }
        }
     */
    }
}
