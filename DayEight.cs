using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHAassessment
{
    public class DayEight
    {
        public static void DisplayOutput(string[] input)
        {
            int result = GetantinodesCount(input);
            Console.WriteLine("Day 8 - Part 1: " + result);
        }

        public static int GetantinodesCount(string[] input)
        {
            int rows = input.Length;
            int cols = input[0].Length;

            // Collect all antenna positions by frequency. create a Dictionary for storing the input
            Dictionary<char, List<(int r, int c)>> antennas = new Dictionary<char, List<(int, int)>>();

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    char ch = input[r][c];
                    if (char.IsLetterOrDigit(ch))
                    {
                        if (!antennas.ContainsKey(ch))
                            antennas[ch] = new List<(int, int)>();
                        antennas[ch].Add((r, c));
                    }
                }
            }

            // Set to store unique antinodes
            HashSet<(int, int)> antinodes = new HashSet<(int, int)>();

            // For each frequency, find valid antinodes
            foreach (var pair in antennas)
            {
                var positions = pair.Value;
                int n = positions.Count;

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (i == j) continue;

                        int r1 = positions[i].r;
                        int c1 = positions[i].c;
                        int r2 = positions[j].r;
                        int c2 = positions[j].c;

                        int dr = r2 - r1;
                        int dc = c2 - c1;

                        // Antinode is in the direction of (dr, dc) from r2,c2
                        int r3 = r2 + dr;  // So check if r2 - r1 == 2*(r1 - r0) -> r0 = r2 - dr
                        int c3 = c2 + dc;

                        if (IsInside(r3, c3, rows, cols))
                            antinodes.Add((r3, c3));

                        // Other side
                        int r0 = r1 - dr;
                        int c0 = c1 - dc;

                        if (IsInside(r0, c0, rows, cols))
                            antinodes.Add((r0, c0));
                    }
                }
            }
            int antinodesCount = antinodes.Count;

            return antinodesCount;
        }

        private static bool IsInside(int r, int c, int rows, int cols)
        {
            return r >= 0 && r < rows && c >= 0 && c < cols;
        }
    }
}
