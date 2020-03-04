using System;
using System.Collections.Generic;
using System.Linq;

namespace ExceptionHandlingDemo
{
    public class LetterCounter
    {
        private Dictionary<char, int?> letterCounts;

        public LetterCounter()
        {
            letterCounts = new Dictionary<char, int?>();
        }

        public void Count(char c)
        {
            if (letterCounts.Keys.Contains(c))
            {
                letterCounts[c]++;
            }
            else
            {
                letterCounts.Add(c, 1);
            }
        }

        public char[] GetAllKeysInOrder(bool isAscendingOrder)
        {
            if (isAscendingOrder)
            {
                return letterCounts.OrderBy(d => d.Value).Select(l => l.Key).ToArray();
            }
            return letterCounts.OrderByDescending(d => d.Value).Select(l => l.Key).ToArray();
        }

        public Dictionary<char,int?> GetAllInOrder(bool isAscendingOrder)
        {
            if (isAscendingOrder)
            {
                return letterCounts.OrderBy(d => d.Value).ToDictionary(p => p.Key, p => p.Value);
            }
            return letterCounts.OrderByDescending(d => d.Value).ToDictionary(p => p.Key, p => p.Value);
        }
    }
}