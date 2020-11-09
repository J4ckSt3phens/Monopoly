using System;
using System.Collections.Generic;
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

        public static string[] GetFileLines(string filename)
        {
            try
            {
                return System.IO.File.ReadAllLines(filename);
            }
            catch(System.IO.FileNotFoundException)
            {
                Console.WriteLine("File not found");
                return null;
            }
         
        }
    }
}
