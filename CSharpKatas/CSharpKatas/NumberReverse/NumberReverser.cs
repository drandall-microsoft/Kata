using System;

namespace CSharpKata.NumberReverse
{
    public class NumberReverser
    {
        public int Reverse(int input)
        {
            var asString = input.ToString();
            bool isNegative = false;
            if (asString.StartsWith('-'))
            {
                isNegative = true;
                asString = asString.Substring(1);
            }

            var asChars = asString.ToCharArray();
            Array.Reverse(asChars);

            if (int.TryParse(asChars, out int result))
            {
                if (isNegative)
                {
                    result *= -1;
                }

                return result;
            }

            return 0;
        }
    }
}