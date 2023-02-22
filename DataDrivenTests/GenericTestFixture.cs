using NUnit.Framework;

namespace DataDrivenTests
{
    // Define a generic test fixture for testing different types
    [TestFixture(typeof(int))]
    [TestFixture(typeof(string))]
    public class GenericTestFixture<T>
    {
        // Define a test method to output the generic test type
        [Test]
        public void TestType()
        {
            // Use the Assert.Pass method to indicate a successful test run
            // Output the generic test type using the typeof operator and string interpolation
            Assert.Pass($"The generic test type is {typeof(T)}");
        }
    }
}
