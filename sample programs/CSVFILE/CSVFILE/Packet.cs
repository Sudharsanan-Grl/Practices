using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvFile
{
    /// <summary>
    /// This class is used for storing all the parameter required in a packet.
    /// Enum value,double value ,string value,int values are created in this class. 
    /// </summary>
    public class Packet
    {
        // creating a double variable
        public double TimeStamp;

        // creating a enum 
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

        // creating a enum variables
        public MsgType MsgValue;

        public CmdType CmdValue;

        public TransactType TransactValue;

        // creating a int
        public int Address;

        public int DataLength;

        // creating a string 
        public string PayloadData;
       
        HelperClass helperObj = new HelperClass();


        // storing the converted datatypes .
        public void ToTimeStamp(string timeStampstring)
        {     
            TimeStamp = helperObj.TimeStampMethod(timeStampstring, TimeStamp);
        }
        public void ToMsgType(string msgTypeString)
        {
            MsgValue = (MsgType)helperObj.EnumConverterMethod(msgTypeString, MsgValue);
        
        }    
        public void ToTransactType(string transactString)
        {
            TransactValue = (TransactType)helperObj.EnumConverterMethod(transactString, TransactValue);        
        }
        public void ToCmdType(string stringValue)
        {
            CmdValue= (CmdType)helperObj.EnumConverterMethod(stringValue, CmdValue);
        }           
        public void ToAddressList(string stringAddress)
        {
           Address  = helperObj.AddressMethod(stringAddress, Address);     
        }       
        public void ToDataLength(string dataLengthString)
        {
            DataLength=helperObj.DataLengthMethod(dataLengthString, DataLength);
        }      
        public void ToPayloadData(string payloadDataString)
        {
            PayloadData = payloadDataString;
        }                   
    }
}
