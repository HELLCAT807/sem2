using System;

class Program
{
    static void Main()
    {
        // Блок объявления переменных
        int rows;              // Количество строк исходной матрицы
        int cols;              // Количество столбцов исходной матрицы
        double[,] matrix;      // Исходная матрица
        double[,] transposed;  // Транспонированная матрица

        // Ввод количества строк матрицы с контролем корректности
        Console.Write("Введите количество строк матрицы: ");
        while (!int.TryParse(Console.ReadLine(), out rows) || rows <= 0)
        {
            Console.WriteLine("Ошибка! Введите целое положительное число для количества строк:");
        }

        // Ввод количества столбцов матрицы с контролем корректности
        Console.Write("Введите количество столбцов матрицы: ");
        while (!int.TryParse(Console.ReadLine(), out cols) || cols <= 0)
        {
            Console.WriteLine("Ошибка! Введите целое положительное число для количества столбцов:");
        }

        // Инициализация исходной матрицы
        matrix = new double[rows, cols];

        Console.WriteLine("Введите элементы матрицы по строкам:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"Элемент [{i + 1},{j + 1}]: ");
                while (!double.TryParse(Console.ReadLine(), out matrix[i, j]))
                {
                    Console.WriteLine("Ошибка! Введите корректное числовое значение элемента:");
                    Console.Write($"Элемент [{i + 1},{j + 1}]: ");
                }
            }
        }


        // Вывод исходной матрицы
        Console.WriteLine("Исходная матрица:");
        for (int i = 0; i < rows; i++)
        {
            Console.Write("|");
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"{matrix[i, j],8:F2}");
            }
            Console.WriteLine(" |");
        }

        // Алгоритмическое транспонирование матрицы
        transposed = new double[cols, rows];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                transposed[j, i] = matrix[i, j];
            }
        }

        // Вывод транспонированной матрицы
        Console.WriteLine("\nТранспонированная матрица:");
        for (int i = 0; i < cols; i++)
        {
            Console.Write("|");
            for (int j = 0; j < rows; j++)
            {
                Console.Write($"{transposed[i, j],8:F2}");
            }
            Console.WriteLine(" |");
        }

        // Ожидание нажатия клавиши перед завершением работы программы
        Console.ReadKey(true);
    }
}
