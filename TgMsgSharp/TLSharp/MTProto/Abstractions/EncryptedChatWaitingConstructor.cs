using System;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class EncryptedChatWaitingConstructor : EncryptedChat
    {
        public int id;
        public long access_hash;
        public int date;
        public int admin_id;
        public int participant_id;

        public EncryptedChatWaitingConstructor()
        {

        }

        public EncryptedChatWaitingConstructor(int id, long access_hash, int date, int admin_id, int participant_id)
        {
            this.id = id;
            this.access_hash = access_hash;
            this.date = date;
            this.admin_id = admin_id;
            this.participant_id = participant_id;
        }


        public Constructor Constructor
        {
            get { return Constructor.encryptedChatWaiting; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x3bf703dc);
            writer.Write(this.id);
            writer.Write(this.access_hash);
            writer.Write(this.date);
            writer.Write(this.admin_id);
            writer.Write(this.participant_id);
        }

        public override void Read(BinaryReader reader)
        {
            this.id = reader.ReadInt32();
            this.access_hash = reader.ReadInt64();
            this.date = reader.ReadInt32();
            this.admin_id = reader.ReadInt32();
            this.participant_id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return String.Format("(encryptedChatWaiting id:{0} access_hash:{1} date:{2} admin_id:{3} participant_id:{4})", id,
                access_hash, date, admin_id, participant_id);
        }
    }
}