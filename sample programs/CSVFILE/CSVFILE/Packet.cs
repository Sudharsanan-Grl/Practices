using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvFile
{
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
        public void ToTimeStamp(string timeStampstring)
        {     
            TimeStamp = hobj.TimeStampMethod(timeStampstring, TimeStamp);
        }
        public void ToMsgType(string msgTypeString)
        {
            MsgValue = (MsgType)hobj.EnumConverterMethod(msgTypeString, MsgValue);
        
        }    
        public void ToTransactType(string transactString)
        {
            TransactValue = (TransactType)hobj.EnumConverterMethod(transactString, TransactValue);        
        }
        public void ToCmdType(string stringValue)
        {
            CmdValue= (CmdType)hobj.EnumConverterMethod(stringValue, CmdValue);
        }           
        public void ToAddressList(string stringAddress)
        {
           Address  = hobj.AddressMethod(stringAddress, Address);     
        }       
        public void ToDataLength(string dataLengthString)
        {
            DataLength=hobj.DataLengthMethod(dataLengthString, DataLength);
        }      
        public void ToPayloadData(string payloadDataString)
        {
            PayloadData = payloadDataString;
        }                   
    }
}
