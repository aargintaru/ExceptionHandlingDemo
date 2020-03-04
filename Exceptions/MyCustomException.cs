using System;

namespace ExceptionHandlingDemo
{
    public class MyCustomException : Exception
    {
        public MyCustomException() : base() { }
        public MyCustomException(string message) : base(message) { }
        public MyCustomException(string message, Exception inner) : base(message, inner) { }
    }
}