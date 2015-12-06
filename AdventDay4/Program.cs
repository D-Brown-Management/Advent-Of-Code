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
            MD5 md5 = new MD5Cng();
            // There is no file input with this challenge - just a prefix.
            string prefix = "yzbqklnj";

            for (int i = 0; i < 100000000; i++)
            {
                string md5input = $"{prefix}{i}";
                byte[] md5Bytes = Encoding.ASCII.GetBytes(md5input);
                byte[] md5Output = md5.ComputeHash(md5Bytes);
                string md5out = BitConverter.ToString(md5Output).Replace("-",string.Empty);

                if (md5out.Substring(0, 6).Equals("000000"))
                {
                    Console.WriteLine($"The number is {i}");
                    break;
                }
            }
        }
    }
}
