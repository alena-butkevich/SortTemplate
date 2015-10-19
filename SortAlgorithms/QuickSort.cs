using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTemplate.SortAlgorithms
{
    class QuickSort : ISort
    {
        public T[] Sort<T>(T[] array, IComparer<T> comparer)
        {
            T[] newArray = new T[array.Length];
            newArray = Sort(array, comparer, 0, array.Length - 1);
            return newArray;
        }

        public T[] Sort<T>(T[] array, IComparer<T> comparer, int a, int b)
        {
            int A = a;
            int B = b;
            T mid;

            if (b > a)
            {

                mid = array[(a + b) / 2];

                while (A <= B)
                {
                    while ((A < b) && (comparer.Compare(array[A], mid) == -1)) ++A;


                    while ((B > a) && (comparer.Compare(array[B], mid) == 1)) --B;

                    if (A <= B)
                    {
                        T Temp;
                        Temp = array[A];
                        array[A] = array[B];
                        array[B] = Temp;

                        ++A;
                        --B;
                    }

                    if (a < B) Sort(array, comparer, a, B);

                    if (A < b) Sort(array, comparer, A, b);
                }
            }
            return array;
        }
    }
}
