using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    public static class EnigmaHelper
    {
        public static int NumLetters = 26;
        private static int asciiBase = 65;
        /// <summary>
        /// Returns 0 for A, 1 for B, etc.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static int ToCode(char c)
        {
            if (c < 65 || (c > 90 && c < 97) || c > 122)
                throw new AxisException("You may only include letters and spaces in your message.");

            var code = c - asciiBase;
            if (code > 25)
            {
                // This must have been a lowercase letter. Adjust down again.
                code -= 32;
            }

            return code;
        }

        public static char ToLetter(int i)
        {
            return (char)(i + asciiBase);
        }
    }
}
