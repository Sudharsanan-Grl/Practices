namespace Inheritance2
{
    public class ClassOne
    {
        public ClassOne(string s) 
        {
            Console.WriteLine("Class 1 constructor " + s);
        }
    }
    public class ClassTwo :ClassOne
    {
        public ClassTwo(a) : base(a) 
        {
            Console.WriteLine("Class 2 constructor");
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            ClassTwo classTwo = new ClassTwo();
        }
    }
}