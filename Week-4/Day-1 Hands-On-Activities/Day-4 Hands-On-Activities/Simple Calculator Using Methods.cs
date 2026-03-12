using System;

namespace ConsoleApp2
{
    internal class Program
    {
        static int CountVowels(string text)
        {
            int count = 0;

            foreach (char ch in text.ToLower())
            {
                if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u')
                {
                    count++;
                }
            }

            return count;
        }

        static void Main(string[] args)
        {
            Console.Write("Enter a word: ");
            string input = Console.ReadLine();

            int result = CountVowels(input);

            Console.WriteLine("Number of vowels: " + result);

            Console.ReadLine();
        }
    }
}
