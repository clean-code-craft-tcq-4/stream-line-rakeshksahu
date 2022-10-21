using System;

namespace BatteryManagementSystem
{
    public static class ArrayExtensions
    {
        public static double GetMin(this double[] array)
        {
            double min = double.MaxValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }
            return min;
        }

        public static double GetMax(this double[] array)
        {
            double max = double.MinValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            return max;
        }

        public static double GetSimpleMovingAverage(this double[] array, int elementsCount)
        {
            double average = 0;

            int startIndex = GetStartIndexForMovingAverage(array.Length, elementsCount, out int totalElements);

            for (int i = startIndex; i < array.Length; i++)
            {
                average += array[i];
            }
            return Math.Round(average / totalElements, 2);
        }

        static int GetStartIndexForMovingAverage(int arrayLength, int elementsCount, out int totalElements)
        {
            int startIndex = arrayLength - elementsCount;
            if (startIndex < 0)
                startIndex = 0;

            totalElements = arrayLength - startIndex;

            return startIndex;
        }
    }
}
