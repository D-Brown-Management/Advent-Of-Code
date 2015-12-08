using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventDay8CS
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadLines("input.txt");
            Console.WriteLine($"Santa's Memory Difference V1 is {EscapeLinesV1(lines)}");
            Console.WriteLine($"Santa's Memory Difference V2 is {EscapeLinesV2(lines)}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        static int EscapeLinesV1(IEnumerable<string> input)
        {
            Regex rx = new Regex("[\\\\]x[0-9a-fA-F][0-9a-fA-F]");
            int totalString = 0;
            int totalMemory = 0;

            foreach (var line in input)
            {
                var inputLen = line.Length;
                var cleanString = line.Substring(1, inputLen - 2);
                cleanString = cleanString.Replace("\\\"", "Q");
                cleanString = cleanString.Replace("\\\\", "B");
                cleanString = rx.Replace(cleanString, "H");
                totalString += inputLen;
                totalMemory += cleanString.Length;                
            }
            
            return totalString - totalMemory;
        }

        static int EscapeLinesV2(IEnumerable<string> input)
        {
            Regex rx = new Regex("[\\\\]x[0-9a-fA-F][0-9a-fA-F]");
            int totalString = 0;
            int totalMemory = 0;

            foreach (var line in input)
            {
                var inputLen = line.Length;

                var cleanString = line.Substring(1, line.Length - 2);
                cleanString = $"OO{cleanString}OO";

                cleanString = cleanString.Replace("\\\"", "QQQQ");
                cleanString = cleanString.Replace("\\\\", "BBBB");
                cleanString = rx.Replace(cleanString, "HHHHH");
                totalString += inputLen;
                totalMemory += cleanString.Length+2;
            }
            
            return totalMemory - totalString;
        }
    }
}
