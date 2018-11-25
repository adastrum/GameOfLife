using Xunit;

namespace Core.Tests
{
    public class GridTests
    {
        [Fact]
        public void Seed_HundredPercent_EverythingIsAlive()
        {
            var sut = new Grid(3, 3);
            var seeder = new Seeder(100);

            sut.Seed(seeder);

            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    Assert.True(sut.IsAlive(i, j));
                }
            }
        }

        [Fact]
        public void NeighboursCount_EmptyGrid_ReturnsZero()
        {
            var sut = new Grid(3, 3);
            var actual = sut.NeighboursCount(1, 1);

            Assert.Equal(0, actual);
        }

        [Theory]
        [InlineData(3, 3, 0, 0, 3)]
        [InlineData(3, 3, 0, 1, 5)]
        [InlineData(3, 3, 0, 2, 3)]
        [InlineData(3, 3, 1, 0, 5)]
        [InlineData(3, 3, 1, 1, 8)]
        [InlineData(3, 3, 1, 2, 5)]
        [InlineData(3, 3, 2, 0, 3)]
        [InlineData(3, 3, 2, 1, 5)]
        [InlineData(3, 3, 2, 2, 3)]
        public void NeighboursCount_FilledGrid_ReturnsNeighboursCount(int width, int height, int x, int y, int expected)
        {
            var sut = new Grid(width, height);
            var seeder = new Seeder(100);

            sut.Seed(seeder);

            var actual = sut.NeighboursCount(x, y);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Kill_Kills()
        {
            var sut = new Grid(1, 1);
            var seeder = new Seeder(100);

            const int x = 0;
            const int y = 0;

            sut.Seed(seeder);

            Assert.True(sut.IsAlive(x, y));

            sut.Kill(x, y);

            Assert.False(sut.IsAlive(x, y));
        }

        [Fact]
        public void Spawn_Spawns()
        {
            var sut = new Grid(1, 1);

            const int x = 0;
            const int y = 0;

            Assert.False(sut.IsAlive(x, y));

            sut.Spawn(x, y);

            Assert.True(sut.IsAlive(x, y));
        }

        [Theory]
        [InlineData(true, 0, false)]
        [InlineData(true, 1, false)]
        [InlineData(true, 2, true)]
        [InlineData(true, 3, true)]
        [InlineData(true, 4, false)]
        [InlineData(false, 3, true)]
        public void Lives(bool isAlive, int neighboursCount, bool expected)
        {
            var sut = new Grid(3, 3);

            var actual = sut.Lives(isAlive, neighboursCount);

            Assert.Equal(expected, actual);
        }
    }
}
