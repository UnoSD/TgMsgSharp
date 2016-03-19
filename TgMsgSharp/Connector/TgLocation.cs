using System;

namespace TgMsgSharp.Connector
{
    public class TgLocation
    {
        public long Id { get; set; }
        public long VolumeId { get; set; }
        public int LocalId { get; set; }
        public long Secret { get; set; }
        public long AccessHash { get; set; }
        public Type InputType { get; set; }
    }
}