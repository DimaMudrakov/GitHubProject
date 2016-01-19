using System;
using System.Text.RegularExpressions;

namespace ConsolePluginLibrary
{
    class PluginDeleteNumbers<T1>
    {
        public string RemoveDigits(string stringWithWords)
        {
            return Regex.Replace(stringWithWords, @"\d", "");
        }
    }
}
