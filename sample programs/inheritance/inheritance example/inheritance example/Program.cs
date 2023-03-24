namespace inheriatnceExample
{
    public class InheritanceExplaination
    {

        //creating the parent class
        public class Employee
        {
            //creating fields for the parent class
            public string firstName;
            public string lastName;
            public int age;
            public string email;

            //constructor for parent class without arguments
            public Employee()
            {
                Console.WriteLine("the parent constructor is invoked");
            }
            //constructor for parent class with arguments

            public Employee(string message)
            {
                Console.WriteLine(message);
            }
        }
        // creating the derived class or child class
        public class FulltimeEmployee : Employee 
        {
            //creating a field
            public  float saleryAmount;

            //method to print details
            public void details()

            {
                //printing all the details
                Console.WriteLine("the Employee full name is {0} {1} and email is {2} and age is {3}.", firstName, lastName, email, age);
            }

            //method to assign fullnamee
            public string fullNameAssign(string fn,string ln)
            {
               string fullName=fn + ln;
                return fullName;
            }

            //method for printing salery
            public void printSalery(string fullName)
            {
                Console.WriteLine("the salery of {0} is  {1}",fullName,saleryAmount);
            }

            //choosing which  constructor is to be invoked while creating a constructor in child class
            public FulltimeEmployee() : base() // we an selet with constructor is need to be invoked
            {
                Console.WriteLine("the children costructor is invoked");
            }
        }
  
        static void Main(string[] args)
        {
            //creatig instance of the child class 
            FulltimeEmployee fte= new FulltimeEmployee();

            //initialising parent fields from child object
            fte.firstName = "sudhar";
            fte.lastName = "sanan";
            fte.age = 21;
            fte.email = "sudhar@gamil.com";

            //calling the child method also using parents fileds
            fte.details();

            //initilasing the saleryAmount
            fte.saleryAmount= 15000;

            //passing parents fileds as an arguments
            string fullName= fte.fullNameAssign(fte.firstName,fte.lastName);

            //passing the fullname as an argument
            fte.printSalery(fullName);
        }

    }
}