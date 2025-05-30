using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        string text = File.ReadAllText("input.txt");

        // Шаг 1: Удаление пунктуации и приведение к нижнему регистру
        var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
        string cleanedText = noPunctuationText.ToLower();

        // Шаг 2: Разделение текста на слова
        string[] words = cleanedText.Split(
            new[] { ' ', '\n', '\r', '\t', '\v', '\f' },
            StringSplitOptions.RemoveEmptyEntries
        );

        // Шаг 3: Подсчёт частоты слов
        Dictionary<string, int> wordCount = new Dictionary<string, int>();
        foreach (string word in words)
        {
            if (wordCount.ContainsKey(word))
                wordCount[word]++;
            else
                wordCount[word] = 1;
        }

        // Шаг 4: Выбор топ-10 слов
        var topWords = wordCount
            .OrderByDescending(pair => pair.Value)
            .Take(10)
            .ToList();

        // Вывод результатов
        Console.WriteLine("Топ-10 самых частых слов:");
        for (int i = 0; i < topWords.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {topWords[i].Key} - {topWords[i].Value} раз");
        }
    }
}
