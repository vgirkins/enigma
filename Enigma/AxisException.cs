using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    public class AxisException : Exception
    {
        public AxisException() : base() { }
        public AxisException(string message) : base($"Enigma has broken: {message}. Devote all resources to solution. -WC") { }
    }
}
