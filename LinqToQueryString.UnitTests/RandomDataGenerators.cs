namespace LinqToQueryString.UnitTests
{
    using System;

    public static class RandomDataGenerators
    {
        private static readonly Random Random = new Random();

        public static string String()
        {
            return Guid.NewGuid().ToString();
        }

        public static int Int(int min, int max)
        {
            return Random.Next(min, max);
        }

        public static long Long()
        {
            return Random.Next(10000, 999999);
        }

        public static long Long(int min, int max)
        {
            return Random.Next(min, max);
        }

        public static Guid NewGuid()
        {
            return Guid.NewGuid();
        }

        public static DateTime DateAndTime()
        {
            var start = new DateTime(1995, 1, 1);
            var range = (int)(DateTime.Today - start).TotalDays;
            return start.AddDays(Random.Next(range));
        }

        public static bool Bool()
        {
            return Random.Next(0, 1) > 0;
        }
    }
}
