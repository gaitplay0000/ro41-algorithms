using System.Text;

namespace T08.Srsp;

/// <summary>
/// Набор методов для работы со строками. Без Regex и LINQ.
/// Все методы безопасны для null, "" и строк из пробелов (исключений не бросают).
/// </summary>
public static class TextTools
{
    /// <summary>Количество слов; слова разделены одним или несколькими пробельными символами.</summary>
    public static int CountWords(string? s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return 0;
        }

        int count = 0;
        bool inWord = false;

        for (int i = 0; i < s.Length; i++)
        {
            if (char.IsWhiteSpace(s[i]))
            {
                inWord = false;
            }
            else if (!inWord)
            {
                inWord = true;   // начало нового слова
                count++;
            }
        }

        return count;
    }

    /// <summary>
    /// Палиндром без учёта регистра и пробельных символов.
    /// Пустая строка и строка из пробелов считаются палиндромами (нечего сравнивать).
    /// </summary>
    public static bool IsPalindrome(string? s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return true;
        }

        int left = 0;
        int right = s.Length - 1;

        while (left < right)
        {
            if (char.IsWhiteSpace(s[left]))
            {
                left++;
                continue;
            }

            if (char.IsWhiteSpace(s[right]))
            {
                right--;
                continue;
            }

            if (char.ToLowerInvariant(s[left]) != char.ToLowerInvariant(s[right]))
            {
                return false;
            }

            left++;
            right--;
        }

        return true;
    }

    /// <summary>"Ахметов Ерлан Серикұлы" → "А. Е. С."; для пустой строки возвращает "".</summary>
    public static string Initials(string? fullName)
    {
        if (string.IsNullOrEmpty(fullName))
        {
            return "";
        }

        var sb = new StringBuilder();
        bool inWord = false;

        for (int i = 0; i < fullName.Length; i++)
        {
            char c = fullName[i];

            if (char.IsWhiteSpace(c))
            {
                inWord = false;
            }
            else if (!inWord)
            {
                inWord = true;   // первая буква слова
                if (sb.Length > 0)
                {
                    sb.Append(' ');
                }

                sb.Append(char.ToUpperInvariant(c));
                sb.Append('.');
            }
        }

        return sb.ToString();
    }

    /// <summary>Повторяет строку n раз. Для null, "" и n &lt;= 0 возвращает "".</summary>
    public static string Repeat(string? s, int n)
    {
        if (string.IsNullOrEmpty(s) || n <= 0)
        {
            return "";
        }

        var sb = new StringBuilder();

        for (int i = 0; i < n; i++)
        {
            sb.Append(s);
        }

        return sb.ToString();
    }
}
