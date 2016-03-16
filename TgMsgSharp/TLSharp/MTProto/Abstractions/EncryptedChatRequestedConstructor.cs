using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class EncryptedChatRequestedConstructor : EncryptedChat
    {
        public int id;
        public long access_hash;
        public int date;
        public int admin_id;
        public int participant_id;
        public byte[] g_a;
        public byte[] nonce;

        public EncryptedChatRequestedConstructor()
        {

        }

        public EncryptedChatRequestedConstructor(int id, long access_hash, int date, int admin_id, int participant_id,
            byte[] g_a, byte[] nonce)
        {
            this.id = id;
            this.access_hash = access_hash;
            this.date = date;
            this.admin_id = admin_id;
            this.participant_id = participant_id;
            this.g_a = g_a;
            this.nonce = nonce;
        }


        public Constructor Constructor
        {
            get { return Constructor.encryptedChatRequested; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xfda9a7b7);
            writer.Write(this.id);
            writer.Write(this.access_hash);
            writer.Write(this.date);
            writer.Write(this.admin_id);
            writer.Write(this.participant_id);
            Serializers.Bytes.write(writer, this.g_a);
            Serializers.Bytes.write(writer, this.nonce);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = reader.ReadInt32();
            this.access_hash = reader.ReadInt64();
            this.date = reader.ReadInt32();
            this.admin_id = reader.ReadInt32();
            this.participant_id = reader.ReadInt32();
            this.g_a = Serializers.Bytes.read(reader);
            this.nonce = Serializers.Bytes.read(reader);
        }

        public override string ToString()
        {
            return
                String.Format(
                    "(encryptedChatRequested id:{0} access_hash:{1} date:{2} admin_id:{3} participant_id:{4} g_a:{5} nonce:{6})", id,
                    access_hash, date, admin_id, participant_id, BitConverter.ToString(g_a), BitConverter.ToString(nonce));
        }
    }
}