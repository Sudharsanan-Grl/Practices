namespace Interfaces
{
    // creating interface
    interface IFirst
    {
        //method without implementation
        void print1();
    }

    // creating interface
    interface ISecond
    {
        //method without implementation
        void print2();
    }

    //creating class with implements the two interfaces
    public class InterfaceClass : IFirst, ISecond
    {
        //creating the implemntts method
        public void print1()
        {
            //for printing
            Console.WriteLine("1st interface");
        }

        //creating the implemntts method
        public void print2()
        {
            //for printing

            Console.WriteLine("2nd interface");
        }
    }
    public class program
    {
        static void Main(string[] args)
        { 
            //creating instance with the interface reference variabe points the derived class

            IFirst first = new InterfaceClass();

            //calling the interface method
            first.print1();

            //creating instance with the interface reference variabe points the derived class
            ISecond second = new InterfaceClass();
            
            //calling the interface method
            second.print2();
        }
    }
}