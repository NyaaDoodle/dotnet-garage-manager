using System.Collections.Generic;

namespace Ex03.GarageLogic.Utilities
{
    public class LinkedListUtilities
    {
        public static void AppendToLinkedList<T>(ICollection<T> i_CollectionToAppend, LinkedList<T> i_ListToAppendTo)
        {
            foreach (var itemToAppend in i_CollectionToAppend)
            {
                i_ListToAppendTo.AddLast(itemToAppend);
            }
        }
    }
}