using Xunit;

namespace TestXUnitPractice
{
    public class UnitTest1
    {
       [Fact]
        public void Test1()
        {
            Assert.False(false,"this is not going to fail");

        }
        [Fact]
        public void Test2()
        {
            Assert.True(true, "this is not going to fail");

        }
        [Fact]
        public void Test3()
        {
            int expected = 100;
            int actual = 10 * 10;
            Assert.Equal(expected, actual);
        }
      
        public class MathOperations
        {
            public int Add(int a, int b)
            {
                 return a + b;
            }
        }

         public class MathOperationsTests
         {
             [Theory]
             [InlineData(2, 3, 5)]
             [InlineData(0, 0, 0)]
             [InlineData(1, 5, 3)]
             public void Add_ShouldReturnCorrectSum(int a, int b, int expected)
             {
           
               MathOperations math = new MathOperations();

            
              int result = math.Add(a, b);

           
              Assert.Equal(expected, result);
             }
         }


    }
}