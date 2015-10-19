using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SortTemplate.SortAlgorithms;

namespace SortTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10];
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                 array[i] = random.Next();
            }
            Console.Write("Quick sort perfomance-> ");
            SortPerfomance(array, new QuickSort());
            Console.Write("Merge sort perfomance-> ");
            SortPerfomance(array, new MergeSort());
            Console.Write("Piramid sort perfomance-> ");
            SortPerfomance(array, new PiramidSort());
        }

        static void SortPerfomance(int[] array, ISort sortAlgorithm)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            array = sortAlgorithm.Sort<int>(array, Comparer<int>.Default);
           
            stopWatch.Stop();
            TimeSpan t = stopWatch.Elapsed;

            string elapsedTime = String.Format('\t' + "{0:00}:{1:00}:{2:00}.{3:00}", t.Hours, t.Minutes, t.Seconds, t.Milliseconds / 10);

            Console.WriteLine(elapsedTime);
        }
    }
}
