using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypeSample
{
    // c# data types
    /* byte
     * short
     * int  
     * long
     * float
     * double
     * string
     * decimal
     * bool
     */
    public class DataTypesSample
    {
        // Declaring all the datatypes
        public byte number1;
        public short number2;
        public int number3;
        public long number4;
        public float number5;
        public double number6;
        public decimal number7;
        public string name;
        public bool isalive;



        //Displaying all the datatypes
       public  void display()
        {
            Console.WriteLine( "the byte value is " + number1);
            Console.WriteLine("the short value is " + number2);
            Console.WriteLine("the int value is " + number3);
            Console.WriteLine("the long value is " + number4);
            Console.WriteLine("the float value is " + number5);
            Console.WriteLine("the double value is " + number6);
            Console.WriteLine("the decimal value is " + number7);
            Console.WriteLine("the string value is " + name);
            Console.WriteLine("the bool value is " + isalive);

        }

        static void Main(string[] args)
        {
            //creating instance of the class
            DataTypesSample obj = new DataTypesSample();
            // assingning values to all the variables
            obj.number1 = 1;
            obj.number2 = 2;
            obj.number3 = 3;
            obj.number4 = 4;
            obj.number5 = 5.5f;
            obj.number6 = 6.6;
            obj.number7 = 7.7m;
            obj.name = "sudhar";
            obj.isalive = true;
            // calling the display method
            obj.display();
            Console.ReadLine();
        }

    }
}

