using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "points01.txt");
        string outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "points02.txt");

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Файл points01.txt не найден.");
            return;
        }

            string content = File.ReadAllText(inputPath);
            string[] pointStrings = content.Split(';');

            double[] distances = new double[pointStrings.Length];
            string[] sortedPoints = new string[pointStrings.Length];

            for (int i = 0; i < pointStrings.Length; i++)
            {
                string[] coords = pointStrings[i].Trim().Split(',');
                int x = int.Parse(coords[0]);
                int y = int.Parse(coords[1]);
                double distance = Math.Sqrt(x * x + y * y);
                distances[i] = distance;
                sortedPoints[i] = coords[0] + "," + coords[1];
            }

            for (int i = 0; i < distances.Length - 1; i++)
            {
                for (int j = i + 1; j < distances.Length; j++)
                {
                    if (distances[i] > distances[j])
                    {
                        double tempD = distances[i];
                        distances[i] = distances[j];
                        distances[j] = tempD;

                        string tempS = sortedPoints[i];
                        sortedPoints[i] = sortedPoints[j];
                        sortedPoints[j] = tempS;
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                Console.WriteLine("Содержимое points02.txt:");
                for (int i = 0; i < sortedPoints.Length; i++)
                {
                    writer.WriteLine(sortedPoints[i]);
                    Console.WriteLine(sortedPoints[i]); 
                }
            }

            Console.WriteLine("\nФайл points02.txt успешно создан.");
    }
}