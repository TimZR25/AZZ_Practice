using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Prac3_3
{



    class Programm
    {

        public static void Main()
        {
            //1
            Console.WriteLine("--------------Первое задание!--------------\n");

            ArrayList arrayList = ArrayListClass.CreateList();
            ArrayListClass.PrintArrayList(arrayList);
            Console.WriteLine();

            Console.WriteLine(ArrayListClass.GetElement(null, 0));
            Console.WriteLine(ArrayListClass.GetElement(arrayList, 0));
            Console.WriteLine();

            ArrayListClass.DelElement(null, 10);
            ArrayListClass.DelElement(arrayList, 10);
            ArrayListClass.DelElement(arrayList, 0);

            Console.WriteLine();
            Console.WriteLine("Измененный список");
            ArrayListClass.PrintArrayList(arrayList);
            Console.WriteLine("\n");
            //2

            Console.WriteLine("--------------Второе задание!--------------\n");

            LinkedListBoolClass linkedListBool = new();
            linkedListBool.AddElem(true);


            linkedListBool.PrintLinkedListBool();

            linkedListBool.RemoveElem(0, 1);

            Console.WriteLine();

            linkedListBool.PrintLinkedListBool();

            Dictionary<int, bool> dict = new();

            Console.WriteLine("\n");

            for (int i = 0; i < linkedListBool.GetLinkList().Count; i++)
            {
                dict.Add(i, linkedListBool.GetLinkList().ElementAt(i));
            }

            Console.WriteLine("\nВывод словаря:");
            foreach (var d in dict)
            {
                Console.WriteLine("Ключ: " + d.Key + "\t" + "Значение: " + d.Value);
            }

            const int N = 0;
            Console.WriteLine("\n\nЗначение по ключу N: " + dict[N]);

            //3

            Console.WriteLine("\n--------------Третие задание!--------------\n");

            LinkedListFoodProducts foodProducts = new();

            //foodProducts.AddElem(new FoodProduct("Салат", 1, 20, 60, -10, 1));

            foodProducts.AddElem(new FoodProduct("Курица", 1.5, 40, 67, 0, 1), new FoodProduct("Арбуз", 5, 10, 50, -10, 1),
                new FoodProduct("Говядина", 2.5, 40, 70, 0, 1), new FoodProduct("Салат", 1, 20, 60, -10, 1));

            foodProducts.PrintLinkedFoodProducts();

            foodProducts.RemoveElem(2, 3);

            Console.WriteLine("После удаления\n");

            foodProducts.PrintLinkedFoodProducts();


            Console.WriteLine("\nДемонстрация реализации интерфейса ICoparer - сортировка по возрастанию длины названия продукта\n");

            foodProducts.SortComparer();
            foodProducts.PrintLinkedFoodProducts();


            Console.WriteLine("\nДемонстрация реализации интерфейса ICoparable - сортировка по убыванию температуры продукта\n");
            foodProducts.ImplementComparable();
            foodProducts.PrintLinkedFoodProducts();

            Dictionary<int, FoodProduct> dict1 = (Dictionary<int, FoodProduct>)foodProducts.Clone();

            Console.WriteLine("Вывод словаря\n");
            foreach (var d in dict1)
            {
                Console.WriteLine("Ключ: " + d.Key + "\t" + "Значение: " + d.Value.Name);
            }

            foodProducts.GetLinkList().First().Name = "Груша";

            Console.WriteLine($"\nНазвание первого первого продукта в списке изменено на {foodProducts.GetLinkList().First().Name}");

            Console.WriteLine("\nВывод словаря(Демонстрация реализации интерфейса IClone)\n");

            foreach (var d in dict1)
            {
                Console.WriteLine("Ключ: " + d.Key + "\t" + "Значение: " + d.Value.Name);
            }

            int N2 = 1;
            Console.WriteLine($"\nВывод элемента с ключом {N2}:\n");
            dict1[N2].Print();

            //4

            Console.WriteLine("\n--------------Четвертое задание!--------------\n");

            ObservableCollection<FoodProduct> observFood = new ObservableCollection<FoodProduct>();

            observFood.CollectionChanged += FoodChange;

            observFood.Add(new FoodProduct("Салат", 1, 20, 60, -10, 1));

            observFood.Add(new FoodProduct("Говядина", 2.5, 40, 70, 0, 1));

            observFood.RemoveAt(1);

            Console.WriteLine();
            foreach (FoodProduct item in observFood)
            {
                item.Print();
            }
        }

        public static void FoodChange(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (e.NewItems?[0] is FoodProduct f)
                        Console.WriteLine($"Добавлен новый объект: {f.Name}");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    if (e.OldItems?[0] is FoodProduct f1)
                        Console.WriteLine($"Удален объект: {f1.Name}");
                    break;
            }
        }
    }
}