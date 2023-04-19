﻿using System;
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
    public class HelperClass
    {
        public double TimeStampMethod(string timeStampstring,double timeStamp)
        {          
            if (Double.TryParse(timeStampstring,out timeStamp)){ }                                
            else
            {
                Console.WriteLine("The string {0} could not be converted to a double.", timeStampstring);
            }         
            return timeStamp;
        }
       
        public Enum EnumConverterMethod(string enumString,Enum enumValue )
        {
            try
            {
               
                if (enumValue.GetType() == typeof(MsgType))
                {
                    enumValue = (MsgType)Enum.Parse(typeof(MsgType), enumString);

                    return enumValue;
                }
                else if(enumValue.GetType() == typeof(CmdType))
                {
                    enumValue = (CmdType)Enum.Parse(typeof(CmdType), enumString);

                    return enumValue;
                }
                else if(enumValue.GetType() == typeof(TransactType))
                {
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
   
        public int  GetDesiredPacket(List<Packet>PacketList,HelperInput obj)
        {
                int index = 0;
                int times=0;

            if(obj.firstOrLastValueSearch == FirstOrLast.first)
            {
                for (int i = 0; i < PacketList.Count; i++)
                {
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
