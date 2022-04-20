using Microsoft.VisualStudio.TestTools.UnitTesting;
using static CurrencyConverter.Helpers.NumberConverter;
using static CurrencyConverter.Helpers.Enums.Unit;

namespace CurrencyConverterTest
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        /*
         * Tests that on a single 1, no plural is added
         */
        public void Test_OneNoplural_Success()
        {
            var expected = "One Dollar";
            var result = ConvertNumberToWords("1", Dollar);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        /*
         * Tests success on a single digit
         */
        public void Test_Singles_Success()
        {
            var expected = "Nine Dollars";
            var result = ConvertNumberToWords("9", Dollar);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        /*
         * Tests success on a double digit
         */
        public void Test_doubleDigit_Success()
        {
            var expected = "Nineteen Dollars";
            var result = ConvertNumberToWords("19", Dollar);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        /*
         * Tests success on a 'tens' multiple
         */
        public void Test_Tens_Success()
        {
            var expected = "Eighty Dollars";
            var result = ConvertNumberToWords("80", Dollar);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        /*
         * Tests success on a 'tens' power
         */
        public void Test_tensPowers_Success()
        {
            var expected = "Two Hundred Dollars";
            var result = ConvertNumberToWords("200", Dollar);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        /*
         * Tests success on a 'tens' power with extra digits
         */
        public void Test_combination_Success()
        {
            var expected = "Two Hundred and Twenty Five Dollars";
            var result = ConvertNumberToWords("225", Dollar);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        /*
         * Tests success on a large number
         */
        public void Test_Massive_Success()
        {
            var expected = "One Billion Two Hundred Dollars";
            var result = ConvertNumberToWords("1000000200", Dollar);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        /*
         * Tests success at twelve digit length
         */
        public void Test_DigitLength_Success()
        {
            var expected = "One Hundred Billion Dollars";
            var result = ConvertNumberToWords("100000000000", Dollar);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        /*
         * Tests success at the limit
         */
        public void Test_limit_Success()
        {
            var expected = "Nine Hundred and Ninety Nine Billion Nine Hundred and Ninety Nine Million Nine Hundred and Ninety Nine Thousand Nine Hundred and Ninety Nine Dollars";
            var result = ConvertNumberToWords("999999999999", Dollar);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        /*
         * Tests success with appending and on large numbers
         */
        public void Test_and_Success()
        {
            var expected = "One Hundred Billion and Fifty Dollars";
            var result = ConvertNumberToWords("100000000050", Dollar);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        /*
         * Tests success on a single digit cent with a leading zero
         */
        public void Test_leadingZeroCents_Success()
        {
            var expected = "Two Cents";
            var result = ConvertNumberToWords("02", Cent);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        /*
         * Tests success on a single digit cent with a trailing zero
         */
        public void Test_TrailingZerocents_Success()
        {
            var expected = "Twenty Cents";
            var result = ConvertNumberToWords("2", Cent);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        /*
         * Tests returns error string when input is not numeric
         */
        public void Test_Numeric_Error()
        {
            var expected = "Sorry, conversion has failed. This input is not a numeric value.";
            var result = ConvertNumberToWords("2.99", Cent);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        /*
         * Tests returns error string when input is too long
         */
        public void Test_DigitLength_Error()
        {
            var expected = "Sorry, conversion has failed. In it's current configuration, this converter can only go up to 12 digits.";
            var result = ConvertNumberToWords("1234567891011", Dollar);
            Assert.AreEqual(expected, result);
        }
    }
}