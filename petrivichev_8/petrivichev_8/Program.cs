using System;

class Program
{
    static void Main(string[] args)
    {
        // Объявление и инициализация переменных
        int n = 0;                // количество элементов ряда
        int k = 0;                // счётчик цикла по элементам ряда
        int j = 0;                // счётчик для вычисления факториала
        int factorial = 1;        // (k + 2)!
        double x = 0.0;           // аргумент x
        double N = -1.5;          // сумма ряда, начальное значение -1.5
        double term = 0.0;        // текущий элемент ряда
        double xPower = 1.0;      // x^k
        double sinArg = 0.0;      // аргумент для функции sin(x^(2^(k-1)))
        double numerator = 0.0;   // подкоренное выражение в числителе
        double denominator = 0.0; // знаменатель элемента ряда
        double eps = 1e-6;        // допустимое отклонение знаменателя от нуля
        bool isXCorrect = false;  // флаг корректности ввода x
        bool isNCorrect = false;  // флаг корректности ввода n
        bool canCalculate = true; // флаг возможности дальнейшего расчёта

        Console.WriteLine("Вычисление суммы N для n элементов ряда.");

        // Ввод x по схеме «ввод до победного»
        while (!isXCorrect)
        {
            Console.Write("Введите значение x (вещественное число): ");
            isXCorrect = double.TryParse(Console.ReadLine(), out x);

            if (!isXCorrect)
            {
                Console.WriteLine("Ошибка: значение x должно быть вещественным числом. Попробуйте ещё раз.");
            }
        }

        // Ввод n по схеме «ввод до победного»
        while (!isNCorrect)
        {
            Console.Write("Введите количество элементов ряда n (целое положительное число): ");
            isNCorrect = int.TryParse(Console.ReadLine(), out n);

            if (!isNCorrect || n <= 0)
            {
                Console.WriteLine("Ошибка: n должно быть целым положительным числом. Попробуйте ещё раз.");
                isNCorrect = false;
            }
        }

        // Подготовка к расчёту ряда
        N = -1.5;   // начальное значение суммы
        xPower = 1; // x^0
        sinArg = x; // для k = 1 аргумент синуса равен x

        // Основной цикл расчёта элементов ряда
        for (k = 1; k <= n && canCalculate; k++)
        {
            // Вычисление (k + 2)! с помощью цикла по известному диапазону значений
            factorial = 1;
            for (j = 1; j <= k + 2; j++)
            {
                factorial *= j;
            }

            // Обновление степени x^k по рекуррентной формуле
            xPower *= x; // на k-й итерации получаем x^k

            // Обновление аргумента sin(x^(2^(k-1)))
            if (k == 1)
            {
                sinArg = x; // x^(2^0) = x
            }
            else
            {
                sinArg = sinArg * sinArg; // x^{2^(k-1)} = (x^{2^(k-2)})^2
            }

            // Формирование числителя: (k + 2)! + 5 * k * x^k
            numerator = factorial + 5.0 * k * xPower;

            // Контроль подкоренного выражения
            if (numerator < 0.0)
            {
                Console.WriteLine(
                    "Невозможно вычислить вещественный кубический корень: " +
                    "подкоренное выражение отрицательно при k = {0}.", k);
                canCalculate = false;
                break;
            }

            // Формирование знаменателя: sin(x^{2^(k-1)}) + (-1)^k * 5 * (k + 2)
            double sign = (k % 2 == 0) ? 1.0 : -1.0;
            denominator = Math.Sin(sinArg) + sign * 5.0 * (k + 2);

            // Контроль знаменателя
            if (Math.Abs(denominator) < eps)
            {
                Console.WriteLine(
                    "Невозможно вычислить элемент ряда: знаменатель слишком " +
                    "близок к нулю при k = {0}.", k);
                canCalculate = false;
                break;
            }

            // Вычисление текущего элемента ряда
            term = Math.Pow(numerator, 1.0 / 3.0) / denominator;

            // Накопление суммы
            N += term;
        }

        // Вывод результата
        if (canCalculate)
        {
            Console.WriteLine("Сумма ряда N = {0}", N);
        }

        Console.ReadKey(true);
    }
}
