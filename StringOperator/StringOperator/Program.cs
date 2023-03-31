namespace StringOperators
{
    public class StringOperators
    {
        // for displaying the string in uppercase
        public void ToUpper(string str)
        {
            str = str.ToUpper();
            Console.WriteLine("To upper : "+str);
        }

        // for displaying the string in lowercase
        public void ToLower(string str)
        {
            str = str.ToLower();
            Console.WriteLine("To lower : " + str);
        }

        //for Concardination
        public void Concardinate(string str1,string str2) 
        {
            string str=string.Concat(str1,str2);
            Console.WriteLine("concardination: "+str);
        }

        //for finding index
        public void IndexOf(string str)
        {
           int index= str.IndexOf('a');
          
            Console.WriteLine("the index of a is :"+index );
        }

        //for creating a substring
        public void SubString(string str)
        {
            string sub = str.Substring(0,5);
            Console.WriteLine("the substring is "+sub);
        }

        //for trimming the extra space
        public void Trim(string str)
        {
            str = str.Trim();
            
            Console.WriteLine("After trimmed :"+str);
        }

        //for checking weather the string contains char or not
        public void Contains(string str)
        {
            Console.WriteLine("the string contains char c - "+ str.Contains("c")); 
        }

        //for removing
        public void Remove(string str)
        {
            string removed = str.Remove(0, 3);
            Console.WriteLine("the removed string :"+removed);
        }

        // for replacing
        public void replace(string str1, string str2)
        {
            Console.WriteLine("before replaced s1={0} s2={1}", str1, str2);

            //replaces str 1 with str 2
            str1 = str1.Replace(str1, str2);

            //repalces a with s
             str2= str2.Replace("a","s");
            Console.WriteLine("after replaced s1={0} s2={1}", str1, str2);
           
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            //creating instance
            StringOperators s = new StringOperators();

            // creating string
            string message1 = "this is a messaGE one";
            
            //calling toupper method and passing a string
            s.ToUpper(message1);

            string message2 = "tHis is a mEssaGE ONe";
            //calling tolower method and passing a string
            s.ToLower(message2);

            //creating two strings
            string s1 = "sudhar";
            string s2 = "sanan";

            //calling concardinate method
            s.Concardinate(s1,s2);

            //calling IndexOf method
            s.IndexOf(s1);

            //calling SubString method
            s.SubString(s1);

            //calling Contains method
            s.Contains(s2);

            //calling replace method
            s.replace(s1,s2);

            string trim = "  the student name  is sudhar ";
            //calling Trim method
            s.Trim(trim);

            //declaring without initialzation
            string name;

            //declaring with null
            string college = null;

            // regular string literals
            string path1 = "C:Users//program//code//run//program.cs";

            // using verbanium string
            string path2 = @"C:Users/program/code/run/program.cs";


            
        }
    }

}