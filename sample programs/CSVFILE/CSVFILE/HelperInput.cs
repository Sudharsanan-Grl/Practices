using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CsvFile.Packet;
using static CsvFile.HelperClass;
using System.Threading.Channels;
using System.Security.Cryptography.X509Certificates;

namespace CsvFile
{
    /// <summary>
    /// This class is used for storing the first/last , Nat/I2C , Req /Res , Rd/Wr and Occurance.
    /// These values are stored in a instance that instance is sent to Helper class for getting desired index.
    /// </summary>
    public class HelperInput
    {
        public HelperInput()
        {
        }
        public enum FirstOrLast
        {
            first,
            last
        }
        public MsgType MsgvalueSearch;
        
        public CmdType CmdValueSearch;
       
        public TransactType TransactValueSearch;
        
        public FirstOrLast firstOrLastValueSearch;

        public int Occurance;
        public HelperInput(MsgType msgvalueSearch, CmdType cmdValueSearch, TransactType transactValueSearch, FirstOrLast firstOrLastValueSearch, int occurance)
        {
            MsgvalueSearch = msgvalueSearch;

            CmdValueSearch = cmdValueSearch;

            TransactValueSearch = transactValueSearch;

            this.firstOrLastValueSearch = firstOrLastValueSearch;

            Occurance = occurance;
        }
    }
}
