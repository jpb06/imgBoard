
using System;

namespace ImgBoard.Framework.Exceptions
{
    public class BaseException : Exception
    {
        public string errorType;

        public BaseException(string errorType, string message) : base(message)
        {
            this.errorType = errorType;
        }
    }
}
