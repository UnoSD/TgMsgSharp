using System;

namespace TLSharp.Core.MTProto
{
    [Flags]
    public enum MessageFlag
    {
        /*
            flags & 0x1 - message is unread (moved here from unread)
            flags & 0x2 - message was sent by the current user (moved here from out)
        */
        Unread = 0x1,
        SentByCurrentUser = 0x2
    }
}