using System;
using System.Collections.Generic;

namespace ConsolePluginLibrary
{
    class PluginCountNumberWords<T>
    {
        T obj;

        public PluginCountNumberWords(T obj)
        {
            this.obj = obj;
        }

        public int CountNumberWords(string stringWithWords)
        {
            stringWithWords = stringWithWords.Trim(new char[] { ',', '.' });
            string[] arrayWithWords = stringWithWords.Split(new char[] { ' ' });

            int countNumberWords = arrayWithWords.Length;
            return countNumberWords;
        }
        public string Modify(string param)

        {
            return param.ToLower();
        }
    }
}
