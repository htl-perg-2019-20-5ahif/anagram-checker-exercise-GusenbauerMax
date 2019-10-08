using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramChecker
{
    public class DictionaryEntry
    {
        public DictionaryEntry()
        {
            words = new List<string>();
        }

        public string key { get; set; }

        public List<string> words { get; set; }

        public string printWords() 
        {
            string output = "";
            foreach (string word in words)
            {
                output += word + "\n";
            }
            return output;
        }
    }
}
