using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    public class Scrambler
    {
        public int rotationTracker; // number of times the scrambler has been rotated
        public int[] wirings;
        public Scrambler(int[] wirings)
        {
            if (wirings.Count() != EnigmaHelper.NumLetters)
                throw new AxisException("You must specify exactly 26 wirings.");

            this.rotationTracker = 0;
            this.wirings = wirings;
        }

        /// <summary>
        /// Run a letter through the scrambler.
        /// </summary>
        /// <param name="letter"></param>
        /// <returns></returns>
        public char Scramble(char letter)
        {
            if (letter == ' ') return letter;

            var index = EnigmaHelper.ToCode(letter);
            var scrambledLetter = EnigmaHelper.ToLetter(wirings[index]);
            return scrambledLetter;
        }

        /// <summary>
        /// Run a letter through the scrambler in reverse.
        /// </summary>
        /// <param name="letter"></param>
        /// <returns></returns>
        public char ReverseScramble(char letter)
        {
            if (letter == ' ') return letter;

            var code = EnigmaHelper.ToCode(letter);
            return EnigmaHelper.ToLetter(wirings.ToList().IndexOf(code));
        }

        /// <summary>
        /// Rotate the scrambler wheel one position.
        /// </summary>
        public void Rotate(int numPositions = 1)
        {
            var shiftedList = this.wirings.Skip(numPositions);
            shiftedList = shiftedList.Concat(this.wirings.Take(numPositions));
            this.wirings = shiftedList.ToArray();
            rotationTracker++;
        }

        public void Reset()
        {
            if (this.rotationTracker == 0) return;
            var startIndex = EnigmaHelper.NumLetters - (this.rotationTracker % EnigmaHelper.NumLetters);    // The index at which the array should start (rotate around this) 
            this.Rotate(startIndex);
            this.rotationTracker = 0;
        }
    }
}
