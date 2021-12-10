using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _07
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                List<long> inputs = sr.ReadToEnd().Split(",").Select(long.Parse).ToList();

                inputs.Sort();

                long min = inputs.Min();
                long max = inputs.Max();

                long[] fuelArray = new long[max - min];

                long minFuelIndex = long.MaxValue;
                long minFuelUsed = long.MaxValue;

                for (var inputIndex = min; inputIndex < max; inputIndex++)
                {
                    foreach(var input in inputs)
                    {
                        long distance = Math.Abs(input - inputIndex);
                        fuelArray[inputIndex] += distance * (distance + 1) / 2;
                    }

                    if(fuelArray[inputIndex] < minFuelUsed)
                    {
                        minFuelUsed = fuelArray[inputIndex];
                        minFuelIndex = inputIndex;
                    }
                }

                Console.WriteLine($"Least fuel used is {minFuelIndex + min} with a use of {minFuelUsed}");
            }
        }
    }
}
