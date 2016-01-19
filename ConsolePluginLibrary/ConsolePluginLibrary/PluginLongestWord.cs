using System;

namespace ConsolePluginLibrary
{
    class PluginLongestWord<T1>
    {
        public string LongestWord(string stringWithWords)
        {
            string longestWord = "";

            stringWithWords = stringWithWords.Trim(new char[] { ',', '.' });
            string[] arrayWithWords = stringWithWords.Split(new char[] { ' ' });

            foreach (string str in arrayWithWords)
                if (str.Length >= longestWord.Length)
                    longestWord = str;

            return longestWord;
        }
    }
}
