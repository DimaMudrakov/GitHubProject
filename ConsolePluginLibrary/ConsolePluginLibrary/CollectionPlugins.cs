using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsolePluginLibrary
{
    class CollectionPlugins<T>
    {

        public List<object> GetCollectionPlugins()
        {

            PluginCountNumberWords<object> countNumberWords = new PluginCountNumberWords<object>();
            PluginDeleteNumbers<object> deleteNumbers = new PluginDeleteNumbers<object>();
            PluginLongestWord<object> longestWord = new PluginLongestWord<object>();
            PluginLowerCase<object> lowerCase = new PluginLowerCase<object>();
            PluginUpperCase<object> upperCase = new PluginUpperCase<object>();

            List<object> collection = new List<object> {countNumberWords, deleteNumbers, longestWord, lowerCase, upperCase};

            return collection;

        }
    }
}
