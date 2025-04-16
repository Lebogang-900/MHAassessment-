using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHAassessment
{
    public class DaySix
    {
        public static void DisplayOutput(string[] path)
        {
            int count = GetCountPart1(path);
            int count1 = GetloopCountPart2(path);


            Console.WriteLine("Day 6 - Part 1: " + count);
            Console.WriteLine("Day 6 - Part 2: " + count1);
        }

        public static int GetCountPart1(string[] input)
        {
            int rows = input.Length;
            int cols = input[0].Length;
            bool[,] visited = new bool[rows, cols];

            (int row, int col) = FindGuard(input);
            char dir = input[row][col]; // '^', '<', 'v', '>'
            visited[row, col] = true;

            int direction = "^>v<".IndexOf(dir);
            int[] dr = { -1, 0, 1, 0 };
            int[] dc = { 0, 1, 0, -1 };

            while (true)
            {
                int newRow = row + dr[direction];
                int newCol = col + dc[direction];

                if (newRow < 0 || newRow >= rows || newCol < 0 || newCol >= cols)
                    break;

                if (input[newRow][newCol] == '#')
                {
                    direction = (direction + 1) % 4; // Turn right
                }
                else
                {
                    row = newRow;
                    col = newCol;
                    visited[row, col] = true;
                }
            }

            int count = 0;
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    if (visited[r, c])
                        count++;

            return count;
        }

        public static int GetloopCountPart2(string[] input)
        {
            int rows = input.Length;
            int cols = input[0].Length;
            int loopCount = 0;

            (int guardRow, int guardCol) = FindGuard(input);

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (input[r][c] == '#' || (r == guardRow && c == guardCol))
                        continue;

                    string[] modifiedMap = (string[])input.Clone();
                    char[] line = modifiedMap[r].ToCharArray();
                    line[c] = '#';
                    modifiedMap[r] = new string(line);

                    if (WouldLoop(modifiedMap))
                        loopCount++;
                }
            }

            return loopCount;
        }

        private static bool WouldLoop(string[] input)
        {

            int rows = input.Length;
            int cols = input[0].Length;
            HashSet<(int, int, int)> seen = new HashSet<(int, int, int)>();

            (int row, int col) = FindGuard(input);
            char dirChar = input[row][col];
            int direction = "^>v<".IndexOf(dirChar);
            int[] dr = { -1, 0, 1, 0 };
            int[] dc = { 0, 1, 0, -1 };

            while (true)
            {
                if (row < 0 || row >= rows || col < 0 || col >= cols)
                    return false;

                if (seen.Contains((row, col, direction)))
                    return true;

                seen.Add((row, col, direction));

                int newRow = row + dr[direction];
                int newCol = col + dc[direction];

                if (newRow < 0 || newRow >= rows || newCol < 0 || newCol >= cols)
                    return false;

                if (input[newRow][newCol] == '#')
                {
                    direction = (direction + 1) % 4;
                }
                else
                {
                    row = newRow;
                    col = newCol;
                }
            }
        }

        private static (int row, int col) FindGuard(string[] input)
        {
            for (int r = 0; r < input.Length; r++)
            {
                for (int c = 0; c < input[r].Length; c++)
                {
                    if ("^v<>".Contains(input[r][c]))
                        return (r, c);
                }
            }
            throw new Exception("Guard not found"); // throw an exception
        }
    }
}
