using log4net;
using System;

namespace DanielBogdan.PlainRSS.Core.Logging
{
    public class Logger
    {
        public ILog Log { get; set; }


        public Logger(string logName)
        {
            if (string.IsNullOrEmpty(logName))
                throw new ArgumentNullException(nameof(logName), @"Cannot be empty");

            Log = log4net.LogManager.GetLogger(logName);
        }
        public Logger(Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type), @"Cannot be empty");

            Log = log4net.LogManager.GetLogger(type);
        }



        public void Debug(object message)
        {
            Log.Debug(message);
        }

        public void Debug(object message, Exception exception)
        {
            Log.Debug(message, exception);
        }


        public void Info(object message)
        {
            Log.Info(message);
        }


        public void Info(object message, Exception exception)
        {
            Log.Info(message, exception);
        }


        public void Warn(object message)
        {
            Log.Warn(message);
        }

        public void Warn(object message, Exception exception)
        {
            Log.Warn(message, exception);
        }


        public void Error(object message)
        {
            Log.Error(message);
        }

        public void Error(object message, Exception exception)
        {
            Log.Error(message, exception);
        }


        public void Fatal(object message)
        {
            Log.Fatal(message);
        }

        public void Fatal(object message, Exception exception)
        {
            Log.Fatal(message, exception);
        }


    }
}
