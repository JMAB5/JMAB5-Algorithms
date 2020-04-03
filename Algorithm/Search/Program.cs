using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using static CsvHandler.Reader;
using static System.Console;

namespace Search
{
    internal struct Result
    {
        string Type;
        int Target;
        int FoundAtIndex;
        long ElapsedTicks;
        internal Result(string type, int target, int foundAtIndex, long elapsedTicks)
        {
            Type = type;
            Target = target;
            FoundAtIndex = foundAtIndex;
            ElapsedTicks = elapsedTicks;
        }

        public override string ToString()
        {
            return $"{Type} search found {Target} at index {FoundAtIndex} in {ElapsedTicks} ticks";
        }
    }

    class Program
    {
        static readonly string sortedFile = @"sorted_numbers.csv";

        static void Main(string[] args)
        {
            // Input
            var sorted = ImportNumbersFromCsv(sortedFile);
            var indexes = new int[] { 1499, 2999, 4499, 5999, 7499, 8999, 10499, 11999, 13499, 14999 };
            var targets = indexes.Select(i => sorted[i]);

            // Computation
            var results = targets.Select(t =>
            {
                var linear = RunLinearSearch(sorted, t);
                var binary = RunBinarySearch(sorted, t);
                return (Linear: linear, Binary: binary);
            }).ToList();

            // Output
            results.ForEach(result
                => WriteLine($"{result.Linear.ToString()}\n{result.Binary.ToString()}\n"));

            ReadKey();
        }

        // Wrapper for Linear search
        static Result RunLinearSearch(int[] array, int target)
        {
            var stopwatch = Stopwatch.StartNew();
            var foundAtIndex = LinearSearch(0, array, target);
            stopwatch.Stop();
            return new Result("Linear", target, foundAtIndex, stopwatch.ElapsedTicks);
        }

        // Wrapper for Binary search
        static Result RunBinarySearch(int[] array, int target)
        {
            var stopwatch = Stopwatch.StartNew();
            var foundAtIndex = BinarySearch(array, 0, array.Length - 1, target);
            stopwatch.Stop();
            return new Result("Binary", target, foundAtIndex, stopwatch.ElapsedTicks);
        }

        // The Linear search algorithm
        static int LinearSearch(int index, int[] array, int number)
        {
            if (index == array.Length)
                return -1;
            if (array[index] == number)
                return index;

            return LinearSearch(++index, array, number);
        }

        // The Binary search algorithm
        static int BinarySearch(int[] array, int left, int right, int number)
        {
            if (left > right)
                return -1;

            int mid = (left + right) / 2;

            if (array[mid] == number)
                return mid;

            if (array[mid] > number)
                return BinarySearch(array, left, mid - 1, number);

            return BinarySearch(array, mid + 1, right, number);
        }
    }
}
