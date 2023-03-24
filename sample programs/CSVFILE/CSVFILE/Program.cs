using CSVFILE;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using static CSVFILE.Packet;

namespace CSVFILES
{

   

    public class Program
    {
        static void Main(string[] args)
        {
            
           string filePath = @"C:\Users\GRL\Downloads\TD_4_2_1_1\TD_4_2_1_1\Test_Pkt.csv";
            string[] csvLines= File.ReadAllLines(filePath);

            Packet O = new Packet();
            

            if (csvLines.Length > 0)
            {
              for(int i=1; i < csvLines.Length; i++)
                {
                 
                    string[] row = csvLines[i].Split(',');
                    O.ToTimeStampList(row[1]);
                    O.ToMsgTypeList(row[3]);
                    O.ToTransactTypeList(row[4]);
                    O.ToCmdTypeList(row[5]);
                    O.ToAddressList(row[6]);
                    O.ToDataLength(row[7] );
                    O.ToPayloadDataList(row[9]);
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
            O.payloadSeparate();
            }
         
               

        }
    }

