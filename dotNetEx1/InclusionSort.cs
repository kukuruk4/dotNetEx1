using System;
using System.Collections.Generic;
using System.Text;

namespace dotNetEx1
{
    public class InclusionSort<T> where T : IComparable<T>
    {
        public static void Ascending(T[] arr)
        {
            for (int i = 1; i < arr.Length; ++i)
            {
                T value = arr[i];
                int index = i;
                while ((index > 0) && (arr[index - 1].CompareTo(value) > 0))
                {
                    arr[index] = arr[index - 1];
                    --index;
                }

                arr[index] = value;
            }
        }

        public static void Descending(T[] arr)
        {
            for (int i = 1; i < arr.Length; ++i)
            {
                T value = arr[i];
                int index = i;
                while ((index > 0) && (arr[index - 1].CompareTo(value) < 0))
                {
                    arr[index] = arr[index - 1];
                    --index;
                }

                arr[index] = value;
            }
        }
    }
}
