using System;

namespace Core
{
    public class Seeder
    {
        private readonly Random _random = new Random();

        private readonly int _percentage;

        public Seeder(int percentage)
        {
            _percentage = percentage;
        }

        public bool Produce()
        {
            return _random.Next(100) < _percentage;
        }
    }
}