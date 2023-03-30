﻿using System;
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
            double value = double.Parse(TimeStampstring);
            StartTimeList.Add(value);
            TimeStamp = value;
        }
        public void DisplayTimeStamp()
        {
        
                Console.WriteLine(TimeStamp);
            
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
        public int FirstNatIndex(List<Packet>PacketList)
        {
            int index=0;
            for(int i=0;i<PacketList.Count;i++)
            {
                if (PacketList[i].TransactValue == TransactType.Nat)
                {
                    index = i;
                        break;
                }
            }
            return index;
        }
        public int LastNatIndex(List<Packet> PacketList)
        {
            int index=0;
            for (int i = PacketList.Count-1; i >0 ; i--)
            {
                if (PacketList[i].TransactValue == TransactType.Nat)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        public int FirstI2CIndex(List<Packet> PacketList)
        {
            int index=0;
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
        public int LastI2CIndex(List<Packet> PacketList)
        {
            int index = 0;
            for (int i = 0; i < PacketList.Count; i++)
            {
                if (PacketList[i].TransactValue == TransactType.I2C)
                    index = i;
            }
            return index;
        }
        public int FirstNatWrIndex(List<Packet> PacketList)
        {
            int index=0;
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
        public int LastNatWrIndex(List<Packet> PacketList)
        {
            int index = 0;
            for (int i = 0; i < PacketList.Count; i++)
            {
                if (PacketList[i].TransactValue == TransactType.Nat && PacketList[i].CmdValue == CmdType.Wr)
                    index = i;
            }
            return index;
        }
        public int FirstI2CWrIndex(List<Packet> PacketList)
        {
            int index=0;
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
        public int LastI2CWrIndex(List<Packet> PacketList)
        {
            int index = 0;
            for (int i = 0; i < PacketList.Count; i++)
            {
                if (PacketList[i].TransactValue == TransactType.I2C && PacketList[i].CmdValue == CmdType.Wr)
                    index = i;
            }
            return index;
        }
     
        public int ReqResOccuranceIndex(List<Packet> PacketList, int NumOfOcc,MsgType ReqOrRes)
        {
            int index = 0;
            int times = 0;
            for (int i = 0; i < PacketList.Count; i++)
            {
                if (PacketList[i].MsgValue == ReqOrRes)
                {

                    times++;
                    if (times == NumOfOcc)
                    {
                        index = i;
                        break;
                    }

                }


            }
            return index;
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
