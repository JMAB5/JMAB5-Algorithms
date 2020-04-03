using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static CsvHandler.Common;
using static System.IO.File;

namespace CsvHandler
{
    public static class Writer
    {
        public static void ExportNumbersToCsv(string fileName, int[] numbers)
            => WriteCsvLines(AtPathOf, fileName, numbers.ToStringArray());

        private static void WriteCsvLines(Func<string, string> toPath, string name, string[] lines)
            => WriteAllLines(toPath(name), lines);
    }
}