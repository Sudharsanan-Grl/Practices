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
           List<double> StartTimeList = new List<double>();

        List<Packet> PacketList = new List<Packet>();
        List<CmdType> CmdList = new List<CmdType>();
        string filePath = @"C:\Users\GRL\Downloads\TD_4_2_1_1\TD_4_2_1_1\Test_Pkt.csv";
            string[] csvLines = File.ReadAllLines(filePath);
           
            
            if (csvLines.Length > 0)
            {
                for (int i = 1; i < csvLines.Length; i++)
                {
                    Packet CurrPkt = new Packet();
                    string[] row = csvLines[i].Split(',');
                      CurrPkt.ToTimeStamp(row[1], StartTimeList);
                      CurrPkt.ToMsgType(row[3]);
                      CurrPkt.ToTransactType(row[4]);
                      CurrPkt.ToCmdType(row[5],CmdList);
                      CurrPkt.ToAddressList(row[6]);
                      CurrPkt.ToDataLength(row[7]);
                      CurrPkt.ToPayloadData(row[9]);
                      PacketList.Add(CurrPkt);
                   

            }        
        
            }
            
            Packet O  = new Packet();
            int FNatIndex = O.FirstNatIndex(PacketList);
            int LNatIndex = O.LastNatIndex(PacketList);
            int FI2CIndex = O.FirstI2CIndex(PacketList);
            int LI2CIndex   = O.LastI2CIndex(PacketList);
            int FNatWrIndex = O.FirstNatWrIndex(PacketList);
            int LNatWrIndex = O.LastNatWrIndex(PacketList);
            int FI2CWrIndex = O.FirstI2CWrIndex(PacketList);
            int LI2CWrIndex = O.LastI2CWrIndex(PacketList);
           
            int MsgTypeOccIndex = O.ReqResOccuranceIndex(PacketList,4,MsgType.Res);
            
            Console.WriteLine("the first occurance of the Nat is comes with the index of "+FNatIndex);
            Console.WriteLine("the Last occurance of the Nat is comes with the index of " + LNatIndex);
            Console.WriteLine("the first occurance of the I2C is comes with the index of " + FI2CIndex);
            Console.WriteLine("the Last occurance of the I2C is comes with the index of " + LI2CIndex);
            Console.WriteLine("the first occurance of the Nat Write is comes with the index of " + FNatWrIndex);
            Console.WriteLine("the Last occurance of the Nat Write is comes with the index of " + LNatWrIndex);
            Console.WriteLine("the first occurance of the I2C Write is comes with the index of " + FI2CWrIndex);
            Console.WriteLine("the Last occurance of the I2C Write is comes with the index of " + LI2CWrIndex);
      
           Console.WriteLine("the fourth occurance of Res  is "+ MsgTypeOccIndex);

          
            TestCase4211 obj = new TestCase4211();
            obj.verify(CmdList,StartTimeList);
            Console.ReadLine();
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
            /*     if   (PacketList[0].TransactValue.Equals("Nat"))
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
                    if(CmdTypes.Contains("TestStart")) 
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
                       }
        */
        }


        //First/last native packet
        //First/last i2c packet
        //First/last native write
        //first/last i2c write

    }
}

