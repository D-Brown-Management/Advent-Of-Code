using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventDay9
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadLines("input.txt.");
            Regex regex = new Regex(@"^(?<Node1>[A-Za-z]+)\sto\s(?<Node2>[A-Za-z]+)\s=\s(?<Weight>[0-9]+)$");            
            List<Tuple<string,string,int>> inputList = new List<Tuple<string, string, int>>();

            // Read all the input file information - not really to do with traversal.
            #region Input Reading 
            foreach (var line in input)
            {
                var match = regex.Match(line);
                var tup1 = new Tuple<string, string, int>(match.Groups["Node1"].Value, match.Groups["Node2"].Value,
                    int.Parse(match.Groups["Weight"].Value));

                var tup2 = new Tuple<string, string, int>(match.Groups["Node2"].Value, match.Groups["Node1"].Value,
                    int.Parse(match.Groups["Weight"].Value));

                if (!inputList.Contains(tup1)) inputList.Add(tup1); 
                if (!inputList.Any(i => i.Item1 == tup2.Item1 && i.Item2 == tup2.Item2)) inputList.Add(tup2);
            }

            var locationList = inputList.Select(i => i.Item1).Distinct();
            
            #endregion

            var testDict = new Dictionary<string, int>();
            var perms = GetPermutations(locationList, 8);
            Console.Write("Calculating Paths");
            int pathCounter = 0;
            foreach (var perm in perms)
            {
                string first = perm.ElementAt(0);
                string previous = first;

                string pathString = string.Empty;
                int pathTotal = 0;
                
                pathString = first;
                if(pathCounter%50==0) Console.Write(".");
                for (int i=1; i<perm.Count(); i++)
                {                             
                    var current = perm.ElementAt(i);
                    int len = inputList.Single(l => l.Item1 == previous && l.Item2 == current).Item3;
                    
                    pathString = $"{pathString}--{len}-->{current}";
                    pathTotal += len;
                    previous = current;
                }
                testDict.Add(pathString, pathTotal);
                pathCounter++;
            }

            var orderedDict = testDict.OrderBy(d => d.Value);
            Console.WriteLine();
            Console.WriteLine($"Santa's Shortest Route (V1) {orderedDict.First().Value}");
            Console.WriteLine($"Santa's Longest Route (V2) {orderedDict.Last().Value}");
            Console.Write("Press any key to continue...");
            Console.ReadLine();
        }

        // Generic IEnumerable permute implementation - recurses through a list finding all 
        // sub-sequences and returning a collection of collections up
        static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }

    }
        
}
