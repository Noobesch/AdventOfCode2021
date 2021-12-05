using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                string[] drawnNumbers = sr.ReadLine().Split(",");
                List<string[]> inputs = new List<string[]>();

                sr.ReadLine();

                string line;

                while (!sr.EndOfStream)
                {
                    List<string> bingoField = new List<string>();

                    for (var inputIndex = 0; inputIndex < 5; inputIndex++)
                    {
                        line = sr.ReadLine();

                        line = (line.StartsWith(" ")) ? line.Remove(0, 1) : line;

                        string[] bingoNumbers = line.Replace("  ", " ").Split(" ");

                        bingoField.AddRange(bingoNumbers);
                    }
                    inputs.Add(bingoField.ToArray());
                    sr.ReadLine();
                }


                List<int>[] foundList = new List<int>[inputs.Count];

                for (var i = 0; i < inputs.Count; i++)
                {
                    foundList[i] = new List<int>();
                }


                int correctField = -1;
                int lastAddedField = -1;

                List<int> correctFields = new List<int>();

                foreach (var number in drawnNumbers)
                {
                    foreach (var input in inputs)
                    {
                        if (input.Contains(number))
                        {
                            int foundIndex = Array.IndexOf(input, number);
                            input[foundIndex] = "";

                            foundList[inputs.IndexOf(input)].Add(foundIndex);
                        }
                    }

                    foreach (var list in foundList)
                    {
                        if (list.Count < 5)
                        {
                            continue;
                        }

                        for (var firstColumn = 0; firstColumn < 25; firstColumn += 5)
                        {
                            if (FindHorizontal(list, firstColumn))
                            {
                                // correctField = Array.IndexOf(foundList, list);
                                // break;
                                if (!correctFields.Contains(Array.IndexOf(foundList, list)))
                                {
                                    correctFields.Add(Array.IndexOf(foundList, list));
                                    lastAddedField = Array.IndexOf(foundList, list);
                                }
                            }
                        }
                        for (var firstRow = 0; firstRow < 5; firstRow++)
                        {
                            if (FindVertical(list, firstRow))
                            {
                                // correctField = Array.IndexOf(foundList, list);
                                // break;

                                if (!correctFields.Contains(Array.IndexOf(foundList, list)))
                                {
                                    correctFields.Add(Array.IndexOf(foundList, list));
                                    lastAddedField = Array.IndexOf(foundList, list);
                                }
                            }
                        }

                        // if (list.Contains(0) && list.Contains(6) && list.Contains(12) && list.Contains(18) && list.Contains(24))
                        // {
                        //     correctField = Array.IndexOf(foundList, list);
                        //     break;
                        // }

                        // if (list.Contains(4) && list.Contains(8) && list.Contains(12) && list.Contains(16) && list.Contains(20))
                        // {
                        //     correctField = Array.IndexOf(foundList, list);
                        //     break;
                        // }
                    }

                    if (correctFields.Count == inputs.Count)
                    {

                        Console.WriteLine("Correct Field: " + lastAddedField);

                        long sum = 0;

                        foreach (var entry in inputs[lastAddedField])
                        {
                            if (entry != "")
                            {
                                sum += long.Parse(entry);
                            }
                        }

                        Console.WriteLine("Sum of Unused: " + sum);
                        Console.WriteLine("Result: " + (sum * long.Parse(number)));
                        break;
                    }

                    // if (correctField != -1)
                    // {
                    //     Console.WriteLine("Correct Field: " + correctField);

                    //     long sum = 0;
                    //     foreach (var bingoFound in foundList[correctField])
                    //     {
                    //         Console.WriteLine(bingoFound);
                    //     }

                    //     foreach (var entry in inputs[correctField])
                    //     {
                    //         if (entry != "")
                    //         {
                    //             sum += long.Parse(entry);
                    //         }
                    //     }

                    //     Console.WriteLine("Sum of Unused: " + sum);
                    //     Console.WriteLine("Result: " + (sum * long.Parse(number)));


                    //     break;
                    // }

                }

                Console.WriteLine();
            }
        }

        static bool FindHorizontal(List<int> list, int index)
        {
            for (int i = 0; i < 5; i++)
            {
                if (!list.Contains(index))
                {
                    return false;
                }

                index++;
            }

            return true;
        }

        static bool FindVertical(List<int> list, int index)
        {
            for (int i = 0; i < 5; i++)
            {
                if (!list.Contains(index))
                {
                    return false;
                }

                index += 5;
            }

            return true;
        }
    }
}
