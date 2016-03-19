namespace TgMsgSharp.Connector
{
    public class TgMedia
    {
        public long Id { get; set; }
        //public TgMessage Message { get; set; }
        public string Path { get; set; }

        public TgLocation Location { get; set; }
    }
}