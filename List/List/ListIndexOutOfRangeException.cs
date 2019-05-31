using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace List
{
    public class ListIndexOutOfRangeException : Exception
    {
        public ListIndexOutOfRangeException()
        {
        }

        public ListIndexOutOfRangeException(string message) : base(message)
        {
        }

        public ListIndexOutOfRangeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ListIndexOutOfRangeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
