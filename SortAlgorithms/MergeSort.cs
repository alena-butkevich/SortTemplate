using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTemplate.SortAlgorithms
{
    public class MergeSort : ISort
    {
        public T[] Sort<T>(T[] array, IComparer<T> comparer)
        {
            if (array.Length == 1)
                return array;
            Int32 mid_point = array.Length / 2;
            return Merge(Sort(array.Take(mid_point).ToArray(), comparer), Sort(array.Skip(mid_point).ToArray(), comparer), comparer);
        }

        static T[] Merge<T>(T[] array1, T[] array2, IComparer<T> comparer)
        {
            Int32 a = 0, b = 0;
            T[] merged = new T[array1.Length + array2.Length];
            for (Int32 i = 0; i < array1.Length + array2.Length; i++)
            {
                if (b < array2.Length && a < array1.Length)
                    if (comparer.Compare(array1[a], array2[b]) == 1)
                        merged[i] = array2[b++];
                    else //if int go for
                        merged[i] = array1[a++];
                else
                    if (b < array2.Length)
                    merged[i] = array2[b++];
                else
                    merged[i] = array1[a++];
            }
            return merged;
        }
    }
}
