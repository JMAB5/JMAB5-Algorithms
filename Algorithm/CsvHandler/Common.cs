using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.IO.Path;
using static System.Environment;

namespace CsvHandler
{
    internal static class Common
    {
        internal static string AtPathOf(string fileName)
            => GetFullPath(Combine(CurrentDirectory, fileName));
    }

    internal static class StringArrayExtensions
    {
        internal static int[] ToIntArray(this string[] lines)
            => lines.Select(line => int.Parse(line)).ToArray();
    }

    internal static class IntArrayExtensions
    {
        internal static string[] ToStringArray(this int[] numbers)
            => numbers.Select(n => n.ToString()).ToArray();
    }
}