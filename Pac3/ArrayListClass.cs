using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prac3_3
{
    static class ArrayListClass
    {
        public static ArrayList CreateList()
        {

            ArrayList arrayList = new ArrayList();

            for (int i = 0; i < 5; i++) { arrayList.Add(new Random().Next(-10, 10)); }
            arrayList.Add("Строка");
            return arrayList;
        }

        public static Object GetElement(ArrayList? array, int index)
        {
            return array?[index] ?? "Нет ссылки на список";
        }

        public static void DelElement(ArrayList array, int index)
        {
            if (array == null)
            {
                Console.WriteLine("Нет ссылки");
                return;
            }
            if (index <= array.Count)
            {
                Console.WriteLine("Удален элемент " + GetElement(array, index));
                array.RemoveAt(index);
            }
            else { Console.WriteLine("Неправильный индекс"); }
        }
        public static void PrintArrayList(ArrayList array)
        {
            Console.WriteLine("Количество элементов в коллекции: " + array.Count);
            foreach (Object i in array) Console.WriteLine(i);
        }
    }
}
