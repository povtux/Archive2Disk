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

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using XPTable.Models;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace Archive2Disk
{
    public partial class ConfigForm : Form
    {
        public ConfigForm(ThisAddIn addin)
        {
            var olApplication = addin.GetApplication();
            int lcid = olApplication.LanguageSettings.get_LanguageID(Microsoft.Office.Core.MsoAppLanguageID.msoLanguageIDUI);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lcid);
            InitializeComponent();
            UpdateLabelsWithLang(Thread.CurrentThread.CurrentUICulture);
            Outlook.Folder root = olApplication.Session.DefaultStore.GetRootFolder() as Outlook.Folder;
            EnumerateFolders(root, "└ ");
            ReloadOptions();
        }

        private void EnumerateFolders(Outlook.Folder folder, string prefix)
        {
            string diskFolder;
            Outlook.Folders childFolders = folder.Folders;
            if (childFolders.Count > 0)
            {
                foreach (Outlook.Folder childFolder in childFolders)
                {
                    if (childFolder.DefaultItemType == Outlook.OlItemType.olMailItem)
                    {
                        if (Config.GetInstance().GetFoldersBinding().ContainsKey(childFolder.EntryID))
                            diskFolder = Config.GetInstance().GetFoldersBinding()[childFolder.EntryID];
                        else
                            diskFolder = "";

                        var row = new Row();
                        row.Cells.Add(new Cell(prefix + childFolder.Name));
                        row.Cells.Add(new Cell(diskFolder));
                        row.Cells.Add(new Cell("..."));
                        row.Tag = childFolder.EntryID;
                        tableModel1.Rows.Add(row);
                        // Call EnumerateFolders using childFolder.
                        EnumerateFolders(childFolder, "    " + prefix);
                    }
                }
            }
        }

        private void ReloadOptions()
        {
            if (Config.GetInstance().GetOption("EXPLODE_ATTACHMENTS").Equals("TRUE")) cb_explode_attachments.Checked = true;
            if (Config.GetInstance().GetOption("TRUNCATE_PATH_TOO_LONG").Equals("TRUE")) cb_truncate.Checked = true;
            if (Config.GetInstance().GetOption("ASK_PATH_TOO_LONG").Equals("TRUE")) cb_ask_path_too_long.Checked = true;
            if (Config.GetInstance().GetOption("ADD_CATEGORIES_IN_FILENAME").Equals("TRUE")) cb_add_categories_in_name.Checked = true;
        }

        private void Bt_ok_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> newBinding = new Dictionary<string, string>();
            foreach (Row item in tableModel1.Rows)
            {
                if (!item.Cells[1].Text.Equals(""))
                    newBinding.Add((string)item.Tag, item.Cells[1].Text);
            }
            Config.GetInstance().UpdateFoldersBinding(newBinding);

            // traitement des options
            SaveOptions();
            this.Close();
        }

        private void Lv_folders_ItemActivate(object sender, EventArgs e)
        {
            ListViewItem item = ((ListView)sender).SelectedItems[0];
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            var result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                item.SubItems[1].Text = fbd.SelectedPath;
            }
        }

        private void UpdateLabelsWithLang(CultureInfo info)
        {
            Localisation loc = Localisation.getInstance();
            this.Text = loc.getString(info.TwoLetterISOLanguageName, this.Text);
            this.label1.Text = loc.getString(info.TwoLetterISOLanguageName, this.label1.Text);
            this.textColumn1.Text = loc.getString(info.TwoLetterISOLanguageName, this.textColumn1.Text);
            this.textColumn2.Text = loc.getString(info.TwoLetterISOLanguageName, this.textColumn2.Text);
            this.bt_ok.Text = loc.getString(info.TwoLetterISOLanguageName, this.bt_ok.Text);
            this.cb_explode_attachments.Text = loc.getString(info.TwoLetterISOLanguageName, this.cb_explode_attachments.Text);
            this.cb_truncate.Text = loc.getString(info.TwoLetterISOLanguageName, this.cb_truncate.Text);
            this.cb_ask_path_too_long.Text = loc.getString(info.TwoLetterISOLanguageName, this.cb_ask_path_too_long.Text);
            this.tabPage1.Text = loc.getString(info.TwoLetterISOLanguageName, this.tabPage1.Text);
            this.tabPage2.Text = loc.getString(info.TwoLetterISOLanguageName, this.tabPage2.Text);
            this.cb_add_categories_in_name.Text = loc.getString(info.TwoLetterISOLanguageName, this.cb_add_categories_in_name.Text);
        }

        private void SaveOptions()
        {
            if (cb_explode_attachments.Checked) Config.GetInstance().AddOrUpdateOption("EXPLODE_ATTACHMENTS", "TRUE");
            else Config.GetInstance().AddOrUpdateOption("EXPLODE_ATTACHMENTS", "FALSE");
            if (cb_truncate.Checked) Config.GetInstance().AddOrUpdateOption("TRUNCATE_PATH_TOO_LONG", "TRUE");
            else Config.GetInstance().AddOrUpdateOption("TRUNCATE_PATH_TOO_LONG", "FALSE");
            if (cb_ask_path_too_long.Checked) Config.GetInstance().AddOrUpdateOption("ASK_PATH_TOO_LONG", "TRUE");
            else Config.GetInstance().AddOrUpdateOption("ASK_PATH_TOO_LONG", "FALSE");
            if (cb_add_categories_in_name.Checked) Config.GetInstance().AddOrUpdateOption("ADD_CATEGORIES_IN_FILENAME", "TRUE");
            else Config.GetInstance().AddOrUpdateOption("ADD_CATEGORIES_IN_FILENAME", "FALSE");

            Config.GetInstance().SaveOptions();
        }

        private void table1_CellButtonClicked(object sender, XPTable.Events.CellButtonEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if(tableModel1.Rows[e.Row].Cells[1].Text.Trim().Length>0)
                fbd.SelectedPath = tableModel1.Rows[e.Row].Cells[1].Text;
            var result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                tableModel1.Rows[e.Row].Cells[1].Text = fbd.SelectedPath;
            }
        }
    }
}