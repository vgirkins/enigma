using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    public class Reflector
    {
        private int[] letterSwaps1;
        private int[] letterSwaps2;

        public Reflector(int[] letterSwaps1, int[] letterSwaps2)
        {
            if (letterSwaps1.Count() != 13 || letterSwaps2.Count() != 13)
                throw new AxisException("You must specify 13 numbers in each array to be swapped with each other");

            this.letterSwaps1 = letterSwaps1;
            this.letterSwaps2 = letterSwaps2;
        }

        public char Reflect(char letter)
        {
            if (letter == ' ') return letter;

            char swappedLetter;
            var code = EnigmaHelper.ToCode(letter);
            var codePos = Array.IndexOf(letterSwaps1, code);
            if (codePos < 0)
            {
                codePos = Array.IndexOf(letterSwaps2, code);
                swappedLetter = EnigmaHelper.ToLetter(letterSwaps1[codePos]);
            }
            else
            {
                swappedLetter = EnigmaHelper.ToLetter(letterSwaps2[codePos]);
            }

            return swappedLetter;
        }
    }
}
