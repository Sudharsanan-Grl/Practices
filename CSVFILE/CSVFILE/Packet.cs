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
       
       Helper hobj=new Helper();
        public void ToTimeStamp(string TimeStampstring)
        {
            //use tryparse instead of parse
            TimeStamp = hobj.TimeStampMethod(TimeStampstring, TimeStamp);


        }
        public void ToMsgType(string MsgTypeString)
        {
            MsgValue = hobj.MsgTypeMethod(MsgTypeString, MsgValue);
        }
       
        public void ToTransactType(string TransactString)
        {
            TransactValue = hobj.TransactTypeMethod(TransactString, TransactValue);
        }
        public void ToCmdType(string stringValue)
        {
            CmdValue=hobj.CmdTypeMethod(stringValue, CmdValue);


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
