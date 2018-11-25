using Xunit;

namespace Core.Tests
{
    public class GameTests
    {
        [Fact]
        public void CanCreateGame()
        {
            var grid = new Grid(3, 3);
            var sut = new Game(grid);
        }
    }

    //The universe of the Game of Life is an infinite, two-dimensional orthogonal grid of square cells, each of which is in one of two possible states, alive or dead, (or populated and unpopulated, respectively). Every cell interacts with its eight neighbours, which are the cells that are horizontally, vertically, or diagonally adjacent.At each step in time, the following transitions occur:

    //Any live cell with fewer than two live neighbors dies, as if by underpopulation.
    //Any live cell with two or three live neighbors lives on to the next generation.
    //Any live cell with more than three live neighbors dies, as if by overpopulation.
    //Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.
}
