using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        //Скачали текст и указали путь к файлу
        string[] data = File.ReadAllLines("input.txt");
        int repetitions = 5;

        Console.WriteLine("Вставка в конец:");
        TestInsertion(data, repetitions, insertAtEnd: true);

        Console.WriteLine("\nВставка в начало:");
        TestInsertion(data, repetitions, insertAtEnd: false);
    }
    /// <summary>
    /// Пишем сам тест для сравнения коллекций
    /// </summary>
    /// <param name="data">Содержимое текстового файла</param>
    /// <param name="repetitions">количество повторений для проверки</param>
    /// <param name="insertAtEnd">проверка на позицию вставки</param>
    static void TestInsertion(string[] data, int repetitions, bool insertAtEnd)
    {
        long listTime = 0;
        long linkedListTime = 0;
        
        for (int i = 0; i < repetitions; i++)
        {
            List<string> list = new List<string>();
            Stopwatch sw = Stopwatch.StartNew();
            foreach (string item in data)
            {
                if (insertAtEnd) list.Add(item);
                else list.Insert(0, item);
            }
            sw.Stop();
            listTime += sw.ElapsedMilliseconds;

            LinkedList<string> linkedList = new LinkedList<string>();
            sw.Restart();
            foreach (string item in data)
            {
                if (insertAtEnd) linkedList.AddLast(item);
                else linkedList.AddFirst(item);
            }
            sw.Stop();
            linkedListTime += sw.ElapsedMilliseconds;
        }

        Console.WriteLine($"List<T>:      {(double)listTime / repetitions:F1} мс");
        Console.WriteLine($"LinkedList<T>: {(double)linkedListTime / repetitions:F1} мс");
    }
}
