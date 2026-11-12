using System;
using T08.Srsp;

namespace T08.Srsp;

public static class Program
{
    private static int _total;
    private static int _failed;

    public static int Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string[] inputs =
        {
            "",
            "   ",
            " a  b ",
            "А роза упала на лапу Азора",
            "Ахметов Ерлан"
        };

        int[] words = { 0, 0, 2, 6, 2 };
        bool[] palindromes = { true, true, false, true, false };
        string[] initials = { "", "", "A. B.", "А. Р. У. Н. Л. А.", "А. Е." };

        Console.WriteLine("Метод | Вход | Ожидаемое | Фактическое | Результат");
        Console.WriteLine(new string('-', 78));

        for (int i = 0; i < inputs.Length; i++)
        {
            Check("CountWords", inputs[i], words[i].ToString(), TextTools.CountWords(inputs[i]).ToString());
            Check("IsPalindrome", inputs[i], palindromes[i].ToString(), TextTools.IsPalindrome(inputs[i]).ToString());
            Check("Initials", inputs[i], Q(initials[i]), Q(TextTools.Initials(inputs[i])));

            // Ожидаемое для Repeat(s, 2) строим простой конкатенацией s + s.
            Check("Repeat(s, 2)", inputs[i], Q(inputs[i] + inputs[i]), Q(TextTools.Repeat(inputs[i], 2)));
        }

        Console.WriteLine();
        Console.WriteLine("Дополнительно (граничные случаи):");
        Check("Repeat(\"ab\", 3)", "ab", Q("ababab"), Q(TextTools.Repeat("ab", 3)));
        Check("Repeat(\"ab\", 0)", "ab", Q(""), Q(TextTools.Repeat("ab", 0)));
        Check("Repeat(\"ab\", -1)", "ab", Q(""), Q(TextTools.Repeat("ab", -1)));
        Check("CountWords(null)", "null", "0", TextTools.CountWords(null).ToString());
        Check("IsPalindrome(null)", "null", "True", TextTools.IsPalindrome(null).ToString());
        Check("Initials(null)", "null", Q(""), Q(TextTools.Initials(null)));
        Check("Initials(3 слова)", "Ахметов Ерлан Серикұлы", Q("А. Е. С."), Q(TextTools.Initials("Ахметов Ерлан Серикұлы")));
        Check("CountWords(таб/перенос)", "a\tb\nc", "3", TextTools.CountWords("a\tb\nc").ToString());

        Console.WriteLine();
        Console.WriteLine($"Всего проверок: {_total}, FAIL: {_failed}");
        return _failed == 0 ? 0 : 1;
    }

    private static string Q(string s) => "\"" + s + "\"";

    private static void Check(string method, string input, string expected, string actual)
    {
        _total++;
        bool ok = expected == actual;
        if (!ok)
        {
            _failed++;
        }

        Console.WriteLine($"{method} | {Q(input)} | {expected} | {actual} | {(ok ? "OK" : "FAIL")}");
    }
}
