using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            None,
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
            HPD_IRQ,
            TriggerStart,
            TriggerStop,
            HPD_Glitch,
            HPD_Asserted
        }

        // creating a enum variables
        public MsgType MsgValue;

        public CmdType CmdValue;

        public TransactType TransactValue;

        // creating a int
        public int Address;

        public int DataLength;

        public int PayloadInfo;

        // creating a string 
        public string PayloadData;

        HelperClass helperObj = new HelperClass();


        // storing the converted datatypes .
        public void ToTimeStamp(string timeStampstring)
        {

            try
            {
                TimeStamp = helperObj.TimeStampMethod(timeStampstring, TimeStamp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void ToMsgType(string msgTypeString)
        {

            try
            {
                MsgValue = (MsgType)helperObj.EnumConverterMethod(msgTypeString, MsgValue);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void ToTransactType(string transactString)
        {
            try
            {
                TransactValue = (TransactType)helperObj.EnumConverterMethod(transactString, TransactValue);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void ToCmdType(string stringValue)
        {
            try
            {
                CmdValue = (CmdType)helperObj.EnumConverterMethod(stringValue, CmdValue);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void ToAddressList(string stringAddress)
        {
            try
            {
                Address = helperObj.AddressMethod(stringAddress, Address);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void ToPayloadInfo(string stringPayloadInfo)
        {
            try
            {
                //removing empty spaces
                string[] splitedPayload = stringPayloadInfo.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);

                if (splitedPayload.Length >= 2)
                {
                    // Get the last two elements from the array
                    string lastElement = splitedPayload[splitedPayload.Length - 1];

                    PayloadInfo = helperObj.PayloadInfo(lastElement, PayloadInfo);
                }
                else
                {
                    PayloadInfo = 0;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void ToDataLength(string dataLengthString)
        {
            try
            {
                DataLength = helperObj.DataLengthMethod(dataLengthString, DataLength);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
      
        public void ToPayloadData(string payloadDataString)
        {
            try
            {
                PayloadData = payloadDataString;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
