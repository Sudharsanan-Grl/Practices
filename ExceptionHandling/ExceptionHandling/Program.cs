
namespace ExceptionHandling
{
   
   public class Program
    {
        static void Main(string[] args) 
        {
            //for handling the execption
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(@"E:\Data\C#\sample programs\ExceptionHandling\eh.txt"))
                {
                    // Read and display lines from the file until the end
                    Console.WriteLine(sr.ReadToEnd());
                }

            }
            catch(FileNotFoundException fnf) 
            {
                // Let the user know what went wrong.
                Console.WriteLine("the path{0} is not founded", fnf.FileName);
            }
            catch(Exception ex)
            {
                // Let the user know what went wrong.
                Console.WriteLine(ex.Message);
            }
            finally 
            {
                //finally block is always executed
                Console.WriteLine("finally block"); 
            }
        }
        
        
    }
}