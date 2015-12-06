using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdventDay4
{
    class Program
    {
        static void Main(string[] args)
        {            
            // There is no file input with this challenge - just a prefix.
            string prefix = "yzbqklnj";
            Console.WriteLine($"Santa's First Number: {SantaHashV1(prefix)}");
            Console.WriteLine($"Santa's Second Number: {SantaHashV2(prefix)}");
            Console.Write("Press any key to continue...");
            Console.ReadLine();
        }

        static int SantaHashV1(string input)
        {
            MD5 md5 = new MD5Cng();
            int output = 0;
            for (int i = 0; i < 1000000000; i++)
            {
                string md5input = $"{input}{i}";
                byte[] md5Bytes = Encoding.ASCII.GetBytes(md5input);
                byte[] md5Output = md5.ComputeHash(md5Bytes);
                string md5out = BitConverter.ToString(md5Output).Replace("-", string.Empty);

                if (md5out.Substring(0, 5).Equals("00000"))
                {
                    output = i;
                    break;
                }
            }

            return output;
        }

        static int SantaHashV2(string input)
        {
            MD5 md5 = new MD5Cng();
            int output =0;
            for (int i = 0; i < 1000000000; i++)
            {
                string md5input = $"{input}{i}";
                byte[] md5Bytes = Encoding.ASCII.GetBytes(md5input);
                byte[] md5Output = md5.ComputeHash(md5Bytes);
                string md5out = BitConverter.ToString(md5Output).Replace("-", string.Empty);

                if (md5out.Substring(0, 6).Equals("000000"))
                {
                    output = i;
                    break;
                }
            }

            return output;
        }
    }
}
