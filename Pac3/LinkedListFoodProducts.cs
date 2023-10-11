using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prac3_3
{
    class LinkedListFoodProducts : ICloneable
    {
        private LinkedList<FoodProduct> linkedList;

        public LinkedListFoodProducts()
        {
            linkedList = new LinkedList<FoodProduct>();
        }

        public LinkedList<FoodProduct> GetLinkList() { return linkedList; }

        public void AddElem(FoodProduct food)
        {
            linkedList.AddLast(food);
        }

        public void AddElem(FoodProduct food1, FoodProduct food2, FoodProduct food3, FoodProduct food4)
        {
            linkedList.AddLast(food4);
            linkedList.AddFirst(food3);
            linkedList.AddBefore(linkedList.First, food1);
            linkedList.AddAfter(linkedList.First, food2);
        }

        public void RemoveElem(int start, int final)
        {
            if (linkedList == null) throw new ArgumentNullException("Нет ссылки");
            if (start >= 0 && linkedList.Count >= start && linkedList.Count >= final && final >= start)
            {
                for (int i = start; i <= final; i++)
                {
                    linkedList.Remove(linkedList.ElementAt(start));
                }
            }
            else Console.WriteLine("\nНеправильно введены индексы");
        }

        public void PrintLinkedFoodProducts()
        {
            foreach (FoodProduct f in linkedList)
            {
                f.Print();
            }
        }

        public object Clone()
        {
            Dictionary<int, FoodProduct> dict = new Dictionary<int, FoodProduct>();
            for (int i = 0; i < linkedList.Count; i++)
            {
                dict.Add(i, new FoodProduct(linkedList.ElementAt(i)));
            }
            return dict;
        }

        public void SortComparer()
        {
            List<FoodProduct> temp = this.GetLinkList().ToList();
            temp.Sort(new LinkedListFoodProductsComparer());
            linkedList = new LinkedList<FoodProduct>(temp);
        }

        public void ImplementComparable()
        {
            List<FoodProduct> temp = this.GetLinkList().ToList();
            temp.Sort();
            linkedList = new LinkedList<FoodProduct>(temp);
        }
    }
}
