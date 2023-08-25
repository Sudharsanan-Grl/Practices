using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSUnitPractice
{
    // this is the class
    
    public class MSUnitTest
    {

        [TestMethod]
        public void MSTestMethod1()
        {
            int x = 10;
            MSUnitTest mSUnitTest = new MSUnitTest();
            int y = mSUnitTest.DoubleMethod(5);
            Assert.AreEqual(x, y);
        }
        [TestMethod]
        [DataRow(10)]
        [DataRow(5)]
        [DataRow(20)]
        public void MSTestMethod2(int y)
        {
            int x = 20;
            MSUnitTest mSUnitTest = new MSUnitTest();

            int z = mSUnitTest.DoubleMethod(y);
            Assert.IsTrue(z>=x);
        }
        public int DoubleMethod(int x)
        {
            x = x * 2;
            return x;
        }
    }

}