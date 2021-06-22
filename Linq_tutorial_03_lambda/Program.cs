using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_tutorial_03_lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "bot", "apple", "apricot" };
            IEnumerable<string> words_start_with_a = words
                .Where(currentWord => currentWord.StartsWith("a"));
            foreach (string single_word_starts_with_a in words_start_with_a)
            {
                Console.WriteLine(single_word_starts_with_a);
            }

            Console.WriteLine();

            int[] numbers = { 4, 7, 10 };
            int product = numbers.Aggregate(1, (interim, next) => interim * next);
            Console.WriteLine(product);   // output: 280

            Console.ReadLine();
        }
    }
}
