﻿namespace Archive2Disk
{
    partial class ConfigForm
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
            this.lv_folders = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.bt_ok = new System.Windows.Forms.Button();
            this.cb_explode_attachments = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lv_folders
            // 
            this.lv_folders.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.lv_folders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lv_folders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lv_folders.FullRowSelect = true;
            this.lv_folders.GridLines = true;
            this.lv_folders.Location = new System.Drawing.Point(8, 18);
            this.lv_folders.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lv_folders.MultiSelect = false;
            this.lv_folders.Name = "lv_folders";
            this.lv_folders.Size = new System.Drawing.Size(701, 313);
            this.lv_folders.TabIndex = 0;
            this.lv_folders.UseCompatibleStateImageBehavior = false;
            this.lv_folders.View = System.Windows.Forms.View.Details;
            this.lv_folders.ItemActivate += new System.EventHandler(this.lv_folders_ItemActivate);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "CONFIG_COLUMN_FOLDER_OUTLOOK";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "CONFIG_COLUMN_FOLDER_DISK";
            this.columnHeader2.Width = 600;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "LABEL_CONFIG_FOLDER_LIST";
            // 
            // bt_ok
            // 
            this.bt_ok.Location = new System.Drawing.Point(669, 379);
            this.bt_ok.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bt_ok.Name = "bt_ok";
            this.bt_ok.Size = new System.Drawing.Size(56, 19);
            this.bt_ok.TabIndex = 2;
            this.bt_ok.Text = "BT_OK";
            this.bt_ok.UseVisualStyleBackColor = true;
            this.bt_ok.Click += new System.EventHandler(this.bt_ok_Click);
            // 
            // cb_explode_attachments
            // 
            this.cb_explode_attachments.AutoSize = true;
            this.cb_explode_attachments.Location = new System.Drawing.Point(5, 5);
            this.cb_explode_attachments.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cb_explode_attachments.Name = "cb_explode_attachments";
            this.cb_explode_attachments.Size = new System.Drawing.Size(183, 17);
            this.cb_explode_attachments.TabIndex = 3;
            this.cb_explode_attachments.Text = "CB_EXPLODE_ATTACHMENTS";
            this.cb_explode_attachments.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(722, 362);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.lv_folders);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(714, 336);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "TAB_FOLDERS";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cb_explode_attachments);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(714, 336);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "TAB_PARAMS";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 407);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.bt_ok);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ConfigForm";
            this.Text = "CONFIG_FORM_TITLE";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lv_folders;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_ok;
        private System.Windows.Forms.CheckBox cb_explode_attachments;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}