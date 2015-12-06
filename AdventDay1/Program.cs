using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDay1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var inputString = File.ReadAllLines("input.txt");

            string santaCode = inputString[0];

            Console.WriteLine($"Ending Floor: {ElevatorV1(santaCode)}");
            Console.WriteLine($"Basement Move: {ElevatorV2(santaCode)}");
            Console.Write("Press any key to continue...");
            Console.ReadLine();

        }

        static int ElevatorV1(string input)
        {
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                var currentChar = input[i];
                if (currentChar == '(')
                {
                    count++;
                }
                else
                {
                    count--;
                }
            }

            return count;
        }

        static int ElevatorV2(string input)
        {
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                var currentChar = input[i];                
                if (currentChar == '(')
                {
                    count++;
                }
                else
                {
                    count--;
                }
                if (count < 0)
                {
                    //break;
                    return i+1;
                }                
            }
            return -1;
            //return count;
        }
    }
}
