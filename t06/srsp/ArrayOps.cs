using System;

namespace ArrayOperations
{
    public static class ArrayOps
    {
        /// <summary>Сумма элементов массива (для пустого массива — 0).</summary>
        public static int Sum(int[] a)
        {
            if (a == null) throw new ArgumentNullException(nameof(a));

            int sum = 0;
            for (int i = 0; i < a.Length; i++)
                sum += a[i];
            return sum;
        }

        /// <summary>Индекс первого минимального элемента.</summary>
        public static int IndexOfMin(int[] a)
        {
            if (a == null) throw new ArgumentNullException(nameof(a));
            if (a.Length == 0)
                throw new ArgumentException("Массив не должен быть пустым.", nameof(a));

            // Начальное значение берётся из массива: первый элемент — кандидат на минимум.
            int minIndex = 0;
            for (int i = 1; i < a.Length; i++)
            {
                // Строгое сравнение: при равных значениях остаётся первый индекс.
                if (a[i] < a[minIndex])
                    minIndex = i;
            }
            return minIndex;
        }

        /// <summary>Количество элементов, строго больших x.</summary>
        public static int CountGreater(int[] a, int x)
        {
            if (a == null) throw new ArgumentNullException(nameof(a));

            int count = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > x)
                    count++;
            }
            return count;
        }

        /// <summary>Разворачивает массив на месте (обмен a[i] и a[n - 1 - i]).</summary>
        public static void Reverse(int[] a)
        {
            if (a == null) throw new ArgumentNullException(nameof(a));

            int n = a.Length;
            // Достаточно дойти до середины: каждый обмен ставит на место сразу два элемента.
            for (int i = 0; i < n / 2; i++)
            {
                int tmp = a[i];
                a[i] = a[n - 1 - i];
                a[n - 1 - i] = tmp;
            }
        }
    }
}
