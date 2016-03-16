using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class PeerNotifySettingsEmptyConstructor : PeerNotifySettings
    {

        public PeerNotifySettingsEmptyConstructor()
        {

        }



        public Constructor Constructor
        {
            get { return Constructor.peerNotifySettingsEmpty; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x70a68512);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return String.Format("(peerNotifySettingsEmpty)");
        }
    }
}