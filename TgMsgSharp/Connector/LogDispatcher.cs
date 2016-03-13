using System;

namespace TgMsgSharp.Connector
{
    public class LogDispatcher
    {
        public static event EventHandler<LogMessageEventArgs> MessageLogged;

        public static void Dispatch(string level, string message)
        {
            MessageLogged?.Invoke(null, new LogMessageEventArgs(level, message));
        }
    }
}
