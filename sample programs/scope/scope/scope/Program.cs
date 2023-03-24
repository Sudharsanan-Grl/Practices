using System.Diagnostics;

    namespace scope
    {

        public class ForScope
        {
            static void Main(string[] args)
            {
                 // we created a variabe x 
                  int x = 2;

                 // calling the two functions
                 fun();

                 Console.WriteLine(x);

                  fun2();
                  //checks the change after reinitialization
                 Console.WriteLine(x);

                void fun()
                {
                    //we can reassign or use the x becaause all the chldren methods are its scope  
                    x = 4;

                    //displays the value of x
                    Console.WriteLine(x);
                }
            
                void fun2()
                {
                      // we can reinitialize the same variable to the child and it does not change the old  
                     int x = 5;
                     Console.WriteLine(x);
                }
                  // creating instancefor timer
                  Stopwatch ifEsleTimer = new Stopwatch();

                  //timer starts
                  ifEsleTimer.Start();

                  //static method calling for ifelse
                  IfelsevsSwitch.timingIfelse(30);

                  //timer stops
                  ifEsleTimer.Stop();

                  //Displaying the execution time
                  Console.WriteLine("the timing  for ifelse is "+ ifEsleTimer.Elapsed);

                  // creating instancefor timer
                  Stopwatch switchCaseTimer = new Stopwatch();
           
                  //timer starts
                  switchCaseTimer.Start();

                  //static method calling for switchcase
                  IfelsevsSwitch.timingSwitchCase(30);

                  //timer stops
                  switchCaseTimer.Stop();

                  //Displaying the execution time
                  Console.WriteLine("the timing  for switchcase is " + switchCaseTimer.Elapsed);
                  randomNumbercs obj=new randomNumbercs();
                  obj.randomNum();
                  array obj8= new array();
                  obj8.sampleArray();
            }
        }

    }
