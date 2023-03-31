namespace Abstract
{

    /// <summary>
    /// if we create a method in abstract base class then 
    /// that method is need to be its derived class
    /// </summary>
    /// abstract base class
    public abstract class AbstractBase
    {
        //abstract method with abstract keyword without having definition
        public abstract void Display();
    }
    //derived class from abstract class
    public class Derived : AbstractBase
    {
        //override method 
        public override void Display()
        {
            //dispay whether the printing from derived class
            Console.WriteLine("abstract is done");
        }
    }
    //derived class from Derived class
    public class DerivedFromDerived :Derived
    {
        //override method for abstract class
        public override void Display()
            
        {
            //display weather it is printing from driverFromDerived class
            Console.WriteLine("derived form derived");
        }
    }
    //driver class
    public class program
    {
        //main method
        static void Main(string[] args)
        {
            // creating instance of a derived class by using the parent reference name.
            AbstractBase o = new Derived();

            // calls the method in derived class
            o.Display();

            // creating instance of a derived from derived class by using the parent reference name.
            AbstractBase o1 = new DerivedFromDerived();

            // calls the method in derivedfrom derived class
            o1.Display();
        }
    }
}