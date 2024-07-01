using System;

namespace EvSef.Core.Generator
{
    public class RandomNumber
    {
        public static int Random(int min, int max)
        {
            var rand = new Random();
            return rand.Next(min, max);
        }
    }
}
