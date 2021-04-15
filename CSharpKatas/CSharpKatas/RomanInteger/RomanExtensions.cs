using System;
using System.Collections.Generic;

namespace CSharpKatas.RomanInteger
{
    public static class RomanExtensions
    {
        private static readonly Dictionary<int, string> SpecialCases = new Dictionary<int, string>
        {
            {4, "IV"},
            {9, "IX"},
            {40, "XL"},
            {49, "IL"},
            {90, "XC"},
            {99, "IC"},
            {400, "CD"},
            {490, "XD"},
            {499, "ID"},
            {900, "CM"},
            {990, "XM"},
            {999, "IM"}
        };

        public static string ToRoman2(this int i)
        {
            int remainder = i;
            string result = "";

            if (remainder < 1)
            {
                throw new Exception($"{i} cannot be represented by Roman Numerals");
            }

            while (remainder > 0)
            {
                UpdateSpecialCase(ref remainder, ref result);
                UpdateNextLargestNumber(ref remainder, ref result);
            }

            return result;
            //while (remainder >= 1000)
            //{
            //}

            //9 = IX
            //40 = XL
            //90 = XC
            //99 = IC??
            //CD = 400
            //XD = 490
            //ID = 499
        }

        private static void UpdateSpecialCase(ref int remainder, ref string outputString)
        {
            if (SpecialCases.ContainsKey(remainder))
            {
                outputString += SpecialCases[remainder];
                remainder = 0;
            }
        }

        private static void UpdateNextLargestNumber(ref int remainder, ref string outputString)
        {
            if (remainder >= 1000)
            {
                outputString += "M";
                remainder -= 1000;
            }
            else if (remainder >= 500)
            {
                outputString += "D";
                remainder -= 500;
            }
            else if (remainder >= 100)
            {
                outputString += "C";
                remainder -= 100;
            }
            else if (remainder >= 50)
            {
                outputString += "L";
                remainder -= 50;
            }
            else if (remainder >= 10)
            {
                outputString += "X";
                remainder -= 10;
            }
            else if (remainder >= 5)
            {
                outputString += "V";
                remainder -= 5;
            }

            else if (remainder >= 1)
            {
                outputString += "I";
                remainder -= 1;
            }
        }
    }
}
