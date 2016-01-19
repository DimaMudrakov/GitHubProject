using System;

namespace ConsolePluginLibrary
{
    class PluginLongestWord<T>
    {
        T obj;

        public PluginLongestWord(T obj)
        {
            this.obj = obj;
        }
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
        public string Modify(string param)

        {

            return param.ToLower();

        }
    }
}
