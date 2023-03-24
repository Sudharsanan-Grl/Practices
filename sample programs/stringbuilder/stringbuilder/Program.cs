using System.Text;
namespace stringBuilder
{
    
    public class program
    {
        static void Main(string[] args)
        {
            var builder = new StringBuilder("vegeta");
            builder.Append('#',20);
            builder.AppendLine();
            builder.Append('#', 26);

            Console.WriteLine(builder);
            builder.Insert(0,"#",3);
            builder.AppendJoin("#","&&&&");
            builder.Replace("vegeta","prince VEGETA");
            builder.Remove(0, 3);
            Console.WriteLine(builder);


        }
    }
}