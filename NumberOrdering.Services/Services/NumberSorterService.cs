using NumberOrdering.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace NumberOrdering.Services.Services
{
    public class NumberSorterService : INumberSorterService
    {
        public virtual List<int> BubbleSort(List<int> arrayToSort)
        {
            int n = arrayToSort.Count;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (arrayToSort[j] > arrayToSort[j + 1])
                    {
                        int temp = arrayToSort[j];
                        arrayToSort[j] = arrayToSort[j + 1];
                        arrayToSort[j + 1] = temp;
                    }

            return arrayToSort;
        }

        public virtual List<int> MergeSort(List<int> arrayToSort)
        {
            if (arrayToSort.Count <= 1)
            {
                return arrayToSort;
            }

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int median = arrayToSort.Count / 2;
            for (int i = 0; i < median; i++)  //Dividing the unsorted list
            {
                left.Add(arrayToSort[i]);
            }
            for (int i = median; i < arrayToSort.Count; i++)
            {
                right.Add(arrayToSort[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>(); //The new collection

            while (left.Any() || right.Any())
            {
                if (left.Any() && right.Any())
                {
                    //Comparing the first element of each sublist 
                    //to see which is smaller
                    if (left.First() <= right.First())
                    {
                        result.Add(left.First());
                        left.Remove(left.First());
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if (left.Any())
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Any())
                {
                    result.Add(right.First());
                    right.Remove(right.First());
                }
            }
            return result;
        }

        public virtual List<int> QuickSort(List<int> arrayToSort)
        {
            if (arrayToSort.Count <= 1)
                return arrayToSort;
            int pivotIndex = arrayToSort.Count / 2;
            int pivot = arrayToSort[pivotIndex];
            List<int> left = new List<int>();
            List<int> right = new List<int>();

            for (int i = 0; i < arrayToSort.Count; i++)
            {
                if (i == pivotIndex) continue;

                if (arrayToSort[i] <= pivot)
                {
                    left.Add(arrayToSort[i]);
                }
                else
                {
                    right.Add(arrayToSort[i]);
                }
            }

            List<int> sorted = QuickSort(left);
            sorted.Add(pivot);
            sorted.AddRange(QuickSort(right));
            return sorted;
        }
    }
}
