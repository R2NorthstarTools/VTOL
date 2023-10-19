using System;

namespace VTOL._EventArgs
{
    public class ExceptionEventArgs<T> : EventArgs where T : Exception
    {
        public T OriginalException { get; set; }
        public string Message { get; set; }

        public ExceptionEventArgs(T originalException)
        {
            OriginalException = originalException;
        }

        public ExceptionEventArgs(T originalException, string message) : this(originalException)
        {
            Message = message;
        }
    }
}
