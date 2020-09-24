using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    public class Plugboard
    {
        private int[][] cables;
        
        public Plugboard(int[][] cables)
        {
            if (cables.Any(c => c.Count() != 2))
                throw new AxisException("Cables can only connect two letters each");

            if (cables.Any(c => cables.Count(k => k.Contains(c[0]) || k.Contains(c[1])) > 1))
                throw new AxisException("You may only plug one cable into a given letter");

            this.cables = cables;
        }

        public char Process(char letter)
        {
            if (letter == ' ') return letter;

            var code = EnigmaHelper.ToCode(letter);
            var cable = this.cables.SingleOrDefault(c => c.Contains(code));
            if (cable == null)
                return letter;

            if (Array.IndexOf(cable, code) == 0)
                return EnigmaHelper.ToLetter(cable[1]);
            else
                return EnigmaHelper.ToLetter(cable[0]);
        }
    }
}
