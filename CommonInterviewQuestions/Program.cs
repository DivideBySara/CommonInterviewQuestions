using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonInterviewQuestions
{
    public class Trie
    {
        public char letter = '\0';
        public Trie[] letters = new Trie[26];

        public Trie()
        {

        }

        public Trie(char letter)
        {
            this.letter = letter;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Largest sum contiguous array...
            Console.WriteLine("Given an array with elements -2, -3, 4, -1, -2, 1, 5, -3, \nfind the largest sum from a contiguous sequence of those elements.");
            Console.WriteLine("\ninput = int[] arr");
            Console.WriteLine("output = 7");

            int[] arr = { -2, -3, 4, -1, -2, 1, 5, -3 };
            int maxSum = GetLargestSum(arr);
            Console.WriteLine($"The largest contiguous sum is {maxSum}");

            int[] arr2 = { -2, -3, -4, -1, -2, -1, -5, -3 };
            int maxSum2 = GetLargestSum(arr2);
            Console.WriteLine($"The largest contiguous sum is {maxSum2}");

            // 2. Populate a trie with the words "mom" and "month".
            Console.WriteLine("\nPopulate a trie with the words mom and month.");
            Console.WriteLine("Use the debugger to prove this method works.");
            List<string> words = new List<string>() { "mom", "month" };
            Trie trie = PopulateTrie(words);

            Console.ReadKey();
        }

        private static Trie PopulateTrie(List<string> words)
        {
            Trie trie = new Trie();

            foreach (string word in words)
            {
                AddWord(word, trie);
            }

            return trie;
        }

        private static void AddWord(string word, Trie current)
        {
            int index = 0;
            
            foreach(char c in word)
            {
                // (int)'a' is ?
                index = (int)c - (int)'a';
                if (current.letters[index] == null)
                {
                    current.letters[index] = new Trie(c);
                } // else a node already exists for this letter

                current = current.letters[index];
            }
        }

        private static int GetLargestSum(int[] arr)
        {
            int maxSum = int.MinValue; // Keeps track of max sum found
            int currentSum = 0;        // Keeps track of sum of contiguous segment

            foreach (int i in arr)
            {
                // We need to add each element to currentSum.
                currentSum = currentSum + i;

                // Assign larger currentSum to maxSum.
                if (maxSum < currentSum)
                {
                    maxSum = currentSum;
                }

                // Stop keeping track of contiguous segment if it is not positive.
                if (currentSum < 0)
                {
                    currentSum = 0;
                }
            }

            return maxSum;
        }
    }
}
