using NUnit.Framework;

namespace DataDrivenTests
{
    // Define a test fixture for data-driven tests
    [TestFixture(10)]
    [TestFixture(42)]
    public class DataDrivenTestFixture
    {
        // Define a private field to store the test argument
        int _x;

        // Define a constructor to initialize the test argument
        public DataDrivenTestFixture(int x)
        {
            _x = x;
        }

        // Define a test method to use the test argument
        [Test]
        public void TestArguments()
        {
            // Use the Assert.Pass method to indicate a successful test run
            // Output the test argument value using string interpolation
            Assert.Pass($"X is {_x}");
        }
    }
}
