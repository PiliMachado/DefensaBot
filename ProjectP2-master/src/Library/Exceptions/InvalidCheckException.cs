using System;

namespace Library.Exceptions
{
    public class InvalidCheckException : Exception
    {
        public InvalidCheckException(string message): base(message)
        {
        }
    }
}