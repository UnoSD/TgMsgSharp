using System;
using System.Collections.Generic;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Photos_photosConstructor : photos_Photos
    {
        public List<Photo> photos;
        public List<User> users;

        public Photos_photosConstructor()
        {

        }

        public Photos_photosConstructor(List<Photo> photos, List<User> users)
        {
            this.photos = photos;
            this.users = users;
        }


        public Constructor Constructor
        {
            get { return Constructor.photos_photos; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x8dca6aa5);
            writer.Write(0x1cb5c415);
            writer.Write(this.photos.Count);
            foreach (Photo photos_element in this.photos)
            {
                photos_element.Write(writer);
            }
            writer.Write(0x1cb5c415);
            writer.Write(this.users.Count);
            foreach (User users_element in this.users)
            {
                users_element.Write(writer);
            }
        }

        public override void Read(BinaryReader reader)
        {
            reader.ReadInt32(); // vector code
            int photos_len = reader.ReadInt32();
            this.photos = new List<Photo>(photos_len);
            for (int photos_index = 0; photos_index < photos_len; photos_index++)
            {
                Photo photos_element;
                photos_element = Tl.Parse<Photo>(reader);
                this.photos.Add(photos_element);
            }
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
            return String.Format("(photos_photos photos:{0} users:{1})", Serializers.VectorToString(photos),
                Serializers.VectorToString(users));
        }
    }
}