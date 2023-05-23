using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvFile
{
    public class ReadCsvFile
    {
        public void ReadCsv(List<Packet> PacketList, string[] csvLines)
        {
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
                    currentPkt.ToPayloadInfo(row[8]);
                    currentPkt.ToPayloadData(row[9]);
                    PacketList.Add(currentPkt);
                }
            }
        }
    }
}
