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

                int currentVal, previousVal;

                int succesCouter = 0;
                int failCounter = 0;

                for (var i = 1; i < input.Length - 2; i++)
                {
                    previousVal = int.Parse(input[i - 1]) + int.Parse(input[i]) + int.Parse(input[i + 1]) ;
                    currentVal = int.Parse(input[i]) + int.Parse(input[i + 1]) + int.Parse(input[i + 2]);

                    if (previousVal < currentVal)
                    {
                        succesCouter++;
                    }
                    else
                    {
                        failCounter++;
                    }
                }

                Console.WriteLine("Sucess: " + succesCouter + "\nFail: " + failCounter);
            }
        }
    }
}
