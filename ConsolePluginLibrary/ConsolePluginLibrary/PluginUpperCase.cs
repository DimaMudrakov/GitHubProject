using System;

namespace ConsolePluginLibrary
{
    class PluginUpperCase<T>
    {

        T obj;

        public PluginUpperCase(T obj)
        {
            this.obj = obj;
        }
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
