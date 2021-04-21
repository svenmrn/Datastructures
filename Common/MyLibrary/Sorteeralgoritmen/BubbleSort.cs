using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Sorteeralgoritmen
{
    public class BubbleSort
    {
        public void Sort(int[] list)              // lijst met lengte n
        {
            var n = list.Length;
            for (int f = 1; f <= n - 1; f++)      // iteraties
            {
                for (int g = 0; g < n - f; g++)   // overloop van links naar rechts
                {
                    if (list[g] > list[g + 1])    // compare
                    {
                        var temp = list[g];       // swap
                        list[g] = list[g + 1];
                        list[g + 1] = temp;
                    }
                }
            }
        }
    }
}
