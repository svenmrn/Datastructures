using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Sorteeralgoritmen
{
    public class InsertionSort
    {
        public void Sort(int[] list)
        {
            for (int i = 1; i < list.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (list[j] < list[j - 1])
                    {
                        var temp = list[j];
                        list[j] = list[j - 1];
                        list[j - 1] = temp;
                    }
                    else
                        break;
                }
            }
        }
    }
}
