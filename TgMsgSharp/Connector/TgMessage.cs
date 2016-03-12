using System;

namespace TgMsgSharp.Connector
{
    public class TgMessage
    {
        public string Flags { get; set; }
        public int SenderId { get; set; }
        public int MsgId { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public bool Unread { get; set; }
        public int ReceiverId { get; set; }
        public string ContentType { get; set; }
    }
}