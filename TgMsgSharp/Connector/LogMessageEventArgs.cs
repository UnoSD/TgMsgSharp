using System;

namespace TgMsgSharp.Connector
{
    public class LogMessageEventArgs : EventArgs
    {
        public string Level { get; }
        public string Message { get; }

        public LogMessageEventArgs(string level, string message)
        {
            Level = level;
            Message = message;
        }
    }
}