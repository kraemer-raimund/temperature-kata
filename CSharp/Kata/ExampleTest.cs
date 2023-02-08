using NUnit.Framework;

namespace Kata
{
    [TestFixture]
    public class ExampleTest
    {
        [Test]
        public void ShouldPass()
        {
            Assert.Pass();
        }

        [Test]
        public void ShouldFail()
        {
            Assert.Fail();
        }
    }
}
