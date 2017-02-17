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
            var olApplication = addin.getApplication();
            int lcid = olApplication.LanguageSettings.get_LanguageID(Microsoft.Office.Core.MsoAppLanguageID.msoLanguageIDUI);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lcid);
            InitializeComponent();
            updateLabelsWithLang(Thread.CurrentThread.CurrentUICulture);
            Outlook.Folder root = olApplication.Session.DefaultStore.GetRootFolder() as Outlook.Folder;
            EnumerateFolders(root, "└ ");
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
                        if (Config.getInstance().getFoldersBinding().ContainsKey(childFolder.EntryID))
                            diskFolder = Config.getInstance().getFoldersBinding()[childFolder.EntryID];
                        else
                            diskFolder = "";
                        var item = new ListViewItem(new string[] {
                            prefix + childFolder.Name,
                            diskFolder
                        });
                        item.Name = childFolder.EntryID;
                        lv_folders.Items.Add(item);
                        // Call EnumerateFolders using childFolder.
                        EnumerateFolders(childFolder, "    " + prefix);
                    }
                }
            }
        }

        private void bt_ok_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> newBinding = new Dictionary<string, string>();
            foreach(ListViewItem item in lv_folders.Items)
            {
                if(!item.SubItems[1].Text.Equals(""))
                    newBinding.Add(item.Name, item.SubItems[1].Text);
            }
            Config.getInstance().updateFoldersBinding(newBinding);
            this.Close();
        }

        private void lv_folders_ItemActivate(object sender, EventArgs e)
        {
            ListViewItem item = ((ListView)sender).SelectedItems[0];
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            var result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                item.SubItems[1].Text = fbd.SelectedPath;
            }
        }

        private void updateLabelsWithLang(CultureInfo info)
        {
            Localisation loc = Localisation.getInstance();
            this.Text = loc.getString(info.TwoLetterISOLanguageName, this.Text);
            this.label1.Text = loc.getString(info.TwoLetterISOLanguageName, this.label1.Text);
            this.columnHeader1.Text = loc.getString(info.TwoLetterISOLanguageName, this.columnHeader1.Text);
            this.columnHeader2.Text = loc.getString(info.TwoLetterISOLanguageName, this.columnHeader2.Text);
            this.bt_ok.Text = loc.getString(info.TwoLetterISOLanguageName, this.bt_ok.Text);
        }
    }
}
