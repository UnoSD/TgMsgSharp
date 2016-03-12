using System.IO;

namespace TgMsgSharp.Launcher
{
    public class TgFileSettingsProvider : ITgSettingsProvider
    {
        readonly FileInfo _fileInfo;

        public TgFileSettingsProvider(FileInfo fileInfo)
        {
            _fileInfo = fileInfo;
        }

        public TgSettings GetSettings()
        {
            if (!_fileInfo.Exists) return null;

            var streamReader = _fileInfo.OpenText();

            streamReader.ReadLine();

            var data = streamReader?.ReadLine()?.Split(',');

            if (data == null) return null;

            var tgSettings = new TgSettings
            {
                AppId = int.Parse(data[0]),
                AppHash = data[1],
                Number = data[5]
            };

            if (data.Length < 12)
                return tgSettings;

            // Support any numer of contacts.

            tgSettings.Contacts.Add(new TgContact
            {
                Id = int.Parse(data[13]),
                Number = data[6],
                FirstName = data[7],
                LastName = data[8]
            });

            tgSettings.Contacts.Add(new TgContact
            {
                Id = int.Parse(data[14]),
                Number = data[10],
                FirstName = data[11],
                LastName = data[12]
            });

            tgSettings.Contacts.Add(new TgContact
            {
                Id = int.Parse(data[17]),
                Number = data[5],
                FirstName = data[15],
                LastName = data[16]
            });

            return tgSettings;
        }
    }
}