using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static CsvFile.Packet;
using static CsvFile.HelperInput;
namespace CsvFile
{

    /// <summary>
    /// This helper class is used for converting string value into enum value.
    /// This helper class is also used for converting string value into double and int  value.
    /// This class is also used for getting the index of first/last nat/i2c req/res rd/wr.
    /// </summary>
    public class HelperClass
    {
        // converting string to double
        public double TimeStampMethod(string timeStampstring,double timeStamp)
        {          
            if (Double.TryParse(timeStampstring,out timeStamp)){ }                                
            else
            {
                Console.WriteLine("The string {0} could not be converted to a double.", timeStampstring);
            }         
            return timeStamp;
        }
        // converting string to enum

        public Enum EnumConverterMethod(string enumString,Enum enumValue )
        {
            try
            {
               // cheks the types of the enum

                if (enumValue.GetType() == typeof(MsgType))
                {
                    // converting string into enum

                    enumValue = (MsgType)Enum.Parse(typeof(MsgType), enumString);

                    return enumValue;
                }
                else if(enumValue.GetType() == typeof(CmdType))
                {
                    // converting string into enum

                    enumValue = (CmdType)Enum.Parse(typeof(CmdType), enumString);

                    return enumValue;
                }
                else if(enumValue.GetType() == typeof(TransactType))
                {
                    // converting string into enum

                    enumValue = (TransactType)Enum.Parse(typeof(TransactType), enumString);

                    return enumValue;
                }
                else 
                {
                    Console.WriteLine("The enum is not in the correct format");

                    return enumValue;
                }              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                return enumValue;
            }
        }
        // converting string to int

        public int AddressMethod(string stringAddress,int address)
        {
            address = Convert.ToInt32(stringAddress, 16);

            return address;
        }
        public int DataLengthMethod(string dataLengthString,int dataLength)
        {
            if (dataLengthString == "")
            {
                return dataLength = 0;
            }
            else
            {
              return  dataLength = int.Parse(dataLengthString);
            }
        }
        // using helper obj to get the desired packet index
        public int  GetDesiredPacketIndex(List<Packet>PacketList,HelperInput obj)
        {
                int index = 0;
                int times=0;

            if(obj.firstOrLastValueSearch == FirstOrLast.first)
            {
                for (int i = 0; i < PacketList.Count; i++)
                {
                    // checks all the required condition( first/last Nat/I2C Req/Res rd/wr Occ)

                    if (PacketList[i].CmdValue == obj.CmdValueSearch && 
                        PacketList[i].TransactValue == obj.TransactValueSearch && 
                        PacketList[i].MsgValue == obj.MsgvalueSearch)
                    {
                        times++;
                        if(times== obj.Occurance)
                        {
                            index = i;
                            break;
                        }                      
                    }
                }
                return index;
            }
            else if ((obj.firstOrLastValueSearch == FirstOrLast.last))
            {
                for (int i = PacketList.Count-1;i>0 ; i--)
                {
                    if (PacketList[i].CmdValue == obj.CmdValueSearch &&
                        PacketList[i].TransactValue == obj.TransactValueSearch && 
                        PacketList[i].MsgValue == obj.MsgvalueSearch)
                    {
                        times++;
                        if (times == obj.Occurance)
                        {
                            index = i;
                            break;
                        }
                    }
                }
                return index;
            }
            else
            {
                Console.WriteLine("please update first or last ");
                return -1;
            }
            
        }
        // getting first nat index
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
        // getting last nat index
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
        // getting first i2c index
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
        // getting last i2c index
        public int LastI2CIndex(List<Packet> PacketList)
        {
            int index = 0;

            for (int i = PacketList.Count-1; i > 0; i--)
            {
                if (PacketList[i].TransactValue == TransactType.I2C)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        // getting first nat wr index
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
        // getting last nat wr index
        public int LastNatWrIndex(List<Packet> PacketList)
        {
            int index = 0;

            for (int i = PacketList.Count - 1; i > 0; i--)
            {
                if (PacketList[i].TransactValue == TransactType.Nat &&
                    PacketList[i].CmdValue == CmdType.Wr)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        // getting first i2c wr index
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
        // getting last i2c wr index
        public int LastI2CWrIndex(List<Packet> PacketList)
        {
            int index = 0;

            for (int i = PacketList.Count - 1; i > 0; i--)
            {
                if (PacketList[i].TransactValue == TransactType.I2C &&
                    PacketList[i].CmdValue == CmdType.Wr)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        // getting req and res occurance index
        public int ReqResOccuranceIndex(List<Packet> PacketList, int numOfOcc, MsgType reqOrRes)
        {
            int index = 0;
            int times = 0;

            for (int i = 0; i < PacketList.Count; i++)
            {
                if (PacketList[i].MsgValue == reqOrRes)
                {
                    times++;
                    if (times == numOfOcc)
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
