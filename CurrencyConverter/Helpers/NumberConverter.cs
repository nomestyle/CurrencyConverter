using static CurrencyConverter.Helpers.Enums;
using static CurrencyConverter.Helpers.Enums.Unit;

namespace CurrencyConverter.Helpers
{
    /**
     * This is a static class for the number to word conversion
     **/
    public static class NumberConverter
    {
        /*
         *  This function takes a numerical input as string and converts it to a word representation
         */
        public static string ConvertNumberToWords(string input, Unit unit)
        {
            Int64 cleanInt = 0;
            if (!Int64.TryParse(input, out cleanInt))
            {
                return "Sorry, conversion has failed. This input is not a numeric value.";
            }

            var digits = input.ToIntArray();

            // Handle zeros in cents
            if (unit == Cent && digits.Length == 1) { digits = $"{input}0".ToIntArray(); }
            if (unit == Cent && digits.Length > 3) { digits = new int[] { 0 }; }
            if (unit == Cent && digits[0] == 0) { digits = input.Remove(0, 1).ToIntArray(); }

            int len = digits.Length;

            var result = "";

            // For single digits
            if (len == 1)
            {
                result += getSingleDigits(digits, 0);
            }

            // limited as to reduce complexity
            if (len > 12)
            {
                return "Sorry, conversion has failed. In it's current configuration, this converter can only go up to 12 digits.";
            }

            int x = 0;
            while (x < digits.Length && digits.Length != 1)
            {
                if (len >= 3)
                {
                    var currentLen = len - 1;
                    // For hundreds of Tenspower
                    if (digits[x] != 0 && currentLen == 5 || digits[x] != 0 && currentLen == 8 || digits[x] != 0 && currentLen == 11)
                    {
                        var and = digits[x + 1] == 0 && digits[x + 2] == 0 ? $"{(TensPowers)currentLen - 2} " : "and ";
                        result += $"{(SingleDigits)digits[x]} {TensPowers.Hundred} {and}";
                    }
                    // For double digits Tenspower
                    else if (digits[x] != 0 && currentLen == 4 || digits[x] != 0 && currentLen == 7 || digits[x] != 0 && currentLen == 10)
                    {
                        result += $"{getDoubleDigits(digits, x)}{(TensPowers)currentLen - 1} ";

                        ++x;
                        --len;
                    }
                    else if (digits[x] != 0)
                    {
                        result += $"{(SingleDigits)digits[x]} {(TensPowers)currentLen} ";
                    }
                    ++x;
                    --len;
                }
                else
                {
                    // Add an and for grammatical sense
                    if (result.EndsWith($"{TensPowers.Hundred} ") && digits[x] != 0 || result.EndsWith($"{TensPowers.Hundred} ") && digits[x + 1] != 0 ||
                        result.EndsWith($"{TensPowers.Thousand} ") && digits[x] != 0 || result.EndsWith($"{TensPowers.Thousand} ") && digits[x + 1] != 0 ||
                        result.EndsWith($"{TensPowers.Million} ") && digits[x] != 0 || result.EndsWith($"{TensPowers.Million} ") && digits[x + 1] != 0 ||
                        result.EndsWith($"{TensPowers.Billion} ") && digits[x] != 0 || result.EndsWith($"{TensPowers.Billion} ") && digits[x + 1] != 0)
                    {
                        result += "and ";
                    }
                    if (digits[x] != 0)
                    {
                        result += getDoubleDigits(digits, x);
                    }
                    else if (digits[x + 1] != 0)
                    {
                        result += getSingleDigits(digits, x + 1);
                    }
                    ++x;
                    ++x;
                    --len;
                    --len;
                }

            }
            return result == "One " ? $"{result}{unit}" : $"{result}{unit}s";
        }

        /*
         *  This function takes an int and converts it to a word representation
         */
        private static string getSingleDigits(int[] digits, int x)
        {
            return $"{(SingleDigits)digits[x]} ";
        }

        /*
         *  This function takes a set of 2 ints and converts it to a word representation
         */
        private static string getDoubleDigits(int[] digits, int x)
        {
            var result = "";

            if (digits[x] == 1)
            {
                result += $"{(DoubleDigits)digits[x + 1]} ";
            }
            else
            {
                if (digits[x] > 0)
                    result += $"{(TensDigits)digits[x]} ";
                if (digits[x + 1] != 0)
                    result += $"{(SingleDigits)digits[x + 1]} ";
            }

            return result;
        }

        /*
         *  This function takes a string and converts it to an array of ints
         */
        private static int[] ToIntArray(this string intString)
        {
            var result = new int[intString.Length];
            for (int i = 0; i < intString.Length; i++)
            {
                result[i] = int.Parse(intString[i].ToString());
            }
            return result;
        }
    }
}
