using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHAassessment
{
    public class DaySeven
    {
        public static void DisplayOutput(string[] input)
        {
            long result = GetTotal(input);
            Console.WriteLine("Day 7 - Part 1: " + result);
        }

        public static long GetTotal(string[] input)
        {
            // use long to store larger numbers.
            long total = 0;

            //loop through the input, split and trim the parts
            foreach (string line in input)
            {
                string[] parts = line.Split(':');
                long target = long.Parse(parts[0].Trim());
                string[] numberStrings = parts[1].Trim().Split(' ');
                List<long> numbers = new List<long>();

                foreach (string n in numberStrings)
                {
                    if (!string.IsNullOrWhiteSpace(n))
                        numbers.Add(long.Parse(n));
                }

                if (CanEvaluateToTarget(numbers, target))
                    total += target;
            }

            return total;
        }

        private static bool CanEvaluateToTarget(List<long> numbers, long target)
        {
            int numOps = numbers.Count - 1;
            int totalCombinations = 1 << numOps;

            for (int mask = 0; mask < totalCombinations; mask++)
            {
                long result = numbers[0];

                for (int i = 0; i < numOps; i++)
                {
                    if (((mask >> i) & 1) == 0)
                    {
                        result += numbers[i + 1];
                    }
                    else
                    {
                        result *= numbers[i + 1];
                    }
                }

                if (result == target)
                    return true;
            }

            return false;
        }
    }

}


