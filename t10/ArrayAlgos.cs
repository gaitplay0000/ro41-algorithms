namespace T10.Srsp;

/// <summary>
/// Алгоритмы для массивов int. Без Array.Sort, Array.BinarySearch и LINQ.
/// null трактуется как пустой массив (исключений методы не бросают).
/// </summary>
public static class ArrayAlgos
{
    /// <summary>
    /// Проверяет, что массив отсортирован по возрастанию (нестрого: равные соседи допустимы).
    /// Пустой массив и массив из одного элемента отсортированы.
    /// </summary>
    public static bool IsSorted(int[]? a)
    {
        if (a == null)
        {
            return true;
        }

        for (int i = 1; i < a.Length; i++)
        {
            if (a[i - 1] > a[i])
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Сортировка пузырьком на месте с флажком раннего выхода.
    /// Возвращает число сравнений элементов.
    /// </summary>
    public static int BubbleSort(int[]? a)
    {
        if (a == null)
        {
            return 0;
        }

        int comparisons = 0;

        for (int pass = 0; pass < a.Length - 1; pass++)
        {
            bool swapped = false;

            // После pass проходов последние pass элементов уже на своих местах.
            for (int j = 0; j < a.Length - 1 - pass; j++)
            {
                comparisons++;

                if (a[j] > a[j + 1])
                {
                    int tmp = a[j];
                    a[j] = a[j + 1];
                    a[j + 1] = tmp;
                    swapped = true;
                }
            }

            if (!swapped)
            {
                break;   // за проход не было обменов: массив уже отсортирован
            }
        }

        return comparisons;
    }

    /// <summary>
    /// Количество вхождений x в отсортированном массиве: UpperBound(x) - LowerBound(x).
    /// Два бинарных поиска, O(log n), без прохода по всему массиву.
    /// </summary>
    public static int CountOccurrences(int[]? sortedA, int x)
    {
        if (sortedA == null || sortedA.Length == 0)
        {
            return 0;
        }

        return UpperBound(sortedA, x) - LowerBound(sortedA, x);
    }

    /// <summary>Первый индекс i, для которого a[i] &gt;= x (или a.Length, если такого нет).</summary>
    private static int LowerBound(int[] a, int x)
    {
        int lo = 0;
        int hi = a.Length;   // полуинтервал [lo, hi)

        while (lo < hi)
        {
            int mid = lo + (hi - lo) / 2;

            if (a[mid] < x)
            {
                lo = mid + 1;
            }
            else
            {
                hi = mid;
            }
        }

        return lo;
    }

    /// <summary>Первый индекс i, для которого a[i] &gt; x (или a.Length, если такого нет).</summary>
    private static int UpperBound(int[] a, int x)
    {
        int lo = 0;
        int hi = a.Length;   // полуинтервал [lo, hi)

        while (lo < hi)
        {
            int mid = lo + (hi - lo) / 2;

            if (a[mid] <= x)
            {
                lo = mid + 1;
            }
            else
            {
                hi = mid;
            }
        }

        return lo;
    }
}
