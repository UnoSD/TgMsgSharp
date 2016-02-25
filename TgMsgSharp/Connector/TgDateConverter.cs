using System;

namespace TgMsgSharp.Connector
{
    class TgDateConverter
    {
        internal static DateTime GetDateTime(int ticks)
        {
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

            dateTime = dateTime.AddSeconds(double.Parse(ticks.ToString())).ToLocalTime();

            return dateTime;
        }
    }
}