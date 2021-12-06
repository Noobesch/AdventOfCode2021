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
                    foreach(var timer in input)
                    {
                        if(timer == 0)
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
        }
    }
}
