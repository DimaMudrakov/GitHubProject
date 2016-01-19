using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsolePluginLibrary
{
    class CollectionPlugins<T> where T : class
    {

        public List<T>GetCollectionPlugins()
        {

            List<T> collection = new List<T>();

            collection.Add(PluginUpperCase<T>);

            return collection;

        }
    }
}
