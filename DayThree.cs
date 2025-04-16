using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHAassessment
{
    public class DayThree
    {
        public static void DisplayOutput(string path)
        {
           
            int totalmultiplications = TotalFromMultiplications(path);
            int totalOfEnabledMmultiplications = TotalFromEnabledMultiplications(path);
            Console.WriteLine($"Day 3 - Part 1: Total from valid multiplications: {totalmultiplications}");
            Console.WriteLine($"Day 3 - Part 2: Total from enabled multiplications: {totalOfEnabledMmultiplications}");


        }
        public static int TotalFromMultiplications(string filePath)
        {
            string contentOfFile = File.ReadAllText(filePath);
            int totalmultiplications = 0;

            for (int i = 0; i < contentOfFile.Length - 7; i++)
            {
                // Check for pattern starting with "mul("
                if (contentOfFile[i] == 'm' && contentOfFile[i + 1] == 'u' && contentOfFile[i + 2] == 'l' && contentOfFile[i + 3] == '(')
                {
                    int j = i + 4;
                    string firstNum = "";
                    string secondNum = "";

                    // Read first number
                    while (j < contentOfFile.Length && char.IsDigit(contentOfFile[j]))
                    {
                        firstNum += contentOfFile[j];
                        j++;
                    }

                    // comma
                    if (j < contentOfFile.Length && contentOfFile[j] == ',')
                    {
                        j++;
                    }
                    else
                    {
                        continue;
                    }

                    // Read second number
                    while (j < contentOfFile.Length && char.IsDigit(contentOfFile[j]))
                    {
                        secondNum += contentOfFile[j];
                        j++;
                    }

                    // closing parenthesis
                    if (j < contentOfFile.Length && contentOfFile[j] == ')')
                    {
                        // Try to parse and multiply
                        if (int.TryParse(firstNum, out int a) && int.TryParse(secondNum, out int b))
                        {
                            totalmultiplications += a * b;
                        }
                    }
                }
            }
           return totalmultiplications;  
        }
        public static int TotalFromEnabledMultiplications(string filePath)
        {
            string contentOfFile = File.ReadAllText(filePath);
            int totalOfEnabledMmultiplications = 0;
            bool isEnabled = true;

            for (int i = 0; i < contentOfFile.Length - 3; i++)
            {
                // Check for do()
                if (i + 4 <= contentOfFile.Length && contentOfFile.Substring(i, 4) == "do()")
                {
                    isEnabled = true;
                    continue;
                }

                // Check for don't()
                if (i + 7 <= contentOfFile.Length && contentOfFile.Substring(i, 7) == "don't()")
                {
                    isEnabled = false;
                    continue;
                }

                // Check for mul(X,Y)
                if (i + 4 <= contentOfFile.Length && contentOfFile.Substring(i, 4) == "mul(")
                {
                    int j = i + 4;
                    string firstNum = "";
                    string secondNum = "";

                    while (j < contentOfFile.Length && char.IsDigit(contentOfFile[j]))
                    {
                        firstNum += contentOfFile[j];
                        j++;
                    }

                    if (j < contentOfFile.Length && contentOfFile[j] == ',')
                    {
                        j++;
                    }
                    else
                    {
                        continue;
                    }

                    while (j < contentOfFile.Length && char.IsDigit(contentOfFile[j]))
                    {
                        secondNum += contentOfFile[j];
                        j++;
                    }

                    if (j < contentOfFile.Length && contentOfFile[j] == ')')
                    {
                        if (int.TryParse(firstNum, out int a) && int.TryParse(secondNum, out int b))
                        {
                            if (isEnabled)
                            {
                                totalOfEnabledMmultiplications += a * b;
                            }
                        }
                    }
                }
            }

            return totalOfEnabledMmultiplications;
        }

    }
}
