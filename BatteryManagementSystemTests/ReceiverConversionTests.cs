using BatteryManagementSystem;
using System.Collections.Generic;
using Xunit;

namespace BatteryManagementSystemTests
{
    public class ReceiverConversionTests
    {
        void TestParameterConversion(string senderOutput, List<BatteryParameter> expectedParameters)
        {
            List<BatteryParameter> actualOutput = Receiver.ConvertInputToParameterList(senderOutput);
            AssertEquality(expectedParameters, actualOutput);
        }

        void AssertEquality(List<BatteryParameter> expectedOutput, List<BatteryParameter> actualOutput)
        {
            //Check equal size
            Assert.Equal(expectedOutput.Count, actualOutput.Count);

            //Check distint elements
            for (int i = 0; i < expectedOutput.Count; i++)
            {
                var expectedItem = expectedOutput[i];
                var actualItem = actualOutput[i];
                AssertEquality(expectedItem, actualItem);
            }
        }

        void AssertEquality(BatteryParameter expectedParameter, BatteryParameter actualParameter)
        {
            Assert.Equal(expectedParameter.Name, actualParameter.Name);
            Assert.Equal(expectedParameter.Values, actualParameter.Values);
        }

        [Fact]
        public void ValidParameterConversionTest()
        {
            BatteryParameter expectedTemperatureReadings = new BatteryParameter()
            {
                Name = "Temperature readings",
                Values = new double[] { 38, 18, 35, 36, 41, 8.9, 15, 35, 12, 25 }
            };

            BatteryParameter expectedSocReadings = new BatteryParameter()
            {
                Name = "SOC readings",
                Values = new double[] { 49, 58, 42, 51, 77, 75, 58, 63, 28, 56 }
            };

            BatteryParameter expectedChargeRateReadings = new BatteryParameter()
            {
                Name = "Charge Rate readings",
                Values = new double[] { 0.013, 0.19, 0.11, 0.64, 0.13, 0.32, 0.1, 0.087, 0.8, 0.17 }
            };

            string senderOutput = ReceiverTestConstants.SingleParametersInput;
            List<BatteryParameter> expectedOutput = new List<BatteryParameter> { expectedTemperatureReadings };
            TestParameterConversion(senderOutput, expectedOutput);

            senderOutput = ReceiverTestConstants.MultipleParametersInput;
            expectedOutput = new List<BatteryParameter>
            {
                expectedTemperatureReadings,
                expectedSocReadings,
                expectedChargeRateReadings
            };
            TestParameterConversion(senderOutput, expectedOutput);
        }

        [Fact]
        public void InvalidInputConversionTest()
        {
            string senderOutput = ReceiverTestConstants.InvalidInput1;
            List<BatteryParameter> expectedOutput = new List<BatteryParameter>();
            TestParameterConversion(senderOutput, expectedOutput);

            senderOutput = ReceiverTestConstants.InvalidInput2;
            TestParameterConversion(senderOutput, expectedOutput);
        }

        [Fact]
        public void EmptyInputConversionTest()
        {
            string senderOutput = string.Empty;
            List<BatteryParameter> expectedOutput = new List<BatteryParameter>();
            TestParameterConversion(senderOutput, expectedOutput);
        }

        [Fact]
        public void NullInputConversionTest()
        {
            string senderOutput = null;
            List<BatteryParameter> expectedOutput = new List<BatteryParameter>();
            TestParameterConversion(senderOutput, expectedOutput);
        }
    }
}
