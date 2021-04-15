using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpKatas.RomanInteger
{
    public static class RomanEx2
    {

        private static Dictionary<string, string> SpecialCases = new Dictionary<string, string>
        {
            {"DCCCCLXXXXVIIII", "IM" }, //999
            {"DCCCCLXXXX", "XM" }, //990
            {"DCCCC", "CM" }, //900
            {"CCCCLXXXXVIIII", "ID" }, //499
            {"CCCCLXXXX", "XD" }, //490
            {"CCCC", "CD" }, //400
            {"LXXXXVIIII", "IC" }, //99
            {"LXXXX", "XC" }, //90
            {"XXXXVIIII", "IL"}, //49
            {"XXXX", "XL" }, //40
            {"VIIII", "IX" }, //9
            {"IIII", "IV" } //4
        };

        public static string ToRoman(this int input)
        {
            if (input < 1 || input > 3000)
            {
                throw new Exception($"${input} cannot be represented by a Roman Numeral");
            }

            var simple = GetSimpleNumeral(input);
            Simplify(ref simple);
            return simple;
        }

        private static string GetSimpleNumeral(int num)
        {
            int remainder = num;
            string result = "";

            while (remainder >= 1000) { result += "M"; remainder -= 1000; }
            while (remainder >= 500) { result += "D"; remainder -= 500; }
            while (remainder >= 100) { result += "C"; remainder -= 100; }
            while (remainder >= 50) { result += "L"; remainder -= 50; }
            while (remainder >= 10) { result += "X"; remainder -= 10; }
            while (remainder >= 5) { result += "V"; remainder -= 5; }
            while (remainder > 0) { result += "I"; remainder -= 1; }

            return result;
        }

        private static void Simplify(ref string romanNumeral)
        {
            foreach (var rep in SpecialCases)
            {
                romanNumeral = romanNumeral.Replace(rep.Key, rep.Value);
            }
        }
    }
}
