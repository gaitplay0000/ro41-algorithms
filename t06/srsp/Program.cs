using System;
using ArrayOperations;

namespace ArrayOperations
{
    internal static class Program
    {
        private const int X = 2;

        private static string Format(int[] a)
        {
            return "{" + string.Join(", ", a) + "}";
        }

        private static void Main()
        {
            int[][] tests =
            {
                new[] { 4, 1, 7, 3, 9 },
                new[] { 5 },
                new[] { -2, -7, -4 },
                new[] { 2, 2, 2 }
            };

            foreach (int[] a in tests)
            {
                Console.WriteLine($"Массив: {Format(a)}");
                Console.WriteLine($"  Sum = {ArrayOps.Sum(a)}");
                Console.WriteLine($"  IndexOfMin = {ArrayOps.IndexOfMin(a)}");
                Console.WriteLine($"  CountGreater(x = {X}) = {ArrayOps.CountGreater(a, X)}");

                // Reverse выполняется последним: он меняет сам массив.
                ArrayOps.Reverse(a);
                Console.WriteLine($"  После Reverse: {Format(a)}");
                Console.WriteLine();
            }
        }
    }
}
