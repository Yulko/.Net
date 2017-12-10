using System;

namespace ConsoleApplication1
{
    class SexException : Exception
    {
        public SexException() : base() { }
        public SexException(string mes) : base(mes) { }
    }
}