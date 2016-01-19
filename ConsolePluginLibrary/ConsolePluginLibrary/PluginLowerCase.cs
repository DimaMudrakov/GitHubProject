using System;

namespace ConsolePluginLibrary
{
    class PluginLowerCase<T>
    {
        T obj;

        public PluginLowerCase(T obj)
        {
            this.obj = obj;
        }

        public string ConvertStringToLowerCase(string stringWithWords)
        {
            string stringLowerCase = stringWithWords.ToLower();
            return stringLowerCase;
        }
    }
}
