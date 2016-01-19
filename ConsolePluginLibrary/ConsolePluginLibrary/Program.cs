using System;

namespace ConsolePluginLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            PluginCountNumberWords<string> count = new PluginCountNumberWords<string>();
            PluginLongestWord<string> longest = new PluginLongestWord<string>();
            PluginUpperCase<string> upperCase = new PluginUpperCase<string>();
            PluginLowerCase<string> lowerCase = new PluginLowerCase<string>();
            PluginDeleteNumbers<string> deleteNumber = new PluginDeleteNumbers<string>();

            Console.Write("Write some text: ");
            string stringWithWords = Console.ReadLine();

            Console.WriteLine("Count number of words: {0}",  count.CountNumberWords(stringWithWords));
            Console.WriteLine("The Longest words is:  {0}",  longest.LongestWord(stringWithWords));
            Console.WriteLine("The string to Upper:   {0}",  upperCase.ConvertStringToUpperCase(stringWithWords));
            Console.WriteLine("The string to Lover:   {0}",  lowerCase.ConvertStringToLowerCase(stringWithWords));
            Console.WriteLine("The string with out numbers: {0}",  deleteNumber.RemoveDigits(stringWithWords));

            Console.ReadLine();
        }      
    }
}
