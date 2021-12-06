using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _06
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                List<long> input = new List<long>();
                List<long> inputAfterDay = new List<long>();

                input.AddRange(sr.ReadToEnd().Split(",").Select(long.Parse).ToArray());


                for (var day = 0; day < 80; day++)
                {
                    foreach (var timer in input)
                    {
                        if (timer == 0)
                        {
                            inputAfterDay.Add(6);
                            inputAfterDay.Add(8);
                        }
                        else
                        {
                            inputAfterDay.Add(timer - 1);
                        }
                    }

                    input.Clear();
                    input.AddRange(inputAfterDay);
                    inputAfterDay.Clear();
                }

                Console.WriteLine($"After 80 days there are {input.Count} fish");

            }
            //Task B

            using (StreamReader sr = new StreamReader("input.txt"))
            {

                long[] amountArray = new long[9];

                long[] inputNumbers = sr.ReadToEnd().Split(",").Select(long.Parse).ToArray();

                //Init array
                foreach (var number in inputNumbers)
                {
                    amountArray[number]++;
                }

                for (var day = 0; day < 256; day++)
                {
                    long[] amountArrayAfter = new long[9];

                    for (var amountIndex = 0; amountIndex < amountArray.Length; amountIndex++)
                    {
                        long amount = amountArray[amountIndex];

                        if (amountIndex == 0)
                        {
                            amountArrayAfter[6] = amount;
                            amountArrayAfter[8] = amount;
                        }
                        else
                        {
                            amountArrayAfter[amountIndex - 1] += amount;
                        }
                    }

                    for (var amountIndex = 0; amountIndex < amountArray.Length; amountIndex++)
                    {
                        amountArray[amountIndex] = amountArrayAfter[amountIndex];
                    }
                }

                long result = 0;

                foreach(var value in amountArray)
                {
                    result += value;
                }

                Console.WriteLine($"After 256 days there are {result} fish");
            }
        }
    }
}
