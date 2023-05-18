using static CsvFile.Packet;

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
        // for assigning first or last in the index
        public enum FirstOrLast
        {
            first,
            last
        }
        //for assingning enum types

        public MsgType MsgvalueSearch;

        public CmdType CmdValueSearch;

        public TransactType TransactValueSearch;

        public FirstOrLast firstOrLastValueSearch;

        public int Occurance;

        //constructor for assingning values
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
