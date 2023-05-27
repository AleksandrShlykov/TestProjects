using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindBoxLib.Exceptions
{
    public class NotValidDataException : Exception
    {
        public NotValidDataException() : base("Argument can't be negative") { }
    }
}
