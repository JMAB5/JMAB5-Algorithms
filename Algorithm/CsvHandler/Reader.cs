using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static System.IO.File;
using static CsvHandler.Common;

namespace CsvHandler
{
    public static class Reader
    {
        public static int[] ImportNumbersFromCsv(string fileName)
            => ReadCsvLines(AtPathOf, fileName).ToIntArray();

        private static string[] ReadCsvLines(Func<string, string> fromFileAtPath, string name)
            => ReadAllLines(fromFileAtPath(name));
    }
}