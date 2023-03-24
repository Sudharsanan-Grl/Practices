namespace AccessModifier
{

    /*  ACCESS MODIFIER
     *  public
     *  private
     *  protected
     *  internal
     *  protected internal
     *  private protected
     */  

    //creating the derived class 
    public class forInternal
    {
        public static void printInternal()
        {
            //creating instance for the AccessModifiers
            AccessModifiers obj5 = new AccessModifiers();
            //example for internal access
            Console.WriteLine("printing using the internal mystate is " + obj5.state);
        }
    }
    public class modify : AccessModifiers
    {
        public void printCollege()
        {
           
            // example of protected 
            modify obj1= new modify();
            Console.WriteLine(" printing example for protected my college is " + obj1.college);

            // example for private protedcted
            Console.WriteLine(" printing example for private protected my district is " + obj1.district);
        }
        
    }
   public class AccessModifiers
    {
        //public can access anywhere  
        public int rollNo = 90;
        // private only availabe in this only
        private string name = "sudhar";
        // only it is available inthis class and its derived class
        protected string college = "kec";
        // access only in this assembly
        internal string state="tamilNadu";
        private protected string district="villupuram";
        public  void method()
        {
             //display available witnin this class
             Console.WriteLine( " printing example for protected "+ name);
        }
       

        static void Main(string[] args)
        {
            AccessModifiers obj = new AccessModifiers();
            //example of public 
            Console.WriteLine(obj.rollNo);

           modify obj2= new modify();  
            obj2.printCollege();
           //calling the method in the forinternal class  
            forInternal.printInternal();
        }
    }
}

