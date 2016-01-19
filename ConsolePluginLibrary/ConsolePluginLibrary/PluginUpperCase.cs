using System;

namespace ConsolePluginLibrary
{
    class PluginUpperCase<T1>
    {
        public string ConvertStringToUpperCase(string stringWithWords)
        {
            string sringToUpper = stringWithWords.ToUpper();
            return sringToUpper;
        }
    }
}
