using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class EncryptedChatConstructor : EncryptedChat
    {
        public int id;
        public long access_hash;
        public int date;
        public int admin_id;
        public int participant_id;
        public byte[] g_a_or_b;
        public byte[] nonce;
        public long key_fingerprint;

        public EncryptedChatConstructor()
        {

        }

        public EncryptedChatConstructor(int id, long access_hash, int date, int admin_id, int participant_id, byte[] g_a_or_b,
            byte[] nonce, long key_fingerprint)
        {
            this.id = id;
            this.access_hash = access_hash;
            this.date = date;
            this.admin_id = admin_id;
            this.participant_id = participant_id;
            this.g_a_or_b = g_a_or_b;
            this.nonce = nonce;
            this.key_fingerprint = key_fingerprint;
        }


        public Constructor Constructor
        {
            get { return Constructor.encryptedChat; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x6601d14f);
            writer.Write(this.id);
            writer.Write(this.access_hash);
            writer.Write(this.date);
            writer.Write(this.admin_id);
            writer.Write(this.participant_id);
            Serializers.Bytes.write(writer, this.g_a_or_b);
            Serializers.Bytes.write(writer, this.nonce);
            writer.Write(this.key_fingerprint);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = reader.ReadInt32();
            this.access_hash = reader.ReadInt64();
            this.date = reader.ReadInt32();
            this.admin_id = reader.ReadInt32();
            this.participant_id = reader.ReadInt32();
            this.g_a_or_b = Serializers.Bytes.read(reader);
            this.nonce = Serializers.Bytes.read(reader);
            this.key_fingerprint = reader.ReadInt64();
        }

        public override string ToString()
        {
            return
                String.Format(
                    "(encryptedChat id:{0} access_hash:{1} date:{2} admin_id:{3} participant_id:{4} g_a_or_b:{5} nonce:{6} key_fingerprint:{7})",
                    id, access_hash, date, admin_id, participant_id, BitConverter.ToString(g_a_or_b), BitConverter.ToString(nonce),
                    key_fingerprint);
        }
    }
}