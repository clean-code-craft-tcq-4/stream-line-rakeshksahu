namespace BatteryManagementSystemTests
{
    public class ReceiverTestConstants
    {
        public const string ShortRangeParametersInput = "Temperature readings: {38, 18, 35, 36}\n" +
            "SOC readings: {49, 58, 63, 28}\n" +
            "Charge Rate readings: {0.013, 0.19, 0.11, 0.64}";

        public const string SingleParametersInput = "Temperature readings: {38, 18, 35, 36, 41, 8.9, 15, 35, 12, 25}";

        public const string MultipleParametersInput = "Temperature readings: {38, 18, 35, 36, 41, 8.9, 15, 35, 12, 25}\n" +
            "SOC readings: {49, 58, 42, 51, 77, 75, 58, 63, 28, 56}\n" +
            "Charge Rate readings: {0.013, 0.19, 0.11, 0.64, 0.13, 0.32, 0.1, 0.087, 0.8, 0.17}";
        
        public const string InvalidInput1 = "{ 38, 18, 35, 36, 41, 8.9, 15, 35, 12, 25 }";
        public const string InvalidInput2 = "Invalid Input";

        public const string OutputFormat = "Min Value: {0}, Max Value: {1}, Average: {2}\n";
    }
}
