using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            var scrambler1 = new Scrambler(new int[] { 18, 6, 8, 16, 22, 20, 5, 10, 7, 21, 4, 17, 9, 1, 13, 25, 19, 23, 0, 12, 2, 11, 3, 14, 15, 24 });
            var scrambler2 = new Scrambler(new int[] { 23, 5, 11, 24, 25, 0, 1, 22, 18, 4, 16, 15, 7, 13, 9, 20, 2, 3, 6, 12, 19, 14, 10, 8, 17, 21 });
            var scrambler3 = new Scrambler(new int[] { 0, 24, 20, 7, 6, 5, 9, 10, 19, 4, 22, 18, 13, 2, 8, 11, 12, 21, 25, 3, 17, 15, 23, 16, 14, 1 });
            
            //  These are for later use when I expand the functionality to allow scramblers to be swapped out and reordered.
            var scrambler4 = new Scrambler(new int[] { 13, 11, 6, 19, 21, 4, 9, 1, 8, 0, 20, 16, 25, 7, 10, 23, 15, 24, 3, 5, 12, 14, 18, 2, 22, 17 });
            var scrambler5 = new Scrambler(new int[] { 1, 12, 17, 21, 3, 0, 6, 24, 4, 23, 13, 15, 25, 20, 2, 5, 22, 14, 18, 9, 7, 8, 10, 11, 16, 19 });
            var scrambler6 = new Scrambler(new int[] { 3, 21, 2, 12, 17, 22, 0, 14, 4, 7, 25, 19, 18, 20, 16, 5, 9, 11, 23, 10, 13, 1, 24, 15, 6, 8 });
            var scrambler7 = new Scrambler(new int[] { 9, 19, 11, 6, 14, 3, 23, 16, 15, 10, 7, 8, 18, 13, 22, 17, 24, 25, 21, 20, 12, 2, 1, 4, 5, 0 });
            var scrambler8 = new Scrambler(new int[] { 1, 19, 3, 4, 9, 23, 25, 2, 21, 10, 7, 6, 12, 20, 8, 5, 0, 18, 13, 24, 11, 17, 16, 15, 22, 14 });

            var reflector = new Reflector(new int[] { 19, 16, 18, 20, 11, 25, 17, 14, 2, 12, 7, 6, 24 }, new int[] { 23, 21, 3, 22, 9, 8, 15, 13, 4, 5, 10, 1, 0 });

            // We will put six cables in our plugboard.
            var plugboard = new Plugboard(new int[][] { new int[] { 0, 9 }, new int[] { 15, 14 }, new int[] { 21, 8 }, new int[] { 12, 25 }, new int[] { 7, 5 }, new int[] { 2, 11 } });


            var enigmaMachine = new EnigmaMachine(scrambler1, scrambler2, scrambler3, reflector, plugboard);

            Console.WriteLine("Please enter your message:");
            var message = Console.ReadLine();
            while (message != "Q" && message != "q")
            {
                var cryptedMessage = enigmaMachine.Crypt(message);
                Console.WriteLine("\r\n\r\nThe crypted message is: \r\n" + cryptedMessage);
                /*
                scrambler4.Reset();
                scrambler5.Reset();
                scrambler6.Reset();
                scrambler7.Reset();
                scrambler8.Reset();
                */

                Console.WriteLine("\r\nEnter another message, or 'Q' to quit:");
                message = Console.ReadLine();
            }
        }
    }
}
