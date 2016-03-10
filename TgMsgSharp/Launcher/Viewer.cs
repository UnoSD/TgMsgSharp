using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TgMsgSharp.Connector;
using TgMsgSharp.Launcher.Properties;

namespace TgMsgSharp.Launcher
{
    public partial class Viewer : Form
    {
        const string NumberColumn = "Number";
        const string NameColumn = "Name";
        const string SurnameColumn = "Surname";

        readonly Lazy<TgConnector> _tgConnector;
        readonly Lazy<SettingsSaver> _tgSettingsSaver;

        TgConnector CreateConnector()
        {
            var tgConnector = new TgConnector(txtNumber.Text, string.Empty, int.Parse(txtAppId.Text), txtAppHash.Text);

            tgConnector.StatusChanged += (_, status) => UpdateStatus(status);

            return tgConnector;
        }

        public Viewer()
        {
            InitializeComponent();

            _tgConnector = new Lazy<TgConnector>(CreateConnector);
            _tgSettingsSaver = new Lazy<SettingsSaver>();
        }

        void PopulateSettings(ITgSettingsProvider settingsProvider)
        {
            var settings = settingsProvider.GetSettings();

            if (settings == null) return;

            txtNumber.Text = settings.Number;
            txtAppId.Text = settings.AppId.ToString();
            txtAppHash.Text = settings.AppHash;

            PopulateContacts(settings.Contacts);
        }

        void PopulateContacts(IEnumerable<TgContact> contacts)
        {
            Func<TgContact, ListViewItem> mapperSelector =
                contact => new ListViewItem(new[] { contact.FirstName, contact.LastName, contact.Number });

            var listViewItems = contacts.Select(mapperSelector).ToArray();

            lvwContacts.Items.AddRange(listViewItems);

            lvwContacts.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        async void btnConnect_Click(object sender, EventArgs e)
        {
            var connect = await _tgConnector.Value.Connect();

            if (connect == ConnectorStatus.ValidationCodeNeeded)
                MessageBox.Show("Code sent.");
        }

        async void btnAuth_Click(object sender, EventArgs e)
        {
            var result = await _tgConnector.Value.Authorize(int.Parse(txtCode.Text));

            if (result == ConnectorStatus.Connected)
                MessageBox.Show("Connected!");
        }

        async void txtDownload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRecipient.Text))
            {
                MessageBox.Show("Insert number of a contact to download messages.");
                return;
            }

            var number = txtRecipient.Text;
            var name = GetValueFromList(NameColumn);
            var surname = GetValueFromList(SurnameColumn);

            var messages = (await _tgConnector.Value.GetMessages(number, name ?? "My Test Name", surname ?? string.Empty)).ToArray();

            PopulateMessagesList(number, name, surname, messages);
        }

        void PopulateMessagesList(string number, string name, string surname, IEnumerable<TgMessage> messages)
        {
            var dataSource = messages.OrderBy(message => message.Date).ToArray();



            Text = $"{number} {name ?? string.Empty} {surname ?? string.Empty} {dataSource.Length}";

            dgvData.Enabled = true;

            dgvData.DataSource = dataSource;

            dgvData.AutoResizeColumns();
        }

        string GetValueFromList(string columnName)
        {
            var selectedItems = lvwContacts.SelectedItems.OfType<ListViewItem>().ToArray();

            if (selectedItems.Length != 1) return null;

            var listViewItem = selectedItems.Single();

            return listViewItem.SubItems[GetColumnIndex(columnName)].Text;
        }

        void Viewer_Load(object sender, EventArgs e)
        {
            var tgSettingsPath = Settings.Default.TgSettingsPath;

            txtSettingsFile.Text = tgSettingsPath;

            PopulateSettings(new TgFileSettingsProvider(new FileInfo(tgSettingsPath)));

            UpdateStatus(ConnectorStatus.NotConnected);
        }

        void UpdateStatus(ConnectorStatus status)
        {
            foreach (var control in Controls.OfType<Control>())
                control.Enabled = false;

            txtSettingsFile.Enabled = true;
            btnBrowse.Enabled = true;
            btnLoad.Enabled = true;
            btnSave.Enabled = true;

            switch (status)
            {
                case ConnectorStatus.NotRegistered:
                    break;
                case ConnectorStatus.ValidationCodeNeeded:
                    txtCode.Enabled = true;
                    btnAuth.Enabled = true;
                    break;
                case ConnectorStatus.Connected:
                    txtRecipient.Enabled = true;
                    txtRecipient.Text = string.Empty;
                    txtDownload.Enabled = true;
                    lvwContacts.Enabled = true;
                    break;
                case ConnectorStatus.ClientError:
                    break;
                case ConnectorStatus.NotConnected:
                    txtAppId.Enabled = true;
                    txtAppHash.Enabled = true;
                    txtNumber.Enabled = true;
                    btnConnect.Enabled = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, null);
            }
        }

        void lvwContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = lvwContacts.SelectedItems.OfType<ListViewItem>().SingleOrDefault();

            if (selectedItem == null) return;

            txtRecipient.Text = selectedItem.SubItems[GetColumnIndex(NumberColumn)].Text;
        }

        int GetColumnIndex(string columnName) => lvwContacts.Columns.OfType<ColumnHeader>().Single(header => header.Text == columnName).Index;

        void btnBrowse_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();

            var dialogResult = saveFileDialog.ShowDialog();

            if (dialogResult != DialogResult.OK) return;

            txtSettingsFile.Text = saveFileDialog.FileName;
        }

        void btnLoad_Click(object sender, EventArgs e)
        {
            var tgFileSettingsProvider = new TgFileSettingsProvider(new FileInfo(txtSettingsFile.Text));

            PopulateSettings(tgFileSettingsProvider);
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            Func<ListViewItem, TgContact> selector = item => new TgContact
            {
                Number = item.SubItems[GetColumnIndex(NumberColumn)].Text,
                FirstName = item.SubItems[GetColumnIndex(NameColumn)].Text,
                LastName = item.SubItems[GetColumnIndex(SurnameColumn)].Text
            };

            var contacts = lvwContacts.Items.OfType<ListViewItem>().Select(selector).ToList();

            var tgSettings = new TgSettings
            {
                AppId = int.Parse(txtAppId.Text),
                AppHash = txtAppHash.Text,
                Number = txtNumber.Text,
                Contacts = contacts
            };

            _tgSettingsSaver.Value.Save(tgSettings, new FileInfo(txtSettingsFile.Text));

            MessageBox.Show("Saved!");
        }

        private void txtSettingsFile_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.TgSettingsPath = txtSettingsFile.Text;

            Settings.Default.Save();
        }
    }
}
