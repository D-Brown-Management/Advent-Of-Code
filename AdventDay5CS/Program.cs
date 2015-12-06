using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventDay5
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadLines(@"input.txt");
            
            Console.WriteLine($"Nice List V1: {NaughtyOrNiceV1(lines)}");
            Console.WriteLine($"Nice List V2: {NaughtyOrNiceV2(lines)}");
            Console.Write("Press any key to continue...");
            Console.ReadLine();
        }


        static int NaughtyOrNiceV1(IEnumerable<string> inputLines)
        {
            int count = 0;
            foreach (var input in inputLines)
            {
                var repeatingTwo = false;
                var vowelThree = false;

                if (Regex.IsMatch(input, "(ab|cd|pq|xy)"))
                {
                    continue;
                }

                if (Regex.IsMatch(input, @"([a-zA-Z])\1"))
                {
                    repeatingTwo = true;
                }

                var matches = Regex.Matches(input, "[aeiou]");
                if (matches.Count > 2)
                {
                    vowelThree = true;
                }

                if (repeatingTwo && vowelThree)
                {
                    count++;
                }
            }
            
            return count;
        }

        static int NaughtyOrNiceV2(IEnumerable<string> inputLines)
        {
            int count = 0;
            foreach (var input in inputLines)
            {
                bool overlappingPair = false;
                bool repeatBetween = false;

                if (Regex.IsMatch(input, @"^.*(?<rpt>([a-zA-Z])\w).*\k<rpt>"))
                {
                    overlappingPair = true;
                }

                if (Regex.IsMatch(input, @"^.*(?<rpt>([a-zA-Z])).{1}\k<rpt>"))
                {
                    repeatBetween = true;
                }

                if (overlappingPair && repeatBetween)
                {
                    count++;
                }
            }

            return count;
            
        }
    }
}
