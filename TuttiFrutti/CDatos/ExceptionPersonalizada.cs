using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDatos
{
    class ExceptionPersonalizada : System.Exception
    {
        public ExceptionPersonalizada() : base() { }
        public ExceptionPersonalizada(string message) : base(message) { }
    }
}
