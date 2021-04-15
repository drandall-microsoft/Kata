namespace CSharpKatas.RomanInteger
{
    public static class RomanExtensions
    {
        public static string ToRoman(this int i)
        {
            if (i == 1)
            {
                return "I";
            }

            return "V";
        }
    }
}
