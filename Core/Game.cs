namespace Core
{
    public class Game
    {
        private readonly Grid _grid;

        public Game(Grid grid)
        {
            _grid = grid;
        }

        public void Next()
        {
            _grid.Next();
        }
    }
}