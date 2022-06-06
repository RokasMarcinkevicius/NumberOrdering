using System.Collections.Generic;

namespace NumberOrdering.Services.Interfaces
{
    public interface INumberSorterService
    {
        // Comparison-Based Sorting:
        public List<int> BubbleSort(List<int> arrayToSort);
        public List<int> QuickSort(List<int> arrayToSort);
        
        // Not-In-Place Sorting
        public List<int> MergeSort(List<int> arrayToSort);
    }
}
