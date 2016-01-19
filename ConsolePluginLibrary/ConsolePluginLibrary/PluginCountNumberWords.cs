using System;

namespace ConsolePluginLibrary
{
    class PluginCountNumberWords<T1>
    {
        public int CountNumberWords(string stringWithWords)
        {
            stringWithWords = stringWithWords.Trim(new char[] { ',', '.' });
            string[] arrayWithWords = stringWithWords.Split(new char[] { ' ' });

            int countNumberWords = arrayWithWords.Length;
            return countNumberWords;
        }
    }
}
