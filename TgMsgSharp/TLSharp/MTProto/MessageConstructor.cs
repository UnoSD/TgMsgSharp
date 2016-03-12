using System.Diagnostics;

namespace TLSharp.Core.MTProto
{
    [DebuggerDisplay("{" + nameof(Message) + "} - {" + nameof(Media) + "}")]
    public partial class MessageConstructor : Message
    {
        //message#567699b3 flags:int id:int from_id:int to_id:Peer date:int message:string media:MessageMedia = Message;

        [TlProperty(0)]
        public int Flags { get; set; }

        [TlProperty(1)]
        public int Id { get; set; }

        [TlProperty(2)]
        public int FromId { get; set; }

        [TlProperty(3)]
        public Peer ToId { get; set; }
        
        [TlProperty(4)]
        public int Date { get; set; }

        [TlProperty(5)]
        public string Message { get; set; }

        [TlProperty(6)]
        public MessageMedia Media { get; set; }
    }
}