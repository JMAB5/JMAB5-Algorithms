using System;
using static CsvHandler.Reader;
using static CsvHandler.Writer;

namespace InsertionSort
{
    class Program
    {
        static readonly string importFile = @"unsorted_numbers.csv";
        static readonly string exportFile = @"sorted_numbers.csv";
        static void Main(string[] args)
        {
            // Input
            var numbers = ImportNumbersFromCsv(importFile);

            // Computation
            InsertionSort(numbers);

            // Output
            ExportNumbersToCsv(exportFile, numbers);
            Console.WriteLine("...done!");
            Console.ReadKey();
        }

        static void InsertionSort(int[] array)
        {
            int length = array.Length;

            // Outer loop
            for (int outerIndex = 1; outerIndex < length; outerIndex++)
            {
                int innerIndex = outerIndex - 1;
                int number = array[outerIndex];

                // Inner loop
                while (innerIndex >= 0
                      && number < array[innerIndex])
                {
                    array[innerIndex + 1] = array[innerIndex];
                    innerIndex--;
                }

                // Insertion
                array[innerIndex + 1] = number;
            }
        }
    }
}