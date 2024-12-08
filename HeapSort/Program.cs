using System;
using System.Diagnostics;

class Heapsort
{
    // Функция Heapify для поддержания кучи
    static void Heapify(int[] arr, int n, int i)
    {
        int largest = i; // Инициализация самого большого элемента как корня
        int left = 2 * i + 1; // Левая часть
        int right = 2 * i + 2; // Правая часть

        if (left < n && arr[left] > arr[largest])
            largest = left;

        if (right < n && arr[right] > arr[largest])
            largest = right;

        // Если самый большой элемент не является корнем
        if (largest != i)
        {
            // Меняем элементы
            int temp = arr[i];
            arr[i] = arr[largest];
            arr[largest] = temp;

            // Рекурсивно вызов Heapify для обновлённого поддерева
            Heapify(arr, n, largest);
        }
    }

    // Основная функция для сортировки массива
    static void HeapsortAlgorithm(int[] arr)
    {
        int n = arr.Length;

        // Построение кучи.
        // Начинаем с последнего родителя и двигаемся вверх.
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(arr, n, i);
        }

        // По одному извлекаем элементы из кучи
        for (int i = n - 1; i > 0; i--)
        {
            // Меняем элементы
            int temp = arr[0];
            arr[0] = arr[i];
            arr[i] = temp;

            // Heapify для обновлённого корня
            Heapify(arr, i, 0);
        }
    }

    static void Main(string[] args)
    {
        // Массивы для тестирования
        int[] smallArray = { 12, 11, 13, 5, 6, 7 };
        int[] largeArray = GenerateRandomArray(1000000);

        Console.WriteLine("Исходный массив (малый):");
        PrintArray(smallArray);

        // Замер времени сортировки малого массива
        Stopwatch stopwatch = Stopwatch.StartNew();
        HeapsortAlgorithm(smallArray);
        stopwatch.Stop();
        Console.WriteLine("\nОтсортированный массив (малый):");
        PrintArray(smallArray);
        Console.WriteLine($"Время выполнения сортировки малого массива: {stopwatch.ElapsedMilliseconds} мс");

        // Замер времени сортировки большого массива
        Console.WriteLine("\nСортировка большого массива...");
        stopwatch.Restart();
        HeapsortAlgorithm(largeArray);
        stopwatch.Stop();
        Console.WriteLine($"Время выполнения сортировки большого массива: {stopwatch.ElapsedMilliseconds} мс");
    
    }

    static void PrintArray(int[] arr)
    {
        foreach (var item in arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }


    static int[] GenerateRandomArray(int size)
    {
        Random rand = new Random();
        int[] arr = new int[size];
        for (int i = 0; i < size; i++)
        {
            arr[i] = rand.Next(0, 100000);
        }
        return arr;
    }
}
