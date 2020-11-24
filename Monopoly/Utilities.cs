using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public static class Utilities
    {

        private static readonly Random Random = new Random();

        public static int GetRandomNumber(int min, int max)
        {
            lock (Random)
            {
                return Random.Next(min, max);
            }
        }

        public static string[] ReadAllResourceLines(string resourceText)
        {
            using (StringReader reader = new StringReader(resourceText))
            {
                return EnumerateLines(reader).ToArray();
            }
        }

        private static IEnumerable<string> EnumerateLines(TextReader reader)
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }
}
