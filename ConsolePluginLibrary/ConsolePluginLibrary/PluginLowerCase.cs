using System;

namespace ConsolePluginLibrary
{
    class PluginLowerCase<T1>
    {
        public string ConvertStringToLowerCase(string stringWithWords)
        {
            string stringLowerCase = stringWithWords.ToLower();
            return stringLowerCase;
        }
    }
}
