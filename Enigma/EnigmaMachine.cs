using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    public class EnigmaMachine
    {
        private Scrambler scrambler1;
        private Scrambler scrambler2;
        private Scrambler scrambler3;
        private Reflector reflector;
        private Plugboard plugboard;

        public EnigmaMachine(Scrambler scrambler1, Scrambler scrambler2, Scrambler scrambler3, Reflector reflector, Plugboard plugboard)
        {
            this.scrambler1 = scrambler1;
            this.scrambler2 = scrambler2;
            this.scrambler3 = scrambler3;
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
                cryptedLetter = scrambler3.Scramble(scrambler2.Scramble(scrambler1.Scramble(cryptedLetter)));
                // Reflect it
                cryptedLetter = reflector.Reflect(cryptedLetter);
                // Run it back through the scramblers
                cryptedLetter = scrambler1.ReverseScramble(scrambler2.ReverseScramble(scrambler3.ReverseScramble(cryptedLetter)));
                // Run it back through the plugboard
                cryptedLetter = plugboard.Process(cryptedLetter);

                cryptedMessage += cryptedLetter;
                // Rotate the scramblers
                scrambler1.Rotate();
                if (i % EnigmaHelper.NumLetters == 0)
                {
                    scrambler2.Rotate();
                    if (i % (EnigmaHelper.NumLetters ^ 2) == 0)
                    {
                        scrambler3.Rotate();
                    }
                }
            }

            // Reset scramblers to their original positions
            scrambler1.Reset();
            scrambler2.Reset();
            scrambler3.Reset();

            return cryptedMessage;
        }
    }
}
