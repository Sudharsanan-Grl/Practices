namespace Constructor
{
    //constructors
 /*    Default constructors
     * Parameterised constructors
     * Copy constructors
     * Static constructors
     * Private constructors  */
    public class ConstructorExamples
    {
        // creating fileds
        public int rollNo;
        public string name;
        public static string college = "kec";

        //default constructor
        public  ConstructorExamples()
        {
            //printing weather it is invoked or not
            Console.WriteLine("Default contructor is invoked");
        }
        public  ConstructorExamples(string name,int rollNo)
        {
            //assigning the values for the fields
            this.name = name;
            this.rollNo = rollNo;

            //printing weather it is invoked or not
            Console.WriteLine("parameterised constructor is invoked");
            Console.WriteLine("MY name is {0} and rollno is {1}",name,rollNo);
        }
        static ConstructorExamples()
        {
            //printing weather it is invoked or not
            Console.WriteLine("static constroctor is invoked");

            //accessing the static members
            Console.WriteLine("My college is "+college);
        }
        public ConstructorExamples(ConstructorExamples obj)
        {
            //assigning the values for the fields using the object
            name = obj.name;
            rollNo= obj.rollNo;

            //printing weather it is invoked or not
            Console.WriteLine(" copy constructor is invoked");
            Console.WriteLine(" BY using Copy constructo - My name is {0} and rollno is {1}", name, rollNo);
        }

    }
    // privateconstructor
    public class PrivateConstructor
    {

        // creating privateconstructor

        private PrivateConstructor()
        {

            

        }
        // creating a method inside  private constructor class

        public static void  forexample()
        {
            //creating instance of a private constructor class
            PrivateConstructor obj = new PrivateConstructor();
             
            obj.printMethod();
            
        }

        // creating a method inside  private constructor class

        public void printMethod()
        {
            //priniting the private constructor example
            Console.WriteLine("we can create instance only inside the private constructor class");

        }


    }
    public class Program
    {
        static void Main(string[] args)
        {
            // creating instance to invoke a default  and static constructor
            ConstructorExamples obj= new ConstructorExamples();

            // creating instance to invoke a Parameterised constructor

            ConstructorExamples obj2 = new ConstructorExamples("sudhar",90);

            // creating instance to invoke a copy constructor

            ConstructorExamples obj3 = new ConstructorExamples(obj2);

            //for private constructor, obj cannot be created
            PrivateConstructor.forexample();

        }
    }
}