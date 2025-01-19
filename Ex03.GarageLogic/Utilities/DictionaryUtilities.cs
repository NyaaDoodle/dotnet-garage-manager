using System.Collections.Generic;

namespace Ex03.GarageLogic.Utilities
{
    public class DictionaryUtilities
    {
        public static void AppendToDictionary<T>(Dictionary<T> i_DictionaryToAppend, Dictionary<T> i_DictionaryToAppendTo)
        {
            foreach (var itemToAppend in i_CollectionToAppend)
            {
                i_ListToAppendTo.AddLast(itemToAppend);
            }
        }
    }
}