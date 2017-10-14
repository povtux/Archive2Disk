namespace Archive2Disk
{
    partial class FormArchiveRename
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
            this.tb_destination = new System.Windows.Forms.ComboBox();
            this.LABEL_DESTINATION = new System.Windows.Forms.Label();
            this.bt_destination = new System.Windows.Forms.Button();
            this.bt_cancel = new System.Windows.Forms.Button();
            this.bt_ok = new System.Windows.Forms.Button();
            this.LABEL_RENAME = new System.Windows.Forms.Label();
            this.TB_RENAME = new System.Windows.Forms.TextBox();
            this.cb_explode_attachements = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tb_destination
            // 
            this.tb_destination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_destination.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tb_destination.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tb_destination.FormattingEnabled = true;
            this.tb_destination.Location = new System.Drawing.Point(171, 12);
            this.tb_destination.Name = "tb_destination";
            this.tb_destination.Size = new System.Drawing.Size(756, 24);
            this.tb_destination.TabIndex = 11;
            this.tb_destination.SelectedIndexChanged += new System.EventHandler(this.tb_destination_SelectedIndexChanged);
            // 
            // LABEL_DESTINATION
            // 
            this.LABEL_DESTINATION.AutoSize = true;
            this.LABEL_DESTINATION.Location = new System.Drawing.Point(13, 16);
            this.LABEL_DESTINATION.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LABEL_DESTINATION.Name = "LABEL_DESTINATION";
            this.LABEL_DESTINATION.Size = new System.Drawing.Size(151, 17);
            this.LABEL_DESTINATION.TabIndex = 12;
            this.LABEL_DESTINATION.Text = "LABEL_DESTINATION";
            // 
            // bt_destination
            // 
            this.bt_destination.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_destination.Location = new System.Drawing.Point(934, 11);
            this.bt_destination.Margin = new System.Windows.Forms.Padding(4);
            this.bt_destination.Name = "bt_destination";
            this.bt_destination.Size = new System.Drawing.Size(49, 25);
            this.bt_destination.TabIndex = 13;
            this.bt_destination.Text = "...";
            this.bt_destination.UseVisualStyleBackColor = true;
            this.bt_destination.Click += new System.EventHandler(this.bt_destination_Click);
            // 
            // bt_cancel
            // 
            this.bt_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_cancel.Location = new System.Drawing.Point(775, 80);
            this.bt_cancel.Margin = new System.Windows.Forms.Padding(4);
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.Size = new System.Drawing.Size(100, 28);
            this.bt_cancel.TabIndex = 14;
            this.bt_cancel.Text = "BT_CANCEL";
            this.bt_cancel.UseVisualStyleBackColor = true;
            this.bt_cancel.Click += new System.EventHandler(this.bt_cancel_Click);
            // 
            // bt_ok
            // 
            this.bt_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_ok.Enabled = false;
            this.bt_ok.Location = new System.Drawing.Point(883, 80);
            this.bt_ok.Margin = new System.Windows.Forms.Padding(4);
            this.bt_ok.Name = "bt_ok";
            this.bt_ok.Size = new System.Drawing.Size(100, 28);
            this.bt_ok.TabIndex = 15;
            this.bt_ok.Text = "BT_OK";
            this.bt_ok.UseVisualStyleBackColor = true;
            this.bt_ok.Click += new System.EventHandler(this.bt_ok_Click);
            // 
            // LABEL_RENAME
            // 
            this.LABEL_RENAME.AutoSize = true;
            this.LABEL_RENAME.Location = new System.Drawing.Point(12, 48);
            this.LABEL_RENAME.Name = "LABEL_RENAME";
            this.LABEL_RENAME.Size = new System.Drawing.Size(117, 17);
            this.LABEL_RENAME.TabIndex = 16;
            this.LABEL_RENAME.Text = "LABEL_RENAME";
            // 
            // TB_RENAME
            // 
            this.TB_RENAME.Location = new System.Drawing.Point(171, 46);
            this.TB_RENAME.Name = "TB_RENAME";
            this.TB_RENAME.Size = new System.Drawing.Size(756, 22);
            this.TB_RENAME.TabIndex = 17;
            // 
            // cb_explode_attachements
            // 
            this.cb_explode_attachements.AutoSize = true;
            this.cb_explode_attachements.Location = new System.Drawing.Point(16, 85);
            this.cb_explode_attachements.Name = "cb_explode_attachements";
            this.cb_explode_attachements.Size = new System.Drawing.Size(232, 21);
            this.cb_explode_attachements.TabIndex = 18;
            this.cb_explode_attachements.Text = "CB_EXPLODE_ATTACHMENTS";
            this.cb_explode_attachements.UseVisualStyleBackColor = true;
            // 
            // FormArchiveRename
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 121);
            this.Controls.Add(this.cb_explode_attachements);
            this.Controls.Add(this.TB_RENAME);
            this.Controls.Add(this.LABEL_RENAME);
            this.Controls.Add(this.bt_ok);
            this.Controls.Add(this.bt_cancel);
            this.Controls.Add(this.bt_destination);
            this.Controls.Add(this.LABEL_DESTINATION);
            this.Controls.Add(this.tb_destination);
            this.Name = "FormArchiveRename";
            this.Text = "FORM_ARCHIVE_RENAME_TITLE";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox tb_destination;
        private System.Windows.Forms.Label LABEL_DESTINATION;
        private System.Windows.Forms.Button bt_destination;
        private System.Windows.Forms.Button bt_cancel;
        private System.Windows.Forms.Button bt_ok;
        private System.Windows.Forms.Label LABEL_RENAME;
        private System.Windows.Forms.TextBox TB_RENAME;
        private System.Windows.Forms.CheckBox cb_explode_attachements;
    }
}