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
                int current = list[i];
                int newIndex = i;
                while (newIndex > 0)
                {
                    if (current < list[newIndex - 1])
                    {
                        list[newIndex] = list[newIndex - 1];
                        newIndex--;
                    }
                    else
                        break;
                }
                list[newIndex] = current;
            }
        }
    }
}
