using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHAassessment
{
    public class DayFour
    {
        //set read only values to be used.
        private static readonly string WordToFind = "XMAS";
        private static readonly (int, int)[] Directions =   {
        (-1, 0), (1, 0), // vertical: up, down
        (0, -1), (0, 1), // horizontal: left, right
        (-1, -1), (-1, 1), // diagonal: up-left, up-right
        (1, -1), (1, 1) // diagonal: down-left, down-right
        };

        public static void DisplayOutput(string path)
        {
            int resultDay4Part1 = getCountOccurrences(path);
            int resultDay4Part2 = GetCount(path);

            //display
            Console.WriteLine("Day 4 - Part 1: " + resultDay4Part1);
            Console.WriteLine("Day 4 - Part 2: " + resultDay4Part2);
        }
        public static int getCountOccurrences(string path)
        {
            string[] lines = File.ReadAllLines(path);
            char[,] grid = new char[lines.Length, lines[0].Length];

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    grid[i, j] = lines[i][j];
                }
            }

            int output = CountOccurrences(grid, WordToFind);

            return output;
        }

        private static int CountOccurrences(char[,] grid, string word)
        {
            int count = 0;
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    foreach (var (dr, dc) in Directions)
                    {
                        if (CheckWord(grid, word, r, c, dr, dc))
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        private static bool CheckWord(char[,] grid, string word, int row, int col, int dr, int dc)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            for (int i = 0; i < word.Length; i++)
            {
                int nr = row + dr * i;
                int nc = col + dc * i;

                if (nr < 0 || nr >= rows || nc < 0 || nc >= cols)
                    return false;

                if (grid[nr, nc] != word[i])
                    return false;
            }

            return true;
        }
        public static int GetCount(string filePath)
        {
            string[] localGrid = File.ReadAllLines(filePath);
            int count = 0;
            int rows = localGrid.Length;
            int cols = localGrid[0].Length;

            for (int r = 1; r < rows - 1; r++)
            {
                for (int c = 1; c < cols - 1; c++)
                {
                    char nw = localGrid[r - 1][c - 1];
                    char ne = localGrid[r - 1][c + 1];
                    char sw = localGrid[r + 1][c - 1];
                    char se = localGrid[r + 1][c + 1];
                    char mid = localGrid[r][c];

                    if (IsMAS(nw, mid, se) && IsMAS(sw, mid, ne))
                        count++;
                }
            }

            return count;
        }

        public static bool IsMAS(char a, char b, char c)
        {
            string str = $"{a}{b}{c}";
            return str == "MAS" || str == "SAM";  //return mas or sam
        }
    }
}
