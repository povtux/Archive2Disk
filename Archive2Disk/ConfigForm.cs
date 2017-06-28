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
                    if(childFolder.DefaultItemType == Outlook.OlItemType.olMailItem)
                    {
                        if (Config.GetInstance().GetFoldersBinding().ContainsKey(childFolder.EntryID))
                            diskFolder = Config.GetInstance().GetFoldersBinding()[childFolder.EntryID];
                        else
                            diskFolder = "";
                        var item = new ListViewItem(new string[] {
                            prefix + childFolder.Name,
                            diskFolder
                        })
                        {
                            Name = childFolder.EntryID
                        };
                        lv_folders.Items.Add(item);
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
        }

        private void Bt_ok_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> newBinding = new Dictionary<string, string>();
            foreach(ListViewItem item in lv_folders.Items)
            {
                if(!item.SubItems[1].Text.Equals(""))
                    newBinding.Add(item.Name, item.SubItems[1].Text);
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
            this.columnHeader1.Text = loc.getString(info.TwoLetterISOLanguageName, this.columnHeader1.Text);
            this.columnHeader2.Text = loc.getString(info.TwoLetterISOLanguageName, this.columnHeader2.Text);
            this.bt_ok.Text = loc.getString(info.TwoLetterISOLanguageName, this.bt_ok.Text);
            this.cb_explode_attachments.Text = loc.getString(info.TwoLetterISOLanguageName, this.cb_explode_attachments.Text);
            this.cb_truncate.Text = loc.getString(info.TwoLetterISOLanguageName, this.cb_truncate.Text);
            this.cb_ask_path_too_long.Text = loc.getString(info.TwoLetterISOLanguageName, this.cb_ask_path_too_long.Text);
            this.tabPage1.Text = loc.getString(info.TwoLetterISOLanguageName, this.tabPage1.Text);
            this.tabPage2.Text = loc.getString(info.TwoLetterISOLanguageName, this.tabPage2.Text);
        }

        private void SaveOptions()
        {
            if (cb_explode_attachments.Checked) Config.GetInstance().AddOrUpdateOption("EXPLODE_ATTACHMENTS", "TRUE");
            else Config.GetInstance().AddOrUpdateOption("EXPLODE_ATTACHMENTS", "FALSE");
            if (cb_truncate.Checked) Config.GetInstance().AddOrUpdateOption("TRUNCATE_PATH_TOO_LONG", "TRUE");
            else Config.GetInstance().AddOrUpdateOption("TRUNCATE_PATH_TOO_LONG", "FALSE");
            if (cb_ask_path_too_long.Checked) Config.GetInstance().AddOrUpdateOption("ASK_PATH_TOO_LONG", "TRUE");
            else Config.GetInstance().AddOrUpdateOption("ASK_PATH_TOO_LONG", "FALSE");

            Config.GetInstance().SaveOptions();
        }
    }
}
