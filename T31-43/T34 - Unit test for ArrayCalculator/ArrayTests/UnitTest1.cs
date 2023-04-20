
namespace ArrayTests
{
    [TestClass]
    public class ArrayCalcsTests
    {
        [TestMethod]
        public void TestSum()
        {
            double[] array = { 1.0, 2.0, 3.3, 5.5, 6.3, -4.5, 12.0 };
            double expected = 25.6;
            double actual = Calculator.Sum(array);
            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestMethod]
        public void TestAverage()
        {
            double[] array = { 1.0, 2.0, 3.3, 5.5, 6.3, -4.5, 12.0 };
            double expected = 3.657;
            double actual = Calculator.Average(array);
            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestMethod]
        public void TestMin()
        {
            double[] array = { 1.0, 2.0, 3.3, 5.5, 6.3, -4.5, 12.0 };
            double expected = -4.5;
            double actual = Calculator.Min(array);
            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestMethod]
        public void TestMax()
        {
            double[] array = { 1.0, 2.0, 3.3, 5.5, 6.3, -4.5, 12.0 };
            double expected = 12.0;
            double actual = Calculator.Max(array);
            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestMethod]
        public void TestEmptyArray()
        {
            double[] array = { };
            double expected = 0.0;
            double actual = Calculator.Sum(array);
            Assert.AreEqual(expected, actual, 0.001);

            expected = 0.0;
            actual = Calculator.Average(array);
            Assert.AreEqual(expected, actual, 0.001);

            // Note: Min() and Max() will throw InvalidOperationException
            // when called with an empty array, so we don't test those cases here.
        }
    }
}