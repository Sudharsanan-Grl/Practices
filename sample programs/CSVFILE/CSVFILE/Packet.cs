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
    public class Packet
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
       
         HelperClass hobj=new HelperClass();
        public void ToTimeStamp(string TimeStampstring)
        {     
            TimeStamp = hobj.TimeStampMethod(TimeStampstring, TimeStamp);
        }
        public void ToMsgType(string MsgTypeString)
        {
            MsgValue = (MsgType)hobj.EnumConverterMethod(MsgTypeString, MsgValue);
        
        }
       
        public void ToTransactType(string TransactString)
        {
            TransactValue = (TransactType)hobj.EnumConverterMethod(TransactString, TransactValue);
          
        }
        public void ToCmdType(string stringValue)
        {
            CmdValue= (CmdType)hobj.EnumConverterMethod(stringValue, CmdValue);
        }           
        public void ToAddressList(string StringAddress)
        {
           Address  = hobj.AddressMethod(StringAddress, Address);     
        }
       
        public void ToDataLength(string DataLengthString)
        {
            DataLength=hobj.DataLengthMethod(DataLengthString, DataLength);
        }
       
        public void ToPayloadData(string PayloadDataString)
        {
            PayloadData = PayloadDataString;
        }
        
        

        
    }
}
