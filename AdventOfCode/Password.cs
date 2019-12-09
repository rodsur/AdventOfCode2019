using System;
using System.Linq;


namespace AdventOfCode
{
    public class Password
    {
        public static int checkPasswords(in int min, in int max)
        {
            int validPasswords = 0;
            for (int i = min; i < max; i++)
            {
                if (isValid(i))
                {
                    validPasswords++;
                }
            }

            return validPasswords;
        }

        private static bool isValid(in int password)
        {
            int[] digits = password.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();
            bool onlyRising = true;
            bool hasPair = false;
            for (int i = 1; i < digits.Length; i++)
            {
                if (digits[i] < digits[i - 1])
                {
                    onlyRising = false;
                    break;
                }

                if (digits[i] == digits[i - 1])
                {
                    hasPair = true;
                }
            }

            if (hasPair == false || onlyRising == false)
            {
                return false;
            }

            return true;
        }
    }
}