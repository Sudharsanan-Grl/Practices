
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using static CsvFile.Packet;
using static CsvFile.HelperInput;

namespace CsvFile

{
    /// <summary>
    /// This is the Driver class .
    /// It is used for getting the parameters in the csv file and sending to the desired class.
    /// It is also used for calling the required methods.
    /// </summary>


    public class Program
    {
        static void Main(string[] args)
        {
            List<Packet> PacketList = new List<Packet>();

            string filePath = @"E:\inputs\4.2.1.1_pkt.csv";

            string[] csvLines = File.ReadAllLines(filePath);

            if (csvLines.Length > 0)
            {
                //  spliting each parameter and sending to the packet class.

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
            //  finding the index

            int firstNatIndex = helperObj.FirstNatIndex(PacketList);
            int lastNatIndex = helperObj.LastNatIndex(PacketList);
            int firstI2CIndex = helperObj.FirstI2CIndex(PacketList);
            int lastI2CIndex = helperObj.LastI2CIndex(PacketList);
            int firstNatWrIndex = helperObj.FirstNatWrIndex(PacketList);
            int lastNatWrIndex = helperObj.LastNatWrIndex(PacketList);
            int firstI2CWrIndex = helperObj.FirstI2CWrIndex(PacketList);
            int lastI2CWrIndex = helperObj.LastI2CWrIndex(PacketList);
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

            //  storing the first/last Nat/I2C Req/Res rd/wr Occ in the instance.

            HelperInput helperInputObj = new HelperInput(MsgType.Req, CmdType.Wr, TransactType.Nat, FirstOrLast.first, 8);

            int desiredIndex = helperObj.GetDesiredPacketIndex(PacketList, helperInputObj);

            Console.WriteLine("the first Nat req wr 8th occ is " + desiredIndex);

            TestCase4211 testCase4211Obj = new TestCase4211();

            // calling the verify method for 4.2.2.1 testcase validation

            testCase4211Obj.Verify4211(PacketList);

            List<Packet> PacketList2 = new List<Packet>();
            string filePath2 = @"E:\inputs\4.2.1.2_pkt.csv";
            string[] csvLines2 = File.ReadAllLines(filePath2);

            if (csvLines2.Length > 0)
            {
                //  spliting each parameter and sending to the packet class.

                for (int i = 1; i < csvLines2.Length; i++)
                {
                    Packet currentPkt = new Packet();
                    string[] row = csvLines2[i].Split(',');
                    currentPkt.ToTimeStamp(row[1]);
                    currentPkt.ToMsgType(row[3]);
                    currentPkt.ToTransactType(row[4]);
                    currentPkt.ToCmdType(row[5]);
                    currentPkt.ToAddressList(row[6]);
                    currentPkt.ToDataLength(row[7]);
                    currentPkt.ToPayloadData(row[9]);
                    PacketList2.Add(currentPkt);
                }
            }

            TestCase4212 testCase4212Obj = new TestCase4212();

            //verifying the 4.2.1.2 testcase
            testCase4212Obj.Verify4212(PacketList2);


            List<Packet> PacketList3= new List<Packet>();
            string filePath3 = @"E:\inputs\4.2.1.3_pkt.csv";
            string[] csvLines3 = File.ReadAllLines(filePath3);

            if (csvLines3.Length > 0)
            {
                //  spliting each parameter and sending to the packet class.

                for (int i = 1; i < csvLines3.Length; i++)
                {
                    Packet currentPkt = new Packet();
                    string[] row = csvLines3[i].Split(',');
                    currentPkt.ToTimeStamp(row[1]);
                    currentPkt.ToMsgType(row[3]);
                    currentPkt.ToTransactType(row[4]);
                    currentPkt.ToCmdType(row[5]);
                    currentPkt.ToAddressList(row[6]);
                    currentPkt.ToDataLength(row[7]);
                    currentPkt.ToPayloadData(row[9]);
                    PacketList3.Add(currentPkt);
                }
            }

            TestCase4213 testCase4213Obj = new TestCase4213();

            //verifying the 4.2.1.3 testcase
            testCase4213Obj.Verify4213(PacketList3);

            List<Packet> PacketList4 = new List<Packet>();
            string filePath4 = @"E:\inputs\4.2.1.4_pkt.csv";
            string[] csvLines4 = File.ReadAllLines(filePath4);

            if (csvLines4.Length > 0)
            {
                //  spliting each parameter and sending to the packet class.

                for (int i = 1; i < csvLines4.Length; i++)
                {
                    Packet currentPkt = new Packet();
                    string[] row = csvLines4[i].Split(',');
                    currentPkt.ToTimeStamp(row[1]);
                    currentPkt.ToMsgType(row[3]);
                    currentPkt.ToTransactType(row[4]);
                    currentPkt.ToCmdType(row[5]);
                    currentPkt.ToAddressList(row[6]);
                    currentPkt.ToDataLength(row[7]);
                    currentPkt.ToPayloadData(row[9]);
                    PacketList4.Add(currentPkt);
                }
            }

            TestCase4214 testCase4214Obj = new TestCase4214();

            //verifying the 4.2.1.4 testcase
            testCase4214Obj.Verify4214(PacketList4);
        }
    }
}

