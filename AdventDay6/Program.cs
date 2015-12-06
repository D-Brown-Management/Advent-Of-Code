using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventDay6
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadLines("input.txt");

            Console.WriteLine($"Santa's Light Count (V1): {SantaLightsV1(lines)}");
            Console.WriteLine($"Santa's Light Intensity (V2): {SantaLightsV2(lines)}");
            Console.Write("Press any key to continue..");
            Console.ReadLine();
        }


        private static int SantaLightsV1(IEnumerable<string> lines)
        {
            bool[,] lightArray = new bool[1000, 1000];

            foreach (var line in lines)
            {
                Regex regex =
                    new Regex(
                        @"^(?<instruction>turn on|turn off|toggle)\s(?<coord1>\d{1,3},\d{1,3})\s(through)\s(?<coord2>\d{1,3},\d{1,3})");

                var match = regex.Match(line);

                var instruction = match.Groups["instruction"].Value;
                var coord1 = match.Groups["coord1"].Value;
                var coord2 = match.Groups["coord2"].Value;

                string[] coord1Split = coord1.Split(',');
                string[] coord2Split = coord2.Split(',');

                Point coord1Point = new Point(Convert.ToInt32(coord1Split[0]), Convert.ToInt32(coord1Split[1]));
                Point coord2Point = new Point(Convert.ToInt32(coord2Split[0]), Convert.ToInt32(coord2Split[1]));

                int lowX = coord1Point.X > coord2Point.X ? coord2Point.X : coord1Point.X;
                int lowY = coord1Point.Y > coord2Point.Y ? coord2Point.Y : coord1Point.Y;

                int highX = coord1Point.X < coord2Point.X ? coord2Point.X : coord1Point.X;
                int highY = coord1Point.Y < coord2Point.Y ? coord2Point.Y : coord1Point.Y;

                for (int i = lowX; i < highX + 1; i++)
                {
                    for (int j = lowY; j < highY + 1; j++)
                    {
                        switch (instruction)
                        {
                            case "turn on":
                                lightArray[i, j] = true;
                                break;
                            case "turn off":
                                lightArray[i, j] = false;                                
                                break;
                            case "toggle":
                                lightArray[i, j] = !lightArray[i,j];
                                break;
                        }
                    }
                }
            }
            int onCount = 0;
            int counter = 0;

            foreach (var a in lightArray)
            {
                if (a)
                {
                    onCount++;
                }
                counter++;
            }

            return onCount;
        }

        private static int SantaLightsV2(IEnumerable<string> lines)
        {
            int[,] lightArray = new int[1000, 1000];

            foreach (var line in lines)
            {
                Regex regex =
                    new Regex(
                        @"^(?<instruction>turn on|turn off|toggle)\s(?<coord1>\d{1,3},\d{1,3})\s(through)\s(?<coord2>\d{1,3},\d{1,3})");

                var match = regex.Match(line);

                var instruction = match.Groups["instruction"].Value;
                var coord1 = match.Groups["coord1"].Value;
                var coord2 = match.Groups["coord2"].Value;

                string[] coord1Split = coord1.Split(',');
                string[] coord2Split = coord2.Split(',');

                Point coord1Point = new Point(Convert.ToInt32(coord1Split[0]), Convert.ToInt32(coord1Split[1]));
                Point coord2Point = new Point(Convert.ToInt32(coord2Split[0]), Convert.ToInt32(coord2Split[1]));

                int lowX = coord1Point.X > coord2Point.X ? coord2Point.X : coord1Point.X;
                int lowY = coord1Point.Y > coord2Point.Y ? coord2Point.Y : coord1Point.Y;

                int highX = coord1Point.X < coord2Point.X ? coord2Point.X : coord1Point.X;
                int highY = coord1Point.Y < coord2Point.Y ? coord2Point.Y : coord1Point.Y;

                for (int i = lowX; i < highX + 1; i++)
                {
                    for (int j = lowY; j < highY + 1; j++)
                    {
                        switch (instruction)
                        {
                            case "turn on":
                                lightArray[i, j] += 1;
                                break;
                            case "turn off":
                                lightArray[i, j] -= 1;
                                if (lightArray[i, j] < 0)
                                    lightArray[i, j] = 0;
                                break;
                            case "toggle":
                                lightArray[i, j] += 2;
                                break;
                        }
                    }
                }
            }
            int onCount = 0;
            int counter = 0;

            foreach (var a in lightArray)
            {
                onCount += a;
                counter++;
            }

            return onCount;
        }
    }
}
