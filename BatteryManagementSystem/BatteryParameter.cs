namespace BatteryManagementSystem
{
    public struct BatteryParameter
    {
        public string Name { get; set; }
        public double[] Values { get; set; }

        public double MinValue
        {
            get => Values.GetMin();
        }

        public double MaxValue
        {
            get => Values.GetMax();
        }

        public double GetSimpleMovingAverage(int elementsCount)
        {
            return Values.GetSimpleMovingAverage(elementsCount);
        }
    }
}
