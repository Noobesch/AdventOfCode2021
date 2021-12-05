using System;
using System.IO;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                string[] input = sr.ReadToEnd().Split("\r\n");
                (int x1, int y1, int x2, int y2)[] coordinates = new (int x1, int y1, int x2, int y2)[input.Length];


                int xMax = 0, yMax = 0;

                string line;
                for (var inputIndex = 0; inputIndex < input.Length; inputIndex++)
                {
                    line = input[inputIndex];
                    line = line.Replace(" -> ", ",");

                    var numbers = line.Split(",");

                    coordinates[inputIndex] = (int.Parse(numbers[0]), int.Parse(numbers[1]), int.Parse(numbers[2]), int.Parse(numbers[3]));

                    xMax = Math.Max(xMax, Math.Max(coordinates[inputIndex].x1, coordinates[inputIndex].x2));
                    yMax = Math.Max(yMax, Math.Max(coordinates[inputIndex].y1, coordinates[inputIndex].y2));
                }

                int[,] occurenceArray = new int[xMax + 1, yMax + 1];

                foreach (var coordinate in coordinates)
                {
                    if (coordinate.x1 != coordinate.x2 && coordinate.y1 != coordinate.y2)
                    {
                        if (coordinate.x1 < coordinate.x2 && coordinate.y1 < coordinate.y2)
                        {
                            int j = coordinate.y1;
                            for (int i = coordinate.x1; i <= coordinate.x2; i++)
                            {
                                occurenceArray[i, j]++;
                                j++;
                            }
                        }
                        else if (coordinate.x2 < coordinate.x1 && coordinate.y1 < coordinate.y2)
                        {
                            int j = coordinate.y2;
                            for (int i = coordinate.x2; i <= coordinate.x1; i++)
                            {
                                occurenceArray[i, j]++;
                                j--;
                            }
                        }
                        else if (coordinate.x2 < coordinate.x1 && coordinate.y2 < coordinate.y1)
                        {
                            int j = coordinate.y2;
                            for (int i = coordinate.x2; i <= coordinate.x1; i++)
                            {
                                occurenceArray[i, j]++;
                                j++;
                            }
                        }
                        else
                        {
                            int j = coordinate.y1;
                            for (int i = coordinate.x1; i <= coordinate.x2; i++)
                            {
                                occurenceArray[i, j]++;
                                j--;
                            }
                        }
                    }

                    else if (coordinate.x1 == coordinate.x2)
                    {
                        if (coordinate.y1 < coordinate.y2)
                        {
                            for (int i = coordinate.y1; i <= coordinate.y2; i++)
                            {
                                occurenceArray[coordinate.x1, i]++;
                            }
                        }
                        else
                        {
                            for (int i = coordinate.y2; i <= coordinate.y1; i++)
                            {
                                occurenceArray[coordinate.x1, i]++;
                            }
                        }

                    }

                    else if (coordinate.y1 == coordinate.y2)
                    {
                        if (coordinate.x1 < coordinate.x2)
                        {
                            for (int i = coordinate.x1; i <= coordinate.x2; i++)
                            {
                                occurenceArray[i, coordinate.y1]++;
                            }
                        }
                        else
                        {
                            for (int i = coordinate.x2; i <= coordinate.x1; i++)
                            {
                                occurenceArray[i, coordinate.y1]++;
                            }
                        }
                    }
                }

                int resultCouter = 0;

                foreach (var occurence in occurenceArray)
                {
                    if (occurence > 1)
                    {
                        resultCouter++;
                    }
                }


                Console.WriteLine("Result " + resultCouter);
            }
        }
    }
}
