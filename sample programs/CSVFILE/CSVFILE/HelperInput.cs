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
    //HelperClass HelperClassObj = new HelperClass();

     // HelperInput HelperInputObj=new HelperInput();
    
     public enum FirstOrLast
        {
            first,
            last
        }

     public  MsgType MsgvalueSearch;
       public void ReqRes(Packet.MsgType MsgValue)
        {
            if(MsgValue == MsgType.Req)
            {
                MsgvalueSearch= MsgValue;
            }
            else if(MsgValue == MsgType.Res){
                MsgvalueSearch= MsgValue;
            }
            else
            {
                Console.WriteLine("Msg value is not set in proper way");
            }
        }
        public CmdType CmdValueSearch;

        public void ReadOrWrite(CmdType CmdValue)
        {
            if(CmdValue == CmdType.Wr)
            {
                CmdValueSearch = CmdValue;
            }
            else if(CmdValue == CmdType.Rd) 
            {
                CmdValueSearch = CmdValue;            
            }
            else 
            {
                Console.WriteLine("Cmd value is not set in proper way");
            }
        }
        public TransactType TransactValueSearch;
        public void NatOrI2C(TransactType transactValue)
        {
            if (transactValue == TransactType.Nat)
            {
                TransactValueSearch = transactValue;
            }
            else if (transactValue == TransactType.I2C)
            {
                TransactValueSearch = transactValue;
            }
            else
            {
                Console.WriteLine("transact value is not set in proper way");
            }
            
        }
        public FirstOrLast firstOrLastValueSearch;
        public void ToFindFirstOrLast(FirstOrLast flValue)
        {
            if (flValue == FirstOrLast.first)
            {
                firstOrLastValueSearch = flValue;
            }
            else if (flValue == FirstOrLast.last)
            {
                firstOrLastValueSearch = flValue;
            }
            else
            {
                Console.WriteLine("FirstOrLast value is not set in proper way");
            }
        }
    }
}
