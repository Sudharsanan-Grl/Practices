
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using static CsvFile.Packet;
using static CsvFile.HelperInput;

namespace CsvFile
{  /// <summary>
     /// This is the Driver class .
     /// It is used for getting the parameters in the csv file and sending to the desired class.
     /// It is also used for calling the required methods.
   /// </summary>
    

    public class Program
    {
        static void Main(string[] args)
        {
            List<Packet> PacketList = new List<Packet>();
          
            string filePath = @"C:\Users\GRL\Downloads\TD_4_2_1_1\TD_4_2_1_1\Test_Pkt.csv";
         
            string[] csvLines = File.ReadAllLines(filePath);

            if (csvLines.Length > 0)
            {
                for (int i = 1; i < csvLines.Length; i++)
                {
                    Packet currentPkt = new Packet();
                    string[] row = csvLines[i].Split(',');
                    currentPkt.ToTimeStamp(row[1]);
                    currentPkt.ToMsgType(row[3]);
                    currentPkt.ToTransactType(row[4]);
                    currentPkt.ToCmdType(row[5]);
                    currentPkt.ToAddressList(row[6]);
                    currentPkt.ToDataLength(row[7]);
                    currentPkt.ToPayloadData(row[9]);
                    PacketList.Add(currentPkt);
                }
            }

            HelperClass helperObj = new HelperClass();

            int firstNatIndex    = helperObj.FirstNatIndex(PacketList);
            int lastNatIndex    = helperObj.LastNatIndex(PacketList);
            int firstI2CIndex    = helperObj.FirstI2CIndex(PacketList);
            int lastI2CIndex    = helperObj.LastI2CIndex(PacketList);
            int firstNatWrIndex  = helperObj.FirstNatWrIndex(PacketList);
            int lastNatWrIndex  = helperObj.LastNatWrIndex(PacketList);
            int firstI2CWrIndex  = helperObj.FirstI2CWrIndex(PacketList);
            int lastI2CWrIndex  = helperObj.LastI2CWrIndex(PacketList);
            int msgTypeOccIndex = helperObj.ReqResOccuranceIndex(PacketList, 4, MsgType.Res);

            Console.WriteLine("the first occurance of the Nat is comes with the index of " + firstNatIndex);
            Console.WriteLine("the Last  occurance of the Nat is comes with the index of " + lastNatIndex);
            Console.WriteLine("the first occurance of the I2C is comes with the index of " + firstI2CIndex);
            Console.WriteLine("the Last  occurance of the I2C is comes with the index of " + lastI2CIndex);
            Console.WriteLine("the first occurance of the Nat Write is comes with the index of " + firstNatWrIndex);
            Console.WriteLine("the Last  occurance of the Nat Write is comes with the index of " + lastNatWrIndex);
            Console.WriteLine("the first occurance of the I2C Write is comes with the index of " + firstI2CWrIndex);
            Console.WriteLine("the Last  occurance of the I2C Write is comes with the index of " + lastI2CWrIndex);
            Console.WriteLine("the fourth occurance of Res  is " + msgTypeOccIndex);

            HelperInput helperInputObj = new HelperInput(MsgType.Req, CmdType.Wr, TransactType.Nat, FirstOrLast.first,8);
            
            int desiredIndex= helperObj.GetDesiredPacket(PacketList, helperInputObj);

            Console.WriteLine("the first Nat req wr 8th occ is "+ desiredIndex);

            TestCase4211 testCase4211Obj = new TestCase4211();

            testCase4211Obj.Verify4211(PacketList);
        }
    }
}

