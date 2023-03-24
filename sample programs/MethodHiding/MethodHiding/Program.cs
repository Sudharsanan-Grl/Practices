namespace MethodHiding
{

    //creating base class
        public class baseClass
        {
            // base class method hidden
            public  void print()
            {
                Console.WriteLine("base class");
            }
        }

        // creating the derived class
        public class derivedClass : baseClass
        {
            // using new keyword for hidding base class method
            public new void print()
            {
                Console.WriteLine("derived class");
            }
        }

        public class program
        {
          static void Main(string[] args)
          {
            //creating object for a derived class through a base class reference
            // for invoking the base class
            baseClass obj = new derivedClass();
                //calling a print method
                obj.print();

            // for invoking the base class
            ((baseClass)obj).print();  

            // creating object for the derived class
            derivedClass obj2= new derivedClass();  
                 obj2.print();   
          }
        }
    
}