
namespace SmallestNumbers
{
    public class SmallestNumbers
    {

        public void getSmallestNumbers(List<int> numbers,int counts) 
        {
            var smallestNumbers = new List<int>();

            for (var i =0;i<counts;i++)
            {
                SmallestNumbers obj = new SmallestNumbers();

                int smallestNumber = obj.getSmallest(numbers);
                smallestNumbers.Add(smallestNumber);
                numbers.Remove(smallestNumber);  
            }
            foreach(var items in smallestNumbers)
            {
                Console.WriteLine(items);
            }

            
      
        }
        public int getSmallest(List<int> numbers)
        {
             int min = numbers[0];
            for(var i =1;i<numbers.Count;i++)
            {
             if( numbers[i] < min)
                {

                    min = numbers[i];
                    
                }
                
            }
            return min;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() {2,4,6 ,10,11,12,1,1,3,5,6,7,0,8,9};
          
            SmallestNumbers obj = new SmallestNumbers();
            obj.getSmallestNumbers(numbers,4);

        }
    }
}