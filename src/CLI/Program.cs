using System;
using Frequency;

namespace CLI
{
    /// <summary>
    /// Entry point.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry point.
        /// </summary>
        /// <param name="args">The arguments from CLI.</param>
        static void Main(string[] args)
        {
            var freq = new TextFrequency();
            var sum = 0;
            foreach (var arg in args)   // treat all args as 1 string
            {
                freq.AddString(arg);
                sum += arg.Length;
            }
            sum += args.Length - 1;     // count spaces between args
            ShowData(freq, sum, sum - freq.CharacterCount);
        }

        /// <summary>
        /// Shows data to console.
        /// </summary>
        /// <param name="freq">The character frequency map.</param>
        /// <param name="sum">Sum of all characters.</param>
        /// <param name="unused">Sum of unused characters.</param>
        static void ShowData(TextFrequency freq, int sum, int unused)
        {
            foreach (var c in freq.CharacterMap)
                PrintData(c.Key.ToString(), c.Value, Math.Round(c.Value / (double)sum * 100, 2));

            if (unused > 0)     // print unused characters
                PrintData("Unused", unused, Math.Round(unused / (double)sum * 100, 2));
        }

        /// <summary>
        /// Prints data to console in pretty graphs.
        /// </summary>
        /// <param name="str">The string or character to print.</param>
        /// <param name="count">The count of character.</param>
        /// <param name="percent">The occurrance percentage of character.</param>
        static void PrintData(string str, int count, double percent)
        {
            Console.WriteLine($"{str, 6}: {count, 4} ({percent + "%", 6}) [{new string('=', (int)percent)}]");
        }
    }
}
