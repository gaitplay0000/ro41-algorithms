namespace Recursion;

public static class Rec
{
    /// <summary>
    /// Сумма цифр неотрицательного числа.
    /// </summary>
    public static int DigitSum(int n)
    {
        if (n < 0)
            throw new ArgumentOutOfRangeException(nameof(n), "n должно быть неотрицательным.");

        // БАЗОВЫЙ СЛУЧАЙ: однозначное число (0..9) — сумма цифр равна самому числу.
        if (n < 10)
            return n;

        // ШАГ РЕКУРСИИ: последняя цифра + сумма цифр числа без последней цифры.
        return n % 10 + DigitSum(n / 10);
    }

    /// <summary>
    /// Возведение x в целую неотрицательную степень n без Math.Pow.
    /// </summary>
    public static long Pow(int x, int n)
    {
        if (n < 0)
            throw new ArgumentOutOfRangeException(nameof(n), "n должно быть >= 0.");

        // БАЗОВЫЙ СЛУЧАЙ: любое число в степени 0 равно 1.
        if (n == 0)
            return 1;

        // ШАГ РЕКУРСИИ: x^n = x * x^(n-1).
        return x * Pow(x, n - 1);
    }
}
