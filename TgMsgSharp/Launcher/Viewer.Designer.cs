﻿namespace TgMsgSharp.Launcher
{
    partial class Viewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.btnAuth = new System.Windows.Forms.Button();
            this.txtRecipient = new System.Windows.Forms.TextBox();
            this.txtDownload = new System.Windows.Forms.Button();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.txtAppHash = new System.Windows.Forms.TextBox();
            this.txtAppId = new System.Windows.Forms.TextBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.lvwContacts = new System.Windows.Forms.ListView();
            this.chrName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chrSurname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chrNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblGetMessages = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Enabled = false;
            this.btnConnect.Location = new System.Drawing.Point(12, 90);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(100, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtCode
            // 
            this.txtCode.Enabled = false;
            this.txtCode.Location = new System.Drawing.Point(12, 119);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(100, 20);
            this.txtCode.TabIndex = 1;
            this.txtCode.Text = "Code";
            // 
            // btnAuth
            // 
            this.btnAuth.Enabled = false;
            this.btnAuth.Location = new System.Drawing.Point(12, 145);
            this.btnAuth.Name = "btnAuth";
            this.btnAuth.Size = new System.Drawing.Size(100, 23);
            this.btnAuth.TabIndex = 0;
            this.btnAuth.Text = "Authorize";
            this.btnAuth.UseVisualStyleBackColor = true;
            this.btnAuth.Click += new System.EventHandler(this.btnAuth_Click);
            // 
            // txtRecipient
            // 
            this.txtRecipient.Enabled = false;
            this.txtRecipient.Location = new System.Drawing.Point(12, 200);
            this.txtRecipient.Name = "txtRecipient";
            this.txtRecipient.Size = new System.Drawing.Size(100, 20);
            this.txtRecipient.TabIndex = 2;
            this.txtRecipient.Text = "Contact number";
            // 
            // txtDownload
            // 
            this.txtDownload.Enabled = false;
            this.txtDownload.Location = new System.Drawing.Point(12, 226);
            this.txtDownload.Name = "txtDownload";
            this.txtDownload.Size = new System.Drawing.Size(100, 23);
            this.txtDownload.TabIndex = 0;
            this.txtDownload.Text = "Download";
            this.txtDownload.UseVisualStyleBackColor = true;
            this.txtDownload.Click += new System.EventHandler(this.txtDownload_Click);
            // 
            // txtNumber
            // 
            this.txtNumber.Enabled = false;
            this.txtNumber.Location = new System.Drawing.Point(12, 64);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(100, 20);
            this.txtNumber.TabIndex = 1;
            this.txtNumber.Text = "Number";
            // 
            // txtAppHash
            // 
            this.txtAppHash.Enabled = false;
            this.txtAppHash.Location = new System.Drawing.Point(12, 38);
            this.txtAppHash.Name = "txtAppHash";
            this.txtAppHash.Size = new System.Drawing.Size(100, 20);
            this.txtAppHash.TabIndex = 1;
            this.txtAppHash.Text = "AppHash";
            // 
            // txtAppId
            // 
            this.txtAppId.Enabled = false;
            this.txtAppId.Location = new System.Drawing.Point(12, 12);
            this.txtAppId.Name = "txtAppId";
            this.txtAppId.Size = new System.Drawing.Size(100, 20);
            this.txtAppId.TabIndex = 1;
            this.txtAppId.Text = "AppId";
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Enabled = false;
            this.dgvData.Location = new System.Drawing.Point(337, 11);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(830, 237);
            this.dgvData.TabIndex = 3;
            // 
            // lvwContacts
            // 
            this.lvwContacts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chrName,
            this.chrSurname,
            this.chrNumber});
            this.lvwContacts.FullRowSelect = true;
            this.lvwContacts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwContacts.HideSelection = false;
            this.lvwContacts.Location = new System.Drawing.Point(118, 12);
            this.lvwContacts.MultiSelect = false;
            this.lvwContacts.Name = "lvwContacts";
            this.lvwContacts.Size = new System.Drawing.Size(213, 237);
            this.lvwContacts.TabIndex = 4;
            this.lvwContacts.UseCompatibleStateImageBehavior = false;
            this.lvwContacts.View = System.Windows.Forms.View.Details;
            this.lvwContacts.SelectedIndexChanged += new System.EventHandler(this.lvwContacts_SelectedIndexChanged);
            // 
            // chrName
            // 
            this.chrName.Text = "Name";
            // 
            // chrSurname
            // 
            this.chrSurname.Text = "Surname";
            // 
            // chrNumber
            // 
            this.chrNumber.Text = "Number";
            // 
            // lblGetMessages
            // 
            this.lblGetMessages.AutoSize = true;
            this.lblGetMessages.Location = new System.Drawing.Point(11, 178);
            this.lblGetMessages.Name = "lblGetMessages";
            this.lblGetMessages.Size = new System.Drawing.Size(77, 13);
            this.lblGetMessages.TabIndex = 5;
            this.lblGetMessages.Text = "Get messages:";
            // 
            // Viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 260);
            this.Controls.Add(this.lblGetMessages);
            this.Controls.Add(this.lvwContacts);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.txtRecipient);
            this.Controls.Add(this.txtAppId);
            this.Controls.Add(this.txtAppHash);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.txtDownload);
            this.Controls.Add(this.btnAuth);
            this.Controls.Add(this.btnConnect);
            this.Name = "Viewer";
            this.Text = "TgMsgSharp";
            this.Load += new System.EventHandler(this.Viewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Button btnAuth;
        private System.Windows.Forms.TextBox txtRecipient;
        private System.Windows.Forms.Button txtDownload;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.TextBox txtAppHash;
        private System.Windows.Forms.TextBox txtAppId;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.ListView lvwContacts;
        private System.Windows.Forms.ColumnHeader chrName;
        private System.Windows.Forms.ColumnHeader chrSurname;
        private System.Windows.Forms.ColumnHeader chrNumber;
        private System.Windows.Forms.Label lblGetMessages;
    }
}

