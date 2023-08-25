namespace GenericsClass
{
    // Generics Class
    // This code is reusable for all the data types and it is type safe

    class GenericsClass<T> // Taking any DataType
    {
       
        //This method Take any datatype add and print on the console
  
        public void Add(T a, T b)
        {
            // dynamic keyword - Type determined at run time

            dynamic d1 = a;
            dynamic d2 = b;
            Console.WriteLine(d1 + d2);
        }
  
        //This method Take any datatype add and print on the console

        public void Sub(T a, T b)
        {
            // dynamic keyword - Type determined at run time

            dynamic d1 = a;
            dynamic d2 = b;
            Console.WriteLine( d1 - d2);
        }
   
        //This method Take any datatype add and print on the console

        public void Mul(T a, T b)
        {
            // dynamic keyword - Type determined at run time

            dynamic d1 = a;
            dynamic d2 = b;
            Console.WriteLine( d1 * d2);
        }

        //This method Take any datatype add and print on the console
   
        public void Div(T a, T b)
        {
            // dynamic keyword - Type determined at run time

            dynamic d1 = a;
            dynamic d2 = b;
            Console.WriteLine(d1 / d2);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //creating instance using int data type
           
            GenericsClass <int> G1 = new GenericsClass<int> ();
            G1.Add(20, 20);
            G1.Sub(20, 40);
            G1.Mul(20, 20);
            G1.Div(20, 20);

            //creating instance using float data type

            GenericsClass<float> G2 = new GenericsClass<float>();
            G2.Add(30.55f, 30.55f);
            G2.Sub(30.55f, 40.55f);
            G2.Mul(30.55f, 30.55f);
            G2.Div(30.55f, 20.55f);

            //creating instance using double data type

            GenericsClass<double> G3 = new GenericsClass<double>();
            G3.Add(10.55, 30.55);
            G3.Sub(70.55f, 40.5);
            G3.Mul(50.55f, 30.55);
            G3.Div(40.55, 20.55);

        }
    }
}