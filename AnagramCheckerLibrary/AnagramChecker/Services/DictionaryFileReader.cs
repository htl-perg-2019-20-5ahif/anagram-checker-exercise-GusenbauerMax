using AnagramChecker.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AnagramChecker
{
    public class DictionaryFileReader : IDictionaryReader
    {
        private readonly IConfiguration config;

        public DictionaryFileReader(IConfiguration config)
        {
            this.config = config;
        }

        public Dictionary Read()
        {
            string filename = config["dictionaryFileName"];
            var text = File.ReadAllText(filename);
            var lines = text.Replace("\r", "").Split('\n');
            var dictionary = new Dictionary();
            foreach (var line in lines)
            {
                DictionaryEntry de = new DictionaryEntry();
                de.key = line.Split(':')[0];
                if (!line.Split(':')[1].Contains(","))
                {
                    de.words.Add(line.Split(':')[1]);
                }
                else
                {
                    foreach(var word in line.Split(':')[1].Split(','))
                    {
                        de.words.Add(word);
                    }
                }
                dictionary.dictionaryEntries.Add(de);
            }
            return dictionary;
        }
    }
}
