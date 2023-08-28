using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSUnitPractice
{
    // This attribute used to run the Class
    [TestClass]
    public class MSUnitTest
    {
        //This attribute used to run the method
        [TestMethod]
        public void MSTestMethod1()
        {
            int x = 10;
            MSUnitTest mSUnitTest = new MSUnitTest();

            // y value doubles
            int y = mSUnitTest.DoubleMethod(5);

            //Checking x and y are equal
            Assert.AreEqual(x, y);
        }

        // this method takes three parameter
        [TestMethod]
        [DataRow(10)]
        [DataRow(5)]
        [DataRow(20)]
        public void MSTestMethod2(int y)
        {
            int x = 20;
            MSUnitTest mSUnitTest = new MSUnitTest();

            int z = mSUnitTest.DoubleMethod(y);

            // Checks z is greater
            Assert.IsTrue(z>=x);
        }
        // doubles the value
        public int DoubleMethod(int x)
        {
            x = x * 2;
            return x;
        }
    }

}