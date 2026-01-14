using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEBOT.Cycletime
{
    internal static class MedianCalculator
    {
        public static double FindMedian(List<double> numbers)
        {
            if (numbers == null || numbers.Count == 0)
            {
                throw new ArgumentException("List cannot be null or empty.", nameof(numbers));
            }

            // Create a copy and sort the list to avoid modifying the original list order.
            List<double> sortedNumbers = new List<double>(numbers);
            sortedNumbers.Sort();

            int n = sortedNumbers.Count;

            // If the number of elements is odd, the median is the middle element.
            if (n % 2 != 0)
            {
                // The index is (n / 2) because of zero-based indexing (integer division works here).
                return sortedNumbers[n / 2];
            }
            else // If the number of elements is even, the median is the average of the two middle elements.
            {
                // Get the two middle values.
                int middleIndex1 = (n / 2) - 1;
                int middleIndex2 = (n / 2);
                double middleValue1 = sortedNumbers[middleIndex1];
                double middleValue2 = sortedNumbers[middleIndex2];

                // Calculate their average. Use 2.0d for double division.
                return (middleValue1 + middleValue2) / 2.0d;
            }
        }
    }
}
