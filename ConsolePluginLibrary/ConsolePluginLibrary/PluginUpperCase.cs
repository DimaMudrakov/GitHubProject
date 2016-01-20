using System;
using System.Collections.Generic;

namespace ConsolePluginLibrary
{
    class PluginUpperCase<T>
    {
        public string ConvertStringToUpperCase(string stringWithWords)
        {
            string sringToUpper = stringWithWords.ToUpper();
            return sringToUpper;
        }
        public string Modify(string param)

        {

            return param.ToLower();

        }
    }
}
