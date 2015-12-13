using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace AdventDay10CS
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string inputString = "1113122113";

            string v1 = LookSayV2(inputString, 65);
            //string v2 = LookSayV2(v1, 10);
            Console.WriteLine($"Elves Look-And-Say V1 Result: {v1.Length}");
            //Console.WriteLine($"Elves Look-And-Say V2 Result: {v2.Length}");
            Console.Write("Press any key to continue...");
            Console.ReadLine();
        }

        static string LookSayV2(string inputString, int times)
        {
            StringBuilder sb = new StringBuilder();
            int repeatCount = 1;
            char currentChar = Char.MinValue;
            for (int i = 0; i < inputString.Length; i++)
            {
                if (i == 0)
                {
                    repeatCount = 1;
                    currentChar = inputString[i];
                    continue;
                }
                if (inputString[i] == currentChar)
                {
                    repeatCount++;
                }
                else
                {                                
                    sb.Append(repeatCount);
                    sb.Append(currentChar);
                    repeatCount = 1;                    
                    currentChar = inputString[i];                    
                }
            }
            sb.Append(repeatCount);
            sb.Append(currentChar);

            if (times > 1)
            {
                return LookSayV2(sb.ToString(), times - 1);
            }

            return sb.ToString();        
        }
    }
}
