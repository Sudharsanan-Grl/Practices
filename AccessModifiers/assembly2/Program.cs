using System;
using AccessModifier;
 // creating a new assembly
namespace assembly
{
    public class AssemblyClass1 : AccessModifiers
    {
        public void display() 
        {
            //creating instance for the modify class
         modify obj3= new modify();
            // accessing the public variable
            Console.WriteLine("this is printing in Other assenbly the roll no is "+obj3.rollNo);
        }

        public void forProtected() 
        {
        
            AssemblyClass1 obj6= new AssemblyClass1();
            
            Console.WriteLine( "this is printing in the other assembly for a protected member ,my college is  "+ obj6.college);
        }
        public static void Main(string[] args)
        {
            //creating instance for assemblyclass1
            AssemblyClass1 obj4 = new AssemblyClass1();
            obj4.display();
            obj4.forProtected();
        }
     
    }
}