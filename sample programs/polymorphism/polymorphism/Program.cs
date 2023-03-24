using polymorphism;

namespace polymorphism
{//creating base class
    public class baseClass
    {
        // using virtual for base class
        public virtual void print()
        {
            Console.WriteLine("base class");
        }
    }

    // creating the derived class
    public class derivedClass : baseClass
    {
        // using overide for derived class
        public override void print()
        {
            Console.WriteLine("derived class");
        }
    }

    public class program
    {
        static void Main(string[] args)
        {
            //creating object for a derived class through a base class reference
           baseClass obj = new derivedClass();
            //calling a print method
        obj.print();
        }
    }
}