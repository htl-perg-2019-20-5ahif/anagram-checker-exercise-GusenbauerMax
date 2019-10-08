using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramChecker.Services
{
    public interface IAnagramChecker
    {
        bool CheckForAnagram(string word1, string word2);
    }
}
