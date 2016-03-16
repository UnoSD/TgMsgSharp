using System;
using System.Collections.Generic;
using System.IO;

namespace TLSharp.Core.MTProto
{
    public class Photos_photosSliceConstructor : photos_Photos
    {
        public int count;
        public List<Photo> photos;
        public List<User> users;

        public Photos_photosSliceConstructor()
        {

        }

        public Photos_photosSliceConstructor(int count, List<Photo> photos, List<User> users)
        {
            this.count = count;
            this.photos = photos;
            this.users = users;
        }


        public Constructor Constructor
        {
            get { return Constructor.photos_photosSlice; }
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x15051f54);
            writer.Write(this.count);
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
            this.count = reader.ReadInt32();
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
            return String.Format("(photos_photosSlice count:{0} photos:{1} users:{2})", count, Serializers.VectorToString(photos),
                Serializers.VectorToString(users));
        }
    }
}