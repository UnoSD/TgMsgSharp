using System;
using System.IO;
using System.Linq;
using MoreLinq;
using TLSharp.Core.MTProto;

namespace TgMsgSharp.Connector
{
    public class MessageMediaPhotoHandler : IMessageMediaHandler
    {
        public Type TypeHandled => typeof(MessageMediaPhotoConstructor);

        public TgMedia Map(MessageMedia media)
        {
            var photo = (media as MessageMediaPhotoConstructor)?.photo;

            var photoConstructor = photo as PhotoConstructor;

            return photoConstructor == null ? null : MapInternal(photoConstructor);
        }

        TgMedia MapInternal(PhotoConstructor photo)
        {
            var biggestPhoto = photo.sizes?.OfType<PhotoSizeConstructor>()
                                           .MaxBy<PhotoSizeConstructor, long>(photoSize => photoSize.h * photoSize.w);

            var location = biggestPhoto?.location as FileLocationConstructor;

            if (location != null)
                return new TgMedia
                {
                    Id = photo.id,
                    Location = MapLocation(location)
                };

            return MapCachedPhoto(photo);
        }

        static TgMedia MapCachedPhoto(PhotoConstructor photo)
        {
            var cachedPhoto = photo.sizes?.OfType<PhotoCachedSizeConstructor>().FirstOrDefault();

            if (cachedPhoto?.bytes == null || !cachedPhoto.bytes.Any())
                return null;

            //var type = cachedPhoto.type;

            var path = $"{photo.id}.jpg";

            File.WriteAllBytes(path, cachedPhoto.bytes);

            return new TgMedia
            {
                Id = photo.id,
                Location = MapLocation(cachedPhoto.location as FileLocationConstructor),
                Path = path
            };
        }

        static TgLocation MapLocation(FileLocationConstructor location)
        {
            if (location == null)
                return null;

            return new TgLocation
            {
                VolumeId = location.volume_id,
                LocalId = location.local_id,
                Secret = location.secret,
                InputType = typeof(InputFileLocationConstructor)
            };
        }
    }
}