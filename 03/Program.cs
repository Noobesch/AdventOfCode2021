using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                string[] input = sr.ReadToEnd().Split("\r\n");

                //Part1
                #region 
                int[] occurenceArray = new int[input[0].Length];

                for (var i = 0; i < input.Length; i++)
                {
                    string line = input[i];
                    for (var stringIndex = 0; stringIndex < occurenceArray.Length; stringIndex++)
                    {
                        if (line[stringIndex] == '0')
                        {
                            occurenceArray[stringIndex]--;
                        }
                        else
                        {
                            occurenceArray[stringIndex]++;
                        }
                    }
                }

                string gamma = "";
                string epsilon = "";

                foreach (var occurence in occurenceArray)
                {
                    if (occurence > 0)
                    {
                        gamma = gamma + "1";
                        epsilon = epsilon + "0";
                    }
                    else
                    {
                        gamma = gamma + "0";
                        epsilon = epsilon + "1";
                    }
                }

                long gammaLong, epsilonLong, resultLong;

                gammaLong = Convert.ToInt64(gamma, 2);
                epsilonLong = Convert.ToInt64(epsilon, 2);


                resultLong = epsilonLong * gammaLong;

                Console.WriteLine($"Strings: {gamma} {epsilon}, ints {gammaLong} {epsilonLong}, result {resultLong}");

                #endregion
                //Part2

                long oxygen = 0, co2 = 0;

                List<string> inputListOxygen = input.ToList<string>();

                //Cycle through the digitPositions
                for (var stringIndex = 0; stringIndex < occurenceArray.Length; stringIndex++)
                {
                    int occurence = 0;

                    //Cycle through the lines to find mostSignificantBit
                    for (var lineIndex = 0; lineIndex < inputListOxygen.Count; lineIndex++)
                    {
                        string line = inputListOxygen[lineIndex];

                        if (line[stringIndex] == '0')
                        {
                            occurence--;
                        }
                        else
                        {
                            occurence++;
                        }
                    }

                    List<string> tempListOxygen = new List<string>();

                    //DiscardLines;
                    for (var lineIndex = 0; lineIndex < inputListOxygen.Count; lineIndex++)
                    {
                        string line = inputListOxygen[lineIndex];

                        if (line[stringIndex] == '1' && occurence >= 0 || line[stringIndex] == '0' && occurence < 0)
                        {
                            tempListOxygen.Add(line);
                        }
                    }

                    if (tempListOxygen.Count <= 1)
                    {
                        //100101011101
                        Console.WriteLine("Most significant line found: " + tempListOxygen[0] + " " + Convert.ToInt64(tempListOxygen[0], 2));
                        oxygen = Convert.ToInt64(tempListOxygen[0], 2);
                        break;
                    }

                    inputListOxygen.Clear();
                    inputListOxygen = tempListOxygen;
                }

                List<string> inputListCO2 = input.ToList<string>();

                //Cycle through the digitPositions
                for (var stringIndex = 0; stringIndex < occurenceArray.Length; stringIndex++)
                {
                    int occurence = 0;

                    //Cycle through the lines to find mostSignificantBit
                    for (var lineIndex = 0; lineIndex < inputListCO2.Count; lineIndex++)
                    {
                        string line = inputListCO2[lineIndex];

                        if (line[stringIndex] == '0')
                        {
                            occurence--;
                        }
                        else
                        {
                            occurence++;
                        }
                    }

                    List<string> tempListCO2 = new List<string>();

                    //DiscardLines;
                    for (var lineIndex = 0; lineIndex < inputListCO2.Count; lineIndex++)
                    {
                        string line = inputListCO2[lineIndex];

                        if (line[stringIndex] == '0' && occurence >= 0 || line[stringIndex] == '1' && occurence < 0)
                        {
                            tempListCO2.Add(line);
                        }
                    }

                    if (tempListCO2.Count <= 1)
                    {
                        Console.WriteLine("Least significant line found: " + tempListCO2[0] + "  " + Convert.ToInt64(tempListCO2[0], 2));
                        co2 = Convert.ToInt64(tempListCO2[0], 2);
                        break;
                    }

                    inputListCO2.Clear();
                    inputListCO2 = tempListCO2;
                }

                //5743212 too high
                Console.WriteLine($"Result = {oxygen * co2}");

            }
        }
    }
}
