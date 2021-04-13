using System;
using System.Collections.Generic;
using System.Text;

namespace toroinvestimentos.patromonio.domain.Exceptions
{
    public class ContaCorrenteException : Exception
    {
        public ContaCorrenteException(string message) : base(message)
        {

        }
    }
}
