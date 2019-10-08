using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AnagramChecker.Services;

namespace AnagramChecker
{
    public class AnagramWordsChecker : IAnagramChecker
    {

        public bool CheckForAnagram(string word1, string word2)
        {
            if (word1 == null || word2 == null) return false;
            return String.Concat(word1.OrderBy(c => c)) == String.Concat(word2.OrderBy(c => c));
        }
    }
}
