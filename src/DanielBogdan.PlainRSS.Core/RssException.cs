using System;
using System.Runtime.Serialization;

namespace DanielBogdan.PlainRSS.Core
{
    public class RssException : Exception
    {
        public RssException()
        {
        }

        public RssException(string message) : base(message)
        {
        }

        public RssException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RssException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
