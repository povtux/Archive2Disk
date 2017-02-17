namespace Archive2Disk
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
            this.label1 = new System.Windows.Forms.Label();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bt_ok = new System.Windows.Forms.Button();
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
            this.lv_folders.Location = new System.Drawing.Point(12, 33);
            this.lv_folders.MultiSelect = false;
            this.lv_folders.Name = "lv_folders";
            this.lv_folders.Size = new System.Drawing.Size(765, 427);
            this.lv_folders.TabIndex = 0;
            this.lv_folders.UseCompatibleStateImageBehavior = false;
            this.lv_folders.View = System.Windows.Forms.View.Details;
            this.lv_folders.ItemActivate += new System.EventHandler(this.lv_folders_ItemActivate);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "LABEL_CONFIG_FOLDER_LIST";
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
            // bt_ok
            // 
            this.bt_ok.Location = new System.Drawing.Point(701, 467);
            this.bt_ok.Name = "bt_ok";
            this.bt_ok.Size = new System.Drawing.Size(75, 23);
            this.bt_ok.TabIndex = 2;
            this.bt_ok.Text = "BT_OK";
            this.bt_ok.UseVisualStyleBackColor = true;
            this.bt_ok.Click += new System.EventHandler(this.bt_ok_Click);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 513);
            this.Controls.Add(this.bt_ok);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lv_folders);
            this.Name = "ConfigForm";
            this.Text = "CONFIG_FORM_TITLE";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lv_folders;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_ok;
    }
}