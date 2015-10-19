using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTemplate
{
    public interface ISort
    {
        T[] Sort<T>(T[] list, IComparer<T> comparer);
    }
}
