using System;

namespace T10.Srsp;

public static class Program
{
    private static int _total;
    private static int _failed;

    public static int Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        TestBubbleSort();
        Console.WriteLine();
        TestSortedThousand();
        Console.WriteLine();
        TestCountOccurrences();

        Console.WriteLine();
        Console.WriteLine($"Всего проверок: {_total}, FAIL: {_failed}");
        return _failed == 0 ? 0 : 1;
    }

    private static void TestBubbleSort()
    {
        Console.WriteLine("BubbleSort");
        Console.WriteLine("До | После | IsSorted до/после | Сравнений (факт/ожид.) | Результат");
        Console.WriteLine(new string('-', 90));

        int[][] inputs =
        {
            new int[] { },
            new int[] { 5 },
            new int[] { 1, 2, 3, 4, 5 },
            new int[] { 5, 4, 3, 2, 1 },
            new int[] { 3, 1, 3, 2, 3 }
        };

        int[][] expectedArrays =
        {
            new int[] { },
            new int[] { 5 },
            new int[] { 1, 2, 3, 4, 5 },
            new int[] { 1, 2, 3, 4, 5 },
            new int[] { 1, 2, 3, 3, 3 }
        };

        // Ожидаемое число сравнений посчитано вручную (с ранним выходом).
        int[] expectedComparisons = { 0, 0, 4, 10, 9 };

        for (int i = 0; i < inputs.Length; i++)
        {
            int[] a = inputs[i];
            string before = Format(a);
            bool sortedBefore = ArrayAlgos.IsSorted(a);

            int comparisons = ArrayAlgos.BubbleSort(a);

            string after = Format(a);
            bool sortedAfter = ArrayAlgos.IsSorted(a);

            bool ok = comparisons == expectedComparisons[i]
                      && sortedAfter
                      && SameArray(a, expectedArrays[i]);

            Report(ok, $"{before} | {after} | {sortedBefore}/{sortedAfter} | {comparisons}/{expectedComparisons[i]}");
        }
    }

    private static void TestSortedThousand()
    {
        Console.WriteLine("BubbleSort на отсортированном массиве из 1000 элементов");

        int[] a = new int[1000];
        for (int i = 0; i < a.Length; i++)
        {
            a[i] = i;
        }

        int comparisons = ArrayAlgos.BubbleSort(a);
        bool ok = comparisons == 999 && ArrayAlgos.IsSorted(a);

        Report(ok, $"n = 1000 | IsSorted = {ArrayAlgos.IsSorted(a)} | сравнений: {comparisons}/999");
    }

    private static void TestCountOccurrences()
    {
        Console.WriteLine("CountOccurrences, a = {1, 2, 2, 2, 5, 7}");
        Console.WriteLine("x | Ожидаемое | Фактическое | Результат");
        Console.WriteLine(new string('-', 50));

        int[] a = { 1, 2, 2, 2, 5, 7 };
        int[] xs = { 2, 1, 7, 3, 9 };
        int[] expected = { 3, 1, 1, 0, 0 };

        for (int i = 0; i < xs.Length; i++)
        {
            int actual = ArrayAlgos.CountOccurrences(a, xs[i]);
            Report(actual == expected[i], $"x = {xs[i]} | {expected[i]} | {actual}");
        }

        Console.WriteLine("Дополнительно:");
        Report(ArrayAlgos.CountOccurrences(new int[] { }, 1) == 0, "пустой массив, x = 1 | 0 | " + ArrayAlgos.CountOccurrences(new int[] { }, 1));
        Report(ArrayAlgos.CountOccurrences(new int[] { 4, 4, 4, 4 }, 4) == 4, "{4, 4, 4, 4}, x = 4 | 4 | " + ArrayAlgos.CountOccurrences(new int[] { 4, 4, 4, 4 }, 4));
        Report(ArrayAlgos.CountOccurrences(a, 0) == 0, "x = 0 (меньше всех) | 0 | " + ArrayAlgos.CountOccurrences(a, 0));
    }

    private static void Report(bool ok, string text)
    {
        _total++;
        if (!ok)
        {
            _failed++;
        }

        Console.WriteLine($"{text} | {(ok ? "OK" : "FAIL")}");
    }

    private static string Format(int[] a) => "{" + string.Join(", ", a) + "}";

    private static bool SameArray(int[] x, int[] y)
    {
        if (x.Length != y.Length)
        {
            return false;
        }

        for (int i = 0; i < x.Length; i++)
        {
            if (x[i] != y[i])
            {
                return false;
            }
        }

        return true;
    }
}
