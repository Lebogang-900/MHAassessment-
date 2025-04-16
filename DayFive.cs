using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHAassessment
{
    public class DayFive
    {
        public static  void DisplayOutput(string path)
        {
            int total = GetTotalPart1(path);
            int total1 = GetTotalPart2(path);

            Console.WriteLine("Day 5 - Part 1: " + total);
            Console.WriteLine("Day 5 - Part 1: " + total1);
        }
        public static int GetTotalPart1(string path)
        {
            var lines = File.ReadAllLines(path);

            var rules = new List<(int before, int after)>();
            var updates = new List<List<int>>();

            // Read rules until a blank/space line is encountered
            int i = 0;
            for (; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i])) break;

                var parts = lines[i].Split('|');
                rules.Add((int.Parse(parts[0]), int.Parse(parts[1])));
            }

            // Read updates
            for (i = i + 1; i < lines.Length; i++)
            {
                var update = lines[i].Split(',').Select(int.Parse).ToList();
                updates.Add(update);
            }

            int total = 0;

            foreach (var update in updates)
            {
                bool isValid = true;

                foreach (var rule in rules)
                {
                    if (update.Contains(rule.before) && update.Contains(rule.after))
                    {
                        if (update.IndexOf(rule.before) >= update.IndexOf(rule.after))
                        {
                            isValid = false;
                            break;
                        }
                    }
                }

                if (isValid)
                {
                    int middle = update[update.Count / 2];
                    total += middle;
                }
            }

            return total;
        }

        public static int GetTotalPart2(string path)
        {
            var lines = File.ReadAllLines(path);

            var rules = new List<(int before, int after)>();
            var updates = new List<List<int>>();

            int i = 0;
            for (; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i])) break;

                var parts = lines[i].Split('|');
                rules.Add((int.Parse(parts[0]), int.Parse(parts[1])));
            }

            for (i = i + 1; i < lines.Length; i++)
            {
                var update = lines[i].Split(',').Select(int.Parse).ToList();
                updates.Add(update);
            }

            int total = 0;

            foreach (var update in updates)
            {
                bool isValid = true;

                foreach (var rule in rules)
                {
                    if (update.Contains(rule.before) && update.Contains(rule.after))
                    {
                        if (update.IndexOf(rule.before) >= update.IndexOf(rule.after))
                        {
                            isValid = false;
                            break;
                        }
                    }
                }

                if (!isValid)
                {
                    var pages = update.Distinct().ToList();
                    var dependencyCount = new Dictionary<int, int>();
                    var dependents = new Dictionary<int, List<int>>();

                    foreach (var page in pages)
                    {
                        dependencyCount[page] = 0;
                        dependents[page] = new List<int>();
                    }

                    foreach (var rule in rules)
                    {
                        if (pages.Contains(rule.before) && pages.Contains(rule.after))
                        {
                            dependencyCount[rule.after]++;
                            dependents[rule.before].Add(rule.after);
                        }
                    }

                    var queue = new Queue<int>(pages.Where(p => dependencyCount[p] == 0));
                    var sorted = new List<int>();

                    while (queue.Count > 0)
                    {
                        var current = queue.Dequeue();
                        sorted.Add(current);

                        foreach (var dependent in dependents[current])
                        {
                            dependencyCount[dependent]--;
                            if (dependencyCount[dependent] == 0)
                            {
                                queue.Enqueue(dependent);
                            }
                        }
                    }

                    if (sorted.Count == update.Count)
                    {
                        int middle = sorted[sorted.Count / 2];
                        total += middle;
                    }
                }
            }

            return total;
        }
    }
}
