using System;

class Program
{
    static void Main(string[] args)
    {
        int n = 0;                 // длина массива
        int[] array = null;        // массив целых чисел
        bool flg = false;          // флаг корректности ввода

        // Ввод длины массива с использованием while
        Console.Write("Введите длину массива: ");
        flg = Int32.TryParse(Console.ReadLine(), out n);

        while (!flg || n <= 0)
        {
            Console.WriteLine("Ошибка ввода. Введите положительное целое число.");
            Console.Write("Введите длину массива: ");
            flg = Int32.TryParse(Console.ReadLine(), out n);
        }

        // Создание массива после корректного ввода n
        array = new int[n];

        // Ввод элементов массива (также без do…while)
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Введите {i + 1}-й элемент массива: ");
            flg = Int32.TryParse(Console.ReadLine(), out array[i]);

            while (!flg)
            {
                Console.WriteLine("Ошибка ввода. Введите корректное числовое значение.");
                Console.Write($"Введите {i + 1}-й элемент массива: ");
                flg = Int32.TryParse(Console.ReadLine(), out array[i]);
            }
        }

        // Подсчёт нулей на нечётных позициях (позиции начинаются с 1)
        int count = 0;

        for (int i = 0; i < n; i++)
        {
            if ((i + 1) % 2 != 0 && array[i] == 0)
            {
                count++;
            }
        }

        // Вывод результата
        Console.WriteLine($"Количество нулей на нечётных позициях: {count}");

        Console.ReadKey(true);
    }
}
