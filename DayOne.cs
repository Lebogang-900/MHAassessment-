using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MHAassessment
{
    public class DayOne
    {
        public static void DisplayOutput(string filePath)
        {
            var (leftList, rightList) = ReadListsFromFile(filePath);
            int totalDistance = GetTotalDistance(leftList, rightList);
            int similarityScore = GetSimilarityScore(leftList, rightList);

            Console.WriteLine($"Day 1 - Part 1: Total distance = {totalDistance}");
            Console.WriteLine($"Day 1 - Part 2: Similarity score = {similarityScore}");
        }

        private static (List<int> leftList, List<int> rightList) ReadListsFromFile(string filePath)
        {
            var leftList = new List<int>();
            var rightList = new List<int>();

            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = Regex.Split(line.Trim(), @"\s{2,}"); // two or more spaces
                if (parts.Length == 2 &&
                    int.TryParse(parts[0], out int left) &&
                    int.TryParse(parts[1], out int right))
                {
                    leftList.Add(left);
                    rightList.Add(right);
                }
            }

            return (leftList, rightList);
        }

        private static int GetTotalDistance(List<int> leftList, List<int> rightList)
        {
            // Sort the lists
            leftList.Sort();
            rightList.Sort();

            // Calculate the total distance
            int totalDistance = 0;
            for (int i = 0; i < leftList.Count; i++)
            {
                totalDistance += Math.Abs(leftList[i] - rightList[i]);
            }

            return totalDistance;
        }


        private static int GetSimilarityScore(List<int> leftList, List<int> rightList)
        {
            // use a dictionary to count each number in the rightList
            var rightCountMap = new Dictionary<int, int>();
            foreach (var num in rightList)
            {
                if (rightCountMap.ContainsKey(num))
                    rightCountMap[num]++;
                else
                    rightCountMap[num] = 1;
            }

            // Calculate similarity score
            int similarityScore = 0;
            foreach (var num in leftList)
            {
                if (rightCountMap.ContainsKey(num))
                {
                    similarityScore += num * rightCountMap[num];
                }
            }

            return similarityScore;
        }

    }
}


