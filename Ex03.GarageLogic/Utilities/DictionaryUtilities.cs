using System.Collections.Generic;

namespace Ex03.GarageLogic.Utilities
{
    public class DictionaryUtilities
    {
        public static void AppendToDictionary<K, V>(
            Dictionary<K, V> i_DictionaryToAppend,
            Dictionary<K, V> i_DictionaryToAppendTo)
        {
            foreach (KeyValuePair<K, V> pairToAppend in i_DictionaryToAppend)
            {
                i_DictionaryToAppendTo.Add(pairToAppend.Key, pairToAppend.Value);
            }
        }
    }
}