using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Sorteeralgoritmen
{
    public class BubbleSort
    {
        public void Sort(int[] list)
        {
            for (int f = 0; f < list.Length; f++)
            {
                for (int g = 1; g < list.Length - f; g++)
                {
                    if (list[g - 1] > list[g])
                    {
                        var temp = list[g];
                        list[g] = list[g - 1];
                        list[g - 1] = temp;
                    }
                }
            }
        }
    }
}
