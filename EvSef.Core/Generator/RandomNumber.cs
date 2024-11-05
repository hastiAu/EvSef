using System;

namespace EvSef.Core.Generator
{
    public static class RandomNumber
    {
        private static readonly Random _rand = new Random();

        public static int Generate(int min, int max)
        {
            return _rand.Next(min, max);
        }
    }

}
