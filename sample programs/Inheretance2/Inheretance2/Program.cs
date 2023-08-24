namespace Inheritance2
{
    // This is the base class
    public class ClassOne
    {
        // base class constructor
        public ClassOne(string s) 
        {
            Console.WriteLine("Class 1 constructor " + s);
        }
    }
    //Derived Class
    public class ClassTwo :ClassOne
    {
        public ClassTwo(string s) : base(s) // calling base class constructor passing string
        {
            Console.WriteLine("Class 2 constructor");
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            //Derived class instance
            ClassTwo classTwo = new ClassTwo("From Second Constructor");// passing string value along with constructor
        }
    }
}