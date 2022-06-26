using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_MP3_Boolean
{
    public class OperaçaoInvalidaException : ApplicationException //derivar sempre da ApplicationException
    {
        public OperaçaoInvalidaException(string msg) : base(msg)
        {

        }
    }
}

