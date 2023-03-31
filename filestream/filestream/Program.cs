using System.IO;
namespace FS 
{ 
   
    public class Program
    {
        static void Main(string[] args)
        {
        FileStream fs = new FileStream(@"C:\Users\Public\Downloads", FileMode.OpenOrCreate);
        StreamWriter writer = new StreamWriter(fs);
        writer.WriteLine("this is a new text file");
        writer.WriteLine("this is the second line");
        writer.WriteLine("this is the third line");
        writer.Close();
        fs.Close();
        }
    }
}
