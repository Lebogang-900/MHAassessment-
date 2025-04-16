using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MHAassessment
{
    public class DayNine
    {
        public static void DisplayOutput(string path)
        {
            string line = File.ReadAllText(path).Trim();
            int checksum = CalculateChecksum(line);
            Console.WriteLine("Day 9 - Part 1: " + checksum);
        }

        public static int CalculateChecksum(string diskMap)
        {
            List<char> disk = GetBuildDiskLayout(diskMap);
            GetCompactDisk(disk);
            return getCheckSum(disk);
        }

        private static List<char> GetBuildDiskLayout(string map)
        {
            List<char> layout = new List<char>();
            int fileId = 0;
            bool isFile = true;

            foreach (char c in map)
            {
                int length = c - '0';

                for (int i = 0; i < length; i++)
                {
                    if (isFile)
                    {
                        layout.Add((char)(fileId + '0'));
                    }
                    else
                    {
                        layout.Add('.');
                    }
                }

                if (isFile)
                    fileId++;

                isFile = !isFile;
            }

            return layout; // return the layout as a list of charecters
        }

        private static void GetCompactDisk(List<char> disk)
        {
            int target = 0;

            for (int i = 0; i < disk.Count; i++)
            {
                if (disk[i] != '.')
                {
                    if (i != target)
                    {
                        disk[target] = disk[i];
                        disk[i] = '.';
                    }
                    target++;
                }
            }
        }

        private static int getCheckSum(List<char> disk)
        {
            int checksum = 0;

            for (int i = 0; i < disk.Count; i++)
            {
                if (disk[i] != '.')
                {
                    int fileId = disk[i] - '0';
                    checksum += i * fileId;
                }
            }

            return checksum;
        }
    }
}
