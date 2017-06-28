//------------------------------------------------------------------------------
// This file is part of Archive2Disk.
//
// Archive2Disk is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// Archive2Disk is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with Archive2Disk.  If not, see <http://www.gnu.org/licenses/>.
//------------------------------------------------------------------------------

namespace Archive2Disk
{
    partial class FormArchiveToDisk
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
            this.label1 = new System.Windows.Forms.Label();
            this.bt_destination = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ch_date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_subject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_etat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.bt_ok = new System.Windows.Forms.Button();
            this.bt_close = new System.Windows.Forms.Button();
            this.l_mailsInSelection = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bt_cancel = new System.Windows.Forms.Button();
            this.tb_destination = new System.Windows.Forms.ComboBox();
            this.cb_explode_attachements = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "LABEL_DESTINATION";
            // 
            // bt_destination
            // 
            this.bt_destination.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_destination.Location = new System.Drawing.Point(932, 12);
            this.bt_destination.Margin = new System.Windows.Forms.Padding(4);
            this.bt_destination.Name = "bt_destination";
            this.bt_destination.Size = new System.Drawing.Size(49, 25);
            this.bt_destination.TabIndex = 2;
            this.bt_destination.Text = "...";
            this.bt_destination.UseVisualStyleBackColor = true;
            this.bt_destination.Click += new System.EventHandler(this.Bt_destination_Click);
            // 
            // listView1
            // 
            this.listView1.AllowColumnReorder = true;
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_date,
            this.ch_subject,
            this.ch_etat});
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(21, 68);
            this.listView1.Margin = new System.Windows.Forms.Padding(4);
            this.listView1.MinimumSize = new System.Drawing.Size(959, 366);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(959, 388);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // ch_date
            // 
            this.ch_date.Text = "LIST_COLUMN_DATE";
            this.ch_date.Width = 150;
            // 
            // ch_subject
            // 
            this.ch_subject.Text = "LIST_COLUMN_SUBJECT";
            this.ch_subject.Width = 500;
            // 
            // ch_etat
            // 
            this.ch_etat.Text = "LIST_COLUMN_STATE";
            this.ch_etat.Width = 305;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "LABEL_LIST_TITLE";
            // 
            // bt_ok
            // 
            this.bt_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_ok.Enabled = false;
            this.bt_ok.Location = new System.Drawing.Point(881, 482);
            this.bt_ok.Margin = new System.Windows.Forms.Padding(4);
            this.bt_ok.Name = "bt_ok";
            this.bt_ok.Size = new System.Drawing.Size(100, 28);
            this.bt_ok.TabIndex = 5;
            this.bt_ok.Text = "BT_OK";
            this.bt_ok.UseVisualStyleBackColor = true;
            this.bt_ok.Click += new System.EventHandler(this.Bt_ok_Click);
            // 
            // bt_close
            // 
            this.bt_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_close.Location = new System.Drawing.Point(773, 482);
            this.bt_close.Margin = new System.Windows.Forms.Padding(4);
            this.bt_close.Name = "bt_close";
            this.bt_close.Size = new System.Drawing.Size(100, 28);
            this.bt_close.TabIndex = 6;
            this.bt_close.Text = "BT_CLOSE";
            this.bt_close.UseVisualStyleBackColor = true;
            this.bt_close.Click += new System.EventHandler(this.Bt_close_Click);
            // 
            // l_mailsInSelection
            // 
            this.l_mailsInSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.l_mailsInSelection.AutoSize = true;
            this.l_mailsInSelection.Location = new System.Drawing.Point(105, 488);
            this.l_mailsInSelection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.l_mailsInSelection.Name = "l_mailsInSelection";
            this.l_mailsInSelection.Size = new System.Drawing.Size(16, 17);
            this.l_mailsInSelection.TabIndex = 7;
            this.l_mailsInSelection.Text = "0";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 487);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "LABEL_NB_MAILS";
            // 
            // bt_cancel
            // 
            this.bt_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_cancel.Enabled = false;
            this.bt_cancel.Location = new System.Drawing.Point(665, 482);
            this.bt_cancel.Margin = new System.Windows.Forms.Padding(4);
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.Size = new System.Drawing.Size(100, 28);
            this.bt_cancel.TabIndex = 9;
            this.bt_cancel.Text = "BT_CANCEL";
            this.bt_cancel.UseVisualStyleBackColor = true;
            this.bt_cancel.Click += new System.EventHandler(this.Bt_cancel_Click);
            // 
            // tb_destination
            // 
            this.tb_destination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_destination.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tb_destination.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tb_destination.FormattingEnabled = true;
            this.tb_destination.Location = new System.Drawing.Point(176, 13);
            this.tb_destination.Name = "tb_destination";
            this.tb_destination.Size = new System.Drawing.Size(749, 24);
            this.tb_destination.TabIndex = 10;
            this.tb_destination.SelectedIndexChanged += new System.EventHandler(this.Tb_destination_SelectedIndexChanged);
            this.tb_destination.TextChanged += new System.EventHandler(this.Tb_destination_TextChanged);
            // 
            // cb_explode_attachements
            // 
            this.cb_explode_attachements.AutoSize = true;
            this.cb_explode_attachements.Location = new System.Drawing.Point(24, 463);
            this.cb_explode_attachements.Name = "cb_explode_attachements";
            this.cb_explode_attachements.Size = new System.Drawing.Size(232, 21);
            this.cb_explode_attachements.TabIndex = 11;
            this.cb_explode_attachements.Text = "CB_EXPLODE_ATTACHMENTS";
            this.cb_explode_attachements.UseVisualStyleBackColor = true;
            // 
            // FormArchiveToDisk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 518);
            this.Controls.Add(this.cb_explode_attachements);
            this.Controls.Add(this.tb_destination);
            this.Controls.Add(this.bt_cancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.l_mailsInSelection);
            this.Controls.Add(this.bt_close);
            this.Controls.Add(this.bt_ok);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.bt_destination);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormArchiveToDisk";
            this.Text = "FORM_ARCHIVE_TO_DISK_TITLE";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_destination;
        private volatile System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader ch_date;
        private System.Windows.Forms.ColumnHeader ch_subject;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_ok;
        private System.Windows.Forms.Button bt_close;
        private System.Windows.Forms.ColumnHeader ch_etat;
        private System.Windows.Forms.Label l_mailsInSelection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bt_cancel;
        private System.Windows.Forms.ComboBox tb_destination;
        private System.Windows.Forms.CheckBox cb_explode_attachements;
    }
}