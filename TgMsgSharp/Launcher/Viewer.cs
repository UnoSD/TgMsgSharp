using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Storage;
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

        IReadOnlyCollection<TgMessage> _messages;

        TgConnector CreateConnector()
        {
            var tgConnector = new TgConnector(txtNumber.Text, Convert.ToInt32(nudAppId.Value), txtAppHash.Text);

            tgConnector.StatusChanged += (_, status) => UpdateStatus(status);

            return tgConnector;
        }

        public Viewer()
        {
            InitializeComponent();

            _tgConnector = new Lazy<TgConnector>(CreateConnector);

            LogDispatcher.MessageLogged += LogDispatcherOnMessageLogged;
        }

        void LogDispatcherOnMessageLogged(object sender, LogMessageEventArgs logMessageEventArgs)
        {
            if (logMessageEventArgs.Level == "Trace" && logMessageEventArgs.Message.StartsWith("Messages loaded: #"))
            {
                this.Text = logMessageEventArgs.Message;

                return;
            }

            var date = DateTime.Now.ToString(CultureInfo.InvariantCulture);

            lvwLog.BeginInvoke((Action)(() =>
            {
                var item = lvwLog.Items.Add
                    (
                        new ListViewItem
                        (
                            new[] { date, logMessageEventArgs.Level, logMessageEventArgs.Message }
                        )
                    );

                lvwLog.EnsureVisible(item.Index);
            }));
        }

        void PopulateSettings()
        {
            txtNumber.Text = Settings.Default.PhoneNumber;
            nudAppId.Value = Settings.Default.ApiId;
            txtAppHash.Text = Settings.Default.ApiHash;
        }

        void PopulateContacts(IEnumerable<TgContact> contacts)
        {
            lvwContacts.Items.Clear();

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

            SetWorkInProgress(true);

            _messages = (await _tgConnector.Value.GetMessages(number, name ?? "My Test Name", surname ?? string.Empty)).OrderBy(message => message.Id).ToArray();

            SetWorkInProgress(false);

            PopulateMessagesList(number, name, surname, _messages);
        }

        void SetWorkInProgress(bool status)
        {
            this.UseWaitCursor = status;
        }

        void PopulateMessagesList(string number, string name, string surname, IEnumerable<TgMessage> messages)
        {
            var dataSource = new SortableBindingList<TgMessage>(messages.OrderBy(message => message.Date).ToList());

            Text = $"{number} {name ?? string.Empty} {surname ?? string.Empty} {dataSource.Count}";

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
            PopulateSettings();

            UpdateStatus(ConnectorStatus.NotConnected);
        }

        void UpdateStatus(ConnectorStatus status)
        {
            foreach (var control in Controls.OfType<Control>())
                control.Enabled = false;

            nudAppId.Enabled = true;
            btnLoad.Enabled = true;
            btnSave.Enabled = true;
            lvwLog.Enabled = true;
            btnExport.Enabled = true;
            btnDownloadImages.Enabled = true;

            switch (status)
            {
                case ConnectorStatus.NotRegistered:
                    break;
                case ConnectorStatus.ValidationCodeNeeded:
                    txtCode.Enabled = true;
                    btnAuth.Enabled = true;
                    break;
                case ConnectorStatus.Connected:
                    UpdateContactsList();
                    txtRecipient.Enabled = true;
                    txtRecipient.Text = string.Empty;
                    txtDownload.Enabled = true;
                    lvwContacts.Enabled = true;
                    break;
                case ConnectorStatus.ClientError:
                    break;
                case ConnectorStatus.NotConnected:
                    nudAppId.Enabled = true;
                    txtAppHash.Enabled = true;
                    txtNumber.Enabled = true;
                    btnConnect.Enabled = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, null);
            }
        }

        async void UpdateContactsList()
        {
            var contacts = await _tgConnector.Value.GetContacts();

            PopulateContacts(contacts);
        }

        void lvwContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = lvwContacts.SelectedItems.OfType<ListViewItem>().SingleOrDefault();

            if (selectedItem == null) return;

            txtRecipient.Text = selectedItem.SubItems[GetColumnIndex(NumberColumn)].Text;
        }

        int GetColumnIndex(string columnName) => lvwContacts.Columns.OfType<ColumnHeader>().Single(header => header.Text == columnName).Index;

        static string GetSaveFile()
        {
            var saveFileDialog = new SaveFileDialog();

            var dialogResult = saveFileDialog.ShowDialog();

            return dialogResult != DialogResult.OK ? null : saveFileDialog.FileName;
        }

        void btnLoad_Click(object sender, EventArgs e)
        {
            Settings.Default.Reload();

            PopulateSettings();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            //Func<ListViewItem, TgContact> selector = item => new TgContact
            //{
            //    Number = item.SubItems[GetColumnIndex(NumberColumn)].Text,
            //    FirstName = item.SubItems[GetColumnIndex(NameColumn)].Text,
            //    LastName = item.SubItems[GetColumnIndex(SurnameColumn)].Text
            //};

            //var contacts = lvwContacts.Items.OfType<ListViewItem>().Select(selector).ToList();

            Settings.Default.ApiId = Convert.ToInt32(nudAppId.Value);
            Settings.Default.ApiHash = txtAppHash.Text;
            Settings.Default.PhoneNumber = txtNumber.Text;

            // TODO: Save contacts: Contacts = contacts
            
            Settings.Default.Save();

            MessageBox.Show("Saved!");
        }

        void btnExport_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Download attachments?", nameof(TgMsgSharp), MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
                ExportWithImages();
            else
            {
                var exportFile = GetSaveFile();

                Export(exportFile);
            }
        }

        void Export(string exportFile)
        {
            if (exportFile == null) return;

            var tgContext = new TgContext(new FileInfo(exportFile));

            // Filter out the already written ones.
            tgContext.Messages.AddRange(_messages);

            tgContext.SaveChanges();

            MessageBox.Show("Data saved.");
        }

        void ExportWithImages()
        {
            var folderBrowserDialog = new FolderBrowserDialog();

            var dialogResult = folderBrowserDialog.ShowDialog();

            if (dialogResult != DialogResult.OK) return;

            var databaseFolderPath = Path.Combine(folderBrowserDialog.SelectedPath, GetExportFolderName());

            var filesPath = Path.Combine(databaseFolderPath, "files");

            Directory.CreateDirectory(filesPath);
            
            _tgConnector.Value.DownloadImages(_messages, filesPath);

            Export(Path.Combine(databaseFolderPath, "database.sqlite"));
        }

        static string GetExportFolderName()
        {
            var cultureInfo = new CultureInfo("it-IT");

            var folderDate = DateTime.Now.ToString("d-MMM-yyyy-HHmmss", cultureInfo);

            return $"{folderDate}.TgMsgSharp";
        }

        void btnDownloadImages_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog = new FolderBrowserDialog();

            var dialogResult = folderBrowserDialog.ShowDialog();

            if(dialogResult == DialogResult.OK)
                _tgConnector.Value.DownloadImages(_messages, folderBrowserDialog.SelectedPath);
        }

        void nudAppId_ValueChanged(object sender, EventArgs eventArgs)
        {
            if (nudAppId.Value%1 != 0)
                nudAppId.Value = Math.Truncate(nudAppId.Value);
        }
    }
}
