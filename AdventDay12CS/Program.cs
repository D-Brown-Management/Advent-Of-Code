using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AdventDay12CS
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadLines("input.txt");
            string input = lines.ElementAt(0);

            

            Console.WriteLine($"The V1 total is: {AccountingElvesV1(input)}");
            Console.WriteLine($"The V2 total is: {AccountingElvesV2(input)}");
            Console.Write("Press Any Key to continue...");
            Console.ReadLine();
        }

        static int AccountingElvesV1(string input)
        {
            Regex regex = new Regex(@"(-?\d+)");

            var matches = regex.Matches(input);

            int total = 0;

            foreach (Match match in matches)
            {
                total += int.Parse(match.Value);
            }

            return total;
        }

        static long AccountingElvesV2(string input)
        {

            return sum;
        }
    }
}
