using System;
using System.Diagnostics;

class HelloWorld
{
    static void Main()
    {
        Console.WriteLine("[Program] Введите количество элементов массива:");
        Console.Write(">>> "); int N = int.Parse(Console.ReadLine());
        int[] Array = new int[N];
        double[] TimerArray = new double[N];
        Stopwatch Timer = Stopwatch.StartNew();
        Timer.Start();

        Random _rnd = new Random();
        for (int i = 0; i < Array.Length; i++) Array[i] = _rnd.Next(-500, 500); // Заполнение массива
        for (int i = 1; i < Array.Length; i++) // Сортировка массива
        {
            for (int j = 1; j < Array.Length; j++)
                if (Array[j - 1] > Array[j])
                {
                    int temp = Array[j];
                    Array[j] = Array[j - 1];
                    Array[j - 1] = temp;
                }
            if (i == 0) TimerArray[i] = Timer.Elapsed.TotalSeconds;
            else TimerArray[i] = Timer.Elapsed.TotalSeconds - TimerArray[i - 1];
        }
        if (N <= 30)
        {
            Console.WriteLine("[Program] Отсортированный массив:");
            for (int i = 0; i < Array.Length; i++) Console.WriteLine($@"[{i}] {Array[i]} ({TimerArray[i]} сек.)");
        }
        Console.WriteLine($@"[Program] Время выполнения: {Timer.Elapsed.TotalSeconds} сек.");

        double E = 0;
        for (int i = 0; i < Array.Length; i++) E += TimerArray[i];
        E /= Array.Length;
        Console.WriteLine($@"[Program] E[{N}] = {E} сек.");

        double Sigma = 0;
        for (int i = 0; i < Array.Length; i++) Sigma = TimerArray[i] - E;
        Sigma *= Sigma;
        Sigma /= (N - 1);
        Console.WriteLine($@"[Program] Сигма[{N}] = {Math.Sqrt(Sigma)} сек.");
        Timer.Stop();
        Console.ReadKey();
    }
}
