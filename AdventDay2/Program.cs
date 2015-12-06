using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDay2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Calculation
            // 2(L*W) + 2(W*H) + 2(H*L)
            // 2x3x4 = 2(2*3) + 2(3*4) + 2(2*4) = 52 sqft
            //          ^smallest               =  6 sqft
            //                                  = 58 sqft
            int totalSqft = 0;
            int totalRibbon = 0;
            var input = File.ReadLines(@"c:\users\steve\desktop\input5.txt");
            foreach (string boxLine in input)
            {
                int length, width, height;
                // Split into L/W/H
                var splitLine = boxLine.Split('x');

                length = int.Parse(splitLine[0]);
                width = int.Parse(splitLine[1]);
                height = int.Parse(splitLine[2]);
                
                int[] sideArea = new int[3];
                sideArea[0] = length*width;
                sideArea[1] = length*height;
                sideArea[2] = width*height;

                int[] sidePerimeter = new int[3];
                sidePerimeter[0] = 2*length + 2*width;
                sidePerimeter[1] = 2*length + 2*height;
                sidePerimeter[2] = 2*width + 2*height;

                int presentVolume = length*width*height;

                Array.Sort(sideArea);
                Array.Sort(sidePerimeter);

                int sqFt = 2*(length*width) + 2*(width*height) + 2*(height*length) + sideArea[0];
                int ribbonLength = sidePerimeter[0] + presentVolume;
                //Console.WriteLine($"The Sqft for a package {length}x{width}x{height} is {sqFt}");
                //Console.WriteLine($"The ribbon for a package {length}x{width}x{height} is {ribbonLength}");
                totalSqft += sqFt;

                
                totalRibbon += ribbonLength;
            }

            Console.WriteLine($"The total sqft was {totalSqft}");
            Console.WriteLine($"The total ribbon was {totalRibbon}");
        }
    }
}
