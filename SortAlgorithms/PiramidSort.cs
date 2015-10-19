using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTemplate.SortAlgorithms
{
    public class PiramidSort : ISort
    {
        public T[] Sort<T>(T[] array, IComparer<T> comparer)
        {
            for (int i = array.Length / 2 - 1; i >= 0; --i)
            {
                long prev_i = i;
                i = add2pyramid(array, i, array.Length, comparer);
                if (prev_i != i) ++i;
            }

            //step 2: sorting
            T buf;
            for (Int32 k = array.Length - 1; k > 0; --k)
            {
                buf = array[0];
                array[0] = array[k];
                array[k] = buf;
                Int32 i = 0, prev_i = -1;
                while (i != prev_i)
                {
                    prev_i = i;
                    i = add2pyramid(array, i, k, comparer);
                }
            }
            return array;
        }

        public int add2pyramid<T>(T[] arr, Int32 i, Int32 N, IComparer<T> comparer)
        {
            Int32 imax;
            T buf;
            if ((2 * i + 2) < N)
            {
                if (comparer.Compare(arr[2 * i + 1], arr[2 * i + 2]) == -1) imax = 2 * i + 2;
                else imax = 2 * i + 1;
            }
            else imax = 2 * i + 1;
            if (imax >= N) return i;
            if (comparer.Compare(arr[i], arr[imax]) == -1)
            {
                buf = arr[i];
                arr[i] = arr[imax];
                arr[imax] = buf;
                if (imax < N / 2) i = imax;
            }
            return i;
        }

    }
}
