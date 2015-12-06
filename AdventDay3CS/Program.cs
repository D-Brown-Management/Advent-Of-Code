using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDay3
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputString = File.ReadAllLines("input.txt");

            string navigation = inputString[0];

            Console.WriteLine($"Santa Visited {SantaLocationsV1(navigation)} houses solo.");
            Console.WriteLine($"Santa Visited {SantaLocationsV2(navigation)} houses with his robot.");
            Console.Write("Press any key to continue...");
            Console.ReadLine();
        }

        static int SantaLocationsV1(string input)
        {
            Tuple<int, int> santaCurrent = new Tuple<int, int>(0, 0);
           
            List<Tuple<int, int>> houseHistory = new List<Tuple<int, int>>();
            houseHistory.Add(santaCurrent);
            for (int i = 0; i < input.Length; i++)
            {
                // move
                switch (input[i])
                {
                    case '^':
                        // north
                        santaCurrent = new Tuple<int, int>(santaCurrent.Item1, santaCurrent.Item2 + 1);                        
                        break;
                    case '>':
                        // east
                        santaCurrent = new Tuple<int, int>(santaCurrent.Item1 + 1, santaCurrent.Item2);                       
                        break;
                    case 'v':
                        // south 
                        santaCurrent = new Tuple<int, int>(santaCurrent.Item1, santaCurrent.Item2 - 1);                       
                        break;
                    case '<':
                        // west
                        santaCurrent = new Tuple<int, int>(santaCurrent.Item1 - 1, santaCurrent.Item2);                        
                        break;

                }
                houseHistory.Add(santaCurrent);
            }

            var numLocations = houseHistory.Distinct().Count();

            return numLocations;

        }

        static int SantaLocationsV2(string input)
        {
            Tuple<int, int> santaCurrent = new Tuple<int, int>(0, 0);
            Tuple<int, int> roboCurrent = new Tuple<int, int>(0, 0);

            List<Tuple<int, int>> houseHistory = new List<Tuple<int, int>>();
            houseHistory.Add(santaCurrent);
            for (int i = 0; i < input.Length; i++)
            {
                // move
                switch (input[i])
                {
                    case '^':
                        // north
                        if (i % 2 == 1)
                        {
                            roboCurrent = new Tuple<int, int>(roboCurrent.Item1, roboCurrent.Item2 + 1);
                        }
                        else
                        {
                            santaCurrent = new Tuple<int, int>(santaCurrent.Item1, santaCurrent.Item2 + 1);
                        }

                        break;
                    case '>':
                        if (i % 2 == 1)
                        {
                            roboCurrent = new Tuple<int, int>(roboCurrent.Item1 + 1, roboCurrent.Item2);
                        }
                        else
                        {
                            santaCurrent = new Tuple<int, int>(santaCurrent.Item1 + 1, santaCurrent.Item2);
                        }
                        // east

                        break;
                    case 'v':
                        if (i % 2 == 1)
                        {
                            roboCurrent = new Tuple<int, int>(roboCurrent.Item1, roboCurrent.Item2 - 1);
                        }
                        else
                        {
                            santaCurrent = new Tuple<int, int>(santaCurrent.Item1, santaCurrent.Item2 - 1);
                        }
                        // south                    

                        break;
                    case '<':
                        if (i % 2 == 1)
                        {
                            roboCurrent = new Tuple<int, int>(roboCurrent.Item1 - 1, roboCurrent.Item2);
                        }
                        else
                        {
                            santaCurrent = new Tuple<int, int>(santaCurrent.Item1 - 1, santaCurrent.Item2);
                        }
                        // west

                        break;

                }
                houseHistory.Add(i % 2 == 1 ? roboCurrent : santaCurrent);
            }

            var numLocations = houseHistory.Distinct().Count();

            return numLocations;
            
        }
    }
}
