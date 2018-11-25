namespace Core
{
    public class Grid
    {
        private readonly bool[,] _grid;

        public Grid(int width, int height)
        {
            Width = width;
            Height = height;
            _grid = new bool[width, height];
        }

        public int Width { get; }

        public int Height { get; }

        public void Seed(Seeder seeder)
        {
            for (var i = 0; i < Height; i++)
            {
                for (var j = 0; j < Width; j++)
                {
                    _grid[j, i] = seeder.Produce();
                }
            }
        }

        public int NeighboursCount(int x, int y)
        {
            var result = 0;

            var xFrom = x == 0 ? x : x - 1;
            var xTo = x == Width - 1 ? x : x + 1;
            var yFrom = y == 0 ? y : y - 1;
            var yTo = y == Height - 1 ? y : y + 1;

            for (var i = yFrom; i <= yTo; i++)
            {
                for (var j = xFrom; j <= xTo; j++)
                {
                    if (!(j == x && i == y) && IsAlive(j, i))
                        result++;
                }
            }

            return result;
        }

        public bool IsAlive(int x, int y) => _grid[x, y];

        public void Kill(int x, int y)
        {
            _grid[x, y] = false;
        }

        public void Spawn(int x, int y)
        {
            _grid[x, y] = true;
        }

        public void Next()
        {
            for (var i = 0; i < Height; i++)
            {
                for (var j = 0; j < Width; j++)
                {
                    Next(j, i);
                }
            }
        }

        public bool Lives(bool isAlive, int neighboursCount)
        {
            if (isAlive)
            {
                if (neighboursCount < 2)
                {
                    return false;
                }

                return neighboursCount <= 3;
            }

            return neighboursCount == 3;
        }

        public void Next(int x, int y)
        {
            var isAlive = IsAlive(x, y);

            var neighboursCount = NeighboursCount(x, y);

            if (Lives(isAlive, neighboursCount))
            {
                Spawn(x, y);
            }
            else
            {
                Kill(x, y);
            }
        }
    }
}