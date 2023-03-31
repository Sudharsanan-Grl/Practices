namespace values_and_reference
{

    /*   VALUE TYPE
     *  int
     *  float
     *  bool
     *  char
     *  enum
     */

    /*   REFERENCE TYPE
     *   string
     *   array
     *   class
     *   delegates
     *   structures
     */
    public class Type
    {

        // Value type example
        
        //creating a method to check the value type
         public void check1(int x)
            {
              //assingning the value of x to the y
                int y = x;
             //displaying before the process for conformation
                Console.WriteLine("Before changing the value of y = {0} and x = {1} ",y,x);
            // assingning the other value to the y for checking the wheather the x will xhange or not
                y = 20;
            // displaying the y and x and check for the x value change
                Console.WriteLine("After changing the value of y = {0} but  x = {1} is not changed ", y, x);
                
            }
        //reference type
        public void check2(int[] x)
        {
            //displaying the values of x
            Console.WriteLine("these are the values of x are before change");
            foreach (int items in x)
                Console.WriteLine(items);
            //creating a y array  and assingning the address of x
            int[] y = x;

            //displaying the values of y 
            Console.WriteLine("these are the values of y ");
            foreach (int item in y)
                Console.WriteLine(item);
            //changing the y values
            y[0] = 10;
            y[1] = 20;
            //displaying the values of x after changing the values of y
            Console.WriteLine("the values of x after changing the values of y");
            foreach (int items in x)

                Console.WriteLine(items);
        }
        static void Main(string[] args)
        {
            //creating an instance of the Type class
           Type obj1= new Type();
            //passing the value to the cheak1 method 
            obj1.check1(1);
            //creating an array
            int[] arr= new int[4] {2,4,6,8};
            //passing the array to the method check2
            obj1.check2(arr);
           
        }
    }
}