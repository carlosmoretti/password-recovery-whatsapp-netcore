using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandling
{
    public class GenericException : Exception
    {
        public GenericException()
        {
        }

        public GenericException(string message) : base(message)
        {
        }
    }
}
