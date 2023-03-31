// using the other namespace in same assembly
using StaticMethodsAndClasses;
namespace ForNamespaceAccess
{
    public class NamespaceAccess
    {
        public int rollNo = 90;
        public string name = "sudhar";
        public void method4 ()
        {
            //creatiing instance for the other namespace class in same assembly
            StaticMethod s =new StaticMethod();
            //caling the other namespace method
            s.method3 ();
            
        }
    }
}