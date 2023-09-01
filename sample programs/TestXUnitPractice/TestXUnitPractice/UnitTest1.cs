using Xunit;

namespace TestXUnitPractice
{
    //Unit testing is a software testing methodology where individual units or components of a program
    //are tested to ensure they are functioning as expected.


    public class UnitTest1
    {
        //this attributes allows to run the method
       [Fact]
        public void Test1()
        {
            //if it is false then the testcase is pass
            Assert.False(false,"this is not going to fail");

        }
        //this attributes allows to run the method

        [Fact]
        public void Test2()
        {
            //if it is true then the testcase is pass
            Assert.True(true, "this is not going to fail");

        }
        //this attributes allows to run the method

        [Fact]
        public void Test3()
        {
            int expected = 100;
            int actual = 10 * 10;

            //if it is equal then the testcase is pass
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
            //this attribute allows to run the method with each of the data indivudually
             [Theory]
             [InlineData(2, 3, 5)]
             [InlineData(0, 0, 0)]
             [InlineData(1, 5, 3)]
             public void Add_ShouldReturnCorrectSum(int a, int b, int expected)
             {
           
               MathOperations math = new MathOperations();

            
              int result = math.Add(a, b);

                //if it is equal then the testcase is pass

                Assert.Equal(expected, result);
             }
         }


    }
}