using System;
using System.IO;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                string[] input = sr.ReadToEnd().Split("\r\n");

                for (var inputIndex = 1; inputIndex < input.Length; inputIndex++)
                {

                }

                Console.WriteLine();
            }
        }
    }
}
