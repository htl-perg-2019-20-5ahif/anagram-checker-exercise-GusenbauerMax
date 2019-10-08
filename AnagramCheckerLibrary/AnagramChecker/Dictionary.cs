using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramChecker
{
    public class Dictionary
    {
        public Dictionary()
        {
            dictionaryEntries = new List<DictionaryEntry>();
        }

        public List<DictionaryEntry> dictionaryEntries { get; set; }

        public DictionaryEntry getEntryForKey(string key) 
        {
            if (key == null) return null;
            foreach (DictionaryEntry dictEntry in dictionaryEntries)
            {
                if (dictEntry.key.Equals(key))
                {
                    return dictEntry;
                } 
            }
            return null;
        }

    }
}
