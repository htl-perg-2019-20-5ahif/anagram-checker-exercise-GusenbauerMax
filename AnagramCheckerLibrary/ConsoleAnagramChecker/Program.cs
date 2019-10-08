using System;
using AnagramChecker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.EnvironmentVariables;


namespace ConsoleAnagramChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("check or get anagrams? ");
            string input = Console.ReadLine();
            if (input != null)
            {
                input = input.Replace(" ", "");
                Console.Write("Anagram ");
                switch (input)
                {
                    case "check": checkAnagrams(); break;
                    case "get": getKnownAnagrams(); break;
                }
            }

        }

        public static void checkAnagrams()
        {
            Console.Write("check: ");
            string input = Console.ReadLine();

            var words = input.Split(" ");

            var ac = new AnagramWordsChecker();
            if (ac.CheckForAnagram(words[0], words[1]))
            {
                Console.WriteLine ("\n\"{0}\" and \"{1} are anagrams", words[0], words[1]);
            }
            else
            {
                Console.WriteLine("\n\"{0}\" and \"{1} are no anagrams", words[0], words[1]);
            }
        }

        public static void getKnownAnagrams()
        {
            Console.Write("getKnown : ");
            string input = Console.ReadLine();

            var config = new ConfigurationBuilder();
            config.AddJsonFile("config.json");
            config.AddEnvironmentVariables();

            var dr = new AnagramChecker.DictionaryFileReader(config.Build());
            Dictionary dict = dr.Read();
            DictionaryEntry entry = dict.getEntryForKey(input);
            Console.WriteLine (entry.printWords());
        }
    }
}
