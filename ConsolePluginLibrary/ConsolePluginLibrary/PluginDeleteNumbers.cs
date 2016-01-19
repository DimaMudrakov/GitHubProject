using System;
using System.Text.RegularExpressions;

namespace ConsolePluginLibrary
{
     class PluginDeleteNumbers<T>
    {
        T obj;

        public PluginDeleteNumbers(T obj)
        {
            this.obj = obj;
        }

        public string RemoveDigits(string stringWithWords)
        {
            return Regex.Replace(stringWithWords, @"\d", "");
        }
        public T Modify(T param)
        {
           return param;
        }
    }
}
