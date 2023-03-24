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
          
            Rd,
            Wr,
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
        public int Address;
        public int DataLength;
        public string PayloadData;
         
        public  List<double>  TimeStampList = new List<double>();
        public List<CmdType>  CmdTypeList = new List<CmdType>();
        public List<TransactType> TransactTypeList= new List<TransactType>();
        public List<MsgType>  MsgTypeList= new List<MsgType>();
        public List<string> PayloadDataList = new List<string>();
        public List<int> DataLengthList = new List<int>();
        public List<int> AddressList = new List<int>();
        public List<string> SeperatedPayloadDataList= new List<string>();   
        public void ToTimeStampList(string TimeStamp)
        {
            double value = double.Parse(TimeStamp);
            TimeStampList.Add(value);
          
        }
        public void DisplayTimeStamp()
        {
           foreach (var t in TimeStampList)
           {
              Console.WriteLine(t);
           }
        }
       public void ToCmdTypeList(string stringValue)
        {
            CmdType value = (CmdType)Enum.Parse(typeof(CmdType), stringValue);
            CmdTypeList.Add(value);
        }
        
       public void DisplayCmdType()
        {
            foreach(var item in CmdTypeList)
            {
                Console.WriteLine(item);
            }
    
        }
        public void ToTransactTypeList(string stringValue)
        {
            TransactType value = (TransactType)Enum.Parse(typeof(TransactType), stringValue);
            TransactTypeList.Add(value);
        }

        public void DisplayTransactType()
        {
            foreach (var item in TransactTypeList)
            {
                Console.WriteLine(item);
            }

        }
        public void ToMsgTypeList(string stringValue)
        {
            MsgType value = (MsgType)Enum.Parse(typeof(MsgType), stringValue);
            MsgTypeList.Add(value);
        }

        public void DisplayMsgType()
        {
            foreach (var item in MsgTypeList)
            {
                Console.WriteLine(item);
            }

        }
        public void ToAddressList(string Address)
        {
            int value= Convert.ToInt32(Address,16);
            AddressList.Add(value);
        }
        public void DisplayAddress() 
        { 
            foreach (var item in AddressList)
            { 
                Console.WriteLine(item); 
            }
        }
        public void ToDataLength(string DataLength)
        {
            int value;
           if(DataLength == "")
            {
                value= 0;
            }
           else
            {
                value = int.Parse(DataLength);
            }
      
           
      
           DataLengthList.Add(value);
        }
        public void DisplayDataLength()
        {
            foreach (var item in DataLengthList)
            {
                Console.WriteLine(item);
            }
        }
        public void ToPayloadDataList(string PayloadData)
        {
            PayloadDataList.Add(PayloadData);
        }
        public void DisplayPayloadData()
        {
            foreach(var item in PayloadDataList)
            {
                Console.WriteLine( item);
            }
        }

        public void payloadSeparate()
        {
            Console.WriteLine(PayloadDataList[127]);
            string[]datas= PayloadDataList[127].Split(':');
            foreach (var item in datas)
            {

                if (item != "")
                {
                  
                    SeperatedPayloadDataList.Add(item.Trim());
                    
                }
            
            }
            foreach (var item in SeperatedPayloadDataList)
            {
                Console.WriteLine(item);
            }
            //Console.WriteLine(datas);
            //     datas.First();
            if (datas[0].Contains("MAIN_LINK_CHANNEL_CODING_SET")) 
            {
                Console.WriteLine("it contain");
            }
        }
    }
}
