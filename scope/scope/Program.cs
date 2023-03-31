

namespace scope 
{

    public class scope
    {
        static void Main(string[] args)
        {
            int x = 2;
            public void fun()
            {
                int x = 4;
               Console.WriteLine(x);
            }
            Console.WriteLine(x);
        }
    }

}