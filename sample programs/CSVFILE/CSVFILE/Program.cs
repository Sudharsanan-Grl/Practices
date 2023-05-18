
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
            ReadCsvFile readCsvFile = new ReadCsvFile();

            List<Packet> PacketList1 = new List<Packet>();

            // Testcase 4.2.1.1
            string filePath = @"E:\inputs\4.2.1.1_pkt.csv";

            string[] csvLines = File.ReadAllLines(filePath);

            HelperClass helperObj = new HelperClass();

            readCsvFile.ReadCsv(PacketList1, csvLines);

            TestCase4211 testCase4211Obj = new TestCase4211();

            // calling the verify method for 4.2.2.1 testcase validation
            testCase4211Obj.Verify4211(PacketList1);

            //  finding the index

            int firstNatIndex = helperObj.FirstNatIndex(PacketList1);
            int lastNatIndex = helperObj.LastNatIndex(PacketList1);
            int firstI2CIndex = helperObj.FirstI2CIndex(PacketList1);
            int lastI2CIndex = helperObj.LastI2CIndex(PacketList1);
            int firstNatWrIndex = helperObj.FirstNatWrIndex(PacketList1);
            int lastNatWrIndex = helperObj.LastNatWrIndex(PacketList1);
            int firstI2CWrIndex = helperObj.FirstI2CWrIndex(PacketList1);
            int lastI2CWrIndex = helperObj.LastI2CWrIndex(PacketList1);
            int msgTypeOccIndex = helperObj.ReqResOccuranceIndex(PacketList1, 4, MsgType.Res);

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

            int desiredIndex = helperObj.GetDesiredPacketIndex(PacketList1, helperInputObj);

            Console.WriteLine("the first Nat req wr 8th occ is " + desiredIndex);


            // Testcase 4.2.1.2 
            List<Packet> PacketList2 = new List<Packet>();

            string filePath2 = @"E:\inputs\4.2.1.2_pkt.csv";

            string[] csvLines2 = File.ReadAllLines(filePath2);

            readCsvFile.ReadCsv(PacketList2, csvLines2);

            TestCase4212 testCase4212Obj = new TestCase4212();

            //verifying the 4.2.1.2 testcase
            testCase4212Obj.Verify4212(PacketList2);


            // Testcase 4.2.1.3
            List<Packet> PacketList3 = new List<Packet>();

            string filePath3 = @"E:\inputs\4.2.1.3_pkt.csv";

            string[] csvLines3 = File.ReadAllLines(filePath3);

            readCsvFile.ReadCsv(PacketList3, csvLines3);

            TestCase4213 testCase4213Obj = new TestCase4213();

            //verifying the 4.2.1.3 testcase
            testCase4213Obj.Verify4213(PacketList3);


            // Testcase 4.2.1.4
            List<Packet> PacketList4 = new List<Packet>();

            string filePath4 = @"E:\inputs\4.2.1.4_pkt.csv";

            string[] csvLines4 = File.ReadAllLines(filePath4);

            readCsvFile.ReadCsv(PacketList4, csvLines4);

            TestCase4214 testCase4214Obj = new TestCase4214();

            //verifying the 4.2.1.4 testcase
            testCase4214Obj.Verify4214(PacketList4);


            // Testcase 4.2.1.5
            List<Packet> PacketList5 = new List<Packet>();

            string filePath5 = @"E:\inputs\4.2.1.5_pkt.csv";

            string[] csvLines5 = File.ReadAllLines(filePath5);

            readCsvFile.ReadCsv(PacketList5, csvLines5);

            TestCase4215 testCase4215Obj = new TestCase4215();

            //verifying the 4.2.1.5 testcase
            testCase4215Obj.Verify4215(PacketList5);


            // Testcase 4.2.2.1
            List<Packet> PacketList6 = new List<Packet>();

            string filePath6 = @"E:\inputs\4.2.2.1_pkt.csv";

            string[] csvLines6 = File.ReadAllLines(filePath6);

            readCsvFile.ReadCsv(PacketList6, csvLines6);

            TestCase4221 testCase4221Obj = new TestCase4221();

            //verifying the 4.2.2.1 testcase
            testCase4221Obj.Verify4221(PacketList6);


            // Testcase 4.2.2.2
            List<Packet> PacketList7 = new List<Packet>();

            string filePath7 = @"E:\inputs\4.2.2.2_pkt.csv";

            string[] csvLines7 = File.ReadAllLines(filePath7);

            readCsvFile.ReadCsv(PacketList7, csvLines7);

            TestCase4222 testCase4222Obj = new TestCase4222();

            //verifying the 4.2.2.2 testcase
            testCase4222Obj.Verify4222(PacketList7);
        }
    }
}

