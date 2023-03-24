namespace Looping
{
    public class Looping
    {
        //while loop
        public void While()
        {
            Console.WriteLine("While loop");
            var i = 5;
            while (i>0)
            {
                Console.WriteLine(i);
                i--;
            }
        }

        // Do while loop
        public void DoWhile() 
        {
            Console.WriteLine("Do While loop");

            var i = 5;

            do
            {
                Console.WriteLine(i);
                i--;

            }while(i>0);
        }

        // For loop
        public void For()
        {
            Console.WriteLine("For loop");

            for (var i = 1; i <= 5; i++)
            {
                Console.WriteLine(i);
            }

        }

        // For Each loop
        public void ForEach()
        {
            Console.WriteLine("ForEach loop");

            int[] array = new int[5] {1,2,3,4,5};

            foreach (var items in array)
            {
                Console.WriteLine(items);
            }
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Looping obj = new Looping();

            //calling dowhile loop 
            obj.DoWhile();

            //calling for loop 
            obj.For();

            //calling foreach loop 
            obj.ForEach();

            //calling while loop 
            obj.While();
       }
    }
}
