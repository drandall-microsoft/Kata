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
        };

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
               else if(remainder >= 0) throw new Exception($"{i} cannot be represented by Roman Numerals");
               else if(remainder >= 1) return "I";
               else if(remainder >= 5) return "V";
               else if(remainder >= 10) return "X";
               else if(remainder >= 50) return "L";
               else if(remainder >= 100) return "C";
               else if(remainder >= 500) return "D";
               else if(remainder >= 1000) return "M";
                default:
                    {
                        while (remainder > 0)
                        {
                            while (remainder >= 10)
                            {
                                if (SpecialCases.ContainsKey(remainder))
                                {
                                    result += SpecialCases[remainder];
                                    remainder = 0;
                                }
                                else
                                {
                                    result += "X";
                                    remainder -= 10;
                                }
                            }
                            while (remainder > 5)
                            {
                                if (SpecialCases.ContainsKey(remainder))
                                {
                                    result += SpecialCases[remainder];
                                    remainder = 0;
                                }
                                else
                                {
                                    result += "V";
                                    remainder -= 5;
                                }
                            }
                            while (remainder > 0)
                            {
                                if (SpecialCases.ContainsKey(remainder))
                                {
                                    result += SpecialCases[remainder];
                                    remainder = 0;
                                }
                                else
                                {
                                    result += "I";
                                    remainder--;
                                }
                            }
                        }
                        return result;
                    }
            }
        }

        private static void UpdateNextLargestNumber(ref int remainder, ref string outputString)
        {
            switch (remainder)
            {
               else if(remainder >= 1000)
                    {
                        outputString += "M";
                        remainder -= 1000;
                        break;
                    }
               else if(remainder >= 500)
                    {
                        outputString += "D";
                        remainder -= 500;
                        break;
                    }
               else if(remainder >= 100)
                    {
                        outputString += "C";
                        remainder -= 100;
                        break;
                    }
               else if(remainder >= 50)
                    {
                        outputString += "L";
                        remainder -= 50;
                        break;
                    }
               else if(remainder >= 10)
                    {
                        outputString += "X";
                        remainder -= 10;
                        break;
                    }
               else if(remainder >= 5)
                    {
                        outputString += "V";
                        remainder -= 5;
                        break;
                    }

               else if(remainder >= $1)
                    {
                        outputString += "I";
                        remainder -= 1;
                        break;
                    }







            }
        }
    }
}
