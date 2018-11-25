using Xunit;

namespace Core.Tests
{
    public class SeederTests
    {
        [Fact]
        public void Produce_Zero_ReturnsFalse()
        {
            var sut = new Seeder(0);

            var actual = sut.Produce();

            Assert.False(actual);
        }

        [Fact]
        public void Produce_Hundred_ReturnsTrue()
        {
            var sut = new Seeder(100);

            var actual = sut.Produce();

            Assert.True(actual);
        }
    }
}
