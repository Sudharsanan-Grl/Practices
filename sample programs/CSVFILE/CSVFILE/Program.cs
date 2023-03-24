using CSVFILE;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using static CSVFILE.Packet;

namespace CSVFILES
{



    public class Program
    {
        static void Main(string[] args)
        {

            string filePath = @"C:\Users\GRL\Downloads\TD_4_2_1_1\TD_4_2_1_1\Test_Pkt.csv";
            string[] csvLines = File.ReadAllLines(filePath);

            Packet CurrPkt = new Packet();
            List<Packet> PacketList = new List<Packet>();

            if (csvLines.Length > 0)
            {
                for (int i = 1; i < csvLines.Length; i++)
                {

                    string[] row = csvLines[i].Split(',');
                      CurrPkt.ToTimeStamp(row[1]);
                      CurrPkt.ToCmdType(row[5]);
                      CurrPkt.ToMsgType(row[3]);
                      CurrPkt.ToTransactType(row[4]);
                      CurrPkt.ToCmdType(row[5]);
                      CurrPkt.ToAddressList(row[6]);
                      CurrPkt.ToDataLength(row[7]);
                      CurrPkt.ToPayloadData(row[9]);
                      PacketList.Add(CurrPkt);
             
                }

                Console.WriteLine(PacketList[0].TransactValue);
                Console.WriteLine(PacketList[1].Address);
                Console.WriteLine(PacketList[2].Address);
                Console.WriteLine(PacketList[3].Address);
                Console.WriteLine(PacketList[4].Address);
                Console.WriteLine(PacketList[5].Address);
             if   (PacketList[0].TransactValue.Equals("Nat"))
                {
                    Console.WriteLine("Nat is contains");

                }
             else
                {
                    Console.WriteLine("Nat is not contains");
                }
             if(   PacketList[0].TransactValue.Equals("I2C"))
                {
                    Console.WriteLine("I2C is contains");

                }
             else
                {
                    Console.WriteLine("I2C is not contains");
                }
                /*    if(CmdTypes.Contains("TestStart")) 
                  {
                       int c = CmdTypes.IndexOf("HPD_Removed");
                       int c2 = CmdTypes.IndexOf("HPD_Asserted");
                       Console.WriteLine(StartTimes[c]);
                       Console.WriteLine(StartTimes[c2]);
                       string ti  = StartTimes[c2];
                       string ti2 = StartTimes[c];
                       var t  = int.Parse(ti);
                       int t2 = int.Parse(ti2);
                   Console.WriteLine(t-t2);
                       }*/
            }
            //     O.DisplayTimeStamp();
            //    O.DisplayCmdType();
            //      O.DisplayTransactType();
            //     O.DisplayMsgType();
            //    O.DisplayPayloadData();
            //     O.DisplayDataLength();
            //        O.DisplayAddress();
            /*   CurrPkt.payloadSeparate(CurrPkt.PayloadDataList, 127);
               CurrPkt.payloadSeparate(CurrPkt.PayloadDataList, 119);
               CurrPkt.payloadSeparate(CurrPkt.PayloadDataList, 120);
            */
         //   CurrPkt.DisplayTimeStamp();
        }
        
       
        //First/last native packet
        //First/last i2c packet
        //First/last native write
        //first/last i2c write
        
    }
}

