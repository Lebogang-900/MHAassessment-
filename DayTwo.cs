using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHAassessment
{
    public class DayTwo
    {

        public static void DisplayOutput(string filePath)
        {
            var reports = File.ReadAllLines(filePath);
            int part1SafeCount = reports.Count(IsSafeReport);
            int part2SafeCount = reports.Count(IsSafeWithDampener);

            Console.WriteLine($"Day 2 - Part 1: Safe Reports = {part1SafeCount}");
            Console.WriteLine($"Day 2 - Part 2: Safe Reports with Problem Dampener = {part2SafeCount}");
        }

        private static bool IsSafeReport(string line)
        {
            var levels = line.Trim().Split(' ').Select(int.Parse).ToArray();
            return IsStrictlySafe(levels);
        }

        private static bool IsStrictlySafe(int[] levels)
        {
            bool isIncreasing = true, isDecreasing = true;

            for (int i = 0; i < levels.Length - 1; i++)
            {
                int difference = levels[i + 1] - levels[i];

                if (difference == 0 || Math.Abs(difference) > 3)
                   
                    return false;

                if (difference < 0) isIncreasing = false;

                if (difference > 0) isDecreasing = false;
            }

            return isIncreasing || isDecreasing;
        }

        private static bool IsSafeWithDampener(string line)
        {
            var levels = line.Trim().Split(' ').Select(int.Parse).ToList();

            if (IsStrictlySafe(levels.ToArray()))
                return true;

            // remove each level one by one
            for (int i = 0; i < levels.Count; i++)
            {
                var modified = new List<int>(levels);
                modified.RemoveAt(i); //remove based on the index/position

                if (IsStrictlySafe(modified.ToArray()))
                    return true;
            }

            return false;
        }
    }
}
