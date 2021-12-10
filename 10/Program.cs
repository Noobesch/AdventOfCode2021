using System;
using System.Collections.Generic;
using System.IO;

namespace _10
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                string[] inputLines = sr.ReadToEnd().Split("\r\n");
                List<char[]> lineValues = new List<char[]>();

                foreach (var line in inputLines)
                {
                    lineValues.Add(line.ToCharArray());
                }

                long resultTaskA = 0;

                List<long> taskBResults = new List<long>();
                long resultTaskB = 0;

                foreach (var line in lineValues)
                {
                    long currentValueTaskA = 0;
                    long currentValueTaskB = 0;
                    Stack<char> characterStack = new Stack<char>();

                    foreach (var character in line)
                    {
                        switch (character)
                        {
                            case '(':
                            case '[':
                            case '{':
                            case '<':
                                characterStack.Push(character);
                                break;

                            case ')':
                                currentValueTaskA += ('(' == characterStack.Pop()) ? 0 : 3;
                                break;

                            case ']':
                                currentValueTaskA += ('[' == characterStack.Pop()) ? 0 : 57;
                                break;

                            case '}':
                                currentValueTaskA += ('{' == characterStack.Pop()) ? 0 : 1197;
                                break;

                            case '>':
                                currentValueTaskA += ('<' == characterStack.Pop()) ? 0 : 25137;
                                break;
                        }

                        if (currentValueTaskA != 0)
                        {
                            resultTaskA += currentValueTaskA;
                            break;
                        }
                    }

                    if (currentValueTaskA == 0)
                    {
                        while (characterStack.Count != 0)
                        {
                            switch (characterStack.Pop())
                            {
                                case '(':
                                    currentValueTaskB *= 5;
                                    currentValueTaskB += 1;
                                    break;

                                case '[':
                                    currentValueTaskB *= 5;
                                    currentValueTaskB += 2;
                                    break;

                                case '{':
                                    currentValueTaskB *= 5;
                                    currentValueTaskB += 3;
                                    break;

                                case '<':
                                    currentValueTaskB *= 5;
                                    currentValueTaskB += 4;
                                    break;
                            }
                        }

                        taskBResults.Add(currentValueTaskB);
                    }
                }

                taskBResults.Sort();
                resultTaskB = taskBResults[taskBResults.Count / 2];

                Console.WriteLine(resultTaskA);
                Console.WriteLine(resultTaskB);
            }
        }
    }
}
