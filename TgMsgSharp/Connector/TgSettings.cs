using System.Collections.Generic;

namespace TgMsgSharp.Launcher
{
    public class TgSettings
    {
        public int AppId { get; set; }
        public string AppHash { get; set; }
        public string Number { get; set; }

        public ICollection<TgContact> Contacts { get; set; } = new List<TgContact>();
    }
}