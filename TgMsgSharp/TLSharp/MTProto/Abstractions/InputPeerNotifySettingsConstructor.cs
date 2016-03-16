using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class InputPeerNotifySettingsConstructor : InputPeerNotifySettings
    {
        public int mute_until;
        public string sound;
        public bool show_previews;
        public int events_mask;

        public InputPeerNotifySettingsConstructor()
        {

        }

        public InputPeerNotifySettingsConstructor(int mute_until, string sound, bool show_previews, int events_mask)
        {
            this.mute_until = mute_until;
            this.sound = sound;
            this.show_previews = show_previews;
            this.events_mask = events_mask;
        }


        public Constructor Constructor
        {
            get { return Constructor.inputPeerNotifySettings; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x46a2ce98);
            writer.Write(this.mute_until);
            Serializers.String.write(writer, this.sound);
            writer.Write(this.show_previews ? 0x997275b5 : 0xbc799737);
            writer.Write(this.events_mask);
        }

        public override void Read(BinaryReader reader)
        {
            this.mute_until = reader.ReadInt32();
            this.sound = Serializers.String.read(reader);
            this.show_previews = reader.ReadUInt32() == 0x997275b5;
            this.events_mask = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(inputPeerNotifySettings mute_until:{0} sound:'{1}' show_previews:{2} events_mask:{3})",
                mute_until, sound, show_previews, events_mask);
        }
    }
}