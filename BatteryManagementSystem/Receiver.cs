using System;
using System.Collections.Generic;

namespace BatteryManagementSystem
{
    public class Receiver
    {
        static char colon = ':';
        static char openingBrace = '{';
        static char closingBrace = '}';
        static string csvSeparator = ", ";
        static char lineBreak = '\n';
        static int simpleMovingAverageElementsCount = 5;

        public static void ReceiveToPrint(string input, Action<string> printCallback, string printFormat)
        {
            var printableOutput = GetPrintableParameters(input, printFormat);
            printCallback(printableOutput);
        }

        public static string GetPrintableParameters(string input, string printFormat)
        {
            var batteryParameters = ConvertInputToParameterList(input);
            string printableString = string.Empty;

            foreach (var parameter in batteryParameters)
            {
                printableString += GetPrintableParameter(printFormat, parameter);
            }

            return printableString;
        }

        private static string GetPrintableParameter(string printFormat, BatteryParameter parameter)
        {
            string printableString = string.Format(printFormat, parameter.MinValue, parameter.MaxValue, parameter.GetSimpleMovingAverage(simpleMovingAverageElementsCount));
            return printableString;
        }

        public static List<BatteryParameter> ConvertInputToParameterList(string input)
        {
            var batteryParameters = new List<BatteryParameter>();

            if (!string.IsNullOrEmpty(input))
            {
                string[] lines = input.Split(lineBreak);
                batteryParameters = GetParametersFromMulitpleLines(batteryParameters, lines);
            }

            return batteryParameters;
        }

        private static List<BatteryParameter> GetParametersFromMulitpleLines(List<BatteryParameter> batteryParameters, string[] lines)
        {
            if (IsInputValid(lines))
            {
                batteryParameters = GetBatteryParameters(lines);
            }

            return batteryParameters;
        }

        static bool IsInputValid(string[] lines)
        {
            foreach (var line in lines)
            {
                if (!IsLineValid(line))
                {
                    return false;
                }
            }

            return true;
        }

        static bool IsLineValid(string line)
        {
            if (line.Contains(colon, openingBrace, closingBrace))
            {
                return true;
            }
            return false;
        }

        static List<BatteryParameter> GetBatteryParameters(string[] lines)
        {
            var batteryParameters = new List<BatteryParameter>();

            foreach (var line in lines)
            {
                var parameter = GetBatteryParameter(line);
                batteryParameters.Add(parameter);
            }

            return batteryParameters;
        }

        static BatteryParameter GetBatteryParameter(string line)
        {
            var name = GetParameterName(line);
            var valuesCsv = GetValuesCsv(line);

            BatteryParameter batteryParameter;

            batteryParameter = new BatteryParameter();
            batteryParameter.Values = valuesCsv.CsvToDoubleArray(csvSeparator);

            batteryParameter.Name = name;

            return batteryParameter;
        }

        static string GetParameterName(string line)
        {
            int nameStartIndex = 0;
            int nameEndIndex = line.IndexOf(colon) - 1;

            return line.TrimString(nameStartIndex, nameEndIndex);
        }

        static string GetValuesCsv(string line)
        {
            int numbersStartIndex = line.IndexOf(openingBrace) + 1;
            int numbersEndIndex = line.IndexOf(closingBrace) - 1;

            return line.TrimString(numbersStartIndex, numbersEndIndex);
        }
    }
}
