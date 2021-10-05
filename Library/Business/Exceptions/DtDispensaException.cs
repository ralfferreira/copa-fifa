using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business.Exceptions
{
    public class DtDispensaException : Exception
    {
        public DtDispensaException() : base()
        {
        }

        public DtDispensaException(string mensagem) : base(mensagem)
        {

        }
    }
}
