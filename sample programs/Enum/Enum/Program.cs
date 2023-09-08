
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
namespace EnumNameSpace
{
    //Enum CLass
 public class EnumClass
 {
        //Enum Fields
     public enum Color
     {
        red,
        blue,
        green
     }
        //enum field
        public Color ColorValue;
        //this method converts string into enum
        public void convertion(string r)
        {
            //converting string to enum using parse
            ColorValue = (Color)Enum.Parse(typeof(Color), r);

            //printing the result
            Console.WriteLine(ColorValue.ToString());
        }

      static void Main(string[] args)
        {
            //creating string with the enum name
            string s = "red";
            EnumClass obj= new EnumClass();
            //calling the method
            obj.convertion(s);
            
        }
  }

}
