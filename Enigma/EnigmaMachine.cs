using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    public class EnigmaMachine
    {
        private Scrambler[] scramblers;
        private Reflector reflector;
        private Plugboard plugboard;

        public EnigmaMachine(Scrambler[] scramblers, Reflector reflector, Plugboard plugboard)
        {
            this.scramblers = scramblers;
            this.reflector = reflector;
            this.plugboard = plugboard;
        }

        public string Crypt(string message)
        {
            string cryptedMessage = "";
            int i = 0;
            foreach (var letter in message)
            {
                i++;
                char cryptedLetter;
                // Run the letter through the plugboard
                cryptedLetter = plugboard.Process(letter);
                // Run the letter through the scramblers
                foreach (var scrambler in this.scramblers)
                {
                    cryptedLetter = scrambler.Scramble(cryptedLetter);
                }
                // Reflect it
                cryptedLetter = reflector.Reflect(cryptedLetter);
                // Run it back through the scramblers
                foreach (var scrambler in this.scramblers.Reverse())
                {
                    cryptedLetter = scrambler.ReverseScramble(cryptedLetter);
                }
                // Run it back through the plugboard
                cryptedLetter = plugboard.Process(cryptedLetter);

                cryptedMessage += cryptedLetter;

                // Rotate the scramblers
                foreach (var scrambler in this.scramblers)
                {
                    if (i % Math.Pow(EnigmaHelper.NumLetters, Array.IndexOf(this.scramblers, scrambler)) == 0)
                        scrambler.Rotate();
                }
            }

            // Reset scramblers to their original positions
            foreach (var scrambler in this.scramblers)
            {
                scrambler.Reset();
            }

            return cryptedMessage;
        }
    }
}
