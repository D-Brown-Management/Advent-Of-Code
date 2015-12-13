using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventDay11CS
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "vzbxxyzz";

            input = IncrementString(input);
            while (!BadPassword(input))
            {
                input = IncrementString(input);
            }

            Console.WriteLine(input);
            //string testString = IncrementString(input);
        }

        static bool BadPassword(string input)
        {
            Regex confusing = new Regex("(i|o|l)");
            //Regex doubleRepeat = new Regex("([a-z]{1,}).*([a-z]{1,})");
            //repeatingTwo = Regex.Matches(input, @"([a-z])\1").Count > 1;
            bool notConfusingFlag = false;
            bool doubleRepeatFlag = false;
            bool ascendingFlag = false;
            notConfusingFlag = !confusing.Match(input).Success;
            //doubleRepeatFlag = doubleRepeat.Match(input).Success;
            doubleRepeatFlag = Regex.Matches(input, @"([a-z])\1").Count > 1;

            int lastChar = 0;
            int ascCount = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (ascCount >= 3)
                {
                    ascendingFlag = true;
                    break;
                }

                if (i == 0)
                {
                    lastChar = input[i];
                    ascCount = 1;
                    continue;
                }

                if (lastChar + 1 == input[i])
                {
                    ascCount += 1;
                    lastChar = input[i];
                }
                else
                {
                    lastChar = input[i];
                    ascCount = 1;
                }
            }

            return (notConfusingFlag && doubleRepeatFlag && ascendingFlag);
        }


        static string IncrementString(string input)
        {
            char[] inputArray = input.ToCharArray();

            inputArray[inputArray.Length - 1]++;
            if (inputArray[inputArray.Length - 1] > 122)
            {
                inputArray[inputArray.Length - 1] = 'a';
                inputArray[inputArray.Length - 2]++;
            }

            if (inputArray[inputArray.Length - 2] > 122)
            {
                inputArray[inputArray.Length - 2] = 'a';
                inputArray[inputArray.Length - 3]++;
            }

            if (inputArray[inputArray.Length - 3] > 122)
            {
                inputArray[inputArray.Length - 3] = 'a';
                inputArray[inputArray.Length - 4]++;
            }

            if (inputArray[inputArray.Length - 4] > 122)
            {
                inputArray[inputArray.Length - 4] = 'a';
                inputArray[inputArray.Length - 5]++;
            }

            if (inputArray[inputArray.Length - 5] > 122)
            {
                inputArray[inputArray.Length - 5] = 'a';
                inputArray[inputArray.Length - 6]++;
            }

            if (inputArray[inputArray.Length - 6] > 122)
            {
                inputArray[inputArray.Length - 6] = 'a';
                inputArray[inputArray.Length - 7]++;
            }

            if (inputArray[inputArray.Length - 7] > 122)
            {
                inputArray[inputArray.Length - 7] = 'a';
                inputArray[inputArray.Length - 8]++;
            }

            if (inputArray[inputArray.Length - 8] > 122)
            {
                inputArray[inputArray.Length - 8] = 'a';                
            }



            StringBuilder sb = new StringBuilder();
            sb.Append(inputArray);
            return sb.ToString();
        }
    }
}
