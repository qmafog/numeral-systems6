using System;

#pragma warning disable
namespace NumeralSystems
{
    public static class Converter
    {
        public static string GetPositiveOctal(this int number)
        {
            if (number < 0)
                throw new ArgumentException("Number must be positive.");

            if (number == 0)
                return "0";

            string result = string.Empty;

            while (number > 0)
            {
                int digit = number % 8;
                result = digit.ToString() + result;
                number /= 8;
            }

            return result;
        }

        public static string GetPositiveDecimal(this int number)
        {
            if (number < 0)
                throw new ArgumentException("Number must be positive.");

            if (number == 0)
                return "0";

            string result = string.Empty;

            while (number > 0)
            {
                int digit = number % 10;
                result = digit.ToString() + result;
                number /= 10;
            }

            return result;
        }

        public static string GetPositiveHex(this int number)
        {
            if (number < 0)
                throw new ArgumentException("Number must be positive.");

            if (number == 0)
                return "0";

            string result = string.Empty;

            while (number > 0)
            {
                int digit = number % 16;
                char hexChar = (digit < 10) ? (char)(digit + '0') : (char)(digit - 10 + 'A');
                result = hexChar + result;
                number /= 16;
            }

            return result;
        }

        public static string GetPositiveRadix(this int number, int radix)
        {
            if (number < 0)
                throw new ArgumentException("Number must be positive.");

            if (radix < 2 || radix > 36)
                throw new ArgumentException("Radix must be between 2 and 36.");

            if (radix != 8 && radix != 10 && radix != 16)
            {
                throw new ArgumentException("Radix is 8, 10 and 16 only.");
            }

            if (number == 0)
                return "0";

            string result = string.Empty;

            while (number > 0)
            {
                int digit = number % radix;
                char radixChar = (digit < 10) ? (char)(digit + '0') : (char)(digit - 10 + 'A');
                result = radixChar + result;
                number /= radix;
            }

            return result;
        }

        public static string GetNegativeRadix(this uint number, int radix)
        {
            if (number < 0)
                throw new ArgumentException("Number must be positive.");

            if (radix < 2 || radix > 36)
                throw new ArgumentException("Radix must be between 2 and 36.");

            if (radix != 8 && radix != 10 && radix != 16)
            {
                throw new ArgumentException("Radix is 8, 10 and 16 only.");
            }

            if (number == 0)
                return "0";

            string result = string.Empty;

            while (number > 0)
            {
                uint digit = number % (uint)radix;
                char radixChar = (digit < 10) ? (char)(digit + '0') : (char)(digit - 10 + 'A');
                result = radixChar + result;
                number /= (uint)radix;
            }

            return result;
        }

        public static string GetRadix(this int number, int radix)
        {
            if (radix < 2 || radix > 36)
                throw new ArgumentException("Radix must be between 2 and 36.");

            string result = string.Empty;

            bool isNegative = number < 0;
            if (isNegative)
            {
                number = -number;
                uint newNum = uint.MaxValue - (uint)number + 1;
                result = newNum.GetNegativeRadix(radix);
            }
            else
                result = number.GetPositiveRadix(radix);

            return result;
        }
    }
}
