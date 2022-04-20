using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Helpers
{
    /**
     * These are the enums used for the units as well as the word representations of numbers
     **/
    public static class Enums
    {
        /*
         *  Currency Unit
         */
        public enum Unit
        {
            Dollar,
            Cent
        }

        /*
         *  Singular Digits 0 - 9
         */
        public enum SingleDigits
        {
            Zero = 0,
            One = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9
        }

        /*
         *  Double Digits 10 - 19
         */
        public enum DoubleDigits
        {
            Ten = 0,
            Eleven = 1,
            Twelve = 2,
            Thirteen = 3,
            Fourteen = 4,
            Fifteen = 5,
            Sixteen = 6,
            Seventeen = 7,
            Eighteen = 8,
            Nineteen = 9,
        }

        /*
         *  Double Digits in multiple of tens
         */
        public enum TensDigits
        {
            Twenty = 2, 
            Thirty = 3,
            Forty = 4, 
            Fifty = 5,
            Sixty = 6,
            Seventy = 7,
            Eighty = 8,
            Ninety = 9
        }

        /*
         *  Powers of tens
         */
        public enum TensPowers
        {
            Hundred = 2,
            Thousand = 3,
            Million = 6,
            Billion = 9,
        }
    }
}
