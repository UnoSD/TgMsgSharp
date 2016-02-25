using System;

namespace TgMsgSharp.Connector
{
    public class TgMessage
    {
        public int MsgType { get; set; }
        public int SenderId { get; set; }
        public int MsgId { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public bool Unread { get; set; }
    }
}