using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scope
{
    //random password generation 
    public class randomNumbercs
    {
        public void randomNum()
        {
            // creating random instance
            var random=new Random();

            //for length of the password
            int passLength = 10;

            //creating an empty array
            char[] buffer  = new char[passLength];

            //random password generation
            for(int i=0; i< passLength; i++)
            {
                //storing the password in array
                buffer[i] = (char) ( 'a' +  random.Next(0,26));
                
            }
            // coppying all the characters in a string
             string passWord=new string(buffer);

            //displaying the random password
            Console.WriteLine( "the randomly generated password is "+ passWord);
        }
    }
}
