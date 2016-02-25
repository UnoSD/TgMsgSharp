using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TgMsgSharp.Connector;

namespace TgMsgSharp.Launcher
{
    public partial class Viewer : Form
    {
        const string NumberColumn = "Number";
        const string NameColumn = "Name";
        const string SurnameColumn = "Surname";

        readonly Lazy<TgConnector> _tgConnector;

        TgConnector CreateConnector() => new TgConnector(txtNumber.Text, string.Empty, int.Parse(txtAppId.Text), txtAppHash.Text);

        public Viewer()
        {
            InitializeComponent();

            _tgConnector = new Lazy<TgConnector>(CreateConnector);
        }

        void PopulateSettings(ITgSettingsProvider settingsProvider)
        {
            var settings = settingsProvider.GetSettings();

            txtNumber.Text = settings.Number;
            txtAppId.Text = settings.AppId.ToString();
            txtAppHash.Text = settings.AppHash;

            PopulateContacts(settings.Contacts);
        }

        void PopulateContacts(IEnumerable<TgContact> contacts)
        {
            Func<TgContact, ListViewItem> mapperSelector =
                contact => new ListViewItem(new[] {contact.FirstName, contact.LastName, contact.Number});

            var listViewItems = contacts.Select(mapperSelector).ToArray();

            lvwContacts.Items.AddRange(listViewItems);

            lvwContacts.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        async void btnConnect_Click(object sender, EventArgs e)
        {
            var connect = await _tgConnector.Value.Connect();

            if(connect == ConnectorStatus.ValidationCodeNeeded)
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
            PopulateSettings(new TgFileSettingsProvider(new FileInfo(@"..\..\..\..\TODO\AppData.csv")));

            UpdateStatus(_tgConnector.Value.Status);

            _tgConnector.Value.StatusChanged += (_, status) => UpdateStatus(status);
        }

        void UpdateStatus(ConnectorStatus status)
        {
            foreach (var control in Controls.OfType<Control>())
                control.Enabled = false;

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
    }
}
