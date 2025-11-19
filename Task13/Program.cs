using System;

class Program
{
    enum WorkState
    {
        Vklucheno = 0b000,
        Vyklucheno = 0b100,
        Ispravno = 0b110,
        Neispravno = 0b010,
        NaRemonte = 0b011
    }

    static void Main()
    {
        int[] values = { 0b000, 0b100, 0b110, 0b010, 0b011 };
        int index = 0;

        do
        {
            WorkState state = (WorkState)values[index];

            switch (state)
            {
                case WorkState.Vklucheno:
                    Console.WriteLine("Включено");
                    break;
                case WorkState.Vyklucheno:
                    Console.WriteLine("Выключено");
                    break;
                case WorkState.Ispravno:
                    Console.WriteLine("Исправно");
                    break;
                case WorkState.Neispravno:
                    Console.WriteLine("Неисправно");
                    break;
                case WorkState.NaRemonte:
                    Console.WriteLine("На ремонте");
                    break;
                default:
                    Console.WriteLine("Неизвестное состояние");
                    break;
            }

            index++;
        }
        while (index < values.Length);
    }
}