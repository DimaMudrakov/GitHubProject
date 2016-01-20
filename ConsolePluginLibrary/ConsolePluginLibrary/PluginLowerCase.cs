using System;

namespace ConsolePluginLibrary
{
    class PluginLowerCase<T>
    {     

        public string ConvertStringToLowerCase(string stringWithWords)
        {
            string stringLowerCase = stringWithWords.ToLower();
            return stringLowerCase;
        }

        public string Modify(string param)

        {

            return param.ToLower();

        }
    }
}
