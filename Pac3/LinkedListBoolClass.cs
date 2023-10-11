using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Prac3_3
{
    class LinkedListBoolClass
    {
        private LinkedList<bool> linkedList;

        public LinkedListBoolClass()
        {
            linkedList = new LinkedList<bool>();
        }

        public LinkedList<bool> GetLinkList() { return linkedList; }
        public void AddElem(bool b)
        {
            linkedList.AddLast(b);
            linkedList.AddFirst(!b);
            linkedList.AddBefore(linkedList.First, !b);
            linkedList.AddAfter(linkedList.First, b);
        }

        public void RemoveElem(int start, int final)
        { // final не включительно
            if (linkedList == null) throw new ArgumentNullException("Нет ссылки");
            if (start >= 0 && linkedList.Count >= start && linkedList.Count >= final && final > start)
            {
                for (int i = start; i < final; i++) linkedList.Remove(linkedList.ElementAt(i));
            }
            else Console.WriteLine("\nНеправильно введены индексы");
        }

        public void PrintLinkedListBool()
        {
            foreach (bool b in linkedList)
            {
                Console.WriteLine(b);
            }
        }
    }
}
