namespace BatteryManagementSystem
{
    public static class StringExtensions
    {
        public static string TrimString(this string inputString, int startIndex, int endIndex)
        {
            int length = CalculateLength(startIndex, endIndex);
            string substring = inputString.Substring(startIndex, length);
            return substring;
        }

        static int CalculateLength(int startIndex, int endIndex)
        {
            int length = endIndex - startIndex + 1;
            return length;
        }

        public static double[] CsvToDoubleArray(this string csv, string separator)
        {
            string[] stringValues = csv.Split(separator);
            double[] doubleValues = StringArrayToDoubleArray(stringValues);
            return doubleValues;
        }

        private static double[] StringArrayToDoubleArray(string[] stringValues)
        {
            double[] doubleValues = new double[stringValues.Length];
            for (int i = 0; i < stringValues.Length; i++)
            {
                doubleValues[i] = double.Parse(stringValues[i]);
            }
            return doubleValues;
        }

        public static bool Contains(this string input, params char[] chars)
        {
            foreach (var _char in chars)
            {
                if (!input.Contains(_char))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
