namespace DateFormat
{
  
    public class Program
    {
        static void Main(string[] args)
        {
            //creating current date and time
            DateTime dateTime= DateTime.Now;

            //for display current date time
            Console.WriteLine(dateTime);

            //creating custom date and time
            DateTime dt = new DateTime(2011,4,23,20,30,30);

            //for display custom time
            Console.WriteLine(dt);


            // display date with year 
            Console.WriteLine( "Date with year : {0:d}", dt);

            // display date only
            Console.WriteLine("Date  : {0:dd}", dt);

            // display month only
            Console.WriteLine("month : {0:MM}", dt);

            // display year only
            Console.WriteLine("year : {0:yy}", dt);

            // display year with month in string
            Console.WriteLine("year with month : {0:y}", dt);

            // display  month with day in string
            Console.WriteLine("month with day : {0:M}", dt);

            // display  full year
            Console.WriteLine("full year : {0:yyyy}", dt);

            // display the time
            Console.WriteLine("Time : {0:T}", dt);

            // display hours 24
            Console.WriteLine("Hours Railway : {0:HH}", dt);

            // display hours 12
            Console.WriteLine("hours : {0:hh}", dt);

            // display minutes
            Console.WriteLine("minutes : {0:mm}", dt);

            // display seconds
            Console.WriteLine("seconds : {0:ss}", dt);

            // display AM PM 
            Console.WriteLine("am or pm : {0:tt}", dt);

            //for all format
            Console.WriteLine("Date with time : {0:yyyy/MM/dd  hh:mm:ss tt}", dt);




        }


    }
}