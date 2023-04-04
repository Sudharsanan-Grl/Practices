using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CSVFILE.Packet;
using static CSVFILE.HelperClass;
using System.Threading.Channels;
using System.Security.Cryptography.X509Certificates;

namespace CSVFILE
{
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
