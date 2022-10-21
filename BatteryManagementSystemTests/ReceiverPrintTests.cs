using BatteryManagementSystem;
using Xunit;

namespace BatteryManagementSystemTests
{
    public class ReceiverPrintTests
    {
        void TestParameterPrint(string senderOutput, string expectedOutput)
        {
            string actualOutput = string.Empty;
            Receiver.ReceiveToPrint(senderOutput, PrintToConsole, ReceiverTestConstants.OutputFormat);

            void PrintToConsole(string text)
            {
                actualOutput = text;
            }

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void ValidParametersPrintTest()
        {
            string senderOutput = ReceiverTestConstants.SingleParametersInput;
            string expectedOutput = string.Format(ReceiverTestConstants.OutputFormat, 8.9, 41, 19.18);
            TestParameterPrint(senderOutput, expectedOutput);

            senderOutput = ReceiverTestConstants.ShortRangeParametersInput;
            expectedOutput = string.Format(ReceiverTestConstants.OutputFormat, 18, 38, 31.75) +
                string.Format(ReceiverTestConstants.OutputFormat, 28, 63, 49.5) +
                string.Format(ReceiverTestConstants.OutputFormat, 0.013, 0.64, 0.24);
            TestParameterPrint(senderOutput, expectedOutput); 
                        
            senderOutput = ReceiverTestConstants.MultipleParametersInput;
            expectedOutput = string.Format(ReceiverTestConstants.OutputFormat, 8.9, 41, 19.18) +
                string.Format(ReceiverTestConstants.OutputFormat, 28, 77, 56) +
                string.Format(ReceiverTestConstants.OutputFormat, 0.013, 0.8, 0.30);
            TestParameterPrint(senderOutput, expectedOutput);
        }

        [Fact]
        public void InvalidInputPrintTest()
        {
            string senderOutput = ReceiverTestConstants.InvalidInput1;
            string expectedOutput = string.Empty;
            TestParameterPrint(senderOutput, expectedOutput);

            senderOutput = ReceiverTestConstants.InvalidInput2;
            TestParameterPrint(senderOutput, expectedOutput);
        }

        [Fact]
        public void EmptyInputPrintTest()
        {
            string senderOutput = string.Empty;
            string expectedOutput = string.Empty;
            TestParameterPrint(senderOutput, expectedOutput);
        }

        [Fact]
        public void NullInputPrintTest()
        {
            string senderOutput = null;
            string expectedOutput = string.Empty;
            TestParameterPrint(senderOutput, expectedOutput);
        }
    }
}
