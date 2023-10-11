using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prac3_3
{
    class LinkedListFoodProductsComparer : IComparer<FoodProduct>
    {
        public int Compare(FoodProduct? x, FoodProduct? y)
        {
            if (x == null || y == null) throw new NotImplementedException();
            return x.Name.Length - y.Name.Length;
        }
    }
}
