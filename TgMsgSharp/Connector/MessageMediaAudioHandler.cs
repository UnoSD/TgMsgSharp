using System;
using TLSharp.Core.MTProto;

namespace TgMsgSharp.Connector
{
    public class MessageMediaAudioHandler : IMessageMediaHandler
    {
        public Type TypeHandled => typeof(MessageMediaAudioConstructor);

        public TgMedia Map(MessageMedia media)
        {
            var audio = (media as MessageMediaAudioConstructor)?.audio;

            var audioConstructor = audio as AudioConstructor;

            return audioConstructor == null ? null : MapInternal(audioConstructor);
        }

        static TgMedia MapInternal(AudioConstructor audio)
        {
            return new TgMedia
            {
                Id = audio.Id,
                Location = GetLocation(audio)
            };
        }

        static TgLocation GetLocation(AudioConstructor audio)
        {
            return new TgLocation
            {
                Id = audio.Id,
                AccessHash = audio.AccessHash,
                InputType = typeof(InputAudioFileLocationConstructor)
            };
        }
    }
}