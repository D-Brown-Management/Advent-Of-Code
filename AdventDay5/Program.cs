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
            var lines = File.ReadLines(@"C:\users\steve\desktop\input_day5.txt");

            int counter = lines.Count(line => NaughtyOrNiceV2(line));
            //var output = NaughtyOrNiceV2("ieodomkazucvgmuy");
            Console.WriteLine($"{counter}");
        }


        static bool NaughtyOrNiceV1(string input)
        {
            var repeatingTwo = false;
            var vowelThree = false;

            if (Regex.IsMatch(input, "(ab|cd|pq|xy)"))
            {
                // not nice bail out
                return false;
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


            return repeatingTwo && vowelThree;
        }

        static bool NaughtyOrNiceV2(string input)
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

            return overlappingPair && repeatBetween;
        }
    }
}
