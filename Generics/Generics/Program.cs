namespace GenericsExample
{
    //creating class using generics
    public class GenericsExample<T> 
    {
        //creating typesafe generic method
        public void compare(T a,T b,string message)
        {
            //checks whether it is true or not
            if(a.Equals(b))
            {
                //for printing the true or not
                Console.WriteLine(message +" {0} ==  {1}",a,b);
                Console.WriteLine("TRUE- they are equal");
            }
            else
            {
                //for printing the true or not

                Console.WriteLine(message +" {0} ==  {1}", a, b);
                Console.WriteLine("FALSE - they are not equal");
            }
        }
    }
    public class Program
    {
        static  void Main(string[] args)
        {
            //create an instance using generics - int
            GenericsExample<int> obj = new GenericsExample<int>();

            //comparing the integers
            obj.compare(1, 1,"using numbers");

            //create an instance using generics - string
            GenericsExample<string> obj2 = new GenericsExample<string>();

            //comparing the strings
            obj2.compare("a", "bbd","using String");

        }
    }
}