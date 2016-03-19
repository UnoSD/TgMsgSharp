using System;

namespace TgMsgSharp.Connector
{
    public class TgMessage
    {
        public bool Output { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public bool Unread { get; set; }
        public int Id { get; set; }
        public string ContentType { get; set; }
        public string Flags { get; set; }
        public TgMedia Media { get; set; }
    }
}