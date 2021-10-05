using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business.Exceptions
{
    public class PosicaoInvalidaException : Exception
    {
        public PosicaoInvalidaException() : base()
        {

        }
        
        public PosicaoInvalidaException(string mensagem) : base(mensagem)
        {

        } 
    }
}
