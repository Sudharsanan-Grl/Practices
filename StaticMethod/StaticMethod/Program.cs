using ForNamespaceAccess;//same assembly namespace access
using OtherAssemblyNamespace;//other assembly namespace access
namespace StaticMethodsAndClasses 
{
    //non static class
    public class StaticMethod
    {
        //static method in the non static class
        public static void method1()
        {
            //printing example for static method
            Console.WriteLine(" example of static method:  method 1");
        }
        //non static method
        public void method3() 
        {
            //print  in other namespace
            Console.WriteLine(" call from other namespace - method3 is invoked");
        }
    }
    // static class
    public static class StaticClass
    {
        //printing example for static class method

        public static void method2()
        {
            //direct prining using class
            Console.WriteLine(" example of static classMethod:  method 2");

        }
    }
    //driver class
    public class Prgram
    {
        static void Main(string[] args)
        {
            //we can create instance for non static class but can't create for static class
            StaticMethod method = new StaticMethod(); 

            //static methods assesible without creating objects
            StaticMethod.method1();

            //static class methods is directly assesible through the class
            StaticClass.method2();

            //creating instance for a class in other namespace in same assembly
            NamespaceAccess obj= new NamespaceAccess();

            //using object we can use other namespace members
            Console.WriteLine("Rool no:"+  obj.rollNo+" && " +"Name :"+obj.name);
            
            //calling the other namespace method
            obj.method4();

            //creating instance for other assembly class
            OtherAssemblyClass obj2= new OtherAssemblyClass();

            // calling the other assembly method
            obj2.otherAssemblyMethod();
        }
    } 
}
