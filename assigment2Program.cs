// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            // PracticeArray Methods
            PracticeArray.CopyArray();
            // PracticeArray.ManageList();
            // var primes = PracticeArray.FindPrimesInRange(10, 50);
            // PracticeArray.RotateAndSum();
            // PracticeArray.FindLongestEqualSequence();
            // PracticeArray.FindMostFrequentNumber();

            // PracticeString Methods
            // PracticeString.ReverseTwoWays("sample");
            // PracticeString.ReverseWords("The quick brown fox jumps over the lazy dog /Yes! Really!!!/.");
            // PracticeString.FindPalindromes("Hi,exe? ABBA! Hog fully a string: ExE. Bob");
            // PracticeString.ParseUrl("https://www.apple.com/iphone");
        }
    }

    class PracticeArray
    {
        public static void CopyArray()
        {
            int[] original = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] copy = new int[original.Length];

            for (int i = 0; i < original.Length; i++)
                copy[i] = original[i];

            Console.WriteLine("Original: " + string.Join(", ", original));
            Console.WriteLine("Copy:     " + string.Join(", ", copy));
        }

        public static void ManageList()
        {
            List<string> list = new List<string>();
            while (true)
            {
                Console.WriteLine("Enter command (+ item, - item, or -- to clear):");
                string input = Console.ReadLine();

                if (input == "--")
                    list.Clear();
                else if (input.StartsWith("+"))
                    list.Add(input.Substring(2));
                else if (input.StartsWith("-"))
                    list.Remove(input.Substring(2));

                Console.WriteLine("Current list: " + string.Join(", ", list));
            }
        }

        public static int[] FindPrimesInRange(int startNum, int endNum)
        {
            List<int> primes = new List<int>();

            for (int num = startNum; num <= endNum; num++)
            {
                if (IsPrime(num)) primes.Add(num);
            }

            return primes.ToArray();
        }

        private static bool IsPrime(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
                if (n % i == 0) return false;
            return true;
        }

        public static void RotateAndSum()
        {
            Console.WriteLine("Enter array:");
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine("Enter rotations:");
            int k = int.Parse(Console.ReadLine());

            int[] sum = new int[arr.Length];

            for (int r = 1; r <= k; r++)
            {
                int[] rotated = new int[arr.Length];
                for (int i = 0; i < arr.Length; i++)
                    rotated[(i + r) % arr.Length] = arr[i];

                for (int i = 0; i < arr.Length; i++)
                    sum[i] += rotated[i];
            }

            Console.WriteLine("Sum: " + string.Join(" ", sum));
        }

        public static void FindLongestEqualSequence()
        {
            Console.WriteLine("Enter array:");
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int maxLen = 1, len = 1, start = 0, bestStart = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] == arr[i - 1])
                    len++;
                else
                    len = 1;

                if (len > maxLen)
                {
                    maxLen = len;
                    bestStart = i - len + 1;
                }
            }

            Console.WriteLine("Longest sequence: " +
                string.Join(" ", arr.Skip(bestStart).Take(maxLen)));
        }

        public static void FindMostFrequentNumber()
        {
            Console.WriteLine("Enter array:");
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var freq = new Dictionary<int, int>();
            foreach (var num in arr)
                freq[num] = freq.ContainsKey(num) ? freq[num] + 1 : 1;

            int maxFreq = freq.Values.Max();
            int result = arr.First(x => freq[x] == maxFreq);

            Console.WriteLine($"Most frequent: {result} (occurs {maxFreq} times)");
        }
    }

    class PracticeString
    {
        public static void ReverseTwoWays(string input)
        {
            // Method 1: using char array
            char[] arr = input.ToCharArray();
            Array.Reverse(arr);
            Console.WriteLine("Reversed (method 1): " + new string(arr));

            // Method 2: loop backwards
            Console.Write("Reversed (method 2): ");
            for (int i = input.Length - 1; i >= 0; i--)
                Console.Write(input[i]);
            Console.WriteLine();
        }

        public static void ReverseWords(string sentence)
        {
            var separators = new string[] { ".", ",", ":", ";", "=", "(", ")", "&", "[", "]", "\"", "'", "\\", "/", "!", "?", " " };
            var words = sentence.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            var matches = Regex.Matches(sentence, @"[\s.,:;=\(\)&\[\]""'\\/!?]+");

            var reversedWords = words.Reverse().ToArray();

            string result = "";
            for (int i = 0; i < reversedWords.Length; i++)
            {
                result += reversedWords[i];
                if (i < matches.Count)
                    result += matches[i];
            }

            Console.WriteLine("Reversed sentence: " + result);
        }

        public static void FindPalindromes(string text)
        {
            var words = Regex.Matches(text, @"\b\w+\b")
                .Select(m => m.Value)
                .Where(w => w.Length > 1 && w.ToLower() == new string(w.Reverse().ToArray()).ToLower())
                .Distinct()
                .OrderBy(w => w)
                .ToList();

            Console.WriteLine("Palindromes: " + string.Join(", ", words));
        }

        public static void ParseUrl(string url)
        {
            string protocol = "", server = "", resource = "";

            if (url.Contains("://"))
            {
                var parts = url.Split(new[] { "://" }, 2, StringSplitOptions.None);
                protocol = parts[0];
                url = parts[1];
            }

            var segments = url.Split('/', 2);
            server = segments[0];
            if (segments.Length > 1)
                resource = segments[1];

            Console.WriteLine($"[protocol] = \"{protocol}\"");
            Console.WriteLine($"[server] = \"{server}\"");
            Console.WriteLine($"[resource] = \"{resource}\"");
        }
    }
}
