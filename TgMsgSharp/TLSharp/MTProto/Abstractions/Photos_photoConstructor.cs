using System;
using System.Collections.Generic;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Photos_photoConstructor : photos_Photo
    {
        public Photo photo;
        public List<User> users;

        public Photos_photoConstructor()
        {

        }

        public Photos_photoConstructor(Photo photo, List<User> users)
        {
            this.photo = photo;
            this.users = users;
        }


        public Constructor Constructor
        {
            get { return Constructor.photos_photo; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x20212ca8);
            this.photo.Write(writer);
            writer.Write(0x1cb5c415);
            writer.Write(this.users.Count);
            foreach (User users_element in this.users)
            {
                users_element.Write(writer);
            }
        }

        public override void Read(BinaryReader reader)
        {
            this.photo = Tl.Parse<Photo>(reader);
            reader.ReadInt32(); // vector code
            int users_len = reader.ReadInt32();
            this.users = new List<User>(users_len);
            for (int users_index = 0; users_index < users_len; users_index++)
            {
                User users_element;
                users_element = Tl.Parse<User>(reader);
                this.users.Add(users_element);
            }
        }

        public override string ToString()
        {
            return String.Format("(photos_photo photo:{0} users:{1})", photo, Serializers.VectorToString(users));
        }
    }
}