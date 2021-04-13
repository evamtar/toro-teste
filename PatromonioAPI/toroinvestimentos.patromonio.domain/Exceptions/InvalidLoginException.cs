using System;
using System.Collections.Generic;
using System.Text;

namespace toroinvestimentos.patromonio.domain.Exceptions
{
    public class InvalidLoginException : Exception
    {
        public InvalidLoginException(string message) : base(message)
        {

        }
    }
}
