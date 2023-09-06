using System.IO;
namespace FS 
{ 
   
    public class Program
    {
        static void Main(string[] args)
        {
            //creating file stream
        FileStream fs = new FileStream(@"C:\Users\Public\Downloads", FileMode.OpenOrCreate);

            //StreamWriter is used for printing
            StreamWriter writer = new StreamWriter(fs);
        writer.WriteLine("this is a new text file");
        writer.WriteLine("this is the second line");
        writer.WriteLine("this is the third line");
            //stoping the writer
        writer.Close();
            //stoping the FileStream

            fs.Close();
        }
    }
}
