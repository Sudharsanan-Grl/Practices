
namespace files
{
    public class Files
    {
        string path = @"C:\Users\GRL\Pictures\Screenshots\Screenshot.png";
        
        
        public void fileMethod()
        {
          //  File.Copy(path,path);
          
           // File.Create(@"E:\Data\C#",32);
            File.ReadAllText(path);
            File.GetAttributes(path);
           // File.Delete(path);
           File.Create(path);
        } 
        public void fileInfoMethod()
        {
           FileInfo fileInfo= new FileInfo(path);   
            fileInfo.Create();
            fileInfo.Delete();
            fileInfo.AppendText();
            fileInfo.CopyTo(path);
            if(fileInfo.Exists)
            {
                Console.WriteLine("it is exist");
            };
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Files obj= new Files();
            obj.fileMethod();
            DExample obj2 = new DExample();
            obj2.directory();
        }

    }
}