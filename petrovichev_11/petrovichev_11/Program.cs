using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main()
    {
        string input;
        char delimiter;
        string delimiterInput;
        string[] result;

        Console.WriteLine("Введите исходную строку:");
        input = Console.ReadLine();
        while (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Ошибка! Строка не должна быть пустой. Повторите ввод:");
            input = Console.ReadLine();
        }

        Console.WriteLine("Введите символ-разделитель:");
        delimiterInput = Console.ReadLine();
        while (string.IsNullOrEmpty(delimiterInput) || !char.TryParse(delimiterInput, out delimiter))
        {
            Console.WriteLine("Ошибка! Введите ровно один символ-разделитель:");
            delimiterInput = Console.ReadLine();
        }

        result = _lSplitWithDelimiter(input, delimiter);

        Console.WriteLine("Результат разбиения строки:");
        for (int i = 0; i < result.Length; i++)
        {
            Console.WriteLine($"[{i}] \"{result[i]}\"");
        }

        Console.ReadKey();
    }

    static string[] _lSplitWithDelimiter(string source, char delimiter)
    {
        List<string> parts;
        StringBuilder current;
        int i;
        char c;

        parts = new List<string>();

        if (source == null)
        {
            return parts.ToArray();
        }

        current = new StringBuilder();

        for (i = 0; i < source.Length; i++)
        {
            c = source[i];

            if (c == delimiter)
            {
                if (current.Length > 0)
                {
                    current.Append(delimiter);
                    parts.Add(current.ToString());
                    current.Length = 0;
                }
            }
            else
            {
                current.Append(c);
            }
        }

        if (current.Length > 0)
        {
            parts.Add(current.ToString());
        }

        return parts.ToArray();
    }
}
