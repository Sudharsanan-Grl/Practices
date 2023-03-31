using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static CSVFILE.Packet;
namespace CSVFILE
{
    internal class Helper
    {
        public double TimeStampMethod(string TimeStampstring,double TimeStamp)
        {
           
            if (Double.TryParse(TimeStampstring,out TimeStamp)){ }                                
            else
            {
                Console.WriteLine("The string {0} could not be converted to a double.", TimeStampstring);
            }         
            return TimeStamp;
        }
        public MsgType MsgTypeMethod(string MsgTypeString, MsgType MsgValue)
        {
            try
            {
                MsgValue = (MsgType)Enum.Parse(typeof(MsgType), MsgTypeString);
                return MsgValue;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return MsgValue;
            }
        }
        public TransactType TransactTypeMethod(string TransactString, TransactType TransactValue)
        {
            try
            {
                TransactValue = (TransactType)Enum.Parse(typeof(TransactType), TransactString);
                return TransactValue;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return TransactValue;
            }
        }

        public  CmdType CmdTypeMethod(string CmdString, CmdType CmdValue)
        {
            try
            {
                CmdValue = (CmdType)Enum.Parse(typeof(CmdType), CmdString);
                return CmdValue;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return CmdValue;
            }
        }
        public int AddressMethod(string StringAddress,int Address)
        {
            Address = Convert.ToInt32(StringAddress, 16);
            return Address;
        }
        public int DataLengthMethod(string DataLengthString,int DataLength)
        {

            if (DataLengthString == "")
            {
                return DataLength = 0;
            }
            else
            {
              return  DataLength = int.Parse(DataLengthString);
            }
        }
        public void GetDesiredPacket()
        {

        }
        //
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

        public int ReqResOccuranceIndex(List<Packet> PacketList, int NumOfOcc, MsgType ReqOrRes)
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
    }
}
