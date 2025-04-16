using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace MHAassessment
{
    public class Program
    {
        static void Main(string[] args)
        {

            //display all the solutions on the console.

            Console.WriteLine("Day 1: Solution");
            DayOne.DisplayOutput("C:\\Users\\lebogangc\\source\\repos\\MHAassessment\\MHAassessment\\data1.txt");

            Console.WriteLine("\nDay 2: Solution");
            DayTwo.DisplayOutput("C:\\Users\\lebogangc\\source\\repos\\MHAassessment\\MHAassessment\\data2.txt");

            Console.WriteLine("\nDay 3: Solution");
            DayThree.DisplayOutput("C:\\Users\\lebogangc\\source\\repos\\MHAassessment\\MHAassessment\\data3.txt");

            Console.WriteLine("\nDay 4: Solution");
            DayFour.DisplayOutput("C:\\Users\\lebogangc\\source\\repos\\MHAassessment\\MHAassessment\\data4.txt");

            Console.WriteLine("\nDay 5: Solution");
            DayFive.DisplayOutput("C:\\Users\\lebogangc\\source\\repos\\MHAassessment\\MHAassessment\\data5.txt");

            string[] input = File.ReadAllLines("C:\\Users\\lebogangc\\source\\repos\\MHAassessment\\MHAassessment\\data6.txt");
            Console.WriteLine("\nDay 6 : Solution");
            DaySix.DisplayOutput(input);

            string[] input1 = File.ReadAllLines("C:\\Users\\lebogangc\\source\\repos\\MHAassessment\\MHAassessment\\data7.txt");
            Console.WriteLine("\nDay 7 : Solution");
            DaySeven.DisplayOutput(input1);

            string[] input2 = File.ReadAllLines("C:\\Users\\lebogangc\\source\\repos\\MHAassessment\\MHAassessment\\data8.txt");
            Console.WriteLine("\nDay 8 : Solution");
            DayEight.DisplayOutput(input2);

            Console.WriteLine("\nDay 9: Solution");
            DayNine.DisplayOutput("C:\\Users\\lebogangc\\source\\repos\\MHAassessment\\MHAassessment\\data9.txt");









        }

    }
}
