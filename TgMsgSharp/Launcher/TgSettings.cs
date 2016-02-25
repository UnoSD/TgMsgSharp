using System.Collections.Generic;

namespace TgMsgSharp.Launcher
{
    class TgSettings
    {
        internal int AppId { get; set; }
        internal string AppHash { get; set; }
        internal string Number { get; set; }

        internal ICollection<TgContact> Contacts { get; set; } = new List<TgContact>();
    }
}