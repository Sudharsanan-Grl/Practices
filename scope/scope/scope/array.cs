using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scope
{
    public class array
    {
        public void sampleArray()
        {
            List<int> list1 = new List<int>();
            list1.Add(2);
            list1.Add(5);
            list1.Add(3);
            list1.Add(0);
            foreach (var x in list1)
                Console.WriteLine( "Ist list"+x);
            list1.AddRange(list1);
            foreach (var x in list1)
                Console.WriteLine("after adding range"+x);
            list1.Sort();
            foreach (var x in list1)
                Console.WriteLine("sorting"+x);

            foreach (var x in list1)
            {
                Console.WriteLine(x);
            }
       
            foreach (var x in list1)
                Console.WriteLine( "2"+x);
        }
    }
}
