using System;
using System.Collections.Generic;
using System.Linq;

namespace SortAlgorithm
{
    class Program
    {
        public static List<int> BucketSort(int[] x)
        {
            List<int> sortedArray = new List<int>();

            int bucketsQty = 10;
            List<int>[] buckets = new List<int>[bucketsQty];
            for (int i = 0; i < bucketsQty; i++)
            {
                buckets[i] = new List<int>();
            }

            for (int i = 0; i < x.Length; i++)
            {
                int bucket = (x[i] / bucketsQty);
                buckets[bucket].Add(x[i]);
            }

            for (int i = 0; i < bucketsQty; i++)
            {
                List<int> sortedInBucket = SortByInserts(buckets[i]);
                sortedArray.AddRange(sortedInBucket);
            }
            return sortedArray;
        }

        public static List<int> SortByInserts(List<int> arr)
        {
            for (int i = 1; i < arr.Count; i++)
            {
                int currentValue = arr[i];
                int index = i - 1;

                while (index >= 0)
                {
                    if (currentValue < arr[index])
                    {
                        arr[index + 1] = arr[index];
                        arr[index] = currentValue;
                    }
                    else break;
                }
            }

            return arr;
        }
        static void Main(string[] args)
        {
            int[] array = new int[] { 58, 45, 2, 68, 33, 9, 69, 75, 22, 14, 81, 34 };
            Console.WriteLine($"Array for sorting");
            Console.WriteLine("[{0}]", string.Join(", ", array));

            Console.WriteLine($"\nSorted array");
            List<int> sorted = BucketSort(array);
            Console.WriteLine("[{0}]", string.Join(", ", sorted));

        }

    }
}
