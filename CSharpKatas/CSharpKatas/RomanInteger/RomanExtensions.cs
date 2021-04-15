using System;

namespace CSharpKatas.RomanInteger
{
    public static class RomanExtensions
    {
        public static string ToRoman(this int i)
        {
            int remainder = i;
            string result = "";
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

            //3321 -> MMM + 321
            //321 -> CCC + 21
            //21 -> XX + 1
            //1 -> I
            switch (i)
            {
                case 0: throw new Exception($"{i} cannot be represented by Roman Numerals");
                case 1: return "I";
                case 5: return "V";
                case 10: return "X";
                case 50: return "L";
                case 100: return "C";
                case 500: return "D";
                case 1000: return "M";
                default:
                    {
                        while (remainder > 0)
                        {
                            if (remainder > 5)
                            {
                                result += "V";
                                remainder -= 5;
                            }
                            else if (remainder > 0)
                            {
                                result += "I";
                                remainder--;

                            }
                        }
                        return result;
                    }
            }
        }
    }
}
