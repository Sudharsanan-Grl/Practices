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
        public MsgType MsgValue;
        public CmdType CmdValue;
        public TransactType TransactValue;
        public int Address;
        public int DataLength;
        public string PayloadData;
       
       
        public void ToTimeStamp(string TimeStampstring, List<double>StartTimeList)
        {
            //use tryparse instead of parse
            double value = double.Parse(TimeStampstring);
            StartTimeList.Add(value);
            TimeStamp = value;
        }
       
        public void ToCmdType(string stringValue,List<CmdType>CmdList)
        {
            
            try
            {
                CmdValue = (CmdType)Enum.Parse(typeof(CmdType), stringValue);
                CmdList.Add(CmdValue);
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
    
      
       
        public void ToTransactType(string stringValue)
        {
           // Resmove transact type and use single method
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
    
        
        public void ToMsgType(string stringValue)
        {
            Helper helper = new Helper();
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

      
        public void ToAddressList(string StringAddress)
        {
           Address  = Convert.ToInt32(StringAddress, 16);
            
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
       
        public void ToPayloadData(string PayloadDataString)
        {
            PayloadData = PayloadDataString;
        }
        
        

        
    }
}
