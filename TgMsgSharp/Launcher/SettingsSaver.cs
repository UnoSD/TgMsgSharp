using System.IO;
using System.Linq;

namespace TgMsgSharp.Launcher
{
    internal class SettingsSaver
    {
        internal void Save(TgSettings tgSettings, FileInfo fileInfo)
        {
            if (fileInfo.Exists)
                fileInfo.Delete();

            using (var writer = fileInfo.CreateText())
            {
                writer.WriteLine();

                var contactsString = tgSettings.Contacts.Select(contact => $"{contact.Number},{contact.FirstName},{contact.LastName}").ToArray();

                var contactsSettingsLine = string.Empty;

                if (contactsString.Any())
                    contactsSettingsLine = contactsString.Aggregate((left, right) => $"{left},{right}");

                var data = string.Join(",", tgSettings.AppId, tgSettings.AppHash, "", "", "", tgSettings.Number, contactsSettingsLine);

                writer.WriteLine(data);
            }
        }
    }
}